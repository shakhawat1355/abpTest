using MAS.FloraFire.ClientPortal.Countries;
using MAS.FloraFire.ClientPortal.StateProvinces;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.MultiTenancy;

namespace MAS.FloraFire.ClientPortal.Data;

public class CountryStateProvinceDataSeederContributor : IDataSeedContributor, ITransientDependency
{
    #region Fields

    private readonly IRepository<Country> _countryRepository;
    private readonly IRepository<StateProvince> _stateProvinceRepository;
    private readonly ICurrentTenant _currentTenant;

    #endregion

    #region Ctor

    public CountryStateProvinceDataSeederContributor(
        IRepository<Country> countryRepository,
        IRepository<StateProvince> stateProvinceRepository,
        ICurrentTenant currentTenant)
    {
        _countryRepository = countryRepository;
        _stateProvinceRepository = stateProvinceRepository;
        _currentTenant = currentTenant;
    }

    #endregion

    #region Methods

    public async Task SeedAsync(DataSeedContext context)
    {
            if (await _countryRepository.GetCountAsync() <= 0)
            {
                var countries = ISO3166.GetCollection().Select(country => new Country
                {
                    Name = country.Name,
                    TwoLetterIsoCode = country.Alpha2,
                    ThreeLetterIsoCode = country.Alpha3,
                    NumericIsoCode = country.NumericCode,
                    DisplayOrder = country.NumericCode == 840 ? 1 : 100,
                    Published = true
                }).ToList();

                await _countryRepository.InsertManyAsync(countries, autoSave: true);

                if (await _stateProvinceRepository.GetCountAsync() <= 0)
                {
                    {
                        var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seed", "states.txt");

                        if (!File.Exists(filePath))
                        {
                            throw new FileNotFoundException($"The file '{filePath}' was not found.");
                        }

                        await using var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        using var reader = new StreamReader(stream);

                        while (!reader.EndOfStream)
                        {
                            var line = await reader.ReadLineAsync();
                            if (string.IsNullOrWhiteSpace(line))
                                continue;

                            var tmp = line.Split(',');

                            if (tmp.Length != 5)
                            {
                                throw new Exception("Wrong file format");
                            }

                            // Parse the values
                            var countryTwoLetterIsoCode = tmp[0].Trim();
                            var name = tmp[1].Trim();
                            var abbreviation = tmp[2].Trim();
                            var published = bool.Parse(tmp[3].Trim());
                            var displayOrder = int.Parse(tmp[4].Trim());

                            // Fetch the country by its ISO code
                            var country = await _countryRepository.FirstOrDefaultAsync(c => c.TwoLetterIsoCode == countryTwoLetterIsoCode);
                            if (country == null)
                            {
                                // Country cannot be loaded. Skip this entry.
                                continue;
                            }

                            // Fetch the list of states for the country
                            var states = await _stateProvinceRepository.GetListAsync(c => c.CountryId == country.Id);
                            var state = states.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));

                            if (state != null)
                            {
                                // Update existing state
                                state.Abbreviation = abbreviation;
                                state.Published = published;
                                state.DisplayOrder = displayOrder;
                                await _stateProvinceRepository.UpdateAsync(state);
                            }
                            else
                            {
                                // Insert new state
                                state = new StateProvince
                                {
                                    CountryId = country.Id,
                                    Name = name,
                                    Abbreviation = abbreviation,
                                    Published = published,
                                    DisplayOrder = displayOrder
                                };
                                await _stateProvinceRepository.InsertAsync(state);
                            }
                        }
                    }
                }
            }
    }

    #endregion
}
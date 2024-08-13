using MAS.FloraFire.ClientPortal.Countries;
using MAS.FloraFire.ClientPortal.Permissions;
using MAS.FloraFire.ClientPortal.StateProvinces;
using MAS.FloraFire.ClientPortal.Stores;
using MAS.FloraFire.ClientPortal.Values;
using MAS.FloraFire.ClientPortal.ValueTypeSettings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Settings;

namespace MAS.FloraFire.ClientPortal.Customers
{
    public class CustomerAppService
        : CrudAppService<
            Customer,
            CustomerDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateCustomerDto
        >,
            ICustomerAppService
    {
        #region Fields

        private readonly IRepository<Value> _valueRepository;
        private readonly IRepository<Store> _storeRepository;
        private readonly ICountryAppService _countryAppService;
        private readonly IStateProvinceAppService _stateProvinceAppService;
        private readonly ISettingProvider _settingProvider;
        private readonly IValueTypeSettingAppService _valueTypeSettingAppService;
        private readonly IValueAppService _valueAppService;

        #endregion

        #region Ctor

        public CustomerAppService(
            IRepository<Customer, Guid> repository,
            ISettingProvider settingProvider,
            IRepository<Value> valueRepository,
            IValueTypeSettingAppService valueTypeSettingAppService,
            IValueAppService valueAppService,
            IRepository<Store> storeRepository,
            ICountryAppService countryAppService,
            IStateProvinceAppService stateProvinceAppService)
            : base(repository)
        {
            GetPolicyName = ClientPortalPermissions.Customers.Default;
            GetListPolicyName = ClientPortalPermissions.Customers.Default;
            CreatePolicyName = ClientPortalPermissions.Customers.Create;
            UpdatePolicyName = ClientPortalPermissions.Customers.Edit;
            DeletePolicyName = ClientPortalPermissions.Customers.Delete;
            _settingProvider = settingProvider;
            _valueRepository = valueRepository;
            _valueTypeSettingAppService = valueTypeSettingAppService;
            _valueAppService = valueAppService;
            _storeRepository = storeRepository;
            _countryAppService = countryAppService;
            _stateProvinceAppService = stateProvinceAppService;
        }

        #endregion

        #region Utilities

        private Guid? GetPreselectedValueId(IEnumerable<ValueDto> items)
        {
            return items.Where(v => v.IsPreSelect).FirstOrDefault()?.Id ?? null;
        }

        #endregion

        #region Methods

        public override async Task<CustomerDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var query = await Repository.GetQueryableAsync();
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query.Where(x => x.Id == id));
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Customer), id);
            }

            var customerDto = ObjectMapper.Map<Customer, CustomerDto>(queryResult);

            return customerDto;
        }

        public override async Task<PagedResultDto<CustomerDto>> GetListAsync(
            PagedAndSortedResultRequestDto input
        )
        {
            await CheckGetListPolicyAsync();

            var query = await Repository.GetQueryableAsync();
            query = query.Skip(input.SkipCount)
                         .Take(input.MaxResultCount)
                         .OrderByDescending(x => x.CreationTime);

            var queryResult = await AsyncExecuter.ToListAsync(query);

            var values = await _valueAppService.GetAllValuesAsync();
            var countries = await _countryAppService.GetByIdsAsync(queryResult.Select(x => x.CountryId).Distinct().ToArray());
            var stateProvinces = await _stateProvinceAppService.GetByIdsAsync(queryResult.Select(x => x.StateProvinceId).Distinct().ToArray());
            var stores = await (await _storeRepository.GetQueryableAsync()).ToListAsync();

            var customerDtos = queryResult
                .Select(x =>
                {
                    var customerDto = ObjectMapper.Map<Customer, CustomerDto>(x);

                    if (customerDto != null)
                    {
                        customerDto.Country = countries.FirstOrDefault(x => x.Id == customerDto.CountryId)?.Name ?? string.Empty;
                        customerDto.StateProvince = stateProvinces.FirstOrDefault(x => x.Id == customerDto.StateProvinceId)?.Name ?? string.Empty;
                        customerDto.Store = stores.FirstOrDefault(s => s.Id == customerDto.StoreId)?.StoreName ?? string.Empty;

                        if (values != null)
                        {
                            if (customerDto.TypeId.HasValue)
                                customerDto.Type = values.FirstOrDefault(v => v.Id == customerDto.TypeId)?.Name ?? string.Empty;

                            if (customerDto.StatusValueId.HasValue)
                                customerDto.StatusValue = values.FirstOrDefault(v => v.Id == customerDto.StatusValueId)?.Name ?? string.Empty;

                            if (customerDto.AcctClassValueId.HasValue)
                                customerDto.AcctClassValue = values.FirstOrDefault(v => v.Id == customerDto.AcctClassValueId)?.Name ?? string.Empty;

                            if (customerDto.AcctManagerValueId.HasValue)
                                customerDto.AcctManagerValue = values.FirstOrDefault(v => v.Id == customerDto.AcctManagerValueId)?.Name ?? string.Empty;

                            if (customerDto.InvoicePaymentSchedulerValueId.HasValue)
                                customerDto.InvoicePaymentSchedulerValue = values.FirstOrDefault(v => v.Id == customerDto.InvoicePaymentSchedulerValueId)?.Name ?? string.Empty;

                            if (customerDto.ARStatementInvoiceTypeValueId.HasValue)
                                customerDto.ARStatementInvoiceTypeValue = values.FirstOrDefault(v => v.Id == customerDto.ARStatementInvoiceTypeValueId)?.Name ?? string.Empty;

                            if (customerDto.ReferredByValueId.HasValue)
                                customerDto.ReferredByValue = values.FirstOrDefault(v => v.Id == customerDto.ReferredByValueId)?.Name ?? string.Empty;

                            if (customerDto.TermValueId.HasValue)
                                customerDto.TermValue = values.FirstOrDefault(v => v.Id == customerDto.TermValueId)?.Name ?? string.Empty;

                            if (customerDto.PriceSheetCodeValueId.HasValue)
                                customerDto.PriceSheetCodeValue = values.FirstOrDefault(v => v.Id == customerDto.PriceSheetCodeValueId)?.Name ?? string.Empty;
                        }
                    }

                    return customerDto;
                })
                .ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<CustomerDto>(totalCount, customerDtos);
        }

        public async Task<CustomerDto> GetCustomerDtoValuesAsync()
        {
            CustomerDto customerDto = new CustomerDto();

            var customerValueTypeSettings =
                await _valueTypeSettingAppService.GetCustomerValueTypeSettingAsync();
            if (customerValueTypeSettings != null)
            {
                customerDto.AvailableStatuses = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.Status);
                customerDto.AvailableTypes = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.Type);
                customerDto.AvailableAcctClasses = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.AcctClass);
                customerDto.AvailableAcctManagers = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.AcctManager);
                customerDto.AvailableInvoicePaymentSchedule = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.InvoicePaymentSchedule);
                customerDto.AvailableTerms = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.Term);
                customerDto.AvailableARStatementInvoiceTypes = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.ARStatementInvoiceType);
                customerDto.AvailablePriceSheetCodes = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.PriceSheetCode);
                customerDto.AvailableReferredBy = await _valueAppService.GetValuesByValueTypeIdAsync(customerValueTypeSettings.ReferredBy);

                // setting default value
                customerDto.StatusValueId = GetPreselectedValueId(customerDto.AvailableStatuses);
                customerDto.TypeId = GetPreselectedValueId(customerDto.AvailableTypes);
                customerDto.AcctClassValueId = GetPreselectedValueId(customerDto.AvailableAcctClasses);
                customerDto.AcctManagerValueId = GetPreselectedValueId(customerDto.AvailableAcctManagers);
                customerDto.InvoicePaymentSchedulerValueId = GetPreselectedValueId(customerDto.AvailableInvoicePaymentSchedule);
                customerDto.TermValueId = GetPreselectedValueId(customerDto.AvailableTerms);
                customerDto.ARStatementInvoiceTypeValueId = GetPreselectedValueId(customerDto.AvailableARStatementInvoiceTypes);
                customerDto.PriceSheetCodeValueId = GetPreselectedValueId(customerDto.AvailablePriceSheetCodes);
                customerDto.ReferredByValueId = GetPreselectedValueId(customerDto.AvailableReferredBy);
            }

            var stores = await (await _storeRepository.GetQueryableAsync()).ToListAsync();
            customerDto.AvailableStores = stores
                .Select(x => ObjectMapper.Map<Store, StoreLookupDto>(x))
                .ToList();

            return customerDto;
        }

        public async Task<string> BatchCustomerImportAsync(ImportCustomerDto[] customerDtoArray)
        {

            return "Processing Done";
        }

        #endregion
    }
}
using MAS.FloraFire.ClientPortal.Permissions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Security.Encryption;

namespace MAS.FloraFire.ClientPortal.PhoneDirectories
{
    public class PhoneDirectoryAppService : CrudAppService<PhoneDirectory, PhoneDirectoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdatePhoneDirectoryDto>, IPhoneDirectoryAppService
    {
        #region Fields

        IStringEncryptionService EncryptionService { get; set; }

        #endregion

        #region Ctor

        public PhoneDirectoryAppService(IRepository<PhoneDirectory, Guid> repository) : base(repository)
        {
            GetPolicyName = ClientPortalPermissions.PhoneDirectory.Default;
            GetListPolicyName = ClientPortalPermissions.PhoneDirectory.Default;
            CreatePolicyName = ClientPortalPermissions.PhoneDirectory.Create;
            UpdatePolicyName = ClientPortalPermissions.PhoneDirectory.Edit;
            DeletePolicyName = ClientPortalPermissions.PhoneDirectory.Delete;
        }

        #endregion

        #region Methods

        public async Task<PagedResultDto<PhoneDirectoryDto>> GetFilteredListAsync(GetPhoneListDto input)
        {
            var query = await Repository.GetQueryableAsync();

            if (input.EntityId.HasValue)
                query = query.Where(c => c.EntityId == input.EntityId);

            if (!string.IsNullOrEmpty(input.EntityName))
                query = query.Where(c => c.EntityName == input.EntityName);

            query = query.OrderByDescending(x => x.CreationTime).PageBy(input.SkipCount, input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(query);

            var totalCount = await query.CountAsync();

            var phoneDirectoryDtos = queryResult.Select(x =>
            {
                var shopDto = ObjectMapper.Map<PhoneDirectory, PhoneDirectoryDto>(x);
                return shopDto;
            }).ToList();

            return new PagedResultDto<PhoneDirectoryDto>(
                totalCount,
                phoneDirectoryDtos
            );
        }

        public override async Task<PhoneDirectoryDto> CreateAsync(CreateUpdatePhoneDirectoryDto input)
        {
            if (!string.IsNullOrEmpty(input.EntityName) && input.EntityId.HasValue)
            {
                bool phoneExists = await Repository.AnyAsync(x =>
                    x.EntityName == input.EntityName
                    && x.EntityId == input.EntityId
                    && x.PhoneNumber == input.PhoneNumber
                );

                if (phoneExists)
                    throw new UserFriendlyException("Phone number already exists.");

                var phoneDirectoryDto = await base.CreateAsync(input);

                // If the new entry is marked as primary, set other entries to not primary
                if (phoneDirectoryDto.IsPrimary)
                {
                    var existingPrimaryEmails = await Repository.GetListAsync(x =>
                        x.EntityName == input.EntityName
                        && x.EntityId == input.EntityId
                        && x.Id != phoneDirectoryDto.Id
                        && x.IsPrimary
                    );

                    foreach (var existingEmail in existingPrimaryEmails)
                    {
                        existingEmail.IsPrimary = false;
                        await Repository.UpdateAsync(existingEmail);
                    }
                }

                return phoneDirectoryDto;
            }

            // If EntityName is null or EntityId is not provided, call the base implementation
            return await base.CreateAsync(input);
        }

        public override async Task<PhoneDirectoryDto> UpdateAsync(Guid id, CreateUpdatePhoneDirectoryDto input)
        {
            if (!string.IsNullOrEmpty(input.EntityName) && input.EntityId.HasValue)
            {
                bool phoneExists = await Repository.AnyAsync(x =>
                    x.EntityName == input.EntityName
                    && x.EntityId == input.EntityId
                    && x.PhoneNumber == input.PhoneNumber
                    && x.Id != id
                );

                if (phoneExists)
                    throw new UserFriendlyException("Phone number already exists.");

                // Update the entry in the repository
                var updatedPhoneDirectoryDto = await base.UpdateAsync(id, input);

                // If the updated entry is marked as primary, set other entries to not primary
                if (updatedPhoneDirectoryDto.IsPrimary)
                {
                    var existingPrimaryEmails = await Repository.GetListAsync(x =>
                        x.EntityName == input.EntityName
                        && x.EntityId == input.EntityId
                        && x.Id != updatedPhoneDirectoryDto.Id
                        && x.IsPrimary
                    );

                    foreach (var existingEmail in existingPrimaryEmails)
                    {
                        existingEmail.IsPrimary = false;
                        await Repository.UpdateAsync(existingEmail);
                    }
                }

                return updatedPhoneDirectoryDto;
            }
            else
                return await base.UpdateAsync(id, input);
        }

        #endregion
    }
}
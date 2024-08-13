using System;
using System.Linq;
using System.Threading.Tasks;
using MAS.FloraFire.ClientPortal.Permissions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace MAS.FloraFire.ClientPortal.EmailDirectories
{
    public class EmailDirectoryAppService : CrudAppService<EmailDirectory, EmailDirectoryDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateEmailDirectoryDto>, IEmailDirectoryAppService
    {
        #region Ctor

        public EmailDirectoryAppService(IRepository<EmailDirectory, Guid> repository) : base(repository)
        {
            GetPolicyName = ClientPortalPermissions.EmailDirectory.Default;
            GetListPolicyName = ClientPortalPermissions.EmailDirectory.Default;
            CreatePolicyName = ClientPortalPermissions.EmailDirectory.Create;
            UpdatePolicyName = ClientPortalPermissions.EmailDirectory.Edit;
            DeletePolicyName = ClientPortalPermissions.EmailDirectory.Delete;
        }

        #endregion

        #region Methods

        public async Task<PagedResultDto<EmailDirectoryDto>> GetFilteredListAsync(GetEmailListDto input)
        {
            var query = await Repository.GetQueryableAsync();

            if (input.EntityId.HasValue)
                query = query.Where(c => c.EntityId == input.EntityId);

            if (!string.IsNullOrEmpty(input.EntityName))
                query = query.Where(c => c.EntityName == input.EntityName);

            query = query
                .OrderByDescending(x => x.CreationTime)
                .PageBy(input.SkipCount, input.MaxResultCount);
            var queryResult = await AsyncExecuter.ToListAsync(query);

            var totalCount = await query.CountAsync();

            var emailDirectoryDtos = queryResult
                .Select(x =>
                {
                    var shopDto = ObjectMapper.Map<EmailDirectory, EmailDirectoryDto>(x);
                    return shopDto;
                })
                .ToList();

            return new PagedResultDto<EmailDirectoryDto>(totalCount, emailDirectoryDtos);
        }

        public override async Task<EmailDirectoryDto> CreateAsync(CreateUpdateEmailDirectoryDto input)
        {
            if (!string.IsNullOrEmpty(input.EntityName) && input.EntityId.HasValue)
            {
                bool emailExists = await Repository.AnyAsync(x =>
                    x.EntityName == input.EntityName
                    && x.EntityId == input.EntityId
                    && x.Email.ToLower() == input.Email.ToLower()
                );

                if (emailExists)
                    throw new UserFriendlyException($"email {input.Email} already exists");

                var emailDirectoryDto = await base.CreateAsync(input);

                // If the new entry is marked as primary, set other entries to not primary
                if (emailDirectoryDto.IsPrimary)
                {
                    var existingPrimaryEmails = await Repository.GetListAsync(x =>
                        x.EntityName == input.EntityName
                        && x.EntityId == input.EntityId
                        && x.Id != emailDirectoryDto.Id
                        && x.IsPrimary
                    );

                    foreach (var existingEmail in existingPrimaryEmails)
                    {
                        existingEmail.IsPrimary = false;
                        await Repository.UpdateAsync(existingEmail);
                    }
                }

                return emailDirectoryDto;
            }

            // If EntityName is null or EntityId is not provided, call the base implementation
            return await base.CreateAsync(input);
        }

        public override async Task<EmailDirectoryDto> UpdateAsync(Guid id, CreateUpdateEmailDirectoryDto input)
        {
            if (!string.IsNullOrEmpty(input.EntityName) && input.EntityId.HasValue)
            {
                bool emailExists = await Repository.AnyAsync(x =>
                    x.EntityName == input.EntityName
                    && x.EntityId == input.EntityId
                    && x.Email.ToLower() == input.Email.ToLower()
                    && x.Id != id
                );

                if (emailExists)
                    throw new UserFriendlyException($"email {input.Email} already exists");

                // Update the entry in the repository
                var updatedEmailDirectoryDto = await base.UpdateAsync(id, input);

                // If the updated entry is marked as primary, set other entries to not primary
                if (updatedEmailDirectoryDto.IsPrimary)
                {
                    var existingPrimaryEmails = await Repository.GetListAsync(x =>
                        x.EntityName == input.EntityName
                        && x.EntityId == input.EntityId
                        && x.Id != updatedEmailDirectoryDto.Id
                        && x.IsPrimary
                    );

                    foreach (var existingEmail in existingPrimaryEmails)
                    {
                        existingEmail.IsPrimary = false;
                        await Repository.UpdateAsync(existingEmail);
                    }
                }

                return updatedEmailDirectoryDto;
            }
            else
                return await base.UpdateAsync(id, input);
        }

        #endregion
    }
}
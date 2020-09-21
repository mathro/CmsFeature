using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using CmsFeature.Authorization;
using CmsFeature.CmsNamespace;
using CmsFeature.CmsNamespace.Dto;
using CmsFeature.MultiTenancy;
using CmsFeature.MultiTenancy.Dto;
using EventCloud.Events;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CmsFeature.CmsPages
{
    [AbpAuthorize(PermissionNames.Pages_Cms)]
    public class CmsAppService : CmsFeatureAppServiceBase, ICmsAppService
    {
        private readonly ICmsManager _cmsManager;
        private readonly IRepository<Cms> _cmsRepository;

        public CmsAppService(IRepository<Cms> cmsRepository, ICmsManager cmsManager)
        {
            _cmsManager = cmsManager;
            _cmsRepository = cmsRepository;
        }

        public async Task InsertOrUpdateCMSContentAsync(InsertOrUpdateCMSContentDto input)
        {
            var cms = Cms.InsertOrUpdateCMSContent(AbpSession.TenantId == null && AbpSession.UserId != null ? 1 : AbpSession.GetTenantId(), input.Id, input.PageName, input.PageContent);
            await _cmsManager.InsertOrUpdateAsync(cms);
        }

        public async Task<CmsDto> GetCMSContent(int pageId)
        {
            var cms = await _cmsRepository
                .FirstOrDefaultAsync(x => x.Id == pageId);

            if (cms == null)
            {
                throw new UserFriendlyException("Could not found the cms page, maybe it's deleted.");
            }

            return cms.MapTo<CmsDto>();
        }

        public async Task<ListResultDto<CmsDto>> GetAll(PagedCmsResultRequestDto input)
        {
            var cms = await _cmsRepository
               .GetAll()
               .ToListAsync();

            return new ListResultDto<CmsDto>(cms.MapTo<List<CmsDto>>());
        }
    }
}
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CmsFeature.CmsNamespace.Dto;
using CmsFeature.MultiTenancy.Dto;
using System.Threading.Tasks;

namespace CmsFeature.MultiTenancy
{
    public interface ICmsAppService : IApplicationService
    {
        Task<CmsDto> GetCMSContent(int pageId);
        Task<ListResultDto<CmsDto>> GetAll(PagedCmsResultRequestDto input);
        Task InsertOrUpdateCMSContentAsync(InsertOrUpdateCMSContentDto input);
    }
}


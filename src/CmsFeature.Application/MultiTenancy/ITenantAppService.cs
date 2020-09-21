using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CmsFeature.MultiTenancy.Dto;

namespace CmsFeature.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


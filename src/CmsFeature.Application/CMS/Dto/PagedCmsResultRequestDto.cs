using Abp.Application.Services.Dto;

namespace CmsFeature.MultiTenancy.Dto
{
    public class PagedCmsResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }
    }
}


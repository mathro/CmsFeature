using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace CmsFeature.CmsNamespace.Dto
{
    [AutoMapFrom(typeof(Cms))]
    public class CmsDto : EntityDto
    {
        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string PageName { get; set; }

        public string PageContent { get; set; }
    }
}

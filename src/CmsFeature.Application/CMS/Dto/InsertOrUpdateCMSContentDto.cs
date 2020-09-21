using Abp.AutoMapper;
using Abp.MultiTenancy;
using System.ComponentModel.DataAnnotations;

namespace CmsFeature.CmsNamespace.Dto
{
    [AutoMapTo(typeof(Cms))]
    public class InsertOrUpdateCMSContentDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(AbpTenantBase.MaxNameLength)]
        public string PageName { get; set; }

        public string PageContent { get; set; }
    }
}

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.UI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CmsFeature.CmsNamespace
{
    [Table("AppCms")]
    public class Cms : FullAuditedEntity<int>, IMustHaveTenant
    {
        public virtual int TenantId { get; set; }
        public const int MinPageNameLength = 1;
        public const int MaxPageNameLength = 64;
        public const int MinContentLength = 1;
        public const int MaxContentLength = 5000;

        public Cms()
        {
        }

        public Cms(int id, string pageName, string pageContent)
        {
        }

        [Required]
        [StringLength(MaxPageNameLength)]
        public virtual string PageName { get; protected set; }

        [Required]
        [StringLength(MaxContentLength)]
        public virtual string PageContent { get; protected set; }

        public static Cms InsertOrUpdateCMSContent(int tenantId, int id, string pageName, string pageContent)
        {
            var cms = new Cms
            {
                TenantId = tenantId,
                Id = id,
                PageName = pageName,
                PageContent = pageContent
            };

            cms.ValidateId(cms.Id);
            cms.ValidatePageNameLength(cms.PageName);
            cms.ValidatePageContentLength(cms.PageContent);

            return cms;
        }

        private void ValidateId(int id)
        {
            if (id < 0)
            {
                throw new UserFriendlyException($"The page id {id} is invalid!");
            }
        }

        private void ValidatePageNameLength(string pageName)
        {
            if (pageName.Length <= MinPageNameLength)
            {
                throw new UserFriendlyException($"The page name length must be greater than {MinPageNameLength}!");
            }

            if (MaxPageNameLength < pageName.Length)
            {
                throw new UserFriendlyException($"The page name length must be equal or smaller than {MaxPageNameLength}!");
            }
        }

        private void ValidatePageContentLength(string pageContent)
        {
            if (pageContent.Length <= MinContentLength)
            {
                throw new UserFriendlyException($"The page content length must be greater than {MinContentLength}!");
            }

            if (MaxContentLength < pageContent.Length)
            {
                throw new UserFriendlyException($"The page content length must be equal or smaller than {MaxContentLength}!");
            }
        }
    }
}

using CmsFeature.CmsNamespace;
using CmsFeature.EntityFrameworkCore;
using CmsFeature.MultiTenancy;
using System.Linq;

namespace CmsFeature.Tests.Data
{
    public class TestDataBuilder
    {
        public const int CmsPageId = 0;
        public const string CmsPageName = "First Page";
        public const string CmsPageContent = "The page content";

        private readonly CmsFeatureDbContext _context;

        public TestDataBuilder(CmsFeatureDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            CreateTestCms();
        }

        private void CreateTestCms()
        {
            var defaultTenant = _context.Tenants.Single(t => t.TenancyName == Tenant.DefaultTenantName);
            _context.Cmss.Add(Cms.InsertOrUpdateCMSContent(defaultTenant.Id, CmsPageId, CmsPageName, CmsPageContent));
            _context.SaveChanges();
        }
    }
}

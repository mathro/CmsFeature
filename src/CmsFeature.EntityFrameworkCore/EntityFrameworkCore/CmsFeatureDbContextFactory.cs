using CmsFeature.Configuration;
using CmsFeature.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CmsFeature.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CmsFeatureDbContextFactory : IDesignTimeDbContextFactory<CmsFeatureDbContext>
    {
        public CmsFeatureDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CmsFeatureDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CmsFeatureDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CmsFeatureConsts.ConnectionStringName));

            return new CmsFeatureDbContext(builder.Options);
        }
    }
}

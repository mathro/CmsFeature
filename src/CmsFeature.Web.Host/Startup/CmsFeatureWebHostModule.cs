using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CmsFeature.Configuration;

namespace CmsFeature.Web.Host.Startup
{
    [DependsOn(
       typeof(CmsFeatureWebCoreModule))]
    public class CmsFeatureWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CmsFeatureWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CmsFeatureWebHostModule).GetAssembly());
        }
    }
}

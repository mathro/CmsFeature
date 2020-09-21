using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CmsFeature.Authorization;

namespace CmsFeature
{
    [DependsOn(
        typeof(CmsFeatureCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CmsFeatureApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CmsFeatureAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CmsFeatureApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

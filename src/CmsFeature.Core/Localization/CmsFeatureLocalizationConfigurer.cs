using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace CmsFeature.Localization
{
    public static class CmsFeatureLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(CmsFeatureConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CmsFeatureLocalizationConfigurer).GetAssembly(),
                        "CmsFeature.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

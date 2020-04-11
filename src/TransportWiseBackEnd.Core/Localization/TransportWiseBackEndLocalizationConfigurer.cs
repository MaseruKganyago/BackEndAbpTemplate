using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace TransportWiseBackEnd.Localization
{
    public static class TransportWiseBackEndLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(TransportWiseBackEndConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(TransportWiseBackEndLocalizationConfigurer).GetAssembly(),
                        "TransportWiseBackEnd.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}

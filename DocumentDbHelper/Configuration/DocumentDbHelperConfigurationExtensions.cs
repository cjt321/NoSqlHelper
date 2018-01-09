using Abp.Configuration.Startup;
using DocumentDbHelper.Configuration.Config;


namespace DocumentDbHelper.Configuration
{
    public static class DocumentDbHelperConfigurationExtensions
    {

        public static IDocumentDbHelperModuleConfiguration AbpMongoDb(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IDocumentDbHelperModuleConfiguration>();
        }

    }
}

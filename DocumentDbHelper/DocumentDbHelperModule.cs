using System;
using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Runtime.Caching.Redis;
using Abp.Zero;
using Abp.Zero.Configuration;

namespace DocumentDbHelper
{
    [DependsOn(typeof(AbpRedisCacheModule), typeof(AbpZeroCoreModule))]
    public class DocumentDbHelperModule : AbpModule
    {
        public override void PreInitialize()
        {
            //            Configuration.Auditing.IsEnabledForAnonymousUsers = true;
            //
            //            //Declare entity types
            //            Configuration.Modules.Zero().EntityTypes.Tenant = typeof(Tenant);
            //            Configuration.Modules.Zero().EntityTypes.Role = typeof(Role);
            //            Configuration.Modules.Zero().EntityTypes.User = typeof(User);
            //
            //            //Remove the following line to disable multi-tenancy.
            //            Configuration.MultiTenancy.IsEnabled = MoinShopConsts.MultiTenancyEnabled;
            //
            //            //Add/remove localization sources here
            //            Configuration.Localization.Sources.Add(
            //                new DictionaryBasedLocalizationSource(
            //                    MoinShopConsts.LocalizationSourceName,
            //                    new XmlEmbeddedFileLocalizationDictionaryProvider(
            //                        Assembly.GetExecutingAssembly(),
            //                        "MoinShop.Localization.Source"
            //                        )
            //                    )
            //                );
            //
            //            AppRoleConfig.Configure(Configuration.Modules.Zero().RoleManagement);
            //
            //            Configuration.Authorization.Providers.Add<MoinShopAuthorizationProvider>();
            //
            //            Configuration.Caching.UseRedis();

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

    }
}

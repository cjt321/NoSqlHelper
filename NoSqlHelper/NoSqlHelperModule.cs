using System;
using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Runtime.Caching.Redis;
using Abp.Zero;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using NoSqlHelper.BaseNoSqlHelper;
using NoSqlHelper.RepositoryManager;

namespace NoSqlHelper
{
    [DependsOn(typeof(AbpRedisCacheModule), typeof(AbpZeroCoreModule))]
    public class NoSqlHelperModule : AbpModule
    {
        public override void PreInitialize()
        {

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Register(
                Component.For(typeof(INoSqlRepository<,>))
                    .ImplementedBy(typeof(NoSqlRepository<,>))
                    .LifestyleTransient()
                );

        }

    }
}

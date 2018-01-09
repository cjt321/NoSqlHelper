using System;
using System.Reflection;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Modules;
using Abp.Runtime.Caching.Redis;
using Abp.Zero;
using Abp.Zero.Configuration;
using Castle.MicroKernel.Registration;
using MongoDbHelper.Configuration;
using MongoDbHelper.Configuration.Config;
using MongoDbHelper.Provider;
using MongoDB.Driver;
using NoSqlHelper;
using NoSqlHelper.BaseNoSqlHelper;
using NoSqlHelper.Provider;
using MongoDbHelper.MongoDb;
using MongoDB.Bson.Serialization;
using NoSqlHelper.BaseEntity;

namespace MongoDbHelper
{
    [DependsOn(
        typeof(AbpRedisCacheModule), 
        typeof(AbpZeroCoreModule),
        typeof(NoSqlHelperModule)
        )]
    public class MongoDbHelperModule : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<IMongoDbHelperModuleConfiguration, MongoDbHelperModuleConfiguration>();
            IocManager.Register<INoSqlProvider<IMongoDatabase>, MongoDbProvider>();

            /*Configuration.UseMongoDb(new MongoDbHelperModuleConfiguration()
            {
                ConnectionString = "mongodb://192.168.1.124:27017/?connectTimeoutMS=300000",
                DatatabaseName = "local"
            });*/

        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            IocManager.IocContainer.Register(
                Component.For(typeof(INoSqlHelper<,>))
                //.ImplementedBy(typeof(BaseNoSqlHelper<,,>))
                    .ImplementedBy(typeof(MongoDbHelper<,>))
                    .LifestyleTransient()
                );


            

        }

    }
}

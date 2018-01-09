using System;
using Abp.Configuration.Startup;
using Abp.Dependency;
using MongoDbHelper.Configuration.Config;
using MongoDbHelper.Provider;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace MongoDbHelper.Configuration
{
    public static class MongoDbHelperConfigurationExtensions
    {

        public static IMongoDbHelperModuleConfiguration MongoDbHelper(this IModuleConfigurations configurations)
        {
            return configurations.AbpConfiguration.Get<IMongoDbHelperModuleConfiguration>();
        }

        /// <summary>
        /// db扩展
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="helperModuleConfiguration"></param>
        public static void UseMongoDb(this IAbpStartupConfiguration configuration, IMongoDbHelperModuleConfiguration helperModuleConfiguration)
        {
            MongoDbProvider provider = IocManager.Instance.Resolve<MongoDbProvider>();

            IMongoDbHelperModuleConfiguration abphelperConfig = IocManager.Instance.Resolve<IAbpStartupConfiguration>().Modules.MongoDbHelper();

            abphelperConfig.ConnectionString = helperModuleConfiguration.ConnectionString;
            abphelperConfig.DatatabaseName = helperModuleConfiguration.DatatabaseName;
            abphelperConfig.IsUseDefaultCollectionName = helperModuleConfiguration.IsUseDefaultCollectionName;

            provider.Database =
                new MongoClient(
                        helperModuleConfiguration.ConnectionString)
                    .GetDatabase(helperModuleConfiguration.DatatabaseName);
            //设置mongodb为local time。默认为utc time
            BsonSerializer.RegisterSerializer(typeof(DateTime), DateTimeSerializer.LocalInstance);
        }

    }
}

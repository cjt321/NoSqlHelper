using Abp.Configuration.Startup;
using Abp.Dependency;
using MongoDB.Driver;
using NoSqlHelper.Provider;

namespace MongoDbHelper.Provider
{
    public class MongoDbProvider: INoSqlProvider<IMongoDatabase>
    {

        /// <summary>
        /// 数据库连接
        /// </summary>
        public IMongoDatabase Database { get; set; }

        public MongoDbProvider()
        {
            /*//IAbpStartupConfiguration configuration = IocManager.

            Database = ;*/
        }

        

    }
}

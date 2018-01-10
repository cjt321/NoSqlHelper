
# 介绍
- 1.此语言版本：C#（ASP.Net）版本
- 2.前提：此包是在ABP框架基础之上开发的，你也可以进行改造。用到ABP是因为它支持的模块化&注入好。
- 3.当前使用ABP版本2.1.3
- 4.模块包含三个模块：基础模块NoSqlHelper、MongoDb模块MongoDbHelper、微软的DocumentDb模块：DocumentDbHelper

# 使用此包的优处：
- 无需改任何核心代码，如果想把mongodb换成memcached，只需要换个依赖、添加相应数据库链接就可以了。
- 使用DDD领域驱动模式开发，沿用仓储Repository的方法，注入不同的实体，进行CRUD操作。

# 说明

# NoSqlHelper模块
- 1.是所有模块的基础模块

# MongoDbHelper模块

# DocumentDbHelper

# 使用
- 在ABP其它模块中首先依赖于：MongoDbHelperModule。如果要换成memcached或documentdb，则依赖于相应的模块。
- 如果依赖于mongodb，则要在与初始化时，建立与mongodb的连接。
1. 首先依赖模块：
typeof(MongoDbHelperModule)
2. 然后建立连接：
            Configuration.UseMongoDb(new MongoDbHelperModuleConfiguration()
            {
                ConnectionString = "mongodb://192.168.1.124:27017/?connectTimeoutMS=300000",
                DatatabaseName = "local",
                IsUseDefaultCollectionName = false
                
            });
![](http://alunchen-img.oss-cn-shenzhen.aliyuncs.com/github/NoSqlHelper/20180110102729.png)  

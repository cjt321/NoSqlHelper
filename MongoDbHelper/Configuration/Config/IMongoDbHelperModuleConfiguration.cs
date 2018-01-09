namespace MongoDbHelper.Configuration.Config
{
    public interface IMongoDbHelperModuleConfiguration
    {
        /// <summary>
        /// db连接
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// db名字
        /// </summary>
        string DatatabaseName { get; set; }

        /// <summary>
        /// 是否使用默认的容器名字。默认为类名
        /// </summary>
        bool IsUseDefaultCollectionName { get; set; }

    }
}

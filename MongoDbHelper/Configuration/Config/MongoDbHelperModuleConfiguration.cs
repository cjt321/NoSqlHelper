namespace MongoDbHelper.Configuration.Config
{
    public class MongoDbHelperModuleConfiguration : IMongoDbHelperModuleConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string DatatabaseName { get; set; }

        public bool IsUseDefaultCollectionName { get; set; }

        public MongoDbHelperModuleConfiguration()
        {
            IsUseDefaultCollectionName = false;
        }
    }
}

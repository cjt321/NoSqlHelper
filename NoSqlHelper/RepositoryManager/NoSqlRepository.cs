using Abp.Dependency;
using NoSqlHelper.BaseEntity;
using NoSqlHelper.BaseNoSqlHelper;

namespace NoSqlHelper.RepositoryManager
{
    /// <summary>
    /// NoSqlRepository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public class NoSqlRepository<TEntity, TPrimaryKey> : BaseNoSqlRepository<TEntity, TPrimaryKey>
        where TEntity : class, IMicroEntity<TPrimaryKey> where TPrimaryKey : class
    {
        /*public INoSqlHelper<TEntity, TPrimaryKey> NoSqlHelper { get; set; }
        public TEntity Save(TEntity entity)
        {
            throw new System.NotImplementedException();
        }*/

        /*public NoSqlRepository()
        {
            NoSqlHelper = IocManager.Instance.Resolve<INoSqlHelper<TEntity, TPrimaryKey>>();
        }*/

        /*public INoSqlHelper<TEntity, TPrimaryKey> NoSqlHelper { get; set; }

        public virtual TEntity Save(TEntity entity)
        {
            return NoSqlHelper.Insert(entity);
        }*/
    }
}

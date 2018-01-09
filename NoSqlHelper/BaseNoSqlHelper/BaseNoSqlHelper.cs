using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Dependency;
using NoSqlHelper.BaseEntity;
using NoSqlHelper.Provider;

namespace NoSqlHelper.BaseNoSqlHelper
{
    /// <summary>
    /// base 连接nosql基础类
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class BaseNoSqlHelper<TEntity, TPrimaryKey, TDataBase> : INoSqlHelper<TEntity, TPrimaryKey> 
        where TDataBase : class where TEntity : class, IMicroEntity<TPrimaryKey> where TPrimaryKey : class
    {

        private readonly INoSqlProvider<TDataBase> _noSqlProvider;

        protected abstract string CollectionName { get; set; }

        protected BaseNoSqlHelper()
        {
            _noSqlProvider = IocManager.Instance.Resolve<INoSqlProvider<TDataBase>>();
        }

        protected virtual TDataBase Database => _noSqlProvider.Database;

        public abstract TEntity Insert(TEntity entity);

        public void SetCollectionName(string collectionName)
        {
            this.CollectionName = collectionName;
        }

        public abstract void Delete(TEntity entity);
        public abstract Task DeleteAsync(TEntity entity);
        public abstract void Delete(TPrimaryKey id);
        public abstract Task DeleteAsync(TPrimaryKey id);
        public abstract void Delete(Expression<Func<TEntity, bool>> predicate);
        public abstract Task DeleteAsync(Expression<Func<TEntity, bool>> predicate);
        
        public abstract Task<TEntity> InsertAsync(TEntity entity);
        public abstract TPrimaryKey InsertAndGetId(TEntity entity);
        public abstract Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity);
        public abstract TEntity InsertOrUpdate(TEntity entity);
        public abstract Task<TEntity> InsertOrUpdateAsync(TEntity entity);
        public abstract TPrimaryKey InsertOrUpdateAndGetId(TEntity entity);
        public abstract Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity);
        public abstract TEntity Update(TEntity entity);
        public abstract Task<TEntity> UpdateAsync(TEntity entity);
        public abstract TEntity Update(TPrimaryKey id, Action<TEntity> updateAction);
        public abstract Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction);
        public abstract IQueryable<TEntity> GetAll();
        public abstract IQueryable<TEntity> GetAllBase();

        public abstract List<TEntity> GetAllList();
        public abstract Task<List<TEntity>> GetAllListAsync();
        public abstract List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract T Query<T>(Func<IQueryable<TEntity>, T> queryMethod);
        public abstract TEntity Get(TPrimaryKey id);
        public abstract Task<TEntity> GetAsync(TPrimaryKey id);
        public abstract TEntity Single(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity FirstOrDefault(TPrimaryKey id);
        public abstract Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id);
        public abstract TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        public abstract Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        public abstract TEntity Load(TPrimaryKey id);
    }
}

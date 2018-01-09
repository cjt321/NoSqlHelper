using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Abp.Dependency;
using NoSqlHelper.BaseEntity;
using NoSqlHelper.BaseNoSqlHelper;

namespace NoSqlHelper.RepositoryManager
{
    /// <summary>
    /// 对外提供的
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    public abstract class BaseNoSqlRepository<TEntity, TPrimaryKey> : INoSqlRepository<TEntity, TPrimaryKey>
        where TEntity : class, IMicroEntity<TPrimaryKey> where TPrimaryKey : class
    {
        //private string _collectionName;


        protected BaseNoSqlRepository()
        {
            NoSqlHelper = IocManager.Instance.Resolve<INoSqlHelper<TEntity, TPrimaryKey>>();

        }

        public void SetCollectionName(string collectionName)
        {
            NoSqlHelper.SetCollectionName(collectionName);
        }

        public INoSqlHelper<TEntity, TPrimaryKey> NoSqlHelper { get; set; }

        public virtual void Delete(TEntity entity)
         {
             NoSqlHelper.Delete(entity.id);
         }

        public virtual async Task DeleteAsync(TEntity entity)
         {
            await NoSqlHelper.DeleteAsync(entity.id);
         }

        public virtual void Delete(TPrimaryKey id)
         {
            NoSqlHelper.Delete(o => o.id == id);
         }

        public virtual async Task DeleteAsync(TPrimaryKey id)
         {
            await NoSqlHelper.DeleteAsync(o => o.id == id);
         }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
         {
            NoSqlHelper.Delete(predicate);
         }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
         {
            await NoSqlHelper.DeleteAsync(predicate);
        }

        public virtual TEntity Insert(TEntity entity)
         {
             return NoSqlHelper.Insert(entity);
         }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
         {
            return await NoSqlHelper.InsertAsync(entity);
         }

        public virtual TPrimaryKey InsertAndGetId(TEntity entity)
         {
            return NoSqlHelper.InsertAndGetId(entity);
         }

        public virtual async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
         {
            return await NoSqlHelper.InsertAndGetIdAsync(entity);
        }

        public virtual TEntity InsertOrUpdate(TEntity entity)
         {
             return NoSqlHelper.InsertOrUpdate(entity);
         }

        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
         {
            return await NoSqlHelper.InsertOrUpdateAsync(entity);
        }

        public virtual TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
         {
            return NoSqlHelper.InsertOrUpdateAndGetId(entity);
         }

        public virtual async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
         {
            return await NoSqlHelper.InsertOrUpdateAndGetIdAsync(entity);
         }

        public virtual TEntity Update(TEntity entity)
        {
            return NoSqlHelper.Update(entity);

        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await NoSqlHelper.UpdateAsync(entity);
        }

        public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
        {
            return NoSqlHelper.Update(id, updateAction);
        }

        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
        {
            return await NoSqlHelper.UpdateAsync(id, updateAction);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return NoSqlHelper.GetAll();
        }

        public IQueryable<TEntity> GetAllBase()
        {
            return NoSqlHelper.GetAllBase();
        }

        public virtual List<TEntity> GetAllList()
         {
            return NoSqlHelper.GetAllList();
        }

        public virtual async Task<List<TEntity>> GetAllListAsync()
         {
            return await NoSqlHelper.GetAllListAsync();
        }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
         {
            return NoSqlHelper.GetAllList(predicate);
        }

        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
         {
            return await NoSqlHelper.GetAllListAsync(predicate);
        }

        //TODO 待验证
         public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
         {
            return NoSqlHelper.Query(queryMethod);
        }

        public virtual TEntity Get(TPrimaryKey id)
        {
            return NoSqlHelper.Get(id);
        }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
        {
            return await NoSqlHelper.GetAsync(id);
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
         {
            return NoSqlHelper.Single(predicate);
        }

        public virtual async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await NoSqlHelper.SingleAsync(predicate);
        }

        public virtual TEntity FirstOrDefault(TPrimaryKey id)
         {
            return NoSqlHelper.FirstOrDefault(id);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
         {
            return await NoSqlHelper.FirstOrDefaultAsync(id);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
         {
            return NoSqlHelper.FirstOrDefault(predicate);
        }
    

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
         {
            return await NoSqlHelper.FirstOrDefaultAsync(predicate);
        }

         public virtual TEntity Load(TPrimaryKey id)
         {
             return NoSqlHelper.Load(id);
         }
         

       

        /*public virtual TEntity Save(TEntity entity)
        {
            return NoSqlHelper.Insert(entity);
        }

        public virtual async Task<TEntity> SaveAsnyc(TEntity entity)
        {
            return await NoSqlHelper.InsertAsync(entity);
        }



        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey key, Func<TEntity, Task> updateAction)
        {
            return await NoSqlHelper.UpdateAsync(key, updateAction);
        }


        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey key, TEntity updatgeEntity)
        {
            return await NoSqlHelper.UpdateAsync(updatgeEntity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity updatgeEntity)
        {
            return await NoSqlHelper.UpdateAsync(updatgeEntity);
        }

        public virtual async Task<TEntity> FindAsync(TPrimaryKey key)
        {
            return await NoSqlHelper.GetAsync(key);
        }

        public virtual async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await NoSqlHelper.GetAllListAsync(predicate);
        }

        public virtual IQueryable<TEntity> Queryable()
        {
            return NoSqlHelper.GetAll();
        }

        public virtual IOrderedQueryable<TEntity> OrderQueryable()
        {
            return NoSqlHelper.GetAll().OrderBy(o=>o.id);
        }

        public virtual async Task DeleteAsync(TPrimaryKey key)
        {
            await NoSqlHelper.DeleteAsync(key);
        }*/
    }
}

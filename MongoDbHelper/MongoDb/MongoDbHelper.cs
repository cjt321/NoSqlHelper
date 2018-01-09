

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Specifications;
using MongoDbHelper.Configuration;
using MongoDbHelper.Configuration.Config;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using NoSqlHelper.BaseEntity;
using NoSqlHelper.BaseNoSqlHelper;
using NoSqlHelper.Provider;

namespace MongoDbHelper.MongoDb
{
    
    /// <summary>
    /// mongo db crud helper with string
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public class MongoDbHelper<TEntity> : MongoDbHelper<TEntity, string>
        where TEntity : class, IMicroEntity<string> 
    {
    }


    /// <summary>
    /// mongo db crud helper
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TPrimaryKey"></typeparam>
    
    public class MongoDbHelper<TEntity, TPrimaryKey> : INoSqlHelper<TEntity, TPrimaryKey> 
        where TEntity :class, IMicroEntity<TPrimaryKey> where TPrimaryKey:class
    {
        private string _collectionName;

        protected IMongoCollection<TEntity> Collection;

        private readonly INoSqlProvider<IMongoDatabase> _noSqlProvider;
        protected virtual IMongoDatabase Database => _noSqlProvider.Database;

        private readonly IMongoDbHelperModuleConfiguration _helperModuleConfiguration;

        private readonly Expression<Func<TEntity, bool>> _andExpression = o => o.BaseDocumentEntityType == typeof(TEntity).FullName;

        public MongoDbHelper()
        {
            _helperModuleConfiguration = IocManager.Instance.Resolve<IAbpStartupConfiguration>().Modules.MongoDbHelper();
            _noSqlProvider = IocManager.Instance.Resolve<INoSqlProvider<IMongoDatabase>>();
            if (_helperModuleConfiguration.IsUseDefaultCollectionName)
                Collection = Database.GetCollection<TEntity>(typeof(TEntity).Name);//.OfType<TEntity>();

            /*if (!BsonClassMap.IsClassMapRegistered(typeof(TEntity)))
            {
                BsonClassMap.RegisterClassMap<TEntity>();
            }*/

            /*Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(item =>
                    item.IsSubclassOf(typeof(TEntity))
                    )
                    .ToList().ForEach(type =>
                    {
                        if (!BsonClassMap.IsClassMapRegistered(type))
                            BsonClassMap.RegisterClassMap(new BsonClassMap(type));
                    });*/
        }
        
        public void SetCollectionName(string collectionName)
        {
            _collectionName = collectionName;
            if (!string.IsNullOrEmpty(_collectionName) && !_helperModuleConfiguration.IsUseDefaultCollectionName)
                Collection = Database.GetCollection<TEntity>(_collectionName); //.OfType<TEntity>();
        }

        public virtual void Delete(TEntity entity)
         {
             Delete(entity.id);
         }

        public virtual async Task DeleteAsync(TEntity entity)
         {
             await DeleteAsync(entity.id);
         }

        public virtual void Delete(TPrimaryKey id)
         {
            Collection.DeleteOne(o => o.id == id);
         }

        public virtual async Task DeleteAsync(TPrimaryKey id)
         {
             await Collection.DeleteOneAsync(o => o.id == id);
         }

        public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
         {
             Collection.DeleteMany(predicate);
         }

        public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
         {
            await Collection.DeleteManyAsync(predicate);
        }

        public virtual TEntity Insert(TEntity entity)
         {
             Collection.InsertOne(entity);
             return entity;
         }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
         {
             await Collection.InsertOneAsync(entity);
             return entity;
         }

        public virtual TPrimaryKey InsertAndGetId(TEntity entity)
         {
             Collection.InsertOne(entity);
             return entity?.id;
         }

        public virtual async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
         {
           await Collection.InsertOneAsync(entity);
            return entity?.id;
        }

        public virtual TEntity InsertOrUpdate(TEntity entity)
         {
             TEntity findEntity = Get(entity.id);
             if (findEntity != null)
                 return Insert(entity);
             return Update(entity);
         }

        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
         {
            TEntity findEntity = Get(entity.id);
            if (findEntity != null)
                return await InsertAsync(entity);
            return await UpdateAsync(entity);
        }

        public virtual TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
         {
             return InsertOrUpdate(entity)?.id;
         }

        public virtual async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
         {
            return (await InsertOrUpdateAsync(entity))?.id;
         }

        public virtual TEntity Update(TEntity entity)
         {
             ReplaceOneResult result = Collection.ReplaceOne(o => o.id == entity.id, entity);
             return UpdateSuccessfulOrFailed(result, entity);

         }



        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
         {
            ReplaceOneResult result = await Collection.ReplaceOneAsync(o => o.id == entity.id, entity);
            return UpdateSuccessfulOrFailed(result, entity);
        }

        public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
         {
             TEntity findEntity = Get(id);
             updateAction(findEntity);
            ReplaceOneResult result = Collection.ReplaceOne(o => o.id == id, findEntity);
            return UpdateSuccessfulOrFailed(result, findEntity);
        }

        public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Func<TEntity, Task> updateAction)
         {
            TEntity findEntity = await GetAsync(id);
            await updateAction(findEntity);
            ReplaceOneResult result = await Collection.ReplaceOneAsync(o => o.id == id, findEntity);
            return UpdateSuccessfulOrFailed(result, findEntity);
        }

        public virtual IQueryable<TEntity> GetAll()
         {
            return Collection.AsQueryable().Where(_andExpression).AsQueryable();
        }


        /// <summary>
        /// 如要使用base，则要注入classmap
        /// Assembly
        ///        .GetExecutingAssembly()
        ///        .GetTypes()
        ///        .Where(item =>
        ///            item.IsSubclassOf(typeof(MicroEntity<string>)))
        ///            .ToList().ForEach(type =>
         ///           {
         ///   if (!BsonClassMap.IsClassMapRegistered(type))
         ///       BsonClassMap.RegisterClassMap(new BsonClassMap(type));
        ///   });
        /// </summary>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllBase()
        {
            return Collection.AsQueryable();
        }

        public virtual List<TEntity> GetAllList()
         {
            return GetAll().ToList();
         }

        public virtual async Task<List<TEntity>> GetAllListAsync()
         {
             return await Task.FromResult(GetAllList());
         }

        public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
        {
             return GetAll().Where(predicate).ToList();
         }

        public virtual async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
         {
            return await Task.FromResult(GetAllList(predicate));
        }

        //TODO 待验证
         public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
         {
             IQueryable<TEntity> queryable = GetAll();
             return queryMethod.Invoke(queryable);
         }

        public virtual TEntity Get(TPrimaryKey id)
         {
            return Collection.Find(_andExpression.And(o => o.id == id)).FirstOrDefault();
         }

        public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
         {
            return (await Collection.FindAsync(_andExpression.And(o => o.id == id))).FirstOrDefault();
        }

        public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
         {
            return FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
         {
            return await FirstOrDefaultAsync(predicate);
        }

        public virtual TEntity FirstOrDefault(TPrimaryKey id)
         {
            return FirstOrDefault(_andExpression.And(o => o.id == id));
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
         {
            return await FirstOrDefaultAsync(o => o.id == id);
        }

        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
         {
            return GetAll().FirstOrDefault(predicate);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
         {
            return await Task.FromResult(FirstOrDefault(predicate));
        }

         public virtual TEntity Load(TPrimaryKey id)
         {
             return Get(id);
         }
         

        /// <summary>
        /// 检查更新是否成功
        /// </summary>
        /// <param name="result"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private TEntity UpdateSuccessfulOrFailed(ReplaceOneResult result, TEntity entity)
        {
            if (result.MatchedCount == result.ModifiedCount && result.ModifiedCount > 0)
                return entity;
            return null;
        }
        

    }
}

using System;
using System.Collections.Generic;
using EagleEye.Core.Interfaces;
using Serilog;

namespace EagleEye.Infrastructure.Repositories
{
   public class BaseRepository<T> : IBaseRepository<T> where T : class
   {
       private readonly IDbFactory _dbFactory;

       public BaseRepository(IDbFactory dbFactory)
       {
           _dbFactory = dbFactory;
       }
        public T Get(string id)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    return db.SingleById<T>(id);
                }
            }
            catch (Exception e)
            {

                Log.Error("Error occured : " + e);
                return null;
            }
        }

        public T Get(long id)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    return db.SingleById<T>(id);
                }
            }
            catch (Exception e)
            {

                Log.Error("Error occured : " + e);
                return null;
            }
        }

        public T FirstOrDefault(string sqlString, object[] parameters)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    return db.FirstOrDefault<T>(sqlString, parameters);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error occured : " + e);
                return null;
            }
        }

        public IEnumerable<T> Fetch(string sqlString, object[] parameters)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    return db.Fetch<T>(sqlString, parameters);
                }
            }
            catch (Exception e)
            {
                Log.Error("Error occured : " + e);
                return null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    return db.Fetch<T>();
                }
            }
            catch (Exception e)
            {
                Log.Error("Error occured : " + e);
                return null;
            }
        }

        public T Add(T entity)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                     db.Insert(entity);
                     return entity;
                }
            }
            catch (Exception e)
            {
                Log.Error("Error occured : " + e);
                return null;
            }
        }

        public T Add(T entity, string tableName, string primaryKeyName)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    db.Insert(tableName,primaryKeyName,false,entity);
                    return entity;
                }
            }
            catch (Exception e)
            {
                Log.Error("Error occured : " + e);
                return null;
            }
        }

        public void AddRange(IEnumerable<T> entities)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    db.InsertBatch(entities);

                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, "An error inserting  batch for entity of type " + nameof(T));

            }
        }

        public void Delete(T entity)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    db.Delete(entity);

                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, "An error deleting entity of type " + nameof(T));

            }
        }

        public T Delete(T entity, string tableName, string primaryKeyName)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    db.Delete<T>(tableName, primaryKeyName, false, entity);
                    return entity;
                }
            }
            catch (Exception e)
            {
                Log.Error("Error occured : " + e);
                return null;
            }
        }


        public T Update(T entity)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    db.Update(entity);

                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, "An error updating entity of type " + nameof(T));

            }

            return entity;
        }

        public T Update(T entity, string primaryKeyId)
        {
            try
            {
                using (var db = _dbFactory.GetConnection())
                {
                    db.Update(entity, primaryKeyId);

                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, "An error updating entity of type " + nameof(T) + " with primary key " + primaryKeyId);

            }


            return entity;
        }
    }
}

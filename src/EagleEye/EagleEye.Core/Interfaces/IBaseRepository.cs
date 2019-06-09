using System;
using System.Collections.Generic;
using System.Text;

namespace EagleEye.Core.Interfaces
{
   public interface IBaseRepository<T> where T : class
   {
       T Get(string id);
       T Get(long id);
       T FirstOrDefault(string sqlString, object[] parameters);

       IEnumerable<T> Fetch(string sqlString, object[] parameters);
       IEnumerable<T> GetAll();

       T Add(T entity);
       T Add(T entity, string tableName, string primaryKeyName);   //NPoco specific nuance
       T Delete(T entity, string tableName, string primaryKeyName);   //NPoco specific nuance
        void AddRange(IEnumerable<T> entities);
       void Delete(T entity);
       T Update(T entity);
       T Update(T entity, string primaryKeyId);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace DAO.Dao
{
    internal abstract class BaseDao<T>
    {
        protected string request = "";
        public abstract T Save (T entity);
        public abstract T Update(T entity);
        public abstract List<T> GetAll();
        public abstract T? GetById(int id);
        public abstract void DeleteById(int id);

    }
}

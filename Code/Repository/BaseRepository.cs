using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using MujZavod.Data;
using System.Web;
using System.Collections;

namespace MujZavod.Code.Repository
{
    public abstract class BaseRepository<T> where T : class
    {
        public DataDbContext Context
        {
            get
            {
                if (HttpContext.Current == null)
                    return new DataDbContext();

                DataDbContext dt = null;
                IDictionary items = HttpContext.Current.Items;
                if (!items.Contains("DataDbContext"))
                {
                    items["DataDbContext"] = new DataDbContext();
                }
                dt = items["DataDbContext"] as DataDbContext;
                return dt;
            }
        }
        protected abstract string dbSetContextName { get; }

        

        protected DbSet<T2> _getAll<T2>(string dbSetContextName) where T2 : class
        {
            return (DbSet<T2>)Context.GetType().GetProperty(dbSetContextName).GetValue(Context);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _getAll<T>(dbSetContextName);
        }
        public virtual IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return GetAll().Where(expression);
        }

        public virtual T Get(Expression<Func<T, bool>> expression)
        {
            return GetAll().FirstOrDefault(expression);
        }

        /// <summary>
        /// Je potřeba aby entity z datového modelu měla označený primární klíč pomocí data anotace [Key], také to zatím funguje pouze pro nesložené primární klíče
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T GetById(object id)
        {
            Expression<Func<T, bool>> expression = ByIdExpression(id);
            if (expression != null)
            {
                return Get(expression);
            }
            return null;
        }

        public virtual void Create(T entity, bool saveChanges)
        {
            var prop = Context.GetType().GetProperty(dbSetContextName);
            ((DbSet<T>)prop.GetValue(Context)).Add(entity);

            if (saveChanges)
            {
                try
                {
                    Context.SaveChanges();
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                
            }
        }

        public virtual void Update(IEnumerable<T> entities, bool saveChanges)
        {
            foreach (var entity in entities)
                Context.Entry(entity).State = EntityState.Modified;

            if (saveChanges)
            {
                
                Context.SaveChanges();
                
            }
        }

        public virtual void Update(T entity, bool saveChanges)
        {
            var entry = Context.Entry(entity).State = EntityState.Modified;

            if (saveChanges)
            {
                
                Context.SaveChanges();
                
            }
        }

        public virtual void Remove(Expression<Func<T, bool>> expression, bool saveChanges)
        {
            Remove(Get(expression), saveChanges);
        }

        public virtual void Remove(T entity, bool saveChanges)
        {
            ((DbSet<T>)GetAll()).Remove(entity);

            if (saveChanges)
            {
                
                Context.SaveChanges();
                
            }
        }

        

        /// <summary>
        /// Je potřeba aby entity z datového modelu měla označený primární klíč pomocí data anotace [Key], také to zatím funguje pouze pro nesložené primární klíče
        /// při potřebě smazat více položek na ráz je lepší použít RemoveAll(Expression)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual bool RemoveById(object id, bool saveChanges)
        {
            Expression<Func<T, bool>> expression = ByIdExpression(id);
            if (expression != null)
            {
                Remove(expression,saveChanges);
                return true;
            }
            return false;
        }

        protected virtual Expression<Func<T, bool>> ByIdExpression(object id)
        {
            var properties = typeof(T).GetProperties();
            PropertyInfo keyProperty = null;
            int found = 0;
            foreach (var property in properties)
            {
                Attribute attr = property.GetCustomAttribute(typeof(KeyAttribute));
                if (attr != null)
                {
                    keyProperty = property;
                    found++;
                }
            }

            if (found == 1 && keyProperty != null)
            {
                ParameterExpression argParam = Expression.Parameter(typeof(T), "x");
                Expression nameProperty = Expression.Property(argParam, keyProperty.Name);
                ConstantExpression val = Expression.Constant(id);
                Expression expression = Expression.Equal(nameProperty, val);

                return Expression.Lambda<Func<T, bool>>(expression, argParam);
            }
            return null;
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Ru.Rubinst.DocumentCommon
{
    public interface IRepository
    {
    }

    public interface IRepository<TEntity> : IRepository where TEntity : class 
    {
        /// <summary>
        /// Возвращает перечисление элементов репозитория
        /// </summary>
        /// <param name="filter">Фильтр возвращаемых значений</param>
        /// <param name="orderBy">Условие сортировки</param>
        /// <param name="includeProperties">Подключаемые справочники, разделяются запятыми</param>
        /// <returns>Перечисление элементов репозитория</returns>
        IEnumerable<TEntity> GetItems(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(params object[] keys);
        void Insert(TEntity item);
        void Delete(params object[] keys);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
    }
}

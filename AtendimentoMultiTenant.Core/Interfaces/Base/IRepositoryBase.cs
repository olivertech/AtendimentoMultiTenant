﻿namespace AtendimentoMultiTenant.Core.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<IEnumerable<T>?> GetAll();
        Task<T?> GetById(Guid? id);
        Task<IEnumerable<T>?> GetList(Expression<Func<T, bool>> predicate);
        Task<int> Count();
        Task<T?> Insert(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(Guid? id);
    }
}

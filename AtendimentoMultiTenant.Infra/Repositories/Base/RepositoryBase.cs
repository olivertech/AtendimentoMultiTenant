using System;

namespace AtendimentoMultiTenant.Infra.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T>
        where T : EntityBase
    {
        protected readonly AppDbContext? _context;
        protected readonly DbSet<T>? _entities;

        public RepositoryBase([NotNull] AppDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async virtual Task<IEnumerable<T>?> GetAll()
        {
            try
            {
                var list = await _entities!.ToListAsync();

                return list ?? Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível recuperar a lista.", ex);
            }
        }

        public async virtual Task<T?> GetById(Guid? id)
        {
            try
            {
                var entity = await _entities!.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (entity == null)
                    throw new InvalidOperationException("Registro não encontrado!");

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível recuperar a id informado.", ex);
            }
        }

        public async virtual Task<IEnumerable<T>?> GetList(Expression<Func<T, bool>> predicate)
        {
            try
            {
                var list = await _entities!.Where(predicate).ToListAsync();

                return list ?? Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível recuperar a lista.", ex);
            }
        }

        public async virtual Task<IEnumerable<T?>> GetPagedList(int pageSize, int pageNumber)
        {
            try
            {
                var list = await _entities!
                                .Skip(pageNumber)
                                .Take(pageSize)
                                .ToListAsync();

                return list ?? Enumerable.Empty<T>();
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível recuperar a lista paginada.", ex);
            }
        }

        public async virtual Task<int> Count()
        {
            try
            {
                var list = await _entities!.ToListAsync();

                return list.Count;
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível recuperar o total.", ex);
            }
        }

        public async virtual Task<T?> Insert(T entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException(nameof(entity));

                await _entities!.AddAsync(entity);

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível inserir a entidade.", ex);
            }
        }

        public async virtual Task<bool> Update(T entity)
        {
            try
            {
                if (entity is null)
                    throw new ArgumentNullException(nameof(entity));

                var item = await _entities!.FindAsync(entity.Id);

                if (item is not null)
                {
                    _entities.Update(entity);
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível atualizar a entidade.", ex);
            }
        }

        public async virtual Task<bool> Delete(Guid? id)
        {
            try
            {
                var entity = await GetById(id);

                if (entity is null)
                    throw new InvalidOperationException("Registro não encontrado!");

                _entities!.Remove(entity);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("RepositoryError - Não foi possível remover a entidade.", ex);
            }
        }
    }
}

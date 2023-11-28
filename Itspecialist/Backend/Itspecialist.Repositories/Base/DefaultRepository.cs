
using System;

namespace Itspecialist.Repositories.Base
{
    [DefaultRepository]
    public class DefaultRepository<T, TKey> : IDefaultRepository<T, TKey> where T : BaseBaseIdDto
    {
        private readonly ItspecialistContext _context;
        public DefaultRepository(ItspecialistContext context)
        {
            _context = context;
        }

        [Add]
        public virtual async Task<T> Add(T t)
        {
            EntityEntry<T> result;
            result = await  _context.Set<T>().AddAsync(t);

            await _context.SaveChangesAsync();
            return result.Entity;
        }

        [Save]
        public virtual async Task<T> Save(T t)
        {
            var foundEntity = await _context.Set<T>().FindAsync(t.GetId());
            EntityEntry<T> result = _context.Entry(foundEntity);
            result.CurrentValues.SetValues(t);
            
            await _context.SaveChangesAsync();
            return result.Entity;
        }
        [Get]
        public virtual async Task<T> Get(TKey id)
        {
            return await EntityByIdAsync(id);
        }
        [GetAll]
        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }
        [Delete]
        public virtual async Task Delete(TKey id)
        {
            var entity = await EntityByIdAsync(id);
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }
        private async Task<T> EntityByIdAsync(TKey id)
        {
            if(id is Guid idGuid)
            {
                return await _context.Set<T>().FindAsync(idGuid);
            }

            throw new KeyNotFoundException();
        }
    }
}

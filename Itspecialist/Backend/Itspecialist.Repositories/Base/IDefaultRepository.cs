using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;

namespace Itspecialist.Repositories.Base
{
    public interface IDefaultRepository<TEntity, TKey> where TEntity : BaseIdDto
    {
        [Delete]
        Task Delete(TKey id);
        [Get]
        Task<TEntity> Get(TKey id);
        [GetAll]
        Task<List<TEntity>> GetAll();
        [Save]
        Task<TEntity> Save(TEntity t);
    }
}

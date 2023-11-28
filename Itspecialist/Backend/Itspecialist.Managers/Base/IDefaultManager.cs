using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Codelisk.GeneratorAttributes.WebAttributes.HttpMethod;

namespace Itspecialist.Managers.Base
{
    public interface IDefaultManager<TDto, TKey, TEntity> where TDto : class where TEntity : BaseBaseIdDto
    {
        [Delete]
        Task Delete(TKey id);
        [Get]
        Task<TDto> Get(TKey id);
        [GetFull]
        Task<object> GetFull(TKey id);
        [GetAll]
        Task<List<TDto>> GetAll();
        [Save]
        Task<TDto> Save(TDto t);
        [Add]
        Task<TDto> Add(TDto t);
        [GetAllFull]
        Task<List<object>> GetAllFull();
    }
}

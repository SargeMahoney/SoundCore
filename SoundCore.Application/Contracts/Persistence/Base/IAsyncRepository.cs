using SoundCore.Application.Models.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoundCore.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task<BaseResult> UpdateAsync(T entity);
        Task<BaseResult> DeleteAsync(T entity);   
    }
}

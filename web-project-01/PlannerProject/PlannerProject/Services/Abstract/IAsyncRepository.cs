using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlannerProject.Services.Abstract
{
    public interface IAsyncRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task Create(T item);
        Task Edit(string id, T item);
        Task Add(T item);
        Task Update(T item);
        Task Delete(string Id);
    }
}

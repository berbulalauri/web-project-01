using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsRent.Services.Abstract
{
    public interface IAsyncRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task Add(T item);
        Task Update(T item);
        Task Delete(string Id);
    }
}

using System;
using System.Threading.Tasks;

namespace workshop_02.Repositories
{
    public interface IRepository<T>
    {
        Task CreateAsync(T item);
        Task<T> ReadAsync();
        void Create(T item);
        T Read();
    }
}


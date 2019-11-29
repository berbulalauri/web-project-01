using System;
using System.Threading.Tasks;

namespace workshop_02.Repositories
{
    public class DbRepository<T> : IRepository<T>
    {
        public DbRepository()
        {
        }
        public async Task CreateAsync(T item)
        {
            throw new NotImplementedException();
        }
        public async Task<T> ReadAsync()
        {
            throw new NotImplementedException();
        }
        public  void Create(T item)
        {
            throw new NotImplementedException();
        }
        public T Read()
        {
            throw new NotImplementedException();
        }
    }
}


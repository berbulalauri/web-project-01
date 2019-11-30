using System;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace workshop2.Repositories
{
    public class JsonFileRepository<T> : IRepository<T>
    {
        public string FilePath { get; set; }

        public JsonFileRepository(string filePath)
        {
            FilePath = filePath;
        }

        public async Task CreateAsync(T item)
        {
            var serializedData = JsonConvert.SerializeObject(item);
            try
            {
                await File.WriteAllTextAsync(FilePath, serializedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Logger.Log("JsonFileRepository.CreateAsync", ex.Message, serializedData);

                throw;
            }
        }

        public async Task<T> ReadAsync()
        {
            var dataFromFile = await File.ReadAllTextAsync(FilePath);
            try
            {
                var data = JsonConvert.DeserializeObject<T>(dataFromFile);
                return data;
            }
            catch (Exception ex)
            {
                Logger.Log("JsonFileRepository.ReadAsync", ex.Message, dataFromFile);
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        public void Create(T item)
        {
            var serializedData = JsonConvert.SerializeObject(item);
            try
            {
                File.WriteAllText(FilePath, serializedData);
            }
            catch (Exception ex)
            {
                Logger.Log("JsonFileRepository.Create", ex.Message, serializedData);
                Console.WriteLine($"something went wrong " +ex.Message);
                throw;
            }
        }
        public T Read()
        {
            var dataFromFile = File.ReadAllText(FilePath);
            try
            {
                var data = JsonConvert.DeserializeObject<T>(dataFromFile);
                return data;
            }
            catch (Exception ex)
            {
                Logger.Log("JsonFileRepository.Read", ex.Message, dataFromFile);
                Console.WriteLine(ex.Message);
                throw;
            }
        }



    }
}

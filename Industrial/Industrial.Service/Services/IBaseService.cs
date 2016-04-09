using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Industrial.Service.Services
{
    public interface IBaseService<T,K>
    {
         Task<List<T>> GetAllAsync();

        List<T> GetAll();
        Task<T> FindByIdAsync(K id);
        Task<List<T>> GetAllAsync(int skip, int pageSize);
        List<T> GetAll(int page, int pageSize);
        Task<T> CreateAsync(T item);

        Task<T> EditAsync(T item);

        Task<T> DeleteAsync(K id);
        IEnumerable<T> Search(string searchWord, int i, int pageSize, out int total);
    }
}

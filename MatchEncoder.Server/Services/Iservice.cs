using System.Collections.Generic;
using System.Threading.Tasks;

public interface Iservice<T> //  T for more generic purposes
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
}

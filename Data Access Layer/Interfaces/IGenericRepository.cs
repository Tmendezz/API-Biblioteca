namespace APIBiblioteca.Data_Access_Layer.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<bool> Insert(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> Delete(int id);
    }
}

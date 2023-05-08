namespace Core.Interfaces.Repositorios
{
    public interface _IBaseRepositorio<T> where T : class
    {
        public Task<T?> GetByIdAsync(uint id, bool? active = true);
        public T? GetById(uint id, bool? active = true);

        public Task<IList<T>> GetAllAsync(bool? active = true);
        public IList<T> GetAll(bool? active = true);

        public Task<T> AddAsync(T item);
        public T Add(T item);

        public Task<T> UpdateAsync(T item);
        public T Update(T item);

        public Task<T> DeleteAsync(T item);
        public T Delete(T item);


    }
}

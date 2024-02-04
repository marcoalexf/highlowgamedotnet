namespace HighLowGame.Infrastructure
{
    public interface IMockDB<T>
    {
        public Task<T> AddAsync(T t);
        public Task DeleteAsync(Guid id);
        public Task<T?> GetAsync(Guid id);

        public Task<T> UpdateAsync(T t); 
    }
}

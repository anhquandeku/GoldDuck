namespace GoldDuckCamera.Server.Repository
{
    public interface IBillDetailRepository<T>
    {
        public Task<T> CreateAsync(T _object);

        public Task UpdateAsync(T _object);

        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(int idBill, int idProduct);

        public Task DeleteAsync(int id, int idProduct);
    }
}

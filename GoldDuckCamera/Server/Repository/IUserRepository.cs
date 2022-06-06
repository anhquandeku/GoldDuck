namespace GoldDuckCamera.Server.Repository
{
    public interface IUserRepository<T>
    {
        public Task<T> CreateAsync(T _object);

        public Task UpdateAsync(T _object);

        public Task<List<T>> GetAllAsync();

        public Task<T> GetByIdAsync(string username);

        public Task DeleteAsync(string username);

        public Task<T> GetUserPassword(string username, string password);
    }
}

namespace BlogiAPI.Domain.Repositories.Base
{
    public interface IBaseRepository
    {
        public Task<int> SaveData<T>(string dBSp, T parameters);
        public Task<int> DeleteData<T>(string dBSp, T parameters);
        public Task<T?> LoadOneData<T, U>(string sqlQuery, U parameters);
        public Task<List<T>> LoadData<T, U>(string dpSp, U parameters);
    }
}
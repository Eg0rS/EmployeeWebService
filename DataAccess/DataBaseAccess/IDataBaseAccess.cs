
namespace DataAccess.DataBaseAccess
{
    public interface IDataBaseAccess
    {
        Task<IEnumerable<T>> GetData<T, U>(string storedProcedure, U parameters, string connectionId = "Default");
        Task SetData<T>(string storedProcedure, T parameters, string connectionId = "Default");
    }
}
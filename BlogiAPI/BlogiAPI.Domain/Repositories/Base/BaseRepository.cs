using System.Data;
using Dapper;
using Npgsql;

namespace BlogiAPI.Domain.Repositories.Base;

public class BaseRepository() : IBaseRepository
{

    public async Task<int> SaveData<T>(string dBSp, T parameters)
    {

        using IDbConnection connection = new NpgsqlConnection(BaseConstants.DbConnectionString);

        return await connection.ExecuteAsync(dBSp, parameters, commandType: CommandType.StoredProcedure);

    }

    public async Task<int> DeleteData<T>(string dBSp, T parameters)
    {

        using IDbConnection connection = new NpgsqlConnection(BaseConstants.DbConnectionString);

        var result = await connection.ExecuteAsync(dBSp, parameters, commandType: CommandType.StoredProcedure);

        return result;
    }

    public async Task<T?> LoadOneData<T, U>(string sqlQuery, U parameters)
    {
        
        try
        {
            using IDbConnection connection = new NpgsqlConnection(BaseConstants.DbConnectionString);
            var result = await connection.QueryFirstOrDefaultAsync<T>(sqlQuery, parameters);

            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

    }

    public async Task<List<T>> LoadData<T, U>(string dpSp, U parameters)
    {

        using IDbConnection connection = new NpgsqlConnection(BaseConstants.DbConnectionString);

        var results = await connection.QueryAsync<T>(dpSp, parameters);

        return results.AsList();
    }

}
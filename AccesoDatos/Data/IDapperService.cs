using Dapper;
using System.Data;

namespace AccesoDatos.Data
{
    public interface IDapperService : IDisposable
    {
        Task<int> InsertUpdateModelo(string conexion, string NomStored, object modelo, CommandType commandType = CommandType.StoredProcedure);
        Task<int> BDAccion(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        Task<string> BDAccionString(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        List<T> LlenarCombo<T>(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        Task<T> BDBuscarReg<T>(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        Task<List<T>> BDLista<T>(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        //Task<string> RegresaValor(string conexion, string NomStored, DynamicParameters paraml, CommandType commandType = CommandType.StoredProcedure);
    }
}

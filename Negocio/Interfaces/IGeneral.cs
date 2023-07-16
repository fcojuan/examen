using Dapper;
using System.Data;

namespace Negocio.Interfaces
{
    public interface IGeneral<T> where T : class
    {
        Task<int> InsertUpdateModelo(string NomStored, Object Modelo, CommandType commandType = CommandType.StoredProcedure);
        Task<int> BDAccion(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        //Task<string> BDAccionString(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        Task<T> BDBuscarReg(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        Task<List<T>> ListAll(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
        List<T> LlenarCombo(string NomStored, string opc, string valor="", CommandType commandType = CommandType.StoredProcedure);
        IDictionary<string, object> CreaDiccionario(string[] param, string[] valores);
        Task<string> BDAccionString(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure);
    }
}

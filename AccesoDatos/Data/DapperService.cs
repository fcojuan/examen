using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos.Data
{
    public class DapperService : IDapperService
    {
        public async Task<int> InsertUpdateModelo(string conexion,string NomStored, object modelo, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = new SqlConnection(conexion))
            {
                try
                {
                    int valorReturn = 0;
                    await con.OpenAsync();
                    SqlTransaction sqltrans = con.BeginTransaction();
                    try
                    {
                        //-------------------------------------------------
                        await con.ExecuteAsync(NomStored, modelo, sqltrans, 0, commandType: commandType);

                        sqltrans.Commit();
                    }
                    catch (Exception)
                    {
                        sqltrans.Rollback();
                        con.Close();
                        valorReturn = 1;
                        throw;
                    }
                    finally
                    {
                        sqltrans.Dispose();
                        con.Close();
                    }
                    return valorReturn;
                }
                catch (Exception)   // si la coneccion falla
                {
                    con.Close();
                    throw;
                }
            }
        }
        public async Task<int> BDAccion(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = new SqlConnection(conexion))
            {
                try
                {
                    int valorReturn = 0;
                    await con.OpenAsync();
                    SqlTransaction sqltrans = con.BeginTransaction();
                    try
                    {
                        //-------------------------------------------------
                        await con.ExecuteAsync(NomStored, new DynamicParameters(param), sqltrans, 0, commandType: commandType);

                        sqltrans.Commit();
                    }
                    catch (Exception)
                    {
                        sqltrans.Rollback();
                        con.Close();
                        valorReturn = 1;
                        throw;
                    }
                    finally
                    {
                        sqltrans.Dispose();
                        con.Close();
                    }
                    return valorReturn;
                }
                catch (Exception)   // si la coneccion falla
                {
                    con.Close();
                    throw;
                }
            }
        }

        public async Task<string> BDAccionString(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = new SqlConnection(conexion))
            {
                try
                {
                    string valorReturn = string.Empty;
                    await con.OpenAsync();
                    try
                    {
                        valorReturn = con.ExecuteScalar<string>(NomStored, new DynamicParameters(param),null, commandType: CommandType.StoredProcedure);
                    }
                    catch (Exception)
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        throw;
                    }
                    finally
                    {
                        if (con.State == ConnectionState.Open)
                            con.Close();
                    }
                    return valorReturn;
                }
                catch (Exception)   // si la coneccion falla
                {
                    con.Close();
                    throw;
                }
            }
        }

        public async Task<T> BDBuscarReg<T>(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();
                    //-------------------------------------------------
                    return await con.QueryFirstAsync<T>(NomStored, new DynamicParameters(param), commandType: commandType);
                }
                catch (Exception ex)
                {
                    con.Close();
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }
        }

        public async Task<List<T>> BDLista<T>(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {
            List<T> lLista = new();

            using (var con = new SqlConnection(conexion))
            {
                try
                {
                    IEnumerable<T> enumerable = await con.QueryAsync<T>(NomStored, new DynamicParameters(param), commandType: commandType);
                    lLista = (List<T>)enumerable;
                }
                catch (Exception ex)
                {
                    lLista = null;
                    con.Close();
                    
                    //throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return lLista;
        }

        public List<T> LlenarCombo<T>(string conexion, string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {
            List<T> lLista = new();

            using (var con = new SqlConnection(conexion))
            {
                try
                {
                    lLista = con.Query<T>(NomStored, new DynamicParameters(param), commandType: commandType).ToList();
                }
                catch (Exception ex)
                {
                    con.Close();
                    //throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return lLista;
        }

        void IDisposable.Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    //public async Task<string> RegresaValor(string conexion, string NomStored, DynamicParameters paraml, CommandType commandType = CommandType.StoredProcedure)
    //{
    //    using (var con = new SqlConnection(conexion))
    //    {
    //        try
    //        {
    //            con.Open();
    //            //-------------------------------------------------
    //            await con.ExecuteScalarAsync(NomStored, param: paraml, commandType: commandType);
    //            string valor = paraml.Get<string>("@RFC_OUT");

    //            return valor;
    //        }
    //        catch (Exception ex)
    //        {
    //            con.Close();
    //            throw ex;
    //        }
    //        finally
    //        {
    //            con.Close();
    //        }
    //    }
    //}
}
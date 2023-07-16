using AccesoDatos.Data;
using System.Data;

namespace Negocio.Interfaces
{
    public class General<T> : IGeneral<T> where T : class
    {
        private readonly DapperContext _configuration;
        private readonly IDapperService _dapperService;

        public General(IDapperService dapperService, DapperContext configuration)
        {
            this._dapperService = dapperService;
            _configuration = configuration;
        }

        public async Task<int> InsertUpdateModelo(string NomStored, Object Modelo, CommandType commandType = CommandType.StoredProcedure)
        {
            int result = 0;
            result = await (await Task.FromResult(_dapperService.InsertUpdateModelo(_configuration.Value, NomStored, Modelo, commandType))).ConfigureAwait(false);
            return result;

        }


        #region Cualquier Accion Podemos realizar (Insertar,Actualizar,Borrar)
        /// <summary>
        /// Cualquier Accion Podemos realizar (Insertar,Actualizar,Borrar)
        /// Regresa un entero
        /// </summary>
        /// <param name="NomStored"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<int> BDAccion(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {
            int result = 0;
            result = await (await Task.FromResult(_dapperService.BDAccion(_configuration.Value, NomStored, param, commandType))).ConfigureAwait(false);
            return result;

        }
        #endregion

        #region Cualquier Accion Select (regresa un string)
        /// <summary>
        /// Cualquier Accion Podemos realizar 
        /// para Regresar un valor string
        /// </summary>
        /// <param name="NomStored"></param>
        /// <param name="param"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public async Task<string> BDAccionString(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {
            string result =string.Empty;
            result = await (await Task.FromResult(_dapperService.BDAccionString(_configuration.Value, NomStored, param, commandType))).ConfigureAwait(false);
            return result;

        }
        #endregion

        #region Buscar Registros
        public async Task<T> BDBuscarReg(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {

            return await (await Task.FromResult(_dapperService.BDBuscarReg<T>(_configuration.Value, NomStored, param, commandType))).ConfigureAwait(false);

        }
        #endregion

        #region Listado
        public async Task<List<T>> ListAll(string NomStored, IDictionary<string, object> param, CommandType commandType = CommandType.StoredProcedure)
        {

            return await (await Task.FromResult(_dapperService.BDLista<T>(_configuration.Value, NomStored, param, commandType))).ConfigureAwait(false);

        }
        #endregion

        public List<T> LlenarCombo(string NomStored, string opc, string valor, CommandType commandType = CommandType.StoredProcedure)
        {

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            dictionary.Add("@Opc", opc);
            dictionary.Add("@Filtro", valor);

            return _dapperService.LlenarCombo<T>(_configuration.Value, NomStored, dictionary);

        }

        //#region Crea los parametros Dinamicos
        //private DynamicParameters CrearParametros(string[] param, string[] valores)
        //{
        //    string sparam = "";
        //    string svalor = "";
        //    var paramreturn = new DynamicParameters();

        //    //Dictionary<string, object> dictionary = new Dictionary<string, object>();

        //    //------------------Crea los parametros para el stored
        //    for (var i = 0; i < param.Length; i++)
        //    {
        //        sparam = param[i];
        //        svalor = valores[i];
        //        paramreturn.Add(sparam, svalor);
        //        //dictionary.Add(sparam, svalor);
        //    }
        //    return paramreturn;
        //}
        //#endregion

        //public async Task<string> RegresaValor(string NomStored, DynamicParameters param, CommandType commandType = CommandType.StoredProcedure)
        //{
        //    string regreso;
        //    using var con = new SqlConnection(_configuration.Value);
        //    try
        //    {
        //        return await Task.FromResult(_dapperService.BDLista<T>(_configuration.Value, NomStored, param, commandType));
        //    }
        //    catch (Exception ex)
        //    {
        //        con.Close();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //}

        public IDictionary<string, object> CreaDiccionario(string[] param, string[] valores)
        {
            var sparam = "";
            var svalor = "";
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            //------------------Crea los parametros para el stored
            for (var i = 0; i < param.Length; i++)
            {
                sparam = param[i];
                if (valores.Length <= i)
                {
                    svalor = ""; ;
                }
                else
                {
                    svalor = valores[i];
                }

                dictionary.Add(sparam, svalor);
            }
            return dictionary;
        }
    }

}
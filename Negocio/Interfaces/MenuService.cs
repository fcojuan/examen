using Dapper;
using Modelo.Dto;
using System.Data;
using System.Data.SqlClient;

namespace Negocio.Interfaces
{
    public class MenuService
    {
        private readonly DapperContext _Configuration;
        public MenuService(DapperContext connectionConfiguration)
        {
            _Configuration = connectionConfiguration;
        }

        public async Task<IEnumerable<MenuDto>> GetMenuData()
        {
            IEnumerable<MenuDto> menuInfos;

            using (var conn = new SqlConnection(_Configuration.Value))
            {
                string query = "Select * From MenuDinamico Order By ParentMenuid";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    menuInfos = await conn.QueryAsync<MenuDto>(query);
                }
                catch (Exception ex)
                {
                    //throw ex;
                    throw;
                }
                finally
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Close();
                }

            }
            return menuInfos;
        }
    }
}


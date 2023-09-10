using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using WaittingHomeWork.Models;

namespace WaittingHomeWork.Respository
{
    public class HomeRepo
    {
        private readonly DBList _dBList;

        public HomeRepo
            (
            IOptions<DBList> dbList
            )
        {
            _dBList = dbList.Value;
        }
        public async Task<List<(Guid, string)>> GetKidListAsync()
        {
            var sql = $@"
                        SELECT [ID],[Cname]
                          FROM [KidsWorld].[dbo].[KidMain]
                          Where 1=1
                          AND [Enabled] = 1
                          AND [Deleted] = 0
                        ";

            using var conn = new SqlConnection(_dBList.KidsWorld);

            try
            {
                var result = await conn.QueryAsync<(Guid, string)>(sql);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

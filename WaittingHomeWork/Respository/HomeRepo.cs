using Dapper;
using System.Data.SqlClient;
using WaittingHomeWork.Models;

namespace WaittingHomeWork.Respository
{
    public class HomeRepo
    {
        public async Task<List<KidMain>> GetKidListAsync()
        {
            var sql = $@"
                        SELECT *
                          FROM [KidsWorld].[dbo].[KidMain]
                          Where 1=1
                          AND [Enabled] = 1
                          AND [Deleted] = 0
                        ";

            using var conn = new SqlConnection("Data Source=192.168.0.143;Initial Catalog=KidsWorld;User ID=ducklorl815;Password=!QAZ@WSX;Integrated Security=false;Pooling=TRUE;Application Name=WaittingHomeWork");

            try
            {
                var result = await conn.QueryAsync<KidMain>(sql);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

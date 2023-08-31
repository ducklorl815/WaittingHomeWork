using Dapper;
using System.Data.SqlClient;

namespace WaittingHomeWork.Respository
{
    public class HomeRepo
    {
        public async Task<List<(Guid, string)>> GetKidListAsync()
        {
            var sql = $@"
                        SELECT [ID],[Cname]
                          FROM [KidsWorld].[dbo].[KidMain]
                          Where 1=1
                          AND [Enabled] = 1
                          AND [Deleted] = 0
                        ";

            using var conn = new SqlConnection("Data Source=192.168.100.2;Initial Catalog=KidsWorld;User ID=ducklorl815;Password=!QAZ@WSX;Integrated Security=false;Pooling=TRUE;Application Name=WaittingHomeWork");

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

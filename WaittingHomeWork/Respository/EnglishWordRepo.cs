using Dapper;
using System.Data.SqlClient;
using WaittingHomeWork.Models;

namespace WaittingHomeWork.Respository
{
    public partial class EnglishWordRepo
    {
        public EnglishWordRepo
            (

            )
        {

        }
        public async Task<List<EnglishWord>> GetListAsync()
        {
            var sqlparam = new DynamicParameters();

            var sql = $@"
                        SELECT * 
                        FROM [LiaoHome].[dbo].[EnglishWord]
                        Where 1=1 
                        AND Enabled = 1
                        AND Deleted = 0
                        ";

            using var conn = new SqlConnection("Data Source=mydb.cthggpmjoh6a.ap-southeast-2.rds.amazonaws.com;Initial Catalog=LiaoHome;User ID=ducklorl815;Password=Tw0092172;Integrated Security=false;Pooling=TRUE;Application Name=WaittingHomeWork");

            try
            {
                var result = await conn.QueryAsync<EnglishWord>(sql, sqlparam);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

using Dapper;
using System.Data.SqlClient;
using WaittingHomeWork.Models;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Respository
{
    public partial class EnglishWordRepo
    {
        public EnglishWordRepo
            (

            )
        {

        }
        public async Task<List<EnglishWordTableModel>> GetListAsync(Guid KidID)
        {
            var sqlparam = new DynamicParameters();
            sqlparam.Add("KidID", KidID);
            var sql = $@"
                        SELECT ew.ID,ew.CName,ew.Word,ew.Explain,wi.ID as WordIndexID,wi.Correct,wi.Review,km.ID as KidID
                        FROM [KidsWorld].[dbo].[EnglishWord] ew
						LEFT JOIN [KidsWorld].dbo.WordIndex wi ON wi.WordID = ew.ID
						LEFT JOIN [KidsWorld].dbo.KidMain km ON km.ID = wi.KidMainID
                        Where km.ID = 'B41597A1-3C2A-45A6-ABC9-087F17A641F0'
                        AND ew.Enabled = 1
                        AND ew.Deleted = 0
                        ";

            using var conn = new SqlConnection("Data Source=192.168.0.143;Initial Catalog=KidsWorld;User ID=ducklorl815;Password=!QAZ@WSX;Integrated Security=false;Pooling=TRUE;Application Name=WaittingHomeWork");

            try
            {
                var result = await conn.QueryAsync<EnglishWordTableModel>(sql, sqlparam);
                return result.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public async Task<bool> GetInsertAsync(string CName, string Word, string Explain)
        {
            var sqlparam = new DynamicParameters();
            sqlparam.Add("CName", CName);
            sqlparam.Add("Word", Word);
            sqlparam.Add("Explain", Explain);

            var sql = $@"
                        INSERT INTO [dbo].[EnglishWord]
                                   ([ID]
                                   ,[CName]
                                   ,[Word]
                                   ,[Explain]
                                   ,[CreateDate]
                                   ,[ModifyDate]
                                   ,[Enabled]
                                   ,[Deleted])
                             VALUES
                                   (NEWID()
                                   ,@CName
                                   ,@Word
                                   ,@Explain
                                   ,GETDATE()
                                   ,GETDATE()
                                   ,1
                                   ,0)
                        ";

            using var conn = new SqlConnection("Data Source=192.168.0.143;Initial Catalog=KidsWorld;User ID=ducklorl815;Password=!QAZ@WSX;Integrated Security=false;Pooling=TRUE;Application Name=WaittingHomeWork");

            try
            {
                var result = await conn.ExecuteAsync(sql, sqlparam);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> GetUpdateWordAsync(EnglishWordViewModel_param param)
        {
            var sqlparam = new DynamicParameters();
            sqlparam.Add("ID", Guid.Parse(param.ID));
            sqlparam.Add("CName", param.CName);
            sqlparam.Add("Word", param.Word);
            sqlparam.Add("Explain", param.Explain);

            var sql = $@"
                        UPDATE [dbo].[EnglishWord]
                           SET [CName] = @CName
                              ,[Word] = @Word
                              ,[Explain] = @Explain
                              ,[ModifyDate] = GETDATE()
                         WHERE ID = @ID
                        ";

            using var conn = new SqlConnection("Data Source=192.168.0.143;Initial Catalog=KidsWorld;User ID=ducklorl815;Password=!QAZ@WSX;Integrated Security=false;Pooling=TRUE;Application Name=WaittingHomeWork");

            try
            {
                var result = await conn.ExecuteAsync(sql, sqlparam);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> GetUpdateWordIndexAsync(EnglishWordViewModel_param param)
        {
            var sqlparam = new DynamicParameters();
            sqlparam.Add("ID", Guid.Parse(param.WordIndexID));
            sqlparam.Add("Correct", param.Correct);
            sqlparam.Add("Review", param.Review);

            var sql = $@"
                        UPDATE [dbo].[WordIndex]
                           SET [Correct] = @Correct
                              ,[Review] = @Review
                              ,[ModifyDate] = GETDATE()
                         WHERE [ID] = @ID
                        ";

            using var conn = new SqlConnection("Data Source=192.168.0.143;Initial Catalog=KidsWorld;User ID=ducklorl815;Password=!QAZ@WSX;Integrated Security=false;Pooling=TRUE;Application Name=WaittingHomeWork");

            try
            {
                var result = await conn.ExecuteAsync(sql, sqlparam);
                return result > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using WaittingHomeWork.Models;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Respository
{
    public partial class EnglishWordRepo
    {
        private readonly DBList _dBList;
        public EnglishWordRepo
            (
                IOptions<DBList> dbList
            )
        {
            _dBList = dbList.Value;
        }
        public async Task<List<EnglishWordTableModel>> GetListAsync(Guid KidID)
        {
            var sqlparam = new DynamicParameters();
            var sql = string.Empty;

            if (KidID != Guid.Empty)
            {
                sqlparam.Add("KidID", KidID);

                sql = KidIDIsNotNullSQL();
            }
            else
            {
                sql = KidIDIsNullSQL();
            }


            using var conn = new SqlConnection(_dBList.KidsWorld);

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

        private string KidIDIsNullSQL()
        {

            var sql = @$"
                        SELECT [ID]
                              ,[Seq]
                              ,[CName]
                              ,[Word]
                              ,[Explain]
                              ,[CreateDate]
                              ,[ModifyDate]
                              ,[Enabled]
                              ,[Deleted]
                          FROM [KidsWorld].[dbo].[EnglishWord]
                        ";
            return sql;
        }
        private string KidIDIsNotNullSQL()
        {

            var sql = @$"
                        SELECT ew.ID,ew.CName,ew.Word,ew.Explain,wi.ID as WordIndexID,wi.Correct,wi.Review,km.ID as KidID
                        FROM [KidsWorld].[dbo].[EnglishWord] ew
						LEFT JOIN [KidsWorld].dbo.WordIndex wi ON wi.WordID = ew.ID
						LEFT JOIN [KidsWorld].dbo.KidMain km ON km.ID = wi.KidMainID
                        Where km.ID =@KidID
                        AND ew.Enabled = 1
                        AND ew.Deleted = 0
                        Order by wi.Correct ,wi.Review
                        ";
            return sql;
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

            using var conn = new SqlConnection(_dBList.KidsWorld);

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

            using var conn = new SqlConnection(_dBList.KidsWorld);

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

            using var conn = new SqlConnection(_dBList.KidsWorld);

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

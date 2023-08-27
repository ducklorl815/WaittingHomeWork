using System.Transactions;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Service
{
    public partial class EnglishWordService
    {
        public async Task<bool> GetInsertAsync(EnglishWordViewModel_param param)
        {
            var chkInsert = await _englishWordRepo.GetInsertAsync(param.CName, param.Word, param.Explain);

            return chkInsert;
        }

        public async Task<bool> GetUpdateAsync(EnglishWordViewModel_param param)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var chkUpdateWord = await _englishWordRepo.GetUpdateWordAsync(param);
                var chkUpdateWordIndex = await _englishWordRepo.GetUpdateWordIndexAsync(param);

                if (chkUpdateWord && chkUpdateWordIndex)
                {
                    scope.Complete();
                    return true;
                }

                return false;
            }
        }
    }
}

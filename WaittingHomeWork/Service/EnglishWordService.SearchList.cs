using WaittingHomeWork.Models;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Service
{
    public partial class EnglishWordService
    {
        public async Task<EnglishWordViewModel_result> GetListAsync(EnglishWordViewModel_param param)
        {
            var result = new EnglishWordViewModel_result()
            {
                WordList = new List<EnglishWord>(),
            };

            var Listdata = await _englishWordRepo.GetListAsync();
            result.WordList = Listdata;

            return result;
        }
    }
}

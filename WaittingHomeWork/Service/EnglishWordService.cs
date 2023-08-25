using WaittingHomeWork.Respository;

namespace WaittingHomeWork.Service
{
    public partial class EnglishWordService
    {
        private readonly EnglishWordRepo _englishWordRepo;
        public EnglishWordService
            (
                EnglishWordRepo englishWordRepo
            )
        {
            _englishWordRepo = englishWordRepo;
        }
    }
}

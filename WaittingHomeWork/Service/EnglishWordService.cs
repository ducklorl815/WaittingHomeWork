using WaittingHomeWork.Respository;

namespace WaittingHomeWork.Service
{
    public partial class EnglishWordService
    {
        private readonly EnglishWordRepo _englishWordRepo;
        private readonly HomeRepo _homeRepo;
        public EnglishWordService
            (
                EnglishWordRepo englishWordRepo
                , HomeRepo homeRepo

            )
        {
            _englishWordRepo = englishWordRepo;
            _homeRepo = homeRepo;
        }
    }
}

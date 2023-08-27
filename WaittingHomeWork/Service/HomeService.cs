using WaittingHomeWork.Models;
using WaittingHomeWork.Respository;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Service
{
    public class HomeService
    {
        private readonly HomeRepo _homeRepo;
        public HomeService
            (
                HomeRepo homeRepo
            )
        {
            _homeRepo = homeRepo;
        }
        public async Task<KidMainViewModel_result> GetKidListAsync()
        {
            var result = new KidMainViewModel_result()
            {
                KidList = new List<KidMain>()
            };

            var KidList = await _homeRepo.GetKidListAsync();
            result.KidList = KidList;
            return result;
        }
    }
}

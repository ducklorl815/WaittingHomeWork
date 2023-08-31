using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<EnglishWordViewModel_result> GetKidListAsync()
        {
            var result = new EnglishWordViewModel_result()
            {
                WordTableList = new List<EnglishWordTableModel>(),
                KidList = new List<SelectListItem>(),
            };

            var KidList = await _homeRepo.GetKidListAsync();
            result.KidList = KidList.Select(x => new SelectListItem { Text = x.Item2, Value = x.Item1.ToString() }).ToList();
            return result;
        }
    }
}

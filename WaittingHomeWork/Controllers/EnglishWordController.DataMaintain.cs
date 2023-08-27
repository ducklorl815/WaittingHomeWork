using Microsoft.AspNetCore.Mvc;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Controllers
{
    public partial class EnglishWordController : Controller
    {
        public async Task<IActionResult> Insert(EnglishWordViewModel_param param)
        {
            var IsSuccess = await _englishWordService.GetInsertAsync(param);

            return Json(IsSuccess);
        }

        public async Task<IActionResult> Update(EnglishWordViewModel_param param)
        {
            var IsSuccess = await _englishWordService.GetUpdateAsync(param);

            return Json(IsSuccess);
        }
    }
}

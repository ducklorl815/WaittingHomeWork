using Microsoft.AspNetCore.Mvc;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Controllers
{
    public partial class EnglishWordController : Controller
    {
        public async Task<IActionResult> SearchList(EnglishWordViewModel_param param)
        {
            var result = await _englishWordService.GetListAsync(param);

            return View("Index", result);
        }
    }
}

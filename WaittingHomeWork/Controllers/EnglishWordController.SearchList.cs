using Microsoft.AspNetCore.Mvc;

namespace WaittingHomeWork.Controllers
{
    public partial class EnglishWordController : Controller
    {
        public async Task<IActionResult> SearchList(Guid KidID)
        {
            var result = await _englishWordService.GetListAsync(KidID);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return PartialView("_SearchList", result);
            }
            else
            {
                return View("Index", result);
            }
        }
    }
}

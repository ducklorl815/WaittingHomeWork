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
                if (KidID != Guid.Empty)
                {
                    return PartialView("_IDNotNullSearchList", result);
                }
                else
                {
                    return PartialView("_IDNullSearchList", result);
                }
            }
            else
            {
                return View("Index", result);
            }
        }
    }
}

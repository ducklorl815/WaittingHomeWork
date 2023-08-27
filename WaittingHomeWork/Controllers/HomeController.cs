using Microsoft.AspNetCore.Mvc;
using WaittingHomeWork.Service;

namespace WaittingHomeWork.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HomeService _homeService;
        public HomeController(
            ILogger<HomeController> logger,
             HomeService homeService
            )
        {
            _logger = logger;
            _homeService = homeService;
        }

        public async Task<IActionResult> Index()
        {
            var KidList = await _homeService.GetKidListAsync();

            return View(KidList);
        }

    }
}
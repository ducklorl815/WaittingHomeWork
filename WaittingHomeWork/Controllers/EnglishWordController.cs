using Microsoft.AspNetCore.Mvc;
using WaittingHomeWork.Service;

namespace WaittingHomeWork.Controllers
{
    public partial class EnglishWordController : Controller
    {
        private readonly EnglishWordService _englishWordService;

        public EnglishWordController
            (
              EnglishWordService englishWordService
            )
        {
            _englishWordService = englishWordService;
        }

    }
}

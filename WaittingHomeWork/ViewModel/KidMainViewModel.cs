using WaittingHomeWork.Models;

namespace WaittingHomeWork.ViewModel
{
    public class KidMainViewModel_result : KidMainViewModel_param
    {
        public string Msg { get; set; }
        public bool IsSuccess { get; set; }
    }
    public class KidMainViewModel_param
    {
        public List<KidMain> KidList { get; set; }

    }
}

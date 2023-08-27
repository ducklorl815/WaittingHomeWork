using Microsoft.AspNetCore.Mvc.Rendering;
using WaittingHomeWork.Models;

namespace WaittingHomeWork.ViewModel
{
    public class EnglishWordViewModel_result : EnglishWordViewModel_param
    {
        public string Msg { get; set; }
        public bool IsSuccess { get; set; }

        /// <summary>小孩清單 /// </summary>
        public List<SelectListItem> KidList { get; set; }

        /// <summary>單字清單 /// </summary>
        public List<EnglishWordTableModel> WordTableList { get; set; }

        /// <summary> 小孩名稱/// </summary>
        public Guid KidID { get; set; }

    }
    public class EnglishWordViewModel_param
    {
        public string CName { get; set; } = string.Empty;
        public string Word { get; set; } = string.Empty;
        public string Explain { get; set; } = string.Empty;
        public bool? Correct { get; set; }
        public int? Review { get; set; }

        /// <summary> 單字/// </summary>
        public string ID { get; set; }
        /// <summary> 小孩名稱/// </summary>
        public string KidID { get; set; }
        /// <summary> 單字與小孩的關係/// </summary>
        public string WordIndexID { get; set; }

    }
    public class EnglishWordTableViewModel
    {
        public string CName { get; set; } = string.Empty;
        public string Word { get; set; } = string.Empty;
        public string Explain { get; set; } = string.Empty;
        public bool? Correct { get; set; }
        public int? Review { get; set; }

        /// <summary> 單字/// </summary>
        public string ID { get; set; }
        /// <summary> 小孩名稱/// </summary>
        public string KidID { get; set; }
        /// <summary> 單字與小孩的關係/// </summary>
        public string WordIndexID { get; set; }

        public EnglishWordTableViewModel()
        {
            Correct = false;
            Review = 0;
        }
    }
}


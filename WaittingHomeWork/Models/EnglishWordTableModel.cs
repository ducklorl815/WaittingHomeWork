namespace WaittingHomeWork.Models
{
    public class EnglishWordTableModel : BaseModel
    {
        public string CName { get; set; } = string.Empty;
        public string Word { get; set; } = string.Empty;
        public string Explain { get; set; } = string.Empty;
        public bool? Correct { get; set; }
        public int? Review { get; set; }
        /// <summary> 小孩名稱/// </summary>
        public Guid KidID { get; set; }
        /// <summary> 單字與小孩的關係/// </summary>
        public Guid WordIndexID { get; set; }

        public EnglishWordTableModel()
        {
            Correct = false;
            Review = 0;
        }
    }
}

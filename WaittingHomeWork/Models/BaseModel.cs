namespace WaittingHomeWork.Models
{
    public class BaseModel
    {
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
    }
}

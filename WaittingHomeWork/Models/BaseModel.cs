namespace WaittingHomeWork.Models
{
    public class BaseModel
    {
        public Guid ID { get; set; }
        public long Seq { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
    }
}

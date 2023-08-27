namespace WaittingHomeWork.Models
{
    public class WordIndex : BaseModel
    {
        public Guid WordID { get; set; }
        public Guid KidMainID { get; set; }
        public bool Correct { get; set; }
        public int Review { get; set; }
    }
}

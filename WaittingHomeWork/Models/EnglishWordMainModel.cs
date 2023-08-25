namespace WaittingHomeWork.Models
{
    public class EnglishWord : BaseModel
    {
        public Guid ID { get; set; }
        public long Seq { get; set; }
        public string CWord { get; set; }
        public string Word { get; set; }
        public string Explain { get; set; }
        public bool Correct { get; set; }
        public int Review { get; set; }

    }



}

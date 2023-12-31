﻿namespace WaittingHomeWork.Models
{
    public class EnglishWord : BaseModel
    {
        public string CName { get; set; } = string.Empty;
        public string Word { get; set; } = string.Empty;
        public string Explain { get; set; } = string.Empty;
        public Guid IndexID { get; set; }
        public bool? Correct { get; set; }
        public int? Review { get; set; }
        public Guid KidID { get; set; }

        public EnglishWord()
        {
            Correct = false;
            Review = 0;
        }
    }



}

﻿using Microsoft.AspNetCore.Mvc.Rendering;
using WaittingHomeWork.Models;
using WaittingHomeWork.ViewModel;

namespace WaittingHomeWork.Service
{
    public partial class EnglishWordService
    {
        public async Task<EnglishWordViewModel_result> GetListAsync(Guid KidID)
        {
            var result = new EnglishWordViewModel_result()
            {
                WordTableList = new List<EnglishWordTableModel>(),
                KidList = new List<SelectListItem>(),
            };

            var Listdata = await _englishWordRepo.GetListAsync(KidID);
            result.WordTableList = Listdata;
            result.KidID = KidID;

            return result;
        }
    }
}

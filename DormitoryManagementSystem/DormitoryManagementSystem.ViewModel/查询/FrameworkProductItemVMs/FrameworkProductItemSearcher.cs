using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.查询.FrameworkProductItemVMs
{
    public partial class FrameworkProductItemSearcher : BaseSearcher
    {
        [Display(Name = "货号名称")]
        public String FName { get; set; }
        [Display(Name = "货号编码")]
        public String FCode { get; set; }

        protected override void InitVM()
        {
        }

    }
}

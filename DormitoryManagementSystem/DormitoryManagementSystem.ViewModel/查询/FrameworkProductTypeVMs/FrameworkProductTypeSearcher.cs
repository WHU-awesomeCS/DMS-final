using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.查询.FrameworkProductTypeVMs
{
    public partial class FrameworkProductTypeSearcher : BaseSearcher
    {
        [Display(Name = "型号名称")]
        public String FName { get; set; }
        [Display(Name = "型号代码")]
        public String FCode { get; set; }

        protected override void InitVM()
        {
        }

    }
}

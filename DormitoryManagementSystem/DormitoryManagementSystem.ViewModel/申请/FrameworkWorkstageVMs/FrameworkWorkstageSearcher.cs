using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.申请.FrameworkWorkstageVMs
{
    public partial class FrameworkWorkstageSearcher : BaseSearcher
    {
        [Display(Name = "工序代码")]
        public String FCode { get; set; }
        [Display(Name = "工序名称")]
        public String FName { get; set; }
        [Display(Name = "工序类型")]
        public WorkstageType? workstageType { get; set; }

        protected override void InitVM()
        {
        }

    }
}

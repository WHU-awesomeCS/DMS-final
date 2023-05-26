using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.申请.FrameworkWorkLineVMs
{
    public partial class FrameworkWorkLineSearcher : BaseSearcher
    {
        [Display(Name = "工艺代码")]
        public String FCode { get; set; }
        [Display(Name = "工艺名称")]
        public String FName { get; set; }

        protected override void InitVM()
        {
        }

    }
}

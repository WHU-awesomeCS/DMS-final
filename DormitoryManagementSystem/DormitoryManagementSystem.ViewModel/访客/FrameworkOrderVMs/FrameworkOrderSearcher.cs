using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.访客.FrameworkOrderVMs
{
    public partial class FrameworkOrderSearcher : BaseSearcher
    {
        [Display(Name = "访客ID")]
        public String FProductionCode { get; set; }
        [Display(Name = "访客姓名")]
        public String FProductItemId { get; set; }
        [Display(Name = "访客状态")]
        public FOrderStatus? FOrderStatus { get; set; }
        [Display(Name = "来访时间")]
        public DateRange FPlanTime { get; set; }
        [Display(Name = "离开时间")]
        public DateRange FFinishTime { get; set; }

        protected override void InitVM()
        {
        }

    }
}

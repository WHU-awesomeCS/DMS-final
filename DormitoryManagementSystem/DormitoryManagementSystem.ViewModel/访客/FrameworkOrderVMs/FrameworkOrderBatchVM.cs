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
    public partial class FrameworkOrderBatchVM : BaseBatchVM<FrameworkOrder, FrameworkOrder_BatchEdit>
    {
        public FrameworkOrderBatchVM()
        {
            ListVM = new FrameworkOrderListVM();
            LinkedVM = new FrameworkOrder_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkOrder_BatchEdit : BaseVM
    {
        [Display(Name = "访客姓名")]
        public String FProductionCode { get; set; }
        [Display(Name = "访客身份证号")]
        public String FProductItemId { get; set; }
        [Display(Name = "访客状态")]
        public FOrderStatus? FOrderStatus { get; set; }
        [Display(Name = "当前预约数量")]
        public Int32? FPlanNumber { get; set; }
        [Display(Name = "访客进入时间")]
        public DateTime? FPlanTime { get; set; }
        [Display(Name = "访客离开时间")]
        public DateTime? FFinishTime { get; set; }
        [Display(Name = "访客电话号码")]
        public Int32? FOkNumber { get; set; }
        [Display(Name = "预约但暂未来访访客数量")]
        public Int32? FNgNumber { get; set; }
        [Display(Name = "正在来访访客数量")]
        public Int32? FWorkingNumber { get; set; }
        [Display(Name = "已离开宿舍的访客数量")]
        public Int32? FScrapNumber { get; set; }

        protected override void InitVM()
        {
        }

    }

}

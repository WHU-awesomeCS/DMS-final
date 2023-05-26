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
    public partial class FrameworkOrderTemplateVM : BaseTemplateVM
    {
        [Display(Name = "访客姓名")]
        public ExcelPropety FProductionCode_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FProductionCode);
        [Display(Name = "访客身份证号")]
        public ExcelPropety FProductItemId_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FProductItemId);
        [Display(Name = "访客状态")]
        public ExcelPropety FOrderStatus_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FOrderStatus);
        [Display(Name = "当前预约数量")]
        public ExcelPropety FPlanNumber_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FPlanNumber);
        [Display(Name = "访客进入时间")]
        public ExcelPropety FPlanTime_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FPlanTime);
        [Display(Name = "访客离开时间")]
        public ExcelPropety FFinishTime_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FFinishTime);
        [Display(Name = "访客电话号码")]
        public ExcelPropety FOkNumber_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FOkNumber);
        [Display(Name = "预约但暂未来访访客数量")]
        public ExcelPropety FNgNumber_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FNgNumber);
        [Display(Name = "正在来访访客数量")]
        public ExcelPropety FWorkingNumber_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FWorkingNumber);
        [Display(Name = "已离开宿舍的访客数量")]
        public ExcelPropety FScrapNumber_Excel = ExcelPropety.CreateProperty<FrameworkOrder>(x => x.FScrapNumber);

	    protected override void InitVM()
        {
        }

    }

    public class FrameworkOrderImportVM : BaseImportVM<FrameworkOrderTemplateVM, FrameworkOrder>
    {

    }

}

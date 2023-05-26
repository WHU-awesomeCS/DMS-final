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
    public partial class FrameworkProductTypeBatchVM : BaseBatchVM<FrameworkProductType, FrameworkProductType_BatchEdit>
    {
        public FrameworkProductTypeBatchVM()
        {
            ListVM = new FrameworkProductTypeListVM();
            LinkedVM = new FrameworkProductType_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkProductType_BatchEdit : BaseVM
    {
        [Display(Name = "型号名称")]
     //   [Display(Name = "宿舍号")]
        public String FName { get; set; }
    //  [Display(Name = "总床位数")]
        [Display(Name = "型号代码")]
        public String FCode { get; set; }
        [Display(Name = "备注")]
    //  [Display(Name = "可用床位数")]
        public String FMark { get; set; }

        protected override void InitVM()
        {
        }

    }
}

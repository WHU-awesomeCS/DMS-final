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
    public partial class FrameworkWorkLineBatchVM : BaseBatchVM<FrameworkWorkLine, FrameworkWorkLine_BatchEdit>
    {
        public FrameworkWorkLineBatchVM()
        {
            ListVM = new FrameworkWorkLineListVM();
            LinkedVM = new FrameworkWorkLine_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkWorkLine_BatchEdit : BaseVM
    {
        [Display(Name = "工艺代码")]
        public String FCode { get; set; }
        [Display(Name = "工艺名称")]
        public String FName { get; set; }
        [Display(Name = "备注")]
        public String FMark { get; set; }

        protected override void InitVM()
        {
        }

    }

}

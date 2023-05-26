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
    public partial class FrameworkWorkstageBatchVM : BaseBatchVM<FrameworkWorkstage, FrameworkWorkstage_BatchEdit>
    {
        public FrameworkWorkstageBatchVM()
        {
            ListVM = new FrameworkWorkstageListVM();
            LinkedVM = new FrameworkWorkstage_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class FrameworkWorkstage_BatchEdit : BaseVM
    {
        [Display(Name = "工序代码")]
        public String FCode { get; set; }
        [Display(Name = "工序名称")]
        public String FName { get; set; }
        [Display(Name = "备注")]
        public String FMark { get; set; }
        [Display(Name = "工序类型")]
        public WorkstageType? workstageType { get; set; }

        protected override void InitVM()
        {
        }

    }

}

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
    public partial class FrameworkWorkstageTemplateVM : BaseTemplateVM
    {
        [Display(Name = "工序代码")]
        public ExcelPropety FCode_Excel = ExcelPropety.CreateProperty<FrameworkWorkstage>(x => x.FCode);
        [Display(Name = "工序名称")]
        public ExcelPropety FName_Excel = ExcelPropety.CreateProperty<FrameworkWorkstage>(x => x.FName);
        [Display(Name = "备注")]
        public ExcelPropety FMark_Excel = ExcelPropety.CreateProperty<FrameworkWorkstage>(x => x.FMark);
        [Display(Name = "工序类型")]
        public ExcelPropety workstageType_Excel = ExcelPropety.CreateProperty<FrameworkWorkstage>(x => x.workstageType);

	    protected override void InitVM()
        {
        }

    }

    public class FrameworkWorkstageImportVM : BaseImportVM<FrameworkWorkstageTemplateVM, FrameworkWorkstage>
    {

    }

}

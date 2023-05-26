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
    public partial class FrameworkWorkLineTemplateVM : BaseTemplateVM
    {
        [Display(Name = "工艺代码")]
        public ExcelPropety FCode_Excel = ExcelPropety.CreateProperty<FrameworkWorkLine>(x => x.FCode);
        [Display(Name = "工艺名称")]
        public ExcelPropety FName_Excel = ExcelPropety.CreateProperty<FrameworkWorkLine>(x => x.FName);
        [Display(Name = "备注")]
        public ExcelPropety FMark_Excel = ExcelPropety.CreateProperty<FrameworkWorkLine>(x => x.FMark);

	    protected override void InitVM()
        {
        }

    }

    public class FrameworkWorkLineImportVM : BaseImportVM<FrameworkWorkLineTemplateVM, FrameworkWorkLine>
    {

    }

}

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
    public partial class FrameworkProductTypeTemplateVM : BaseTemplateVM
    {
        [Display(Name = "型号名称")]
        public ExcelPropety FName_Excel = ExcelPropety.CreateProperty<FrameworkProductType>(x => x.FName);
        [Display(Name = "型号代码")]
        public ExcelPropety FCode_Excel = ExcelPropety.CreateProperty<FrameworkProductType>(x => x.FCode);
        [Display(Name = "备注")]
        public ExcelPropety FMark_Excel = ExcelPropety.CreateProperty<FrameworkProductType>(x => x.FMark);

	    protected override void InitVM()
        {
        }

    }

    public class FrameworkProductTypeImportVM : BaseImportVM<FrameworkProductTypeTemplateVM, FrameworkProductType>
    {

    }

}

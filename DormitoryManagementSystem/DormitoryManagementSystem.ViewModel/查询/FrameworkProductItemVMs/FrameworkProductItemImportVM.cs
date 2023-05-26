using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.查询.FrameworkProductItemVMs
{
    public partial class FrameworkProductItemTemplateVM : BaseTemplateVM
    {
        [Display(Name = "货号名称")]
        public ExcelPropety FName_Excel = ExcelPropety.CreateProperty<FrameworkProductItem>(x => x.FName);
        [Display(Name = "货号编码")]
        public ExcelPropety FCode_Excel = ExcelPropety.CreateProperty<FrameworkProductItem>(x => x.FCode);
        [Display(Name = "宿舍信息查询")]
        public ExcelPropety FProductTypeId_Excel = ExcelPropety.CreateProperty<FrameworkProductItem>(x => x.FProductTypeId);
        [Display(Name = "其他申请")]
        public ExcelPropety FWorkLineId_Excel = ExcelPropety.CreateProperty<FrameworkProductItem>(x => x.FWorkLineId);

	    protected override void InitVM()
        {
        }

    }

    public class FrameworkProductItemImportVM : BaseImportVM<FrameworkProductItemTemplateVM, FrameworkProductItem>
    {

    }

}

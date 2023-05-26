using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.查询.FrameworkProductTypeVMs
{
    public partial class FrameworkProductTypeListVM : BasePagedListVM<FrameworkProductType_View, FrameworkProductTypeSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkProductType_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkProductType_View>>{
                this.MakeGridHeader(x => x.FName),
                this.MakeGridHeader(x => x.FCode),
                this.MakeGridHeader(x => x.FMark),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkProductType_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkProductType>()
                .CheckContain(Searcher.FName, x=>x.FName)
                .CheckContain(Searcher.FCode, x=>x.FCode)
                .Select(x => new FrameworkProductType_View
                {
				    ID = x.ID,
                    FName = x.FName,
                    FCode = x.FCode,
                    FMark = x.FMark,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class FrameworkProductType_View : FrameworkProductType{

    }
}

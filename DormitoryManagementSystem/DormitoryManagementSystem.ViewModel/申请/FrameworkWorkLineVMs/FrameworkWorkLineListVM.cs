using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.申请.FrameworkWorkLineVMs
{
    public partial class FrameworkWorkLineListVM : BasePagedListVM<FrameworkWorkLine_View, FrameworkWorkLineSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkWorkLine_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkWorkLine_View>>{
                this.MakeGridHeader(x => x.FCode),
                this.MakeGridHeader(x => x.FName),
                this.MakeGridHeader(x => x.FMark),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkWorkLine_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkWorkLine>()
                .CheckContain(Searcher.FCode, x=>x.FCode)
                .CheckContain(Searcher.FName, x=>x.FName)
                .Select(x => new FrameworkWorkLine_View
                {
				    ID = x.ID,
                    FCode = x.FCode,
                    FName = x.FName,
                    FMark = x.FMark,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class FrameworkWorkLine_View : FrameworkWorkLine{

    }
}

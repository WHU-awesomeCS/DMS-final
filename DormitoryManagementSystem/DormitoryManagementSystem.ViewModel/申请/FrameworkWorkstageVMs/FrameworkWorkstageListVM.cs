using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.申请.FrameworkWorkstageVMs
{
    public partial class FrameworkWorkstageListVM : BasePagedListVM<FrameworkWorkstage_View, FrameworkWorkstageSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkWorkstage_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkWorkstage_View>>{
                this.MakeGridHeader(x => x.FCode),
                this.MakeGridHeader(x => x.FName),
                this.MakeGridHeader(x => x.FMark),
                this.MakeGridHeader(x => x.workstageType),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkWorkstage_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkWorkstage>()
                .CheckContain(Searcher.FCode, x=>x.FCode)
                .CheckContain(Searcher.FName, x=>x.FName)
                .CheckEqual(Searcher.workstageType, x=>x.workstageType)
                .Select(x => new FrameworkWorkstage_View
                {
				    ID = x.ID,
                    FCode = x.FCode,
                    FName = x.FName,
                    FMark = x.FMark,
                    workstageType = x.workstageType,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class FrameworkWorkstage_View : FrameworkWorkstage{

    }
}

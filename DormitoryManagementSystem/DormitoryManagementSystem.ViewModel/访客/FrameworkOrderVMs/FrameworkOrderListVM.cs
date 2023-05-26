using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.访客.FrameworkOrderVMs
{
    public partial class FrameworkOrderListVM : BasePagedListVM<FrameworkOrder_View, FrameworkOrderSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkOrder_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkOrder_View>>{
                this.MakeGridHeader(x => x.FProductionCode),
                this.MakeGridHeader(x => x.FProductItemId),
                this.MakeGridHeader(x => x.FOrderStatus),
                this.MakeGridHeader(x => x.FPlanNumber),
                this.MakeGridHeader(x => x.FPlanTime),
                this.MakeGridHeader(x => x.FFinishTime),
                this.MakeGridHeader(x => x.FOkNumber),
                this.MakeGridHeader(x => x.FNgNumber),
                this.MakeGridHeader(x => x.FWorkingNumber),
                this.MakeGridHeader(x => x.FScrapNumber),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkOrder_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkOrder>()
                .CheckContain(Searcher.FProductionCode, x=>x.FProductionCode)
                .CheckContain(Searcher.FProductItemId, x=>x.FProductItemId)
                .CheckEqual(Searcher.FOrderStatus, x=>x.FOrderStatus)
                .CheckBetween(Searcher.FPlanTime?.GetStartTime(), Searcher.FPlanTime?.GetEndTime(), x => x.FPlanTime, includeMax: false)
                .CheckBetween(Searcher.FFinishTime?.GetStartTime(), Searcher.FFinishTime?.GetEndTime(), x => x.FFinishTime, includeMax: false)
                .Select(x => new FrameworkOrder_View
                {
				    ID = x.ID,
                    FProductionCode = x.FProductionCode,
                    FProductItemId = x.FProductItemId,
                    FOrderStatus = x.FOrderStatus,
                    FPlanNumber = x.FPlanNumber,
                    FPlanTime = x.FPlanTime,
                    FFinishTime = x.FFinishTime,
                    FOkNumber = x.FOkNumber,
                    FNgNumber = x.FNgNumber,
                    FWorkingNumber = x.FWorkingNumber,
                    FScrapNumber = x.FScrapNumber,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class FrameworkOrder_View : FrameworkOrder{

    }
}

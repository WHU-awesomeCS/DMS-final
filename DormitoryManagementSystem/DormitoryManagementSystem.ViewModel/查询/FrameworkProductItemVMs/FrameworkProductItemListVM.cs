using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using DormitoryManagementSystem.Model;


namespace DormitoryManagementSystem.ViewModel.查询.FrameworkProductItemVMs
{
    public partial class FrameworkProductItemListVM : BasePagedListVM<FrameworkProductItem_View, FrameworkProductItemSearcher>
    {

        protected override IEnumerable<IGridColumn<FrameworkProductItem_View>> InitGridHeader()
        {
            return new List<GridColumn<FrameworkProductItem_View>>{
                this.MakeGridHeader(x => x.FName),
                this.MakeGridHeader(x => x.FCode),
                this.MakeGridHeader(x => x.FProductTypeId),
                this.MakeGridHeader(x => x.FWorkLineId),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<FrameworkProductItem_View> GetSearchQuery()
        {
            var query = DC.Set<FrameworkProductItem>()
                .CheckContain(Searcher.FName, x=>x.FName)
                .CheckContain(Searcher.FCode, x=>x.FCode)
                .Select(x => new FrameworkProductItem_View
                {
				    ID = x.ID,
                    FName = x.FName,
                    FCode = x.FCode,
                    FProductTypeId = x.FProductTypeId,
                    FWorkLineId = x.FWorkLineId,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class FrameworkProductItem_View : FrameworkProductItem{

    }
}

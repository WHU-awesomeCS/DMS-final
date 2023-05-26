using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace DormitoryManagementSystem.Model
{
    public enum FOrderStatus
    {
        预约状态 = 0,
        已来访状态 = 1,//已预约
        已离开状态 = 2,//已预约
        预约失效状态 = 3,//未来坊
        非合法来访 = 4,
    }


    public class FrameworkOrder : BasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public new char ID { get; set; }
        [Display(Name = "访客姓名")]
        [Required(ErrorMessage = "{0}是必填项")]
        
        public string FProductionCode { get; set; }
        [Display(Name = "访客身份证号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FProductItemId { get; set; }
        [Display(Name = "访客状态")]
        [Required(ErrorMessage = "{0}是必填项")]
        public FOrderStatus FOrderStatus { get; set; }
        [Display(Name = "当前预约访客数量")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int FPlanNumber { get; set; }
        [Display(Name = "访客进入时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime FPlanTime { get; set; }
        [Display(Name = "访客离开时间")]
        public DateTime FFinishTime { get; set; }
        [Display(Name = "访客电话号码")]
        public int FOkNumber { get; set; }
        [Display(Name = "预约但暂未来访访客数量")]
        public int FNgNumber { get; set; }
        [Display(Name = "正在来访的访客数量")]
        public int FWorkingNumber { get; set; }
        [Display(Name = "已离开宿舍的访客数量")]
        public int FScrapNumber { get; set; }


    }
}

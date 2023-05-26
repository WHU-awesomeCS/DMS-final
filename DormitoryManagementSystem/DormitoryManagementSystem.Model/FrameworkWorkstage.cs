using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace DormitoryManagementSystem.Model
{
    public  enum WorkstageType
    {
        无=0,
        绑定=1,
        解绑=2,
        绑定解绑=3,
    }
    [Table("FrameworkWorkstages")]
    public partial class FrameworkWorkstage:BasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public new int ID { get; set; }

        [Display(Name = "工序代码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FCode { get; set; }
        [Display(Name ="工序名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FName { get; set; }
        [Display(Name ="备注")]
        public string FMark { get; set; }
        [Display(Name ="工序类型")]
         [Required(ErrorMessage = "{0}是必填项")]
        public WorkstageType workstageType { get; set; }

    }
}

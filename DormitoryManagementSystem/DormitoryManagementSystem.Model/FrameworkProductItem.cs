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
 
    public class FrameworkProductItem:BasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public new int ID { get; set; }
        [Display(Name ="货号名称")]
       [Required(ErrorMessage = "{0}是必填项")]
        public string FName { get; set; }
        [Required(ErrorMessage = "{0}是必填项")]
        [Display(Name ="货号编码")]
        public string FCode { get; set; }
        [Required(ErrorMessage = "{0}是必填项")]
        [Display(Name ="宿舍信息查询")]
        public int FProductTypeId { get; set; }
        [Required(ErrorMessage = "{0}是必填项")]
        [Display(Name ="其他申请")]
        public  int FWorkLineId { get; set; }
    }

    
}

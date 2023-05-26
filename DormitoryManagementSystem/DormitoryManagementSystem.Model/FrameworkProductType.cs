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
    public class FrameworkProductType : BasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public new int ID { get; set; }
        [Display(Name ="型号名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FName { get; set; }
        [Display(Name = "型号代码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FCode { get; set; }
        [Display(Name = "备注")]
        public string FMark { get; set; }


    }
}

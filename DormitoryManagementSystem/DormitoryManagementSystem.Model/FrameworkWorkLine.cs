using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace DormitoryManagementSystem.Model
{
    public class FrameworkWorkLine : BasePoco
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public new int ID { get; set; }

        [Display(Name = "工艺代码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FCode { get; set; }
        [Display(Name = "工艺名称")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string FName { get; set; }
        [Display(Name = "备注")]
        public string FMark { get; set; }
      
    }
}

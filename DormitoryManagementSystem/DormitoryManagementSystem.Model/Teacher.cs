using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormitoryManagementSystem.Model
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "老师工号")]
        public string WorkId { get; set; }

        [Display(Name = "老师姓名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
        [Display(Name = "电话号码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string PhoneNumber { get; set; }
        [Display(Name = "所在院系")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int Department { get; set; }

        [Display(Name = "邮箱")]
   
        public string Email { get; set; }


        [Display(Name = "管理宿舍号")]
        public string DormitoryNumber { get; set; }

    }
}

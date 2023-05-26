using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.Model
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "职工工号")]

        public string WorkId { get; set; }


        [Display(Name = "职工姓名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
        [Display(Name = "职工部门")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Sector { get; set; }
        [Display(Name = "电话号码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string PhoneNumber { get; set; }

        [Display(Name = "邮箱")]
        public string Email { get; set; }

        [Display(Name = "管理宿舍号")]
        public string DormitoryNumber { get; set; }
    }
}


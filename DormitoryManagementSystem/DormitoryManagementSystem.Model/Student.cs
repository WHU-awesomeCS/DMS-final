using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormitoryManagementSystem.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "学生学号")]
        public string StudentId { get; set; }

        [Display(Name = "学生姓名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        [Display(Name = "学生所在院系")]
        public int Department { get; set; }

        [Display(Name = "性别")]
        [Required(ErrorMessage = "{0}是必填项")]
        public bool Gender { get; set; }
        [Display(Name = "年龄")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int Age { get; set; }
        [Display(Name = "电话号码")]
        public string PhoneNumber { get; set; }
        [Display(Name = "宿舍号")]
        public string DormitoryNumber { get; set; }

        [Display(Name = "房间号")]
        public string RoomNumber { get; set; }
        [Display(Name = "是否在宿舍")]
        [Required(ErrorMessage = "{0}是必填项")]
        public bool WhetherLeave { get; set; }

        [Display(Name = "离开时间")]
        public DateTime? LeaveDate { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.Model
{
    public class LeaveApplication
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "编号")]
        public string Id { get; set; }
        [Display(Name = "学生学号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string StudentId { get; set; }

        [Display(Name = "请假开始时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime StartTime { get; set; }
        [Display(Name = "请假结束时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime EndTime { get; set; }

        [Display(Name = "请假原因")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Reason { get; set; }

        [Display(Name = "请假状态")]
        public string ApplicationStatus { get; set; }

        [Display(Name = "处理审批老师")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Applicant { get; set; }

    }
}

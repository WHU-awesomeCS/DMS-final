using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.Model
{
    public class RepairRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "编号")]
        public string Id { get; set; }
        [Display(Name = "学生学号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string StudentId { get; set; }
        [Display(Name = "宿舍号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string DormitoryNumber { get; set; }
        [Display(Name = "房间号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string RoomNumber { get; set; }
        [Display(Name = "报修类型")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string RequestType { get; set; }
        [Display(Name = "描述")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string QuestionDescribe { get; set; }
        [Display(Name = "申请报修时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime RequestTime { get; set; }
        [Display(Name = "进度")]
        public string ProcessStatus { get; set; }

    }
}

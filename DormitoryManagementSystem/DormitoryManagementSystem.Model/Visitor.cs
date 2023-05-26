using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormitoryManagementSystem.Model
{
    public class Visitor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "访客编号")]
        public string Id { get; set; }
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }

        [Display(Name = "身份证号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string IDNumber { get; set; }
        [Display(Name = "电话号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string PhoneNumber { get; set; }

        [Display(Name = "访问时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime CheckInTime { get; set; }
        [Display(Name = "离开时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime CheckOutTime { get; set; }

        [Display(Name = "访问宿舍号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string DormitoryNumber { get; set; }

    }
}

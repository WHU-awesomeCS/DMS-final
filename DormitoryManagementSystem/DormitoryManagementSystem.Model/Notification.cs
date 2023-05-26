using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DormitoryManagementSystem.Model
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "编号")]
        public string Id { get; set; }

        [Display(Name = "标题")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Caption { get; set; }
        [Display(Name = "内容")]
        [Required(ErrorMessage = "{0}是必填项")]

        public string Content { get; set; }

        [Display(Name = "发布时间")]
        [Required(ErrorMessage = "{0}是必填项")]
        public DateTime PublishTime { get; set; }
        [Display(Name = "接收人")]
        public string Receiver { get; set; }
    }
}

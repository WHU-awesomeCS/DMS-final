using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormitoryManagementSystem.Model
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "账号")]
        public string Id { get; set; }
        [Display(Name = "用户名")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string UserName { get; set; }
        [Display(Name = "密码")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Password { get; set; }
        [Display(Name = "用户角色")]
        public string UserRole { get; set; }
    }
}

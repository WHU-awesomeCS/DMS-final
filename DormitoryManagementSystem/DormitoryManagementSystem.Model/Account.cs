using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DormitoryManagementSystem.Model
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "�˺�")]
        public string Id { get; set; }
        [Display(Name = "�û���")]
        [Required(ErrorMessage = "{0}�Ǳ�����")]
        public string UserName { get; set; }
        [Display(Name = "����")]
        [Required(ErrorMessage = "{0}�Ǳ�����")]
        public string Password { get; set; }
        [Display(Name = "�û���ɫ")]
        public string UserRole { get; set; }
    }
}

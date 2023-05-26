using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WalkingTec.Mvvm.Core
{
    /// <summary>
    /// FrameworkUser
    /// </summary>
    [Table("FrameworkUsers")]
    public class FrameworkUser : FrameworkUserBase
    {
        [Display(Name = "管理.Email")]
        [RegularExpression("^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\\.[a-zA-Z0-9_-]+)+$", ErrorMessage = "Validate.{0}formaterror")]
        [StringLength(50, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Email { get; set; }

        [Display(Name = "管理.Gender")]
        public GenderEnum? Gender { get; set; }

        [Display(Name = "管理.CellPhone")]
        [RegularExpression("^[1][3-9]\\d{9}$", ErrorMessage = "Validate.{0}formaterror")]
        public string CellPhone { get; set; }

        [Display(Name = "管理.HomePhone")]
        [StringLength(30, ErrorMessage = "Validate.{0}stringmax{1}")]
        [RegularExpression("^[-0-9\\s]{8,30}$", ErrorMessage = "Validate.{0}formaterror")]
        public string HomePhone { get; set; }

        [Display(Name = "管理.Address")]
        [StringLength(200, ErrorMessage = "Validate.{0}stringmax{1}")]
        public string Address { get; set; }

        [Display(Name = "管理.ZipCode")]
        [RegularExpression("^[0-9]{6,6}$", ErrorMessage = "Validate.{0}formaterror")]
        public string ZipCode { get; set; }
    }
}

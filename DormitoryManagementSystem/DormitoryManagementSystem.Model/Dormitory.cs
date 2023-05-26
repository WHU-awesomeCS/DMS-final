using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.Model
{
    public class Dormitory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "宿舍号")]
        public string DormitoryNumber { get; set; }

        [Display(Name = "楼层数")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int FloorNumber { get; set; }

        [Display(Name = "可用床位")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int AvailableBed { get; set; }
        [Display(Name = "总床位")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int SumBed { get; set; }
    }
}

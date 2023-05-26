using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DormitoryManagementSystem.Model
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "房间号")]
        public string RoomNumber { get; set; }

        [Display(Name = "宿舍号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string DormitoryNumber { get; set; }
        [Display(Name = "总床位")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int SumBed { get; set; }
        [Display(Name = "可用床位")]
        [Required(ErrorMessage = "{0}是必填项")]
        public int AvailableBed { get; set; }

        [Display(Name = "设备状态")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string DeviceStatus { get; set; }
    }
}

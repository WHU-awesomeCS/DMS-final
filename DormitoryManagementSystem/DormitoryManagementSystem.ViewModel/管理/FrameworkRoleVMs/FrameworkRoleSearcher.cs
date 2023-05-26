// WTM默认页面 Wtm buidin page
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkRoleVMs
{
    public class FrameworkRoleSearcher : BaseSearcher
    {
        [Display(Name = "管理.RoleCode")]
        public string RoleCode { get; set; }

        [Display(Name = "管理.RoleName")]
        public string RoleName { get; set; }
    }
}

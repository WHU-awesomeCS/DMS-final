// WTM默认页面 Wtm buidin page
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkMenuVMs
{
    public enum FrameworkMenuMode { Normal = 0, RoleMode = 1, RoleSetMode = 2 }
    public class FrameworkMenuSearcher : BaseSearcher
    {
        [Display(Name = "管理.PageName")]
        public string PageName { get; set; }
        [Display(Name = "Codegen.ModuleName")]
        public string ModuleName { get; set; }
        [Display(Name = "管理.ActionName")]
        public string ActionName { get; set; }
        [Display(Name = "管理.ShowOnMenu")]
        public bool? ShowOnMenu { get; set; }
        [Display(Name = "管理.IsPublic")]
        public bool? IsPublic { get; set; }
        [Display(Name = "管理.FolderOnly")]
        public bool? FolderOnly { get; set; }

        public Guid? RoleID { get; set; }
    }
}

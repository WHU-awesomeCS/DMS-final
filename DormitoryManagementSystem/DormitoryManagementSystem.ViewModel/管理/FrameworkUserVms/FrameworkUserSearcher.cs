// WTM默认页面 Wtm buidin page
using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.FrameworkUserVms
{
    public class FrameworkUserSearcher : BaseSearcher
    {
        [Display(Name = "管理.Account")]
        public string ITCode { get; set; }

        [Display(Name = "管理.Name")]
        public string Name { get; set; }
        [Display(Name = "管理.IsValid")]
        public bool? IsValid { get; set; }

    }
}

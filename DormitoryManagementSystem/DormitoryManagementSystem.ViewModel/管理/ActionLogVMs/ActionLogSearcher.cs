// WTM默认页面 Wtm buidin page
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WalkingTec.Mvvm.Mvc.Admin.ViewModels.ActionLogVMs
{
    public class ActionLogSearcher : BaseSearcher
    {

        [Display(Name = "管理.Account")]
        public string ITCode { get; set; }

        [Display(Name = "Url")]
        public string ActionUrl { get; set; }

        [Display(Name = "管理.LogType")]
        public List<ActionLogTypesEnum> LogType { get; set; }

        [Display(Name = "管理.ActionTime")]
        public DateRange ActionTime { get; set; }


        [Display(Name = "IP")]
        public string IP { get; set; }

        [Display(Name = "管理.Duration")]
        public double? Duration { get; set; }

    }
}

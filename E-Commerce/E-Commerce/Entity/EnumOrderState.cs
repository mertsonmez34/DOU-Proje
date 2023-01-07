using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_Commerce.Entity
{
    public enum EnumOrderState
    {
        [Display(Name = "Awaiting Approval")]
        Waiting,
        [Display(Name = "Completed")]
        Completed
    }
}
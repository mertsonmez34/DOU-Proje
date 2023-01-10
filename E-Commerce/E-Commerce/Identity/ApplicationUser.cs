using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace E_Commerce.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public int? Height { get; set; }

        public int? Weight { get; set; }

        public bool? Sex { get; set; }

    }
}
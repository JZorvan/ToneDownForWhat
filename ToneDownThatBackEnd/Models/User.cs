using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToneDownThatBackEnd.Models
{
    public class User : IdentityUser
    {
        public virtual List<Entry> Entries { get; set; }
    }
}
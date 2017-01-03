using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToneDownThatBackEnd.Models;

namespace ToneDownThatBackEnd.DAL
{
    public class ToneDownContext : IdentityDbContext<User>
    {
        public ToneDownContext() : base("ToneDownContext") { }

        public virtual DbSet<Entry> Entries { get; set; }
    }
}
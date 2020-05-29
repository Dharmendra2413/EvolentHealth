using EvolentHealthWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EvolentHealthWebAPI.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("EvolentConnection")
        {

        }
        public DbSet<UserContact> Contacts { get; set; }
    }
}
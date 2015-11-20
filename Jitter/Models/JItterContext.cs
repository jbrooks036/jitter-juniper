using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Jitter.Models
{
    // our way into the DB
    // the glue that holds [MVC app?] together w/ DB; pipeline to table(s) in DB
    // DbContext knows way into DB, w/ auth creds, etc.
    public class JitterContext : DbContext
    {
        // could also use IDbSet IQueryable, IList; DbSet implements all interfaces
        public DbSet<JitterUser> JitterUsers { get; set; } // creates JitterUser table in Db
        public DbSet<Jot> Jots { get; set; }
    }
}
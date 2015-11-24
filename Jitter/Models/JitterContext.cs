﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Jitter.Models
{
    public class JitterContext : DbContext 
    {
        // IDbSet, IQueryable
        // each DbSet corresponds to a DB table 
        public virtual DbSet<JitterUser> JitterUsers { get; set; }  // allows to save changes, w/ mock(!)
        public DbSet<Jot> Jots { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ErrorLog.Models
{
    public class ErrorLogContext : DbContext
    {
        public DbSet<Error> Errors { get; set; }
        public ErrorLogContext() : base("ErrorLogEntity")
        { }
    }
}
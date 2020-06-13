using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TCAPP.DataAccess.Context
{
    public class TCAPPContext : DbContext
    {
        public TCAPPContext(DbContextOptions<TCAPPContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {

        }
    }
}

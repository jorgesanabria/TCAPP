using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using TCAPP.DataAccess.Context;

namespace TCAPP.DataAccess.DesignTime
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TCAPPContext>
    {
        public TCAPPContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TCAPPContext>();
            builder.UseMySql("Server=localhost;Database=TCAPP;Uid=root;Pwd=root;");
            return new TCAPPContext(builder.Options);
        }
    }
}

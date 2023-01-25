using Microsoft.EntityFrameworkCore;
using BBS.Entity;

namespace BBS
{
    public class BBSContext : DbContext
    {
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = String.Format(
                "server={};user={};password={};database={};",
                Config.getValue("server"),
                Config.getValue("user"),
                Config.getValue("password"),
                Config.getValue("database")
            );

            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
    }
}

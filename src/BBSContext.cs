using Microsoft.EntityFrameworkCore;
using BBS.Entity;

namespace BBS
{
    public class BBSContext : DbContext
    {
        public DbSet<Entity.User> User { get; set; }
        public DbSet<Entity.Message> Message { get; set; }
        public DbSet<Entity.Ban> Ban { get; set; }
        public DbSet<Entity.Board> Board { get; set; }
        public DbSet<Entity.Thread> Thread { get; set; }
        public DbSet<Entity.Post> Post { get; set; }
        public DbSet<Entity.Moderator> Moderator { get; set; }
        public DbSet<Entity.Bookmark> Bookmark { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = String.Format(
                "server={0};user={1};password={2};database={3}",
                Config.GetValue("server"),
                Config.GetValue("user"),
                Config.GetValue("password"),
                Config.GetValue("database")
            );

            optionsBuilder.UseMySql(connection, ServerVersion.AutoDetect(connection));
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Beta3.Entity;

namespace Beta3
{
    public class Beta3Context : DbContext
    {
        public DbSet<Entity.User> User { get; set; }
        public DbSet<Entity.Message> Message { get; set; }
        public DbSet<Entity.Ban> Ban { get; set; }
        public DbSet<Entity.Board> Board { get; set; }
        public DbSet<Entity.Thread> Thread { get; set; }
        public DbSet<Entity.Post> Post { get; set; }
        public DbSet<Entity.Moderator> Moderator { get; set; }
        public DbSet<Entity.Bookmark> Bookmark { get; set; }

        private static Beta3Context instance = null;

        public static Beta3Context Context
        {
            get
            {
                if (instance == null)
                {
                    instance = new Beta3Context();
                }

                return instance;
            }
        }

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

        public static void Init()
        {

        }
    }
}

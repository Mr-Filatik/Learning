using Microsoft.EntityFrameworkCore;
using StudyDatabaseProject.Entity;

namespace StudyDatabaseProject
{
    public class SqlServerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserKey> UserKeys { get; set; }
        public DbSet<UserK> UserK { get; set; }
        public DbSet<User2> User2s { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<MessageReaction> MessageReactions { get; set; }

        public SqlServerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User[] users = new User[3]
            {
                new User() { Id = 1, Name = "Vlad", Email = "Vlad@gmail.com", Password = "password"},
                new User() { Id = 2, Name = "Oleg", Email = "Oleg@gmail.com", Password = "password"},
                new User() { Id = 3, Name = "Sergey", Email = "Sergey@gmail.com", Password = "password"},
            };
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<UserKey>().HasKey(x => x.Id);
            modelBuilder.Entity<UserK>().HasKey(x => x.Id);
            modelBuilder.Entity<UserK>()
                .HasOne<UserKey>(x => x.UserKey)
                .WithOne(x => x.User)
                .HasForeignKey<UserK>(x => x.UserKeyId);
        }
    }
}

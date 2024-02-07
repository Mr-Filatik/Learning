using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudyDatabaseProject
{
    public class SqlServerDbContextFactory : IDesignTimeDbContextFactory<SqlServerDbContext>
    {
        public SqlServerDbContext CreateDbContext(string[] args)
        {
            var connString = "Server=(localdb)\\mssqllocaldb;Database=StudyDatabase;Trusted_Connection=True;";

            var option = new DbContextOptionsBuilder<SqlServerDbContext>()
                .UseSqlServer(connString).Options;

            return new SqlServerDbContext(option);
        }
    }
}

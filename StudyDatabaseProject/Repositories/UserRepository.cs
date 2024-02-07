using StudyDatabaseProject.Entity;
using System.Collections;

namespace StudyDatabaseProject.Repositories
{
    public class UserRepository : IDisposable
    {
        private readonly SqlServerDbContext _context;

        public UserRepository(SqlServerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            await Task.Delay(5000);
            return _context.Users;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="NullReferenceException"></exception>
        /// <returns></returns>
        public User GetUserById(int id) 
        { 
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new NullReferenceException($"User (id == {id}) not found");
            }
            return user;
        }

        public void Dispose()
        {
            Console.WriteLine("CLOSE");
        }
    }
}

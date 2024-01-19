using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Entities
{
    internal class User
    {
        internal int Id { get; private set; }
        internal string Name { get; private set; }
        internal UserRole Role { get; private set; }
        internal string HashPassword { get; private set; }

        public User(int id, string name, UserRole role, string hashPassword)
        {
            Id = id;
            Name = name;
            Role = role;
            HashPassword = hashPassword;
        }
    }

    internal enum UserRole
    {
        User,
        Admin
    }
}

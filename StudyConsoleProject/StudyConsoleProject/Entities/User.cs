using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyConsoleProject.Entities
{
    /// <summary>
    /// Сущность для пользователя
    /// </summary>
    internal class User
    {
        internal int Id { get; private set; } // уникальный идентификатор для бд
        internal string Name { get; private set; } // имя
        internal UserRole Role { get; private set; } // роль в приложении
        internal string HashPassword { get; private set; } // пароль

        public User(int id, string name, UserRole role, string hashPassword)
        {
            Id = id;
            Name = name;
            Role = role;
            HashPassword = hashPassword;
        }
    }

    /// <summary>
    /// Роли пользователей в приложении
    /// </summary>
    internal enum UserRole
    {
        User,
        Admin
    }
}

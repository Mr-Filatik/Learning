using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLibraryProject.Entities
{
    /// <summary>
    /// Сущность для пользователя
    /// </summary>
    public class User
    {
        public int Id { get; set; } // уникальный идентификатор для бд
        public string Name { get; set; } // имя
        public UserRole Role { get; set; } // роль в приложении
        public string HashPassword { get; set; } // пароль

        public User(int id, string name, UserRole role, string hashPassword)
        {
            Id = id;
            Name = name;
            Role = role;
            HashPassword = hashPassword;
        }

        public User() { }
    }

    /// <summary>
    /// Роли пользователей в приложении
    /// </summary>
    public enum UserRole
    {
        User,
        Admin
    }
}

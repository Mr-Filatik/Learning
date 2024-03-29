﻿using StudyLibraryProject.Abstract;
using StudyLibraryProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLibraryProject.Managers
{
    /// <summary>
    /// класс для управления пользователями
    /// </summary>
    public class UserManager : IUserManager
    {
        private List<User> _users; //список пользователей (редко такие данные целиком хранятся в приложении, поэтому таким образом мы изобразили запрос данных, которые где-то хранятся)

        public bool LoadUsers()
        {
            _users = new List<User>();
            _users.Add(new User(0, "Admin", UserRole.Admin, "012"));
            _users.Add(new User(1, "User 1", UserRole.User, "123"));
            _users.Add(new User(2, "User 2", UserRole.User, "234"));
            return true;
        }

        // метод авторизации пользователей
        public User Login(string login, string password)
        {
            foreach (var user in _users)
            {
                if (user.Name == login)
                {
                    if (user.HashPassword == password)
                    {
                        return user;
                    }
                }
            }
            return null;
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void AddUser()
        {
            throw new NotImplementedException();
        }

        public void EditUser()
        {
            throw new NotImplementedException();
        }

        public void RemoveUser()
        {
            throw new NotImplementedException();
        }
    }
}

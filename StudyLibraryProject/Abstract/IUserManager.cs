using StudyLibraryProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLibraryProject.Abstract
{
    public interface IUserManager
    {
        bool LoadUsers();
        void AddUser();
        void RemoveUser();
        void EditUser();

        User Login(string login, string password);
        void Logout();
    }
}

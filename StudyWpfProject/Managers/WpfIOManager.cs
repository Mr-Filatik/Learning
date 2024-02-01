using StudyLibraryProject.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWpfProject.Managers
{
    internal class WpfIOManager : IIOManager
    {
        public string? GetData()
        {
            throw new NotImplementedException();
        }

        public void ShowError(string text)
        {
            throw new NotImplementedException();
        }

        public void ShowLogin(Action<string, string> action)
        {
            (App.Current as App)?.Logout();
        }

        public void ShowMainMenu()
        {
            throw new NotImplementedException();
        }

        public void ShowMessage(string text)
        {
            throw new NotImplementedException();
        }
    }
}

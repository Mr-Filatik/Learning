using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyLibraryProject.Abstract
{
    public interface IIOManager
    {
        void ShowLogin(Action<string, string> action);
        void ShowMainMenu();
        void ShowMessage(string text);
        void ShowError(string text);
        string? GetData();
    }
}

using StudyLibraryProject.Entities;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace StudyConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // имимтируем работу внедрения зависимости (она выполняется за нас автоматически)
            //Questionnaire questionnaire = new Questionnaire(new UserManager(), new QuestionManager(), new ConsoleIOManager());

            //// запуск работы опросника
            //questionnaire.Run();

            // запуск старого опросника
            //OldVersion.Run();

            Console.WriteLine("Start");
            Console.WriteLine();



            //изменение части одной строки в файле

            string path1 = @"E:\Test\MyText.txt";

            string tempPath = path1 + ".tmp";
            using (StreamReader sr = new StreamReader(path1)) // читаем
            using (StreamWriter sw = new StreamWriter(tempPath)) // и сразу же пишем во временный файл
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine(); // считываем строку
                    User? user = JsonSerializer.Deserialize<User>(line); // десериализуем строку в объект
                    if (user != null && user.Id == 3) // условие для изменяемого объекта (пользователь с id = 3)
                    {
                        user.Password = "password"; // изменяем что-то в объекте
                        string newValue = JsonSerializer.Serialize(user); // сериализуем объект обратно в строку
                        sw.WriteLine(newValue); // записываем в новый фаил
                    }
                    else
                    {
                        sw.WriteLine(line); // записываем в новый фаил
                    }
                }
            }
            File.Delete(path1); // удаляем старый файл
            File.Move(tempPath, path1); // переименовываем временный файл

            //считывание строк с файла
            //using (StreamReader fs = new StreamReader(path1))
            //{
            //    string line = "";

            //    while ((line = fs.ReadLine()) != null)
            //    {
            //        Console.WriteLine($"{line}");
            //    }
            //}

            //запись в фаил
            //using (StreamWriter sw = new StreamWriter(path1))
            //{
            //    sw.WriteLine("Ackjsnskck");
            //}

            //виды записей строк
            //string path1 = "E:\\Test\\MyText.txt";
            //string path2 = @"E:\Test\One\MyText.txt";
            //string path3 = "/Test"; //относительный путь - относительно проекта
            ////string path3 = "Test\\One"; // для маков и линукс

            //информация о файле
            //FileInfo fileInfo = new FileInfo(path1);
            //fileInfo.CopyTo(path2, true);

            //прочитывание файла целиком
            //var datas = File.ReadAllLines(path1);
            //foreach ( var data in datas )
            //{
            //    Console.WriteLine(data);
            //}
            ////datas[4] += "!";
            ////File.WriteAllLines(path2, datas);
            ////File.AppendAllText(path1, "Новый год!");
            //File.Delete(path2);

            //сериализация
            //User user = new User() { Id = 1, Name = "Vlad", Email = "vlad@mail.ru", Password = "password" };

            //Console.WriteLine();
            //Console.WriteLine($"{user.Id} {user.Name} {user.Email} {user.Password}");

            //string data = JsonSerializer.Serialize(user);

            //Console.WriteLine();
            //Console.WriteLine(data);

            //File.WriteAllText(path1, data);

            //var newdata = File.ReadAllLines(path1);

            //user = null;
            //user = JsonSerializer.Deserialize<User>(newdata[0]);

            //Console.WriteLine();
            //Console.WriteLine($"{user.Id} {user.Name} {user.Email} {user.Password}");

            Console.WriteLine();
            Console.WriteLine("End");
        }
    }

    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        //[JsonIgnore]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
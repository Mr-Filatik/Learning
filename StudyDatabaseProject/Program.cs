using Microsoft.EntityFrameworkCore;
using StudyDatabaseProject.Entity;
using StudyDatabaseProject.Repositories;
using System;

namespace StudyDatabaseProject
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            SqlServerDbContextFactory sqlServerDbContextFactory = new SqlServerDbContextFactory();
            SqlServerDbContext context = sqlServerDbContextFactory.CreateDbContext(new string[0]);

            //#region Main work with context

            //Console.WriteLine();
            //foreach (var item in context.Users)
            //{
            //    Console.WriteLine($"{item.Id} - {item.Name} - {item.Email}.");
            //}

            ////Add data
            //context.Users.Add(new User() { Name = "Olga", Email = "Olga@gmail.com", Password = "password" });
            //context.SaveChanges();

            //Console.WriteLine();
            //foreach (var item in context.Users)
            //{
            //    Console.WriteLine($"{item.Id} - {item.Name} - {item.Email}.");
            //}

            ////Delete data
            //User? deleteUser = context.Users.FirstOrDefault(x => x.Name == "Olga");
            //if (deleteUser != null) context.Users.Remove(deleteUser);
            //context.SaveChanges();

            //Console.WriteLine();
            //foreach (var item in context.Users)
            //{
            //    Console.WriteLine($"{item.Id} - {item.Name} - {item.Email}.");
            //}

            ////Change data
            //User? changeUser = context.Users.FirstOrDefault(x => x.Email == "Oleg@gmail.com");
            //if (changeUser != null)
            //{
            //    if (changeUser.Name == "Oleg")
            //    {
            //        changeUser.Name = "Olegsey";
            //    }
            //    else
            //    {
            //        changeUser.Name = "Oleg";
            //    }
            //}
            //context.SaveChanges();

            //Console.WriteLine();
            //foreach (var item in context.Users)
            //{
            //    Console.WriteLine($"{item.Id} - {item.Name} - {item.Email}.");
            //}

            //#endregion

            //int => int
            //string => nvarchar(max)
            //bool => bit
            //long => bigint
            //char => nvarchar(1)
            //DateTime => datetime2(7)
            //float => real
            //double => float

            // 1) Code Convention (Соглашения о коде)

            //User? user = context.Users.FirstOrDefault(x => x.Name == "Vlad");
            //context.Messages.Add(new Message() { Text = "Hello, Oleg!", UserId = user.Id });
            //context.SaveChanges();

            //Console.WriteLine();
            //foreach (var item in context.Messages.Include(u => u.User))
            //{
            //    Console.WriteLine($"{item.Id} - {item.Text} - {item.User.Email}.");
            //}

            //Console.WriteLine();
            //foreach (var item in context.Users.FirstOrDefault(x => x.Name == "Vlad").Messages)
            //{
            //    Console.WriteLine($"{item.Id} - {item.Text} - {item.User.Email}.");
            //}

            //Console.WriteLine();
            //foreach (var item in context.Users.Include(u => u.Messages).FirstOrDefault(x => x.Name == "Vlad").Messages)
            //{
            //    Console.WriteLine($"{item.Id} - {item.Text} - {item.User.Email}.");
            //    //var reacts = context.Reactions.Where(x => x.); //не хватает функционала
            //    foreach (var react in item.Reactions)
            //    {
            //        Console.WriteLine($"      - {react.Name}.");
            //    }
            //}

            // 2) Data Annotation Atributes (Атрибуты данных)

            //Console.WriteLine();
            //foreach (var item in context.Messages.Where(x => x.UserId == 1).Include(x => x.Reactions).Include(x => x.User))
            //{
            //    Console.WriteLine($"{item.Id} - {item.Text} - {item.User.Email}.");
            //    foreach (var react in item.Reactions)
            //    {
            //        Console.WriteLine($"    - {react.Name}.");
            //    }
            //}

            // 3) FluentAPI.

            //int ids = 0;

            //using UserRepository userRepository = new UserRepository(context);

            //var users = await userRepository.GetUsers();
            //while (ids < 5)
            //{
            //    Console.ReadLine();
            //    try
            //    {
            //        var item = userRepository.GetUserById(ids);
            //        Console.WriteLine($"{item.Id} - {item.Name} - {item.Email}.");
            //    }
            //    catch (NullReferenceException e)
            //    {
            //        Console.WriteLine($"{e.Message} - {e.StackTrace}");
            //        throw;
            //    }
            //    catch
            //    {
            //        Console.WriteLine($"Непредвиденная ошибка");
            //    }
            //    ids++;
            //}
            //foreach (var item in users)
            //{
            //    Console.WriteLine($" ======== {item.Id} - {item.Name} - {item.Email}.");
            //}

            var dateTime = DateTime.Now;
            Console.WriteLine($"Start");

            var userInfo1 = GetUser1();
            var userInfo2 = GetUser2();

            for ( int i = 0; i < 12; i++ )
            {
                await Task.Delay(500);
                Console.SetCursorPosition(i, 1);
                Console.Write("=");
            }
            Console.WriteLine();

            Console.WriteLine(await userInfo1);
            try
            {
                Console.WriteLine(await userInfo2);
            }
            catch (Exception)
            {
                Console.WriteLine("User not found");
            }
            

            var span = DateTime.Now - dateTime;
            Console.WriteLine($"{span.Seconds}:{span.Milliseconds}");
        }

        static async Task<string> GetUser1()
        {
            await Task.Delay(5000);
            return "user 1";
        }

        static async Task<string> GetUser2()
        {
            await Task.Delay(5000);
            throw new NotImplementedException();
            return "none user";
        }
    }
}
using System;
using System.Text.RegularExpressions;

//                                                  Задание 1.
//  Создать программу, которая будет проверять корректность ввода логина. Корректным логином будет
//  строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом
//  цифра не может быть первой:
//      а) без использования регулярных выражений;
//      б) с использованием регулярных выражений.

//  Ступин А.А.

namespace GeekBrains_HW_5
{
    class Program
    {
        static bool IsCorrect(string login)
        {
            if (login.Length < 2 || login.Length > 10 || char.IsDigit(login[0]))
                return false;

            for (int i = 0; i < login.Length; i++)
            {
                if (!char.IsDigit(login[i]) && !char.IsLetter(login[i]))
                    return false;
                if ((login[i] >= 'А') && (login[i] <= 'Я') ||
                    (login[i] >= 'а') && (login[i] <= 'я'))
                    return false;
            }
            return true;
        }

        static void LoginForm1()
        {
            string userInput;
            do
            {
                userInput = Console.ReadLine();

                if (IsCorrect(userInput))
                    Console.WriteLine("Логин корректный.");
                else
                    Console.WriteLine("Логин некорректный.");
            } while (userInput != "quit");
        }

        static void LoginForm2()
        {
            string pattern = @"^[A-Za-z][A-Za-z0-9]{1,9}$";
            string userInput;

            do
            {
                userInput = Console.ReadLine();

                if (Regex.IsMatch(userInput, pattern, RegexOptions.IgnoreCase))
                    Console.WriteLine("Логин корректный.");
                else
                    Console.WriteLine("Логин некорректный.");
            } while (userInput != "quit");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Корректным логином будет строка от 2 до 10 символов,\n" +
                              "содержащая только буквы латинского алфавита или цифры,\n" +
                              "при этом цифра не может быть первой.");
            Console.WriteLine(new string('-', 54));
            Console.WriteLine("Выберите режим проверки логина:");
            Console.WriteLine("1 - Без использования регулярных выражений.");
            Console.WriteLine("2 - С использованием регулярных выражений.");

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.D1 || input.Key == ConsoleKey.D2)
                Console.WriteLine("\n\nДля выхода введите quit или нажмите Ctrl + C");
            switch (input.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("\nВведите логин:");
                    LoginForm1();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine("\nВведите логин:");
                    LoginForm2();
                    break;
                default:
                    Console.WriteLine("\n\nНеверный ввод.");
                    break;
            }
            Console.WriteLine("Для завершения нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}
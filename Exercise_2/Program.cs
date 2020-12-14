using System;
using System.IO;
using System.Linq;
using System.Text;

//                               Задание 2.
//  Разработать класс Message, содержащий следующие статические методы для обработки текста:
//      а) Вывести только те слова сообщения, которые содержат не более n букв.
//      б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
//      в) Найти самое длинное слово сообщения.
//      г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
//  Продемонстрируйте работу программы на текстовом файле с вашей программой.

//  Ступин А.А.

namespace Exercise_2
{
    static class Message
    {
        public static string NoLonger(string msg, int length)
        {
            string str = DeletePunctuation(msg);
            string[] s = str.Split(' ');
            string selected = String.Empty;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length < length)
                    selected += $"{String.Join(" ", s[i])} ";
            }
            selected.TrimEnd(' ');

            return selected;
        }

        public static string Delete(string msg, char ch)
        {
            string[] s = msg.Split(' ');
            string[] s2 = msg.Split(',', '.', '!', '?', ' ');
            s2 = DeleteEmptyStrings(s2);

            for (int i = 0; i < s2.Length; i++)
            {
                if (s2[i][s2[i].Length - 1] == ch)
                    s[i] = s[i].Replace(s[i], String.Empty);
            }

            msg = string.Join(" ", s);

            return msg;
        }

        public static string Longest(string msg)
        {
            msg = DeletePunctuation(msg);

            string[] s = msg.Split(' ');
            string longest = s[0];

            for (int i = 0; i < s.Length; i++)
            {
                if (longest.Length < s[i].Length)
                    longest = s[i];
            }

            return longest;
        }

        public static StringBuilder LongestWords(string msg)
        {
            StringBuilder sb;
            msg = DeletePunctuation(msg);
            string[] s = msg.Split(' ');

            int average = 0;

            for (int i = 0; i < s.Length; i++)
            {
                average += s[i].Length;
            }

            msg = String.Empty;
            average /= s.Length;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Length > average)
                    msg += $"{String.Join(" ", s[i])} ";
            }
            msg.TrimEnd(' ');
            sb = new StringBuilder(msg);

            return sb;
        }

        private static string DeletePunctuation(string msg)
        {
            StringBuilder sb = new StringBuilder(msg);
            for (int i = 0; i < sb.Length; i++)
            {
                if (char.IsPunctuation(sb[i]))
                    sb.Remove(i, 1);
            }

            return sb.ToString();
        }

        private static string[] DeleteEmptyStrings(string[] msg)
        {
            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] == "")
                    msg = msg.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            }

            return msg;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"text.txt";
            string message = String.Empty;
            try
            {
                message = File.ReadAllText(filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            int length = 6;
            Console.WriteLine(new string('-', 50));
            Console.WriteLine($"Вывести только те слова текста, которые содержат не более {length} букв:");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(Message.NoLonger(message, length));

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Удалить из текста все слова, которые заканчиваются на заданный символ 'я':");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(Message.Delete(message, 'я'));

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Найти самое длинное слово текста:");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(Message.Longest(message));

            Console.WriteLine(new string('-', 50));
            Console.WriteLine("Сформировать строку с помощью StringBuilder из самых длинных слов текста:");
            Console.WriteLine(new string('-', 50));
            Console.WriteLine(Message.LongestWords(message));
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Для завершения нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}

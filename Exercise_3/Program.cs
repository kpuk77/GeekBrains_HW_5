using System;

//                                              Задание 3.
//  *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
//      а) с использованием методов C#;
//      б) *разработав собственный алгоритм.
//  Например:
//      badc являются перестановкой abcd.

//  Ступин А.А.

namespace Exercise_3
{
    class Program
    {
        private static bool IsSameA(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            char[] ch = str1.ToCharArray();
            char[] ch2 = str2.ToCharArray();

            Array.Sort(ch);
            Array.Sort(ch2);

            str1 = String.Join("", ch);
            str2 = String.Join("", ch2);

            return str1.CompareTo(str2) == 0;
        }

        private static bool IsSameB(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;

            DoubleSort(ref str1, ref str2);

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                    return false;
            }

            return true;
        }

        private static char[] Iterating(char[] ch)
        {
            char t;
            for (int i = 0; i < ch.Length; i++)
            {
                for (int j = 0; j < ch.Length - 1; j++)
                {
                    if (ch[j] > ch[j + 1])
                    {
                        t = ch[j];
                        ch[j] = ch[j + 1];
                        ch[j + 1] = t;
                    }
                }
            }

            return ch;
        }

        private static void DoubleSort(ref string str1, ref string str2)
        {
            char[] ch1 = str1.ToCharArray();
            char[] ch2 = str2.ToCharArray();

            ch1 = Iterating(ch1);
            ch2 = Iterating(ch2);

            str1 = String.Join("", ch1);
            str2 = String.Join("", ch2);
        }

        static void Main(string[] args)
        {
            string str1;
            string str2;

            Console.WriteLine("Для сравнение двух строк, введите первую строку и нажмите enter, затем введите вторую и нажмите enter.\nДля выхода нажмите Ctrl + C или введите quit.\n");
            do
            {
                str1 = Console.ReadLine();
                str2 = Console.ReadLine();

                if (IsSameA(str1, str2))
                    Console.WriteLine($"\nIsSameA: Одинаковые.");
                else
                    Console.WriteLine($"\nIsSameA: Разные.");

                if (IsSameB(str1, str2))
                    Console.WriteLine($"IsSameB: Одинаковые.\n");
                else
                    Console.WriteLine($"IsSameB: Разные.\n");

            } while (str1 != "quit" && str2 != "quit");

            Console.WriteLine("Для завершения нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}

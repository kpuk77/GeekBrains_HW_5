using System;
using System.IO;

//                              Задание 4. Задача ЕГЭ.
//      На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
//  школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
//  превосходит 100, каждая из следующих N строк имеет следующий формат:
//      < Фамилия > < Имя > < оценки >,
//  где < Фамилия > — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
//  более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
//  пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
//  Пример входной строки:
//      Иванов Петр 4 5 3
//  Требуется написать как можно более эффективную программу, которая будет выводить на экран
//  фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
//  набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.
//  Достаточно решить 2 задачи. Старайтесь разбивать программы на подпрограммы. Переписывайте в
//  начало программы условие и свою фамилию. Все программы сделать в одном решении. Для решения
//  задач используйте неизменяемые строки (string).

//  Ступин А.А.

namespace ConsoleApp1
{
    public class Pupils
    {
        public Person[] persons { get; private set; }

        public struct Person
        {
            public string lastName;
            public string name;
            public int[] grades;
            public double averageGrade;
        }

        public Pupils(string filePath)
        {
            persons = ReadFromFile(filePath);
        }

        private void Sort(Person[] person)
        {
            Person t = new Person();
            for (int i = 0; i < person.Length; i++)
            {
                for (int j = 0; j < person.Length - 1; j++)
                {
                    if (person[j].averageGrade > person[j + 1].averageGrade)
                    {
                        t = person[j + 1];
                        person[j + 1] = person[j];
                        person[j] = t;
                    }
                }
            }
        }

        private string PrintGrades(int[] grades)
        {
            string str = String.Empty;
            for (int i = 0; i < grades.Length; i++)
            {
                str += $"{grades[i]} ";
            }

            str.TrimEnd(' ');
            return str;
        }

        public void PrintSilly()
        {
            Sort(persons);

            Person[] silly;
            int count = 0;
            int index;

            for (index = 0; count != 3; index++)
            {
                if (persons[index].averageGrade == persons[index + 1].averageGrade)
                    continue;
                count++;
            }

            Console.Write("Фамилия, Имя ученика:\tОценки:\t\tСредний бал:\n");
            Console.WriteLine(new string('-', 52));
            for (int i = 0; i < index; i++)
            {
                Console.Write($"{persons[i].lastName,-12} {persons[i].name,-13} {PrintGrades(persons[i].grades),-18} {persons[i].averageGrade:f1}");
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 52));
        }

        private Person[] ReadFromFile(string filePath)
        {
            Person[] person;
            string[] str;

            if (!File.Exists(filePath))
                throw new Exception("Файл не найден.");

            if (File.ReadAllText(filePath).Length == 0)
                throw new Exception("Файл пустой не содержит информации.");

            using (StreamReader sr = new StreamReader(filePath))
            {
                int.TryParse(sr.ReadLine(), out int size);

                str = new string[size];
                person = new Person[size];

                for (int i = 0; i < str.Length; i++)
                {
                    string[] t = new string[5];
                    double a = 0;
                    str[i] = sr.ReadLine();
                    t = str[i].Split(' ');

                    person[i].lastName = t[0];
                    person[i].name = t[1];
                    person[i].grades = new int[3];

                    for (int j = 0; j < 3; j++)
                    {
                        person[i].grades[j] = int.Parse(t[j + 2]);
                        a += int.Parse(t[j + 2]);
                    }

                    a /= 3;
                    person[i].averageGrade = a;
                }
            }

            return person;
        }
    }
    

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"exam.txt";

            try
            {
                Pupils pupils = new Pupils(filePath);
                pupils.PrintSilly();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
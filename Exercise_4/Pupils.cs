using System;
using System.IO;

namespace Exercise_4
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
}

﻿using System;

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

namespace Exercise_4
{
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

            Console.WriteLine("Для завершения нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}
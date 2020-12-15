using System;
using System.IO;

//                                  Задание 5.
//  *Написать игру «Верю.Не верю». В файле хранятся вопрос и ответ, правда это или нет.
//      Например: «Шариковую ручку изобрели в древнем Египте», «Да».
//  Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку.
//  Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ.
//  Список вопросов ищите во вложении или воспользуйтесь интернетом.

//  Ступин А.А.

namespace Exercise_5
{
    class GameOfAnswers
    {
        private string[] questions;
        private string[] answers;
        public int score { get; set; }

        public GameOfAnswers(string filePath)
        {
            ReadFromFile(filePath);
            score = 0;
        }

        private void ReadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                throw new Exception("Файл не найден.");
            if (File.ReadAllText(filePath).Length == 0)
                throw new Exception("Файл не содержит информации.");

            int size = File.ReadAllLines(filePath).Length;

            using (StreamReader sr = new StreamReader(filePath))
            {
                questions = new string[size / 2];
                answers = new string[size / 2];
                for (int i = 0; i < size / 2; i++)
                {
                    questions[i] = sr.ReadLine();
                    answers[i] = sr.ReadLine();
                }
            }
        }

        public void Ask()
        {
            Random rand = new Random();
            string userInput;

            int nQuestion = rand.Next(0, questions.Length);

            Console.WriteLine(questions[nQuestion]);
            userInput = Console.ReadLine();

            userInput = userInput.ToLower();
            if (userInput == answers[nQuestion].ToLower())
            {
                Console.WriteLine("Верно!\n+10 очков.");
                score += 10;
            }
            else
                Console.WriteLine("Неверно!");

            questions = RemoveByIndex(nQuestion, questions);
            answers = RemoveByIndex(nQuestion, answers);
        }

        private string[] RemoveByIndex(int index, string[] stringArray)
        {
            int j = stringArray.Length - 1;
            string[] str = new string[j];
            int inx = 0;

            for (int i = 0; i < stringArray.Length; i++)
            {
                if (index == i)
                    continue;
                str[inx] = stringArray[i];
                inx++;
            }

            return str;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "questions.txt";

            GameOfAnswers game = new GameOfAnswers(filePath);

            for(int i = 0; i < 5; i++)
                game.Ask();

            Console.WriteLine($"Ваш счет: {game.score}\n");
            Console.WriteLine("Для завершения нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}

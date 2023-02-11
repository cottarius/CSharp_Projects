using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUIZ
{
    public class Operation
    {        
        int stateMenu;
        string path = @"..\..\..\DataBase.json";
        Random random = new Random();
        int correctAnswer = 0;
        int questionCount = 0;

        public void Read()
        {
            string json = File.ReadAllText(path);
            List<DataBase> listBase = JsonConvert.DeserializeObject<List<DataBase>>(json)!;
            foreach(var l in listBase)
            {
                Console.WriteLine(l);
            }
        }

        public void AddQuestion()
        {
            string json = File.ReadAllText(path);
            List<DataBase>? listBase = JsonConvert.DeserializeObject<List<DataBase>>(json);
            Console.Write("Введите вопрос: ");
            string question = Console.ReadLine()!;
            Console.Write("Введите ответ: ");
            string answer = Console.ReadLine()!;

            DataBase item = new DataBase(question, answer);
            listBase!.Add(item);

            string serializedItem = JsonConvert.SerializeObject(listBase);

            File.WriteAllText(path, serializedItem);
            Console.WriteLine("Добавлено!");
        }

        public void Menu()
        {
            Console.WriteLine("=== Меню викторины ===");
            Console.WriteLine("1. Запуск игры\n" +
                "2. Список всех вопросов\n" +
                "3. Добавить вопрос/ответ\n" +                
                "0. Выход");
            Console.Write("Выберите пункт меню: ");
            while (!int.TryParse(Console.ReadLine(), out stateMenu) || stateMenu > 3)
            {
                Console.Write("Ошибка! Введите правильный пункт меню: ");
            }
        }

        public void Game()
        {
            string json = File.ReadAllText(path);
            List<DataBase> databaseList = JsonConvert.DeserializeObject<List<DataBase>>(json)!;
            var index = Enumerable.Range(0, databaseList!.Count).OrderBy(n => random.Next()).ToArray();

            for(int i = 0; i < 10; i++)
            {
                string question = databaseList.ElementAt(index[i]).Question!;
                string answer = databaseList.ElementAt(index[i]).Answer!;
                Console.Write($"{question} ");
                string inputAnswer = Console.ReadLine()!;
                if(inputAnswer.ToLower() == answer.ToLower())
                {
                    Console.WriteLine("Правильно! Молодец!!");
                    correctAnswer++;
                }
                else
                {
                    Console.WriteLine($"Неверно! Правильный ответ - {answer}");
                }
                questionCount++;
                Thread.Sleep(3000);
                Console.Clear();
            }
            if (correctAnswer > questionCount / 2)
            {
                Console.WriteLine($"Ты молодец! Правильно ответил на {correctAnswer} из {questionCount}");
            }
            else
            {
                Console.WriteLine($"Правильно ответил на {correctAnswer} из {questionCount}");
            }
        }

        public void Run()
        {
            Console.Clear();
            Menu();

            while (stateMenu != 0)
            {
                switch (stateMenu)
                {
                    case 1:
                        {
                            Console.Clear();
                            Game();
                        }
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                        break;
                    case 2:
                        {
                            Console.Clear();
                            Read();
                        }
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                        break;
                    case 3:
                        {
                            Console.Clear();
                            AddQuestion();
                        }
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                        break;
                    default: Console.WriteLine("Что-то сломалось..."); break;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using System.Net.Http.Headers;
using System.Collections;
using System.Data;

namespace QUIZ
{
    public class Operation
    {
        int stateMenu;
        string path = @"..\..\..\1.csv";
        Random random = new Random();
        int correctAnswer = 0;
        int questionCount = 0;


        CsvConfiguration cfgHeaderFalse = new CsvConfiguration(CultureInfo.CurrentCulture) { HasHeaderRecord = false };
        CsvConfiguration cfg = new CsvConfiguration(CultureInfo.CurrentCulture);
        

        public void Read()
        {            
            if (File.Exists(path))
            {
                using (StreamReader strReader = new StreamReader(path))
                {
                    using (CsvReader csvReader = new CsvReader(strReader, cfg))
                    {
                        IEnumerable list = csvReader.GetRecords<DataBase>();
                        foreach (var l in list)
                        {
                            Console.WriteLine(l);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Списка не существует");
            }
        }
        public void AddQuestion()
        {            
            List<DataBase> list = new List<DataBase>();


            Console.Write("Введите вопрос: ");
            string question = Console.ReadLine()!;
            Console.Write("Введите ответ: ");
            string answer = Console.ReadLine()!;
            list.Add(new DataBase(question, answer));

            if (File.Exists(path))
            {
                using (StreamWriter strWriter = new StreamWriter(path, true))
                {
                    using (CsvWriter csvWriter = new CsvWriter(strWriter, cfgHeaderFalse))
                    {
                        csvWriter.WriteRecords(list);
                    }
                }
            }
            else
            {
                using (StreamWriter strWriter = new StreamWriter(path))
                {
                    using (CsvWriter csvWriter = new CsvWriter(strWriter, cfg))
                    {
                        csvWriter.WriteRecords(list);
                    }
                }
            }
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

        public void Game(int numberOfQuestions)
        {
            correctAnswer = 0;
            questionCount = 0;
            //var index = Enumerable.Range(0, list!.Count).OrderBy(n => random.Next()).ToArray();

            if (File.Exists(path))
            {
                using (StreamReader strReader = new StreamReader(path))
                {
                    using (CsvReader csvReader = new CsvReader(strReader, cfg))
                    {
                        //Console.SetCursorPosition(45, 15);
                        var list = csvReader.GetRecords<DataBase>().ToList();
                        var index = Enumerable.Range(0, list!.Count()).OrderBy(n => random.Next()).ToArray();
                        for (int i = 0; i < numberOfQuestions; i++)
                        {
                            string question = list.ElementAt(index[i]).Question!;
                            string answer = list.ElementAt(index[i]).Answer!;
                            Console.Write($"{question} ");
                            string inputAnswer = Console.ReadLine()!;
                            if (inputAnswer.ToLower() == answer.ToLower())
                            {
                                Console.WriteLine("Правильно! Молодец!!");
                                correctAnswer++;
                            }
                            else
                            {
                                Console.WriteLine($"Неверно! Правильный ответ - {answer}");
                            }
                            questionCount++;
                        }
                        if (correctAnswer > questionCount / 2)
                        {
                            Console.WriteLine($"Ты молодец! Правильно ответил на {correctAnswer} из {questionCount}");
                        }
                        else
                        {
                            Console.WriteLine($"Тебе нужно подучить страны и столицы. Правильно ответил на {correctAnswer} из {questionCount}");
                        }
                    }
                }
            }
            
            else
            {
                Console.WriteLine("Списка не существует");
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
                            int numbersOfQuestions = 0;
                            Console.Write("Введите количество вопросов: ");
                            while (!int.TryParse(Console.ReadLine(), out numbersOfQuestions) || numbersOfQuestions < 0)
                            {
                                Console.WriteLine("Ошибка! Введите целое положительное число: ");
                            }
                            Game(numbersOfQuestions);
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

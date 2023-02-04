using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GeographicalQUIZ
{
    class Operation
    {
        int stateMenu;
        //Country? country;

        string path = @"..\..\..\country.json";
        Random random = new Random();
        int correctAnswer = 0;
        int questionCount = 0;

        public void Read()
        {
            string json = File.ReadAllText(path);
            List<Country> list = JsonConvert.DeserializeObject<List<Country>>(json)!;
            foreach (var l in list!)
            {
                Console.WriteLine(l);
            }
        }

        public void AddCountry()
        {
            string json = File.ReadAllText(path);
            List<Country>? allCountries = JsonConvert.DeserializeObject<List<Country>>(json);
            Console.Write("Введите страну: ");
            string countryName = Console.ReadLine()!;
            Console.Write("Введите столицу: ");
            string capital = Console.ReadLine()!;

            Country country = new Country(countryName, capital);

            allCountries!.Add(country);

            string serializedCountry = JsonConvert.SerializeObject(allCountries);

            File.WriteAllText(path, serializedCountry);
        }
        public void Menu()
        {
            Console.WriteLine("=== Меню викторины ===");
            Console.WriteLine("1. Запуск игры\n" +
                "2. Список всех стран\n" +
                "3. Добавить страну\n" +
                "4. Добавить список стран\n" +
                "0. Выход");
            Console.Write("Выберите пункт меню: ");
            while (!int.TryParse(Console.ReadLine(), out stateMenu))
            {
                Console.Write("Ошибка! Введите правильный пункт меню: ");
            }
        }

        void Game()
        {
            string json = File.ReadAllText(path);
            List<Country>? countryList = JsonConvert.DeserializeObject<List<Country>>(json);
            var index = Enumerable.Range(0, countryList!.Count).OrderBy(n => random.Next()).ToArray();

            //if (countryList != null)
            //{
            for (int i = 0; i < countryList!.Count; i++)
            {
                string country = countryList.ElementAt(index[i]).CountryName!;
                string capital = countryList.ElementAt(index[i]).Capital!;
                Console.Write($"Столица {country}: ");
                string inputCapital = Console.ReadLine()!;
                if (inputCapital.ToLower() == capital.ToLower())
                {
                    Console.WriteLine("Правильно! Молодец!!");
                    correctAnswer++;
                }
                else
                {
                    Console.WriteLine($"Неверно! Правильный ответ - {capital}");
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
            //}
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
                            AddCountry();
                        }
                        Console.WriteLine("Нажмите любую клавишу...");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                        break;
                    case 4:
                        {
                            Console.Clear();

                        }
                        break;
                }
            }
        }
    }
}

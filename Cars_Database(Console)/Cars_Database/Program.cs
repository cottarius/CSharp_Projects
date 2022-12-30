using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars_Database
{
    internal class Program
    {
        static int stateMenu;
        static void ListMenu()
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Список автомобилей");
            Console.WriteLine("2. Добавление нового автомобиля");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");
            stateMenu = Convert.ToInt32(Console.ReadLine());
        }
        static void Main(string[] args)
        {
            Console.Clear();
            ListMenu();

            while(stateMenu != 0)
            {
                switch(stateMenu)
                {
                    case 1:
                        {
                            Console.Clear();
                            DataOperation data = new DataOperation();
                            var list = data.GetAllCars();
                            Console.WriteLine("*********All Cars*********");
                            Console.WriteLine(String.Format("{0, -10}{1, -10}{2, -10}{3, -10}", "Brand", "Model", "Color", "Release"));
                            Console.WriteLine("--------------------------------------");
                            foreach(var car in list)
                            {
                                Console.WriteLine(String.Format("{0, -10}{1, -10}{2, -10}{3, -10}", car.carBrand, car.carModel, car.carColor, car.release));
                            }
                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую клавишу...");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                        break;

                    case 2:
                        {
                            Console.Clear();
                            DataOperation data = new DataOperation();
                            data.InsertCar();
                            Console.WriteLine();
                            Console.WriteLine("Нажмите любую клавишу...");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        ListMenu();
                        break;
                }
            }
        }
    }
}

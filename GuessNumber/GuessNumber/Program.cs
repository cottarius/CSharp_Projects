
void GuessNumber() 
{
    Random random = new Random();
    int number = random.Next(0, 20);
    int inputNumber;
    int tryes = 4;
    while (tryes > 0)
    {        
        System.Console.Write("Введите число от 0 до 20: ");
        while (!int.TryParse(Console.ReadLine(), out inputNumber) || inputNumber < 0 || inputNumber > 20)
        {
            Console.WriteLine("Ошибка! Введите число от 0 до 20: ");
        }

        if (inputNumber == number)
        {
            Console.WriteLine("Поздравляю! Вы угадали число!!!");
            break;
        }
        else
        {
            if (tryes == 1)
            {
                Console.WriteLine("Вы проиграли...");
                tryes--;
            }
            else if (inputNumber > number)
            {
                Console.WriteLine($"Меньше... Осталось попыток: {--tryes}");                
            }
            else
            {
                Console.WriteLine($"Больше... Осталось попыток: {--tryes}");
            }
        }
        
    }   
}
GuessNumber();

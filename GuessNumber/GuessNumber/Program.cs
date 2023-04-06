
void GuessNumber() 
{
    Random random = new Random();
    int number = random.Next(0, 20);
    int inputNumber = 0;
    int tryes = 4;
    while (tryes > 0)
    {
        while (!int.TryParse(Console.ReadLine(), out inputNumber) || inputNumber < 0 || inputNumber > 20)
        {
            Console.WriteLine("Введите число от 0 до 20: ");
        }
        if (inputNumber == number)
        {
            Console.WriteLine("Поздравляю! Вы угадали число!!!");
        }
        else
        {
            if (inputNumber > number)
            {
                Console.WriteLine($"Меньше... Осталось {--tryes} попыток...");
            }
            else
            {
                Console.WriteLine($"Больше... Осталось {--tryes} попыток...");
            }
        }
        
    }   
}
GuessNumber();

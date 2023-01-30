
using System.Text.Json;
using System.Text.Json.Serialization;

string path = @"d:\country.json";
Random random = new Random();
int correctAnswer = 0;
int questionCount = 0;

//Create();
//AddCountry();
//Func();
//Read();

//Console.Write($"Вы правильно ответили: {correctAnswer} раз из {questionCount} вопросов");

void Create()
{
    using(FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
    {
        List<Country> countries = new List<Country>()
        {
            new Country("Россия", "Москва"),
            new Country("Китай", "Пекин"),
            new Country("Франция", "Париж"),
            new Country("Германия", "Берлин"),
        };
        JsonSerializer.Serialize<List<Country>>(fstream, countries);
    }
}
void AddCountry()
{
    using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
    {
        Console.Write("Введите страну: ");
        string? countryName = Console.ReadLine();
        Console.Write("Введите столицу: ");
        string? capital = Console.ReadLine();
        Country country = new Country(countryName, capital);

        List<Country>? countries = new List<Country>();
        
        countries.Add(country);
        
        JsonSerializer.Serialize<List<Country>>(fstream, countries);
        Console.WriteLine("Записано в файл");
    }
}

void Read()
{
    using(FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
    {
        List<Country>? countries = JsonSerializer.Deserialize<List<Country>>(fileStream);
        foreach(var list in countries)
        {
            Console.WriteLine($"{list.CountryName} - {list.Capital}");
        }
    }
}

void Func()
{
    using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate))
    {        
        int index = random.Next(0, 4);
        List<Country>? countryList = JsonSerializer.Deserialize<List<Country>>(fileStream);
        string? country = countryList?.ElementAt(index).CountryName;
        string? capital = countryList?.ElementAt(index).Capital;
        Console.Write($"Столица {country}: ");
        string? inputCapital = Console.ReadLine();
        if (inputCapital?.ToLower() == capital?.ToLower())
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
}

class Country
{
    public string? CountryName { get; set; }
    public string? Capital { get; set; }
      
    public Country(string? countryName, string? capital)
    {
        CountryName = countryName;
        Capital = capital;
    }
}



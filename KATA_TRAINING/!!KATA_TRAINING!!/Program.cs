using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;


namespace __KATA_TRAINING__
{    
    internal class Program
    {
        public static long[] Digitize(long n)
        {
            string str = n.ToString();
            long[] result = new long[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                string b = str[str.Length - i - 1].ToString();
                long a = Int64.Parse(b);
                result[i] = a;
            }
            return result;
        }
        public static int FindSmallestInt(int[] args)
        {
            int min = args[0];
            for(int i = 1; i < args.Length; i++)
            {
                if(args[i] < min)
                {
                    min = args[i];
                }
            }
            return min;
        }
        public static char GetGrade(int s1, int s2, int s3)
        {
            int average = (s1 + s2 + s3)/3;
            if (average >= 90 && average <= 100)
                return 'A';
            else if (average >= 80 && average < 90)
                return 'B';
            else if (average >= 70 && average < 80)
                return 'C';
            else if (average >= 60 && average < 70)
                return 'D';
            else 
                return 'F';
        }
        public static int CockroachSpeed(double x)
        {
            double cmPerSec =  x * 100000 / 3600;            
            return Convert.ToInt32(Math.Floor(cmPerSec));
        }
        public static double basicOp(char operation, double value1, double value2)
        {            
            switch(operation)
            {
                case '+': return value1 + value2;                  
                case '-': return value1 - value2;                  
                case '*': return value1 * value2;                  
                case '/': return value1 / value2;                  
                default:
                    return -1;
            }
        }
        public static int[] InvertValues(int[] input)
        {
            int[] newInput = new int[input.Length];
            if (input == null)
            {
                return null;
            }
            else if (input.Length == 0)
                return newInput;
            else
            {
                for (int i = 0; i < input.Length; i++)
                {
                    newInput[i] = -1 * input[i];
                }
            }
            return newInput;
        }
        public static int SquareSum(int[] numbers)
        {
            int sum = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i] * numbers[i];
            }
            return sum;
            //return numbers.Sum(x => x*x); альтернатива
        }
        public static bool XO(string input)
        {
            return input.ToLower().Count(i => i == 'x') == input.ToLower().Count(i => i == 'o');

        }
        public static int summation(int num)
        {
            int sum = 0;
            for(int i = 1; i <= num; i++)
            {
                sum += i;
            }
            return sum;
        }
        public static string MakeUpperCase(string str)
        {
            return str.ToUpper();
        }
        public static string CountSheep(int n)
        {
            string str = "";
            for (int i = 1; i <= n; i++)
            {
                str += $"{i} sheep...";
            }
            return str;
            //return string.Concat(Enumerable.Range(1, n).Select(i => $"{i} sheep..."));
        }
        public static string ReverseWords(string str)
        {
            return string.Join(" ", str.Split(' ').Select(i => new string(i.Reverse().ToArray())));
            
        }
        public static bool IsIsogram(string str)
        {
            for(int i = 0; i < str.Length - 1; i++)
            {
                for(int j = i + 1; j < str.Length; j++)
                {
                    if(str[j].ToString().ToLower() == str[i].ToString().ToLower())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static string HighAndLow(string numbers)
        {
            var nums = numbers.Split(' ').Select(Int32.Parse).ToArray();
            return $"{nums.Max()} {nums.Min()}";
        }
        public static string Greet(string name)
        {
            return $"Hello, {name} how are you doing today";
        }
        public static bool Check(object[] a, object x)
        {
            if (a.Contains(x))
            {
                return true;
            }
            else return false;
        }
        public static string AbbrevName(string name)
        {
            string[] buf = name.Split(' ');

            var firstName = buf.First();
            var lastName = buf.Last();

            var oneUpper = Char.ToUpper(firstName.First());
            var twoUpper = Char.ToUpper(lastName.First());

            return $"{oneUpper}.{twoUpper}";
        }
        public static int TotalPoints(string[] games)
        {
            int sum = 0;
            foreach(string game in games)
            {
                if (game[0] > game[2])
                {
                    sum += 3;
                }
                else if (game[0] == game[2])
                {
                    sum += 1;
                }                
            }
            return sum;
        }
        public static List<int> RemoveSmallest(List<int> numbers)
        {
            if (!numbers.Any())
                return numbers;
            else
            {
                numbers.Remove(numbers.Min());
                return numbers;
            }
        }
        public static string FakeBin(string x)
        {
            string y = "";            
            foreach (char c in x)
            {
                y += c < '5' ? "0" : "1";
            }
            return y;
        }
        public static int СenturyFromYear(int year)
        {

            int temp = year / 100;
            if ((double)year / 100 == temp)
                return temp;
            else
                return temp + 1;
        }
        public static string Disemvowel(string str)
        {
            string[] vowels = { "a", "e", "i", "o", "u", "A", "E", "I", "O", "U" };
            for(int i = 0; i < vowels.Length; i++)
            {
                str = str.Replace(vowels[i], "");            
            }
            return str;
        }
        public static string seriesSum(int n)
        {
            double sum = 0;
            int k = 1;
            if (n != 0)
            {
                for (int i = 1; i <= n; i++)
                {
                    sum = sum + 1 / (double)k; ;
                    k += 3;
                }
                return String.Format("{0:0.00}", sum);
            }
            else return "0.00";
        }
        public static int DescendingOrder(int num)
        {
            char[] chars = num.ToString().ToCharArray();
            Array.Sort(chars);
            Array.Reverse(chars);
            return Convert.ToInt32(new string(chars));            
        }
        public static int StringToNumber(String str)
        {
            return Convert.ToInt32(str);
        }
        public static string FindNeedle(object[] haystack)
        {            
            for (int index = 0; index < haystack.Length; index++)
            {
                if (haystack[index] != null)
                {
                    if (haystack[index].ToString() == "needle")
                    {
                        return $"found the needle at position {index}";
                    }
                }
            }
            return null;
        }
        public static int RentalCarCost(int d)
        {
            int carRent = 40;
            int total = carRent * d;
            if (d >= 7)
            {
                total -= 50;
            }
            else if (d >= 3 && d < 7)
            {
                total -= 20;
            }
            return total;
        }
        public static int PositiveSum(int[] arr)
        {
            return arr.Sum(x => (x < 0 ? 0 : x));
        }
        public static string boolToWord(bool word)
        {
            return word ? "Yes" : "No";
        }
        public static int sumTwoSmallestNumbers(int[] numbers)
        {
            /*int secondMin = numbers[0];
            int firstMin = numbers[0];

            if (numbers[1] < firstMin)
            {
                firstMin = numbers[1];
            }
            else
            {
                secondMin = numbers[1];
            }
            
            for(int i = 2; i < numbers.Length; i++)
            {
                if (numbers[i] < firstMin)
                {
                    secondMin = firstMin;
                    firstMin = numbers[i];
                }
                else if (numbers[i] < secondMin)
                {
                    secondMin = numbers[i];
                }
            }
            
            return firstMin + secondMin; 
            */
            //Array.Sort(numbers);
            //int sum = numbers.Take(2).Sum();
            //return sum;

            return numbers.OrderBy(x => x).Take(2).Sum();
        }

        static void Main(string[] args)
        {

            int number = 35231;
            Digitize(number);
            int[] number2 = { 78, 56, -2, 12, 8, -33 };
            Console.WriteLine(FindSmallestInt(number2));
            Console.WriteLine(GetGrade(70, 70, 100));
            Console.WriteLine(CockroachSpeed(0.17913232547532032));
            Console.WriteLine(basicOp('+', 7, 4));
            InvertValues(number2);
            int[] a = { 1, 2, 2 };
            Console.WriteLine(SquareSum(a));
            XO("zpzzp");
            Console.WriteLine(summation(213));
            Console.WriteLine(MakeUpperCase("привет олегус"));
            Console.WriteLine(CountSheep(5));
            Console.WriteLine(ReverseWords("Hello world"));
            Console.WriteLine(IsIsogram("erttdfg"));
            Console.WriteLine(HighAndLow("1 2 3 4 5"));
            Check(new object[] {66, 101}, 66);
            Console.WriteLine(AbbrevName("Sam Harris"));
            Console.WriteLine(TotalPoints(new[] { "1:0", "2:0", "3:0", "4:0", "2:1", "3:1", "4:1", "3:2", "4:2", "4:3" }));
            RemoveSmallest(new List<int> { 1, 2, 3, 4, 5 });
            FakeBin("45385593107843568");
            Console.WriteLine(СenturyFromYear(2000));
            Console.WriteLine(Disemvowel("This website is for losers LOL!"));
            Console.WriteLine(seriesSum(9));
            Console.WriteLine(DescendingOrder(42145));
            var haystack_1 = new object[] { '3', "123124234", null, "needle", "world", "hay", 2, '3', true, false };
            Console.WriteLine(FindNeedle(haystack_1));
            Console.WriteLine(RentalCarCost(7));
            int[] numbers5 = { 19, 5, 42, 2, 77 };
            Console.WriteLine(sumTwoSmallestNumbers(numbers5));
        }
    }
}

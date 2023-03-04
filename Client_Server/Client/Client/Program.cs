namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Это наш клиент");
            OurClient ourClient = new OurClient("127.0.0.1", 5555);
        }
    }
}
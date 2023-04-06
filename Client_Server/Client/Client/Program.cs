namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Это наш клиент");
            OurClient ourClient = new OurClient("192.168.1.74", 5555);
        }
    }
}
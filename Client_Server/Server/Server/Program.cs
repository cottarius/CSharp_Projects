namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("Это наш сервер");
            OurServer ourServer = new OurServer();
        }
    }
}
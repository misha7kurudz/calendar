namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DatabaseService service = new DatabaseService();
            service.RandomInsertionInto("Calendars", 5);
            service.ShowAllDataFrom("Calendars");
        }
    }
}

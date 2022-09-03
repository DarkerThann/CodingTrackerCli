using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CodingController db = new CodingController();
            db.CheckIfTableExists();

            Menu menu = new Menu();
            menu.MenuOptions();
        }
    }
}
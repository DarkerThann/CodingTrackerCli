using Microsoft.Data.Sqlite;

namespace CodingTracker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.MenuOptions();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Validation
    {
        public DateTime HourValidation()
        {
            string hour = Console.ReadLine();

            DateTime parseHour;

            while (!DateTime.TryParseExact(hour, "dd/MM/yyyy HH:mm", null, DateTimeStyles.None, out parseHour))
            {
                Console.WriteLine("Hora Invalida. Tente novamente. (Formato: HH:mm)");
                hour = Console.ReadLine();
            }
            return parseHour;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class UserInput
    {
        private readonly CodingSession coding = CodingSession.GetInstance();
        public void UserValues()
        {
            
            Validation input = new Validation();

            Console.WriteLine("Por favor Insira Data e Hora no seguinte Formato: dd/MM/yyyy HH:mm");

            Console.WriteLine("Data e Hora de Inicio");
            coding.StartTime = input.HourValidation();

            Console.WriteLine("Data e Hora de Finalização");
            coding.EndTime = input.HourValidation();
        }

        public void Id()
        {
            Console.WriteLine("Informe o ID da sessão: ");
            try
            {
                coding.Id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine($"ID Inválido. Digite Apenas Números");
                Id();
            }
        }

    }
}

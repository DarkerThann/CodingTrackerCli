namespace CodingTracker
{
    internal class UserInput
    {
        private readonly CodingSession coding = CodingSession.GetInstance();
        public void UserValues()
        {

            Validation input = new Validation();

            Console.WriteLine("Por favor Insira Data e Hora no seguinte Formato: dd/MM/yyyy HH:mm");

            Console.Write("Data e Hora de Inicio: ");
            coding.StartTime = input.HourValidation();

            Console.Write("Data e Hora de Finalização: ");
            coding.EndTime = input.HourValidation();

            TimeSpan hour = coding.StartTime.Subtract(coding.EndTime);            
            coding.Duration = hour.Duration();

        }

        public void Id()
        {
            Console.Write("Informe o ID da sessão: ");
            try
            {
                coding.Id = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine($"ID Inválido. Digite Apenas Números");
                Id();
            }
        }

    }
}

namespace CodingTracker
{
    internal class Menu
    {
        private readonly CodingController controller = new CodingController();
        private readonly UserInput input = new UserInput();

        public void MenuOptions()
        {
            string[] menu = new string[]
                     {"Menu Principal",
                     "--------------------------",
                      "0 Sair",
                      "1 Ver todas as sessões",
                      "2 Criar uma nova sessão",
                      "3 Atualizar uma sessão",
                      "4 Deletar uma sessão",
                      "--------------------------",
                     };

            foreach (var options in menu)
            {
                Console.WriteLine(options);
            }
            controller.CheckIfTableExists();
            MenuChoise();
        }

        private void MenuChoise()
        {
            Console.Write("Digite o número da opção: ");
            byte menuInput = 0;
            bool condition = true;

            while (condition)
            {
                try
                {
                    menuInput = Convert.ToByte(Console.ReadLine());
                    condition = false;
                    Console.Clear();
                }
                catch (Exception)
                {
                    Console.Write("Opção inválida.\nPor favor Digite novamente:");
                }
            }

            switch (menuInput)
            {
                case 0:
                    Environment.Exit(0);
                    break;
                case 1:
                    controller.GetAllCodingSession();
                    BackMenuOrExit();
                    break;
                case 2:
                    input.UserValues();
                    controller.CreateCodingSession();
                    BackMenuOrExit();
                    break;
                case 3:
                    input.Id();
                    input.UserValues();
                    controller.UpdateCodingSession();
                    BackMenuOrExit();
                    break;
                case 4:
                    input.Id();
                    controller.DeleteCodingSession();
                    BackMenuOrExit();
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor Digite novamente.");
                    MenuOptions();
                    break;
            }
        }

        private void BackMenuOrExit()
        {
            Console.Write("--------------------------\n" +
                          "0 Voltar ao Menu Principal\n" +
                          "1 Sair da Aplicação\n" +
                          "--------------------------\n" +
                          "Digite o número da opção:");

            bool condition = true;

            while (condition)
            {
                try
                {
                    byte choise = Convert.ToByte(Console.ReadLine());
                    condition = false;
                    
                    if (choise == 0)
                    {
                        Console.Clear();
                        MenuOptions();
                    }
                    else
                    {
                        Environment.Exit(0);
                    }
                }
                catch (Exception)
                {
                    Console.Write("Opção inválida.\nPor favor Digite novamente:");
                }
            }

     


        }

    }
}

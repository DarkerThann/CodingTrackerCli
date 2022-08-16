using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingTracker
{
    internal class Menu
    {
        private readonly CodingController controller = new CodingController();
        private readonly UserInput input = new UserInput();

        public void MenuOptions()
        {
            string[] menu = new string[]
                     {"Digite o número correspondente ao que deseja fazer\n",
                      "0 Sair",
                      "1 Ver todas as sessões",
                      "2 Criar uma nova sessão",
                      "3 Atualizar uma sessão",
                      "4 Deletar uma sessão\n"
                     };

            foreach (var options in menu)
            {
                Console.WriteLine(options);
            }
            MenuChoise();
        }

        private void MenuChoise()
        {
            Console.WriteLine("O que você deseja fazer?");
            string menuInput = Console.ReadLine();

            switch (menuInput)
            {
                case "0":
                    Environment.Exit(0);
                    break;
                case "1":                   
                    controller.GetAllCodingSession();
                    break;
                case "2":
                    input.UserValues();
                    controller.CreateCodingSession();
                    break;
                case "3":
                    input.Id();
                    input.UserValues();
                    controller.UpdateCodingSession();
                    break;
                case "4":
                    input.Id();
                    controller.DeleteCodingSession();
                    break;
            }
        
        }
        
    }
}

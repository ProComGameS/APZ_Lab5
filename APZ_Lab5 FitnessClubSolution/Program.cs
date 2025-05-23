using System;
using Autofac;
using FitnessClub.BLL.Interfaces;
using FitnessClub.DAL.Models;
using FitnessClub.UI;

namespace FitnessClub.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<APZ_Lab4_FitnessClubSolution.AutofacModule>();


            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var clubService = scope.Resolve<IClubService>();
                var memberService = scope.Resolve<IMemberService>();

                ShowMenu(clubService, memberService);
            }
        }

        private static void ShowMenu(IClubService clubService, IMemberService memberService)
        {
            Console.WriteLine("\n------ Фітнес клуб ------");
            Console.WriteLine("1. Переглянути клуби");
            Console.WriteLine("2. Зареєструватись на заняття");
            Console.WriteLine("3. Купити абонемент");
            Console.WriteLine("4. Вихід");
            Console.Write("Оберіть пункт: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": ShowClubs(clubService); break;
                case "2": RegisterSession(clubService); break;
                case "3": BuySubscription(clubService); break;
                case "4": Console.WriteLine("До побачення!"); break;
                default: Console.WriteLine("Невірний пункт меню."); break;
            }
        }

        private static void ShowClubs(IClubService clubService)
        {
            Console.WriteLine("\nСписок клубів:");
            foreach (var club in clubService.GetAllClubs())
            {
                Console.WriteLine($"ID: {club.Id}, Назва: {club.Name}, Локація: {club.Location}");
            }
        }

        private static void RegisterSession(IClubService clubService)
        {
            Console.Write("Введіть ID сесії: ");
            int sessionId = int.Parse(Console.ReadLine());

            Console.Write("Введіть ID вашої клубної картки: ");
            int cardId = int.Parse(Console.ReadLine());

            bool result = clubService.RegisterForSession(sessionId, cardId);
            Console.WriteLine(result ? "Реєстрація успішна!" : "Помилка реєстрації!");
        }

        private static void BuySubscription(IClubService clubService)
        {
            Console.Write("Введіть ID клубу: ");
            int clubId = int.Parse(Console.ReadLine());

            Console.Write("Введіть ID члена клубу: ");
            int memberId = int.Parse(Console.ReadLine());

            bool result = clubService.BuySubscription(clubId, memberId, CardType.Subscription);
            Console.WriteLine(result ? "Абонемент куплено!" : "Помилка!");
        }
    }
}

using System;
using System.Collections.Generic;
using FitnessClub.DAL;
using FitnessClub.BLL.Services;
using FitnessClub.BLL.DTOs;
using Microsoft.EntityFrameworkCore;
using FitnessClub.DAL.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FitnessClub.BLL;

namespace FitnessClub.UI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            
            serviceCollection.AddAutoMapper(cfg => cfg.AddProfile(new MappingProfiles()));
            
            serviceCollection.AddDbContext<FitnessClubContext>(options =>
                options.UseSqlite("Data Source=fitnessclub.db")); 
            
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            
            serviceCollection.AddTransient<ClubService>();
            serviceCollection.AddTransient<MemberService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var clubService = serviceProvider.GetService<ClubService>();
            var memberService = serviceProvider.GetService<MemberService>();

            ShowMenu(clubService, memberService);
        }

        private static void ShowMenu(ClubService clubService, MemberService memberService)
        {
            bool exit = false;
            while (!exit)
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
                    case "4": exit = true; break;
                    default: Console.WriteLine("Невірний пункт меню. Спробуйте знову."); break;
                }
            }
        }

        private static void ShowClubs(ClubService clubService)
        {
            Console.WriteLine("\nСписок клубів:");
            var clubs = clubService.GetAllClubs();
            foreach (var club in clubs)
            {
                Console.WriteLine($"ID: {club.Id}, Назва: {club.Name}, Локація: {club.Location}");
            }
        }

        private static void RegisterSession(ClubService clubService)
        {
            Console.Write("Введіть ID сесії: ");
            int sessionId = int.Parse(Console.ReadLine());

            Console.Write("Введіть ID вашої клубної картки: ");
            int cardId = int.Parse(Console.ReadLine());

            bool result = clubService.RegisterToSession(sessionId, cardId);
            Console.WriteLine(result ? "Реєстрація успішна!" : "Помилка реєстрації!");
        }

        private static void BuySubscription(ClubService clubService)
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

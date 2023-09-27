using System;
using System.Collections.Generic;

namespace ex35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string CommandAddDossier = "1";
            const string CommandShowAllDossier = "2";
            const string CommandDeleteDossier = "3";
            const string CommandExit = "4";

            bool isOpen = true;
            Dictionary<string, string> dossiers = new Dictionary<string, string>();

            while (isOpen)
            {
                Console.Write($"Добавить досье - {CommandAddDossier}\nПоказать все досье - {CommandShowAllDossier}" +
                    $"\nУдалить досье - {CommandDeleteDossier}\nВыйти из программы - {CommandExit}\n\nВведите номер команду: ");
                string chosenOperation = Console.ReadLine();

                switch (chosenOperation)
                {
                    case CommandAddDossier:
                        AddDossier(dossiers);
                        break;

                    case CommandShowAllDossier:
                        ShowAllDossier(dossiers);
                        break;

                    case CommandDeleteDossier:
                        DeleteDossier(dossiers);
                        break;

                    case CommandExit:
                        isOpen = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            bool isFound = true;
            Console.Clear();
            Console.Write("Введите ваши ФИО: ");
            string name = Console.ReadLine().ToUpper();

            if (dossiers.ContainsKey(name))
            {
                isFound = false;
                Console.WriteLine("Досье с такими ФИО уже существует...");
            }
            else
            {
                Console.Write("Введите вашу должность: ");
                string post = Console.ReadLine().ToUpper();
                dossiers.Add(name, post);
                Console.WriteLine($"{name} успешно добавлен...");
            }
        }

        static void ShowAllDossier(Dictionary<string, string> dossiers)
        {
            Console.Clear();
            Console.WriteLine("Список всех досье: ");

            foreach (var dossier in dossiers)
            {
                Console.WriteLine($"{dossier.Key} - {dossier.Value}");
            }
        }

        static void DeleteDossier(Dictionary<string, string> dossiers)
        {
            Console.Clear();
            Console.Write("Введите ФИО, чье досье вы хотите удалить: ");
            string name = Console.ReadLine().ToUpper();

            if (dossiers.ContainsKey(name))
            {
                dossiers.Remove(name);
                Console.WriteLine($"Досье {name} успешно удалено...");
            }
            else
            {
                Console.WriteLine("Такого досье не существует...");
            }
        }
    }
}

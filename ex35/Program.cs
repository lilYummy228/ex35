using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ex35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int CommandAddDossier = 1;
            const int CommandShowAllDossier = 2;
            const int CommandDeleteDossier = 3;
            const int CommandExit = 4;

            bool isOpen = true;
            Dictionary<string, string> dossiers = new Dictionary<string, string>();

            while (isOpen)
            {
                Console.Write($"Добавить досье - {CommandAddDossier}\nПоказать все досье - {CommandShowAllDossier}" +
                    $"\nУдалить досье - {CommandDeleteDossier}\nВыйти из программы - {CommandExit}\n\nВведите номер команду: ");
                string chosenOperation = Console.ReadLine();

                if (int.TryParse(chosenOperation, out int integer))
                {
                    switch (Convert.ToInt32(chosenOperation))
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
                }
                else
                {
                    Console.WriteLine("Неверный ввод...");
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        static void AddDossier(Dictionary<string, string> dossiers)
        {
            Console.Clear();
            Console.Write("Введите ваши ФИО: ");
            string name = Console.ReadLine().ToUpper();
            Console.Write("Введите вашу должность: ");
            string post = Console.ReadLine().ToUpper();
            dossiers.Add(name, post);
            Console.WriteLine($"{name} успешно добавлен...");
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

        static void DeleteDossier(Dictionary<string, string> dossier)
        {
            Console.Clear();
            Console.Write("Введите ФИО, чье досье вы хотите удалить: ");
            string name = Console.ReadLine().ToUpper();

            if (dossier.ContainsKey(name))
            {
                dossier.Remove(name);
                Console.WriteLine($"Досье {name} успешно удалено...");
            }
            else
            {
                Console.WriteLine("Такого досье не существует...");
            }
        }
    }
}

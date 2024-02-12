using System;
using System.Collections.Generic;

namespace MenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<MenuItem> menu = new List<MenuItem>()
            {
                new MenuItem("Coca Cola 150 ml", 2.50),
                new MenuItem("Insalata di pollo", 5.20),
                new MenuItem("Pizza Margherita", 10.00),
                new MenuItem("Pizza 4 Formaggi", 12.50),
                new MenuItem("Pz patatine fritte", 3.50),
                new MenuItem("Insalata di riso", 8.00),
                new MenuItem("Frutta di stagione", 5.00),
                new MenuItem("Pizza fritta", 5.00),
                new MenuItem("Piadina vegetariana", 6.00),
                new MenuItem("Panino Hamburger", 7.90)
            };

            Console.WriteLine("\r\n███    ███ ███████ ███    ██ ██    ██ \r\n████  ████ ██      ████   ██ ██    ██ \r\n██ ████ ██ █████   ██ ██  ██ ██    ██ \r\n██  ██  ██ ██      ██  ██ ██ ██    ██ \r\n██      ██ ███████ ██   ████  ██████  \r\n                                      \r\n                                      \r\n");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {menu[i].Name} (Euro {menu[i].Price:F2})");
            }
            Console.WriteLine("==============FINE MENU==============");
            Console.WriteLine($"{menu.Count + 1}: Stampa riepilogo ordine e conto finale");

            List<MenuItem> selectedItems = new List<MenuItem>();

            while (true)
            {
                Console.Write("Selezione: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    if (choice >= 1 && choice <= menu.Count)
                    {
                        selectedItems.Add(menu[choice - 1]);
                        Console.WriteLine($"Hai aggiunto {menu[choice - 1].Name} al conto.");
                    }
                    else if (choice == menu.Count + 1)
                    {
                        Console.WriteLine("\r\n ░▒▓██████▓▒░  ░▒▓███████▓▒░  ░▒▓███████▓▒░  ░▒▓█▓▒░ ░▒▓███████▓▒░  ░▒▓████████▓▒░ \r\n░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        \r\n░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        \r\n░▒▓█▓▒░░▒▓█▓▒░ ░▒▓███████▓▒░  ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓██████▓▒░   \r\n░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        \r\n░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓█▓▒░        \r\n ░▒▓██████▓▒░  ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓███████▓▒░  ░▒▓█▓▒░ ░▒▓█▓▒░░▒▓█▓▒░ ░▒▓████████▓▒░ \r\n                                                                                   \r\n                                                                                   \r\n");
                        foreach (var item in selectedItems)
                        {
                            Console.WriteLine($"{item.Name} (Euro {item.Price:F2})");
                        }

                        double totalPrice = CalculateTotalPrice(selectedItems);
                        Console.WriteLine($"\nCosto finale (compreso il servizio al tavolo di Euro 3.00): Euro {(totalPrice + 3.00):F2}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Selezione non valida.");
                    }
                }
                else
                {
                    Console.WriteLine("Inserimento non valido.");
                }
            }
        }

        static double CalculateTotalPrice(List<MenuItem> selectedItems)
        {
            double totalPrice = 0;
            foreach (var item in selectedItems)
            {
                totalPrice += item.Price;
            }
            return totalPrice;
        }
    }

    class MenuItem
    {
        public string Name { get; }
        public double Price { get; }

        public MenuItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}

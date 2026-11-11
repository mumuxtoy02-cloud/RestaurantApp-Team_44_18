using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp_Team_44_18
{
    class Restaurant
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Rating { get; set; }
    }

    internal class Program
    {
        static List<Restaurant> restaurants = new List<Restaurant>
    {
        new Restaurant { Name = "KFC", Type = "Fast Food", Rating = 4.2 },
        new Restaurant { Name = "MK", Type = "Suki", Rating = 4.7 },
        new Restaurant { Name = "Fuji", Type = "Japanese", Rating = 4.4 }
        new Restaurant { Name = "paizza", Type = "Italia", Rating = 4.9 }
        new Restaurant { Name = "BBQ plaza", Type = "Grill or roast", Rating = 4.3 }
        new Restaurant { Name = "McDonald's ", Type = "fast food" = 4.1 }
    };

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== Restaurant Menu =====");
                Console.WriteLine("1. Add Restaurant");
                Console.WriteLine("2. Show Good Rating");
                Console.WriteLine("3. Show Summary");
                Console.WriteLine("0. Exit");
                Console.Write("Select Menu: ");

                string menu = Console.ReadLine();

                switch (menu)
                {
                    case "1":
                        AddRestaurant();
                        break;
                    case "2":
                        ShowGoodRating();
                        break;
                    case "3":
                        ShowSummary();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid Menu");
                        break;
                }
            }
        }

        // คน A รับผิดชอบ
        static void AddRestaurant()
        {
            Console.Write("Enter restaurant name: ");
            string name = Console.ReadLine();

            Console.Write("Enter restaurant type: ");
            string type = Console.ReadLine();

            double rating;
            while (true)
            {
                Console.Write("Enter rating (0 - 5): ");
                if (double.TryParse(Console.ReadLine(), out rating) && rating >= 0 && rating <= 5)
                    break;
                Console.WriteLine("Invalid rating. Please enter a number between 0 and 5.");
            }

            restaurants.Add(new Restaurant { Name = name, Type = type, Rating = rating });
            Console.WriteLine("Restaurant added successfully!");
        }

        // คน B รับผิดชอบ
        static void ShowGoodRating()
        {
            Console.WriteLine("\n--- Restaurants with Rating ");

            var good = restaurants.Where(r => r.Rating >= 4.5).ToList();

            if (good.Count == 0)
            {
                Console.WriteLine("No restaurants with good rating.");
                return;
            }

            foreach (var r in good)
            {
                Console.WriteLine($"{r.Name} | {r.Type} | Rating: {r.Rating}");
            }
        }


        // คน C รับผิดชอบ
        static void ShowSummary()
        {
            Console.WriteLine("\n===== Restaurant Summary =====");

            
            if (restaurants.Count == 0)
            {
                Console.WriteLine("No restaurant data.");
                return;
            }

            
            Console.WriteLine("Total Restaurants: " + restaurants.Count);

            
            double averageRating = restaurants.Average(r => r.Rating);
            Console.WriteLine("Average Rating: " + averageRating.ToString("F2"));

            
            Restaurant topRestaurant = restaurants.OrderByDescending(r => r.Rating).First();

            Console.WriteLine("Top Rated Restaurant: " + topRestaurant.Name);
            Console.WriteLine("Highest Rating: " + topRestaurant.Rating);
        }
    }

}

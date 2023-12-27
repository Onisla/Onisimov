using System;
using System.Collections.Generic;
using System.IO;

namespace Main
{

    // Main Application Class
    public class ReservationApp
    {
        static void Main(string[] args)
        {
            ReservationManager manager = new ReservationManager();
            manager.AddRestaurant("A", 10);
            manager.AddRestaurant("B", 5);

            Console.WriteLine(manager.BookTable("A", new DateTime(2023, 12, 25), 3)); // True
            Console.WriteLine(manager.BookTable("A", new DateTime(2023, 12, 25), 3)); // False
        }
    }

    // Reservation Manager Class
    public class ReservationManager
    {
        private List<Restaurant> restaurants;

        public List<Restaurant> Restaurants
        {
            get { return restaurants; }
        }

        public ReservationManager()
        {
            restaurants = new List<Restaurant>();
        }

        public void AddRestaurant(string name, int tableCount)
        {
            try
            {
                Restaurant restaurant = new Restaurant();
                restaurant.Name = name;
                restaurant.Tables = new RestaurantTable[tableCount];

                for (int i = 0; i < tableCount; i++)
                {
                    restaurant.Tables[i] = new RestaurantTable();
                }

                restaurants.Add(restaurant);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void LoadRestaurantsFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');

                    if (parts.Length == 2 && int.TryParse(parts[1], out int tableCount))
                    {
                        AddRestaurant(parts[0], tableCount);
                    }
                    else
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public List<string> FindAllFreeTables(DateTime date)
        {
            try
            {
                List<string> freeTables = new List<string>();
                foreach (var restaurant in restaurants)
                {
                    for (int i = 0; i < restaurant.Tables.Length; i++)
                    {
                        if (!restaurant.Tables[i].IsBooked(date))
                        {
                            freeTables.Add($"{restaurant.Name} - Table {i + 1}");
                        }
                    }
                }
                return freeTables;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return new List<string>();
            }
        }

        public bool BookTable(string restaurantName, DateTime date, int tableNumber)
        {
            try
            {
                foreach (var restaurant in restaurants)
                {
                    if (restaurant.Name == restaurantName)
                    {
                        if (tableNumber < 0 || tableNumber >= restaurant.Tables.Length)
                        {
                            throw new Exception("Invalid table number");
                        }

                        return restaurant.Tables[tableNumber].Book(date);
                    }
                }

                throw new Exception("Restaurant not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public void SortRestaurantsByAvailabilityForUsers(DateTime date)
        {
            try
            {
                bool swapped;
                do
                {
                    swapped = false;
                    for (int i = 0; i < restaurants.Count - 1; i++)
                    {
                        int avTc = CountAvailableTables(restaurants[i], date);
                        int avTn = CountAvailableTables(restaurants[i + 1], date);

                        if (avTc < avTn)
                        {
                            // Swap restaurants
                            var temp = restaurants[i];
                            restaurants[i] = restaurants[i + 1];
                            restaurants[i + 1] = temp;
                            swapped = true;
                        }
                    }
                } while (swapped);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public int CountAvailableTables(Restaurant restaurant, DateTime date)
        {
            try
            {
                int count = 0;
                foreach (var table in restaurant.Tables)
                {
                    if (!table.IsBooked(date))
                    {
                        count++;
                    }
                }
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return 0;
            }
        }
    }

    // Restaurant Class
    public class Restaurant
    {
        public string Name { get; set; }
        public RestaurantTable[] Tables { get; set; }
    }

    // Table Class
    public class RestaurantTable
    {
        private HashSet<DateTime> bookedDates;

        public RestaurantTable()
        {
            bookedDates = new HashSet<DateTime>();
        }

        public bool Book(DateTime date)
        {
            try
            {
                if (bookedDates.Contains(date))
                {
                    return false;
                }

                bookedDates.Add(date);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        public bool IsBooked(DateTime date)
        {
            return bookedDates.Contains(date);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzShop
{
    class Player
    {
        public Dictionary<string, int> FoodUser;
        public Dictionary<string, int> Food;

        public Player(Dictionary<string, int> foodUser , Dictionary<string, int> food)
        {
            FoodUser = foodUser;
            Food = food;
        }

        public Dictionary<string, int> ChoosingProducts(Dictionary<string, int> foodUser, Dictionary<string, int> food)
        {
            string foodTipe = string.Empty;
            bool exitChooseFoodTipe = false;
            while (exitChooseFoodTipe == false)
            {
                foodTipe = Console.ReadLine();
                if (food.ContainsKey(foodTipe) == true && foodTipe != "exit")
                {
                    foodUser.Add(foodTipe, 0);
                }
                else if (foodTipe == "exit")
                {
                    exitChooseFoodTipe = true;
                }
            }

            int foodValue = 0;

            List<string> keys = new List<string>();

            foreach(var item in foodUser.Keys)
            {
                keys.Add(item);
            }
            foreach (var item in keys)
            {
                Console.Write($"Cколько вы хотите взять {item}: ");
                foodValue = int.Parse(Console.ReadLine());
                if (foodValue <= food[item])
                    foodUser[item] = foodValue;
            }
            return foodUser;
        }
    }

    class Seller
    {
        public Dictionary<string, int> Food;

        public Seller(Dictionary<string, int> food)
        {
            Food = food;
        }

        public void ShowMenu()
        {
            foreach (var item in Food)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        public Dictionary<string, int> SellingProduct(Dictionary<string, int> foodUser, Dictionary<string, int> food)
        {
            Player player = new Player(foodUser, food);
            foodUser = player.ChoosingProducts(foodUser, food);
            return foodUser;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, int> food = new Dictionary<string, int>();
            food.Add("арбуз", 15);
            food.Add("апельсин", 20);
            food.Add("персик", 25);
            food.Add("дыня", 15);
            Seller seller = new Seller(food);
            bool exit = false;
            string commandUser = string.Empty;
            Dictionary<string, int> foodUser = new Dictionary<string, int>();
            while (exit == false)
            {
                commandUser = Console.ReadLine();
                switch (commandUser)
                {
                    case "Show":
                        seller.ShowMenu();
                        break;
                    case "Buy":
                        foodUser = seller.SellingProduct(foodUser, food);
                        exit = true;
                        break;
                }
            }

            Console.WriteLine("Вот, что вы купили: ");

            foreach(var item in foodUser)
            {
                Console.WriteLine(item.Key + item.Value);
            }

            Console.ReadKey();
        }
    }
}






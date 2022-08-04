using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MultiShop
{
    class Program
    {
        static void Main(string[] args)
        {                     
            bool inShop = true;
            var customer = new Customer();
            while (inShop)
            {
                PrintMenu();
                var x = Console.ReadLine();
                var shop = GetShop(x);
                OpenShop(shop);

                var itemToAddToCart = Console.ReadLine();
                var item = GetItemFromItemId(itemToAddToCart, shop);
                
                customer.AddItemToShoppingCart(item);
                shop.PrintCartItemsAndCost(customer);

                var canAfford = shop.CheckOut(customer);
                if (canAfford)
                {
                    customer.BuyItemsInCart();
                }                
            }
        }

        private static Shop GetShop(string x)
        {
            switch (x)
            {
                case "f":
                   return new FoodShop();                 
                case "c":
                    return new ClothesShop();                 
                case "e":
                    return new ElectronicsShop();  
                default:
                    return new FoodShop();
            }
        }
        private static void PrintMenu()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("Welcome to the Multishop, what kind of shop do you want to enter?");
            Console.WriteLine("Food shop = f");
            Console.WriteLine("Clothes shop = c");
            Console.WriteLine("Electronics shop = e");
            Console.WriteLine("Exit shop = x");
        }

        private static Item GetItemFromItemId(string id, Shop foodShop)
        {
           return foodShop.Items.Where(Item => Item.Id == id).First();         
        }
       
        private static void OpenShop(Shop shop)
        {
            PrintMenu(shop);
        }

        private static void PrintMenu(Shop shop)
        {
            shop.PrintItems();
            Console.WriteLine("*************************");
            Console.WriteLine("What do you want to buy?");
        }
    }
}

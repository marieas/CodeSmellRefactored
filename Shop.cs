using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiShop
{
    public class Shop
    {
        public List<Item> Items { get; set; }
        Random random { get; set; } = new Random();
        public string ShopType { get; set; }
       
        public Shop(string shopType)
        {
            ShopType = shopType;
            GenerateItems();        
        }
        private void GenerateItems()
        {
            Items = new List<Item>();
            List<string> itemNames;

            if (ShopType == "c")
            {
                itemNames = Enum.GetNames(typeof(ClothesNames)).ToList();
            }
            else if (ShopType == "f")
            {
                itemNames =  Enum.GetNames(typeof(FoodNames)).ToList();
            }
            else
            {
                itemNames = Enum.GetNames(typeof(Electronics)).ToList();
            }

            int i = 1;
            foreach (var item in itemNames)
            {
                string itemString = Convert.ToString(item);
                int price = random.Next(100, 899);
                string itemId = i.ToString();
                var Item = new Item(itemId, price, itemString);
                Items.Add(Item);
                i++;
            }
        }

        public void PrintItems()
        {
            foreach (var item in Items)
            {
                Console.WriteLine($"item: {item.Id} {item.ItemName} costs {item.Price}.");
            }
        }

        public void PrintCartItemsAndCost(Customer customer)
        {
            Console.WriteLine("ShoppingCart now has: ");
            var totalPrice = 0;

            if (customer.ShopItems.Count == 0)
            {
                Console.WriteLine("No items in cart!");
                return;
            }

            foreach (var item in customer.ShopItems)
            {
                Console.WriteLine($"item: {item.Id} {item.ItemName} costs {item.Price}.");
                totalPrice += item.Price;
            }
            PrintTotalPriceMessage(totalPrice);
        }

        private void PrintTotalPriceMessage(int totalPrice)
        {
            Console.WriteLine("total price is: " + totalPrice);
            Console.WriteLine("******************");
            Console.WriteLine();
        }

        public bool CheckOut(Customer customer)
        {
            var totalPrice = 0;            
           
            foreach (var Item in customer.ShopItems)
            {
                totalPrice += Item.Price;
            }

            if (customer.BankInfo.EnoughFunds(totalPrice))
            {
                return true;
            }
            else
            {
                Console.WriteLine("You dont have enough funds");
                return false;
            }

        }
    }
}


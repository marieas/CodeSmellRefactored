using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop
{
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public BankInformation BankInfo { get; set; }
        public List<Item> ShopItems { get; set; }
        public List<string> Inventory { get; set; }       

        public Customer()
        {
            Address = new Address();
            BankInfo = new BankInformation();
            ShopItems = new List<Item>();
            Inventory = new List<string>();
        }
               
        public void AddItemToShoppingCart(Item item)
        {
            ShopItems.Add(item);
        }
        public void RemoveItemFromShoppingCart(Item item)
        {
            ShopItems.Remove(item);
        }
       
        public void BuyItemsInCart()
        {
            var totalPrice = 0;
            foreach (var item in ShopItems)
            {
                totalPrice += item.Price;
                Inventory.Add(item.ItemName);
            }
            Console.WriteLine("Items bought");
           
            ShopItems = new List<Item>();

            BankInfo.DeductFromBalance(totalPrice);
            Console.WriteLine($"Balance is now: {BankInfo.Balance}");
            Console.WriteLine("Inventory now contains: ");

            foreach(var item in Inventory)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop
{
    public class Item
    {
        public string Id { get; set; }
        public int Price { get; set; }
        public string ItemName { get; set; }

        public Item(string id,int price, string itemName)
        {
            Id = id;
            Price = price;
            ItemName = itemName;
        }
    }
}

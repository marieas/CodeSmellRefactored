using System;
using System.Collections.Generic;
using System.Text;

namespace MultiShop
{
    public class BankInformation
    {
        public string AccountNumber { get; set; }
        public string BankName { get; set; }
        public string Currency { get; set; }
        public int Balance { get; set; } = 50000;

        public bool EnoughFunds(int charge)
        {
            if (Balance > charge)
                return true;
            else
                return false;
        }
        public void DeductFromBalance(int charge)
        {
            Balance -= charge;
        }
    }
}

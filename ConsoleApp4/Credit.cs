using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Credit
{
    class Credit
    {
        public Guid Guid { get; set; }
        public Client.Client TheClient { get; set; }
        public decimal Amount { get; set; }
        public decimal Percent { get; private set; }
        public int Month { get; set; }
        public Credit(Guid id, Client.Client cl, decimal amount, int month)
        {
            Guid = id;
            TheClient = cl;
            Amount = amount;
            Month = month;
            CalculatePercent();
        }
        public void CalculatePercent()
        {
            decimal a;
            a = Amount / 100;
            Percent =  a * Month / 100;
        }
        public decimal MonthlyPay()
        {
            return Amount / Month;
        }
        public void Print()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"GuId : {Guid}");
            Console.WriteLine($"Client : {TheClient.Name}");
            Console.WriteLine($"Amount : {Amount}");
            Console.WriteLine($"Month : {Month}");
            Console.WriteLine($"Percent : {Percent}");
        }
    }
}

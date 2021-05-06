using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankWorker
{
    abstract class BankWorker : Human.Human
    {

        public string Position { get; set; }

        protected BankWorker(Guid id, string name, string surname, int age, string position, decimal salary) : base(id, name, surname, age, salary)
        {
            Position = position;
        }
        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Position: {Position}");

        }
    }
}

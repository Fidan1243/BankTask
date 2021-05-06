using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{

    class Client : Human.Human
    {
        public string Work_address { get; set; }
        public string Live_address { get; set; }
        public Client(Guid id, string name, string surname, int age, decimal salary, string w_a, string l_a) : base(id, name, surname, age, salary)
        {
            Work_address = w_a;
            Live_address = l_a;
        }
        override public void Print()
        {
            base.Print();
            Console.WriteLine($"Live Address: {Live_address}");
            Console.WriteLine($"Work Address: {Work_address}");
        }
    }

}

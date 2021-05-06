using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human
{
    abstract class Human
    {
        public Guid GuId { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public Human(Guid id, string name, string surname, int age, decimal salary)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
        }
        virtual public void Print()
        {
            Console.WriteLine("==================");
            Console.WriteLine($"GUID: {GuId}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Surname: {Surname}");
            Console.WriteLine($"Age: {Age}");
            Console.WriteLine($"Salary: {Salary}");
        }
    }
}

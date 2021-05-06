using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    class Manager : BankWorker.BankWorker, ConsoleApp3.IOrganize
    {
        public Worker.Worker[] Workers { get; set; }
        public Ceo.Ceo Ceo { get; set; }

        public int WorkerCount { get; set; }
        public Manager(Guid ID, string name, string surname, int age, string position, decimal salary) : base(ID, name, surname, age, position, salary)
        {
        }
        public void addWorker(Worker.Worker resource)
        {
            Worker.Worker[] temp = new Worker.Worker[++WorkerCount];
            if (Workers != null)
            {
                Workers.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = resource;
            Workers = temp;
        }
        public void Organize()
        {
            MakeMeeting();
        }
        private void MakeMeeting()
        {
            Random random = new Random();
            Console.WriteLine($"Hello {Workers[random.Next(0, WorkerCount)]}, Meeting started!");
        }
        public decimal CalculateSalaries()
        {
            decimal total = Ceo.Salary;
            foreach (var item in Workers)
            {
                total = item.Salary;
            }
            return total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceo
{
    class Ceo : BankWorker.BankWorker, ConsoleApp3.IOrganize
    {
        public Worker.Worker[] Workers { get; set; }
        public Manager.Manager[] Managers { get; set; }
        public int WorkerCount { get; set; }
        public int ManagerCount { get; set; }
        public Ceo(Guid ID, string name, string surname, int age, string position, decimal salary) : base(ID, name, surname, age, position, salary)
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
        public void addManager(Manager.Manager resource)
        {
            Manager.Manager[] temp = new Manager.Manager[++ManagerCount];
            if (Managers != null)
            {
                Managers.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = resource;
            Managers = temp;
        }
        public void Organize()
        {
            MakeMeeting();
        }
        public void MakeMeeting()
        {
            Random random = new Random();
            Console.WriteLine($@"Welcome to new meeting {Workers[random.Next(0, WorkerCount)].Name} Today we have importan content ");
        }
        public void Control(int choose)
        {
            if (choose == 1)
            {
                Console.WriteLine("==========Workers'_Salary==========");
                foreach (var item in Workers)
                {
                    Console.WriteLine($"{item.Name}'s salary: {item.Salary}");
                }
                Console.WriteLine("==========Managers'_Salary==========");
                foreach (var item in Managers)
                {
                    Console.WriteLine($"{item.Name}'s salary: {item.Salary}");
                }
            }
            else if (choose == 2)
            {
                Organize();
            }
        }

        public void DecreasePercentage(int percent)
        {
            Console.WriteLine(Salary);
            decimal a;
            a = (Salary / 100) * percent;
            Salary -= a;
            Console.WriteLine(Salary);
        }
    }
}

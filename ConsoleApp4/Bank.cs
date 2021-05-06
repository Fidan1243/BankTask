using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    class Bank
    {
        public string BankName { get; set; }
        public decimal Budget { get; set; }
        public decimal Profit { get; private set; }
        public Ceo.Ceo Ceo { get; set; }
        public Worker.Worker[] Workers { get; set; }
        public Credit.Credit[] Credits { get; set; }
        public Manager.Manager[] Managers { get; set; }
        public int WorkerCount { get; set; }
        public int ManagerCount { get; set; }
        public int ClientCount { get; set; }
        public Bank(string name, decimal budget, Ceo.Ceo ceo)
        {
            BankName = name;
            Budget = budget;
            Ceo = ceo;
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
        public void addClient(Credit.Credit resource)
        {
            Credit.Credit[] temp = new Credit.Credit[++ClientCount];
            if (Credits != null)
            {
                Credits.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = resource;
            Credits = temp;
        }
        public void ShowClientCredit(string fullname)
        {
            for (int i = 0; i < ClientCount; i++)
            {
                if (Credits[i].TheClient.Name == fullname)
                {
                    Credits[i].Print();
                }
            }
        }
        public void PayCredit(Client.Client cl, decimal money)
        {
            for (int i = 0; i < ClientCount; i++)
            {
                if (cl == Credits[i].TheClient)
                {
                    decimal d = Credits[i].MonthlyPay();
                    
                    Credits[i].Amount -= money;

                    if (d == money)
                    {
                        Credits[i].Month -= 1;
                    }
                    else
                    {
                        Credits[i].Month -= Convert.ToInt32(money / d);
                    }
                    
                }
            }
        }
        public void ShowAllCredits()
        {
            foreach (var item in Credits)
            {
                item.Print();
            }
        }
        public void ProfitCalculating()
        {
            decimal total = Ceo.Salary;
            for (int i = 0; i < ClientCount; i++)
            {
                total += Credits[i].Amount;
            }
            for (int i = 0; i < WorkerCount; i++)
            {
                total += Workers[i].Salary;
            }
            for (int i = 0; i < ManagerCount; i++)
            {
                total += Managers[i].Salary;
            }

            Profit = Budget - total;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helper
{
    class Helper
    {
        public void Starter()
        {
            Worker.Worker w1 = new Worker.Worker(Guid.NewGuid(), "Hakuna", "", 35, "Cart operations", 2123);
            Worker.Worker w2 = new Worker.Worker(Guid.NewGuid(), "Sun", "", 26, "Cart operations", 221);
            Worker.Worker w3 = new Worker.Worker(Guid.NewGuid(), "Moon", "", 37, "Cart operations", 1233);
            Worker.Worker w4 = new Worker.Worker(Guid.NewGuid(), "Sky", "", 40, "Cart operations", 223);
            w1.addOperation(new Operation.Operation(Guid.NewGuid(), "Cart Added", DateTime.Now));
            Worker.Worker[] workers = new Worker.Worker[4] { w1, w2, w3, w4 };

            Manager.Manager m1 = new Manager.Manager(Guid.NewGuid(), "Matata", "", 46, "Main Manager", 98123);
            m1.addWorker(w1);
            m1.addWorker(w2);
            m1.addWorker(w3);
            m1.addWorker(w4);
            Manager.Manager m2 = new Manager.Manager(Guid.NewGuid(), "Glass", "", 19, "Manager", 2721);
            m2.addWorker(w1);
            m2.addWorker(w2);
            Manager.Manager m3 = new Manager.Manager(Guid.NewGuid(), "Light", "", 29, "Manager", 12671);
            m3.addWorker(w3);
            m3.addWorker(w4);
            Manager.Manager m4 = new Manager.Manager(Guid.NewGuid(), "Blue", "", 41, "Manager", 82342);
            m4.addWorker(w1);
            m4.addWorker(w3);
            Manager.Manager[] managers = new Manager.Manager[4] { m1, m2, m3, m4 };

            Client.Client c1 = new Client.Client(Guid.NewGuid(), "Matatata", "Nana", 22, 34324, "X street,New York", "Y street, New Jersey");
            Client.Client c2 = new Client.Client(Guid.NewGuid(), "Last", "Glass", 56, 1434, "I don't work", "Y street, Vegas");
            Client.Client[] clients = new Client.Client[2] { c1, c2 };

            Ceo.Ceo ceo = new Ceo.Ceo(Guid.NewGuid(), "Hakuna", "", 35, "Ceo", 100000);
            ceo.addWorker(w1);
            ceo.addWorker(w2);
            ceo.addWorker(w3);
            ceo.addWorker(w4);
            ceo.addManager(m1);
            ceo.addManager(m2);
            ceo.addManager(m3);
            ceo.addManager(m4);

            Credit.Credit cr1 = new Credit.Credit(Guid.NewGuid(), c1, 20013, 6);
            Credit.Credit cr3 = new Credit.Credit(Guid.NewGuid(), c1, 142, 2);
            Credit.Credit cr2 = new Credit.Credit(Guid.NewGuid(), c2, 41500, 3);

            m1.Ceo = ceo;
            m2.Ceo = ceo;
            m3.Ceo = ceo;
            m4.Ceo = ceo;

            Bank.Bank bank = new Bank.Bank("Time bank", 10000000, ceo);

            Credit.Credit[] credits = new Credit.Credit[3] { cr1, cr2, cr3 };
            

            while (true)
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("1) Ceo");
                    Console.WriteLine("2) Worker");
                    Console.WriteLine("3) Manager");
                    Console.WriteLine("4) Client");
                    Console.WriteLine("5) Bank");
                    Choose(Console.ReadLine(), ref ceo, ref workers, ref managers, ref clients, ref credits, bank);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
        }
        public void Choose(string choose, ref Ceo.Ceo ceo, ref Worker.Worker[] workers, ref Manager.Manager[] managers, ref Client.Client[] clients, ref Credit.Credit[] credits, Bank.Bank bank)
        {
            bool IsInt = int.TryParse(choose, out int result);
            if (IsInt)
            {
                Console.Clear();
                if (result == 1)
                {
                    Console.WriteLine("1) For look your jobs in bank");
                    Console.WriteLine("2) For Decrease Salary with percentage");
                    CeoPart(ref ceo);
                }
                else if (result == 2)
                {
                    Console.Clear();
                    foreach (var item in workers)
                    {
                        item.Print();
                    }
                    Console.Write("Enter your Name:");
                    LookForWorkers(Console.ReadLine(), ref workers, 1);
                }
                else if (result == 3)
                {
                    Console.Clear();
                    foreach (var item in managers)
                    {
                        item.Print();
                    }
                    Console.Write("Enter your nane: ");
                    LookForManagers(Console.ReadLine(), ref managers, workers, ceo);
                }
                else if (result == 4)
                {
                    Console.Clear();
                    foreach (var item in clients)
                    {
                        item.Print();
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    foreach (var item in workers)
                    {
                        item.Print();
                    }
                    Console.Write("Enter your name: ");
                    string clname = Console.ReadLine();
                    Console.Write("Enter your cart manager name: ");
                    string wname = Console.ReadLine();
                    LookForClients(clname, wname, ref clients, ref credits, ref bank, ref workers, 1);
                }
                else if (result == 5)
                {
                    Console.Clear();
                    BankPart(ref bank);
                }
                else
                {
                    throw new Exception("Invalid number!");
                }
            }
            else
            {
                throw new Exception("Invalid type!");
            }
        }

        public void CeoPart(ref Ceo.Ceo ceo)
        {
            bool IsInt = int.TryParse(Console.ReadLine(), out int choose);
            if (IsInt)
            {
                if (choose == 1)
                {
                    Console.Clear();
                    Console.WriteLine("1) For Control menu");
                    Console.WriteLine("2) For Organize menu");
                    bool isInt2 = int.TryParse(Console.ReadLine(), out int ch);
                    if (isInt2 && ch == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("1) For Look Bank Workers' salaries");
                        Console.WriteLine("2) For Start Meeting");
                        bool isInt3 = int.TryParse(Console.ReadLine(), out int ch2);
                        if (isInt3)
                        {
                            ceo.Control(ch2);
                            Thread.Sleep(3000);
                        }
                    }

                    if (isInt2 && ch == 2)
                    {
                        Console.Clear();
                        ceo.Organize();
                        Thread.Sleep(3000);
                    }
                }
                else if (choose == 2)
                {
                    Console.Clear();
                    Console.Write("Enter percent for decrease: ");
                    bool isInt2 = int.TryParse(Console.ReadLine(), out int ch);
                    if (isInt2)
                    {
                        ceo.DecreasePercentage(ch);
                        Thread.Sleep(3000);
                    }
                }
            }
            else
            {
                throw new Exception("Invalid type!");
            }
        }
        public void WorkerPart(ref Worker.Worker w)
        {
            Console.Clear();
            Console.WriteLine("1) for operations");
            Console.WriteLine("2) for your information");
            bool IsInt = int.TryParse(Console.ReadLine(), out int choose);
            if (IsInt)
            {
                if (choose == 1)
                {
                    Console.Clear();
                    if (w.Operations != null)
                    {
                        for (int i = 0; i < w.OperationCount; i++)
                        {
                            w.Operations[i].Print();
                            Thread.Sleep(3000);
                        }
                    }
                }
                else if (choose == 2)
                {
                    Console.Clear();
                    w.Print();
                }
            }
            else
            {
                throw new Exception("Invalid type!");
            }
        }
        public void BankPart(ref Bank.Bank bank)
        {
            Console.Clear();
            Console.WriteLine("1) for Look clients' credits");
            Console.WriteLine("2) for Look profit of bank");
            bool IsInt = int.TryParse(Console.ReadLine(), out int choose);
            if (IsInt)
            {
                if (choose == 1)
                {
                    Console.Clear();
                    if (bank.Credits != null)
                    {
                        bank.ShowAllCredits();
                        Thread.Sleep(3000);
                    }
                }
                else if (choose == 2)
                {
                    Console.Clear();
                    bank.ProfitCalculating();
                    Console.WriteLine($"Profit of bank: {bank.Profit} azn");
                    Thread.Sleep(3000);
                }
            }
            else
            {
                throw new Exception("Invalid type!");
            }
        }
        public void ManagerPart(ref Manager.Manager m, Worker.Worker[] w, Ceo.Ceo c)
        {
            Console.Clear();
            Console.WriteLine("1) For organize something");
            Console.WriteLine("2) For Calculate Salaries");
            bool IsInt = int.TryParse(Console.ReadLine(), out int choose);
            if (IsInt)
            {
                if (choose == 1)
                {
                    Console.Clear();
                    m.Organize();
                    Thread.Sleep(3000);
                }
                else if (choose == 2)
                {
                    Console.Clear();
                    Console.Write($"Total of ");
                    foreach (var item in m.Workers)
                    {
                        Console.Write($" {item.Name}'s ,");
                    }
                    Console.WriteLine($"and {m.Ceo.Name}'s salaries: {m.CalculateSalaries()}");
                    Thread.Sleep(3000);
                    Thread.Sleep(3000);
                }
            }
            else
            {
                throw new Exception("Invalid type!");
            }
        }
        public void ClientPart(ref Client.Client cl, ref Credit.Credit[] credits, ref Bank.Bank bank, ref Worker.Worker w)
        {
            Console.Clear();
            Console.WriteLine("1) For look your credit(s)");
            Console.WriteLine("2) For add new credit");
            Console.WriteLine("3) For convert money to dollar");
            bool IsInt = int.TryParse(Console.ReadLine(), out int choose);
            if (IsInt)
            {
                if (choose == 1)
                {
                    Console.Clear();
                    foreach (var item in credits)
                    {
                        if (item.TheClient.Name == cl.Name)
                        {
                            item.Print();
                        }
                        
                    }
                    Thread.Sleep(3000);
                    Console.Clear();
                }
                else if (choose == 2)
                {
                    Console.Clear();
                    Console.Write("Enter amonut: ");
                    decimal amount = Convert.ToDecimal(Console.ReadLine());
                    Console.WriteLine("Enter month: ");
                    int month = Convert.ToInt32(Console.ReadLine());

                    w.addOperation(new Operation.Operation(Guid.NewGuid(), $"New credit was added in {cl.Name} account", DateTime.Now));
                    Credit.Credit[] cre = new Credit.Credit[credits.Length + 1];
                    for (int i = 0; i < credits.Length; i++)
                    {
                        cre[i] = credits[i];
                    }
                    cre[cre.Length - 1] = new Credit.Credit(Guid.NewGuid(), cl, amount, month);
                    credits = cre;
                }
                else if (choose == 3)
                {
                    Console.Clear();
                    Console.Write("Write amount: ");
                    bool isD = decimal.TryParse(Console.ReadLine(), out decimal res);
                    if (isD)
                    {
                        decimal dess = res * (17 / 10);
                        cl.Salary += res;
                        cl.Salary -= dess;
                        bank.Budget += dess * (17 / 10) - dess * (171 / 10);
                        bank.ProfitCalculating();
                    }
                }
            }
            else
            {
                throw new Exception("Invalid type!");
            }
        }

        public Worker.Worker LookForWorkers(string name, ref Worker.Worker[] w, int loo)
        {
            for (int i = 0; i < w.Length; i++)
            {
                if (w[i].Name == name)
                {
                    if (loo == 1)
                    {
                        WorkerPart(ref w[i]);
                    }
                    
                    return w[i];
                }
            }
            return null;
        }
        public void LookForManagers(string name, ref Manager.Manager[] m, Worker.Worker[] w, Ceo.Ceo c)
        {
            for (int i = 0; i < m.Length; i++)
            {
                if (m[i].Name == name)
                {
                    ManagerPart(ref m[i], w, c);
                    break;
                }
            }
        }
        public Client.Client LookForClients(string name, string wname, ref Client.Client[] c, ref Credit.Credit[] credits, ref Bank.Bank bank, ref Worker.Worker[] worker, int cw)
        {
            Client.Client cl = null;
            Worker.Worker wr = null;
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i].Name == name)
                {
                    cl = c[i];
                    break;
                }
            }
            wr = LookForWorkers(wname, ref worker, 0);
            if (cl == null || wr == null)
            {
                throw new Exception("Invalid worker name or client name");
            }
            else
            {
                if (cw == 1) ClientPart(ref cl, ref credits, ref bank, ref wr);
                else return cl;
            }
            return null;
        }
    }
}

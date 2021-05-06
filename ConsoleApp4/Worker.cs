using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    class Worker : BankWorker.BankWorker
    {
        public TimeSpan StartTime { get; set; } = new TimeSpan(9, 0, 0);
        public TimeSpan EndTime { get; set; } = new TimeSpan(20, 0, 0);
        public Operation.Operation[] Operations { get; set; }
        public int OperationCount { get; private set; } = 0;
        public Worker(Guid ID, string name, string surname, int age, string position, decimal salary) : base(ID, name, surname, age, position, salary)
        {

        }
        public void addOperation(Operation.Operation resource)
        {
            Operation.Operation[] temp = new Operation.Operation[++OperationCount];
            if (Operations != null)
            {
                Operations.CopyTo(temp, 0);
            }
            temp[temp.Length - 1] = resource;
            Operations = temp;

        }
        public override void Print()
        {
            base.Print();
            Console.Write("Work Times : {0:hh\\:mm}", StartTime);
            Console.WriteLine(" - {0:hh\\:mm}", EndTime);
        }
        public Operation.Operation this[int i]
        {
            get => Operations[i];
            set => Operations[i] = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operation
{
    class Operation
    {
        public Guid GuId { get; set; }
        public string Process_name { get; set; }
        public DateTime Date { get; set; }

        public Operation(Guid id, string p_name, DateTime dateTime)
        {
            Date = dateTime;
            Process_name = p_name;
            GuId = id;
        }
        public void Print()
        {
            Console.WriteLine("==========================");
            Console.WriteLine($"Process : {Process_name}");
            Console.WriteLine($"GuId : {GuId}");
            Console.WriteLine($"Date : {Date.ToLongDateString()}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ConsoleApp3
{

    interface IOrganize
    {
        void Organize();
    }

    class Program
    {
        static void Main(string[] args)
        {
            Helper.Helper helper = new Helper.Helper();
            helper.Starter();
        }
    }
}



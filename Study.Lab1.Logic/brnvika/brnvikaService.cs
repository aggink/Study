using Study.Lab1.Logic.brnvika.firstTask;
using Study.Lab1.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study.Lab1.Logic.brnvika
{
    public class brnvikaService : IRunService
    {
        public void RunTask1()
        {
            var num = new rationalNumbers(1, 1);
            Console.WriteLine(num.ToString());
        }

        public void RunTask2()
        {
            throw new NotImplementedException();
        }

        public void RunTask3()
        {
            throw new NotImplementedException();
        }
    }
}

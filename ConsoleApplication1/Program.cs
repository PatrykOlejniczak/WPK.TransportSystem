using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new BoostAccountCreator.BoostAccountCreatorServiceClient();




            var k = test.GetNewCodeFor(10.0);


        }
    }
}

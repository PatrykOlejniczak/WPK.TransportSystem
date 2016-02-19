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

            for (int i = 0; i < 10; i++)
            {
                var k = test.GetNewCodeFor(10.0);

                Console.WriteLine(k);
            }


            Console.ReadKey();
        }
    }
}

using System;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Boost code generator.");

            var test = new BoostAccountCreator.BoostAccountCreatorServiceClient();

            for (int i = 0; i < 10; i++)
            {
                var k = test.GetNewCodeFor(10.0);

                Console.WriteLine("Code: " + k);
            }

            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpTut1
{
    class Program
    {
        public static void Main()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    if (i % 2 == 0)
                    {

                        if (j % 2 == 0)
                        {
                            Console.Write("0");
                        }
                        else
                        {
                            Console.Write("X");
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            Console.Write("X");
                        }
                        else
                        {
                            Console.Write("0");
                        }
                    }
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}

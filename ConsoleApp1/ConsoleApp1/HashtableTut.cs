using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HashtableTut
    {
        public static void Main(String[] args)
        {
            Hashtable Ht = new Hashtable();
            Ht.Add("1", "A");
            Ht.Add("2", "B");
            Ht.Add("3", "C");
            Ht.Add("4", "D");

            ICollection key = Ht.Keys;
            foreach (string output in key)
            {
                Console.WriteLine(Ht[output]);
            }
            Console.WriteLine(Ht.ContainsKey("2"));
            Console.WriteLine(Ht.ContainsValue("C"));
            Console.ReadKey();
        }
    }
}

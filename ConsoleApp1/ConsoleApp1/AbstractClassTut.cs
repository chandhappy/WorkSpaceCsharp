using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class AbstractClassTut
    {
        public void Blank()
        {

        }

        /*   static void Main(String[] args)
            {
                AbstractClassTut1 Init = new AbstractClassTut1();
                Init.TutID = 27;
                Init.TutName = "Class C# Tut";
                Console.WriteLine(Init.getTutorial());
                Console.ReadKey();
            }*/
        }

        class AbstractClassTut1 : AbstractClassTut
        {
            public int TutID;
            public string TutName;

            public void setTutotial(int Tid, String Tname)
            {
                TutID = Tid;
                TutName = Tname;
            }
            public String getTutorial()
            {
                return TutName;
            }



        }



}

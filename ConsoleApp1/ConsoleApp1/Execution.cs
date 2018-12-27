using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Execution
    {
       protected int TutID;
       protected string TutName;

        public void setTutotial(int Tid, String Tname)
        {
            TutID = Tid;
            TutName = Tname;
        }
        public String getTutorial()
        {
            return TutName;
        }

        class ChildClass:Execution
        {
            public void RenameTutorial(string name)
            {
                this.TutName = name;
            }
        }

       /* static void Main(String[] args)
        {
            Execution Init = new Execution();
            Init.TutID = 27;
            Init.TutName = "Class C# Tut";
            Console.WriteLine(Init.getTutorial());

            ChildClass ch = new ChildClass();
            ch.TutName = "New Class C#";
            
            Console.Write(ch.getTutorial());
            Console.ReadKey();
        }*/
    }
}

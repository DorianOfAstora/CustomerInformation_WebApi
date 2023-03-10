using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Class1 : Class2
    {
        public Class3 GetClass3()
        {
            return new Class3 ();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Class1
    {
        private int x = 0;
        private int y = 1;
        public void count()
        {
            try
            {
                int m=x / y;
                if(m>0){
                    Console.WriteLine("m大于0");
                }
                else
                {
                    Console.WriteLine("m小于等于0");
                }
            }catch(Exception e){

            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB_MAS;
using LIB_8;

namespace LIB_8
{
    public static class CALCULATECOSINUS
    {
        public static string DisplaySUmmaCos(this Display array)
        {
            int sumCos = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 3)
                {
                    sumCos += array[i];
                }


            }

            return Math.Cos(sumCos).ToString();
        }
    }
}

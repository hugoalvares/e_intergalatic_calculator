using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntergalaticCalculator
{
    class File
    {
        public static string[] loadQueryFile(string stQueryFileLocation)
        {
            return System.IO.File.ReadAllLines(@stQueryFileLocation);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class RandomNumber
    {
        public static int randInt() {
            Random rnd = new Random();
            int _rand = rnd.Next(100000, 999999);
            return _rand;
        }

        
    }
}

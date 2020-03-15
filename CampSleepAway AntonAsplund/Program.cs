using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CampSleepAway_AntonAsplund.Database;

namespace CampSleepAway_AntonAsplund
{
    class Program
    {
        static void Main(string[] args)
        {
            var campSleepAwayMain = new CampSleepAwayMain(10, 3);
            campSleepAwayMain.RunMain();

        }
    }
}

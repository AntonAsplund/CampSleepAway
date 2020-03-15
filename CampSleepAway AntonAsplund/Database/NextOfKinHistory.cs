using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund.Database
{
    public class NextOfKinHistory
    {
        //On create timestampadded is used, on delete timestapremoved is used.
        //Methodcall is used instead of trigger
        public int NextOfKinHistoryID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int SocialSecurityNumber { get; set; }
        public int CamperID { get; set; }
        public int NextOfKinID { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

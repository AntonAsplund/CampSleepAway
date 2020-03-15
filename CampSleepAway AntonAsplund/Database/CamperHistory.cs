using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund.Database
{
    public class CamperHistory
    {
        //On Create the Checkin is used, On Delete the Checkout is used. On Update (i.e. camper moves to new cabin, timestamp is used)
        //Methodcall is used instead of trigger
        public int CamperHistoryID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int SocialSecurityNumber { get; set; }
        public int? CabinID { get; set; }
        public int CamperID { get; set; }
        public bool IsActive { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

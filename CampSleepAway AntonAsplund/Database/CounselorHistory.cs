using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund.Database
{
    public class CounselorHistory
    {
        //On Create, Delete, Update on Counselor a record is stored here.
        //Methodcall is used instead of trigger
        public int CounselorHistoryID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int SocialSecurityNumber { get; set; }
        public int CounselorID { get; set; }
        public int? CabinID { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

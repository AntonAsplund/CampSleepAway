using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund.Database
{
    public class NextOfKinCheckInCheckOut
    {
        //Mangaes visiting nextofkin. 

        public int NextOfKinCheckInCheckOutID { get; set; }
        [Required]
        public int CamperID { get; set; }
        [Required]
        public int NextOfKinID { get; set; }
        [Required]
        public bool IsPresent { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }

    }
}

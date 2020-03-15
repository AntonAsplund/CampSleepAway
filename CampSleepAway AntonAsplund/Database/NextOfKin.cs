using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CampSleepAway_AntonAsplund
{
    public class NextOfKin
    {

        public int NextOfKinID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Required]
        [Index("IX_CounselorUniqueSSN", IsUnique = true)]
        public int SocialSecurtyNumber { get; set; }



        //Camper navigational propertys and FK
        public int CamperID { get; set; }
        [ForeignKey("CamperID")]
        public virtual Camper Camper { get; set; }

    }
}

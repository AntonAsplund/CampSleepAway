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
    public class Camper
    {
        public Camper()
        {
            this.NextOfKins = new List<NextOfKin>();
        }

        public int CamperId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [Index("IX_CamperUniqueSSN", IsUnique = true)]
        public int SocialSecurityNumber { get; set; }


        //Camper navigational propertys and FK
        public int? CabinID { get; set; }
        [ForeignKey("CabinID")]
        public virtual Cabin Cabin { get; set; }


        //NextOfKin navigational propertys and FK
        public virtual ICollection<NextOfKin> NextOfKins { get; set; }

    }
}

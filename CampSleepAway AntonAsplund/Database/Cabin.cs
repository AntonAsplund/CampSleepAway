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
    public class Cabin
    {
        public Cabin()
        {
            this.Campers = new List<Camper>();
        }

        [Key]
        public int CabinID { get; set; }
        [Required]
        public int CabinNumber { get; set; }
        [Required]
        public string CabinNickName { get; set; }
        [Required]
        public int FreeCamperBunks { get; set; }
        [Required]
        public int TotalCamperBunks { get; set; }


        //Camper navigational propertys and FK
        public virtual ICollection<Camper> Campers { get; set; }

    }   
}

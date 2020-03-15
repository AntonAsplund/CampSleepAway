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
    public class Counselor
    {
        [Key]
        public int CounselorID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastNAme { get; set; }

        [Required]
        public int PhoneNumber { get; set; }

        [Index("IX_CounselorUniqueSSN", IsUnique = true)]
        public int SocialSecurityNumber { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund.Database
{
    public class CabinsCounselor
    {
        public int CabinsCounselorID { get; set; }

        [Index("UIX_OneSingleCounselor", IsUnique = true)]
        public int CounselorID { get; set; }
        [ForeignKey("CounselorID")]
        public virtual Counselor Counselor { get; set; }

        [Index("UIX_OneSingleCabin", IsUnique = true)]
        public int CabinID { get; set; }
        [ForeignKey("CabinID")]
        public virtual Cabin Cabin { get; set; }
    }
}

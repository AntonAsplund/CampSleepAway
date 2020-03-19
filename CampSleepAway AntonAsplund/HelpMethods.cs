using CampSleepAway_AntonAsplund.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSleepAway_AntonAsplund
{
    public static class HelpMethods
    {
        public static CamperHistory GetACamperHistory(Camper camper, bool isActive)
        {

            var camperHistory = new CamperHistory()
            {
                CamperID = camper.CamperId,
                FirstName = camper.FirstName,
                LastName = camper.LastName,
                SocialSecurityNumber = camper.SocialSecurityNumber,
                IsActive = isActive,
                TimeStamp = DateTime.UtcNow
            };

            if (camper.CabinID != null)
            {
                camperHistory.CabinID = camper.CabinID;
            }

            return camperHistory;
        }

        internal static NextOfKinHistory GetANextOfKinHistory(NextOfKin nextOfKin, bool isActive)
        {

            var nextOfKinHistory = new NextOfKinHistory()
            {
                FirstName = nextOfKin.FirstName,
                LastName = nextOfKin.LastName,
                PhoneNumber = nextOfKin.PhoneNumber,
                SocialSecurityNumber = nextOfKin.SocialSecurtyNumber,
                CamperID = nextOfKin.CamperID,
                NextOfKinID = nextOfKin.NextOfKinID,
                IsActive = isActive,
                TimeStamp = DateTime.UtcNow
            };

            return nextOfKinHistory;
        }

        internal static NextOfKinCheckInCheckOut GetANextOFKinCheckInCheckOut(NextOfKin nextOfKin, bool isPresent)
        {
            return  new NextOfKinCheckInCheckOut()
            {
                CamperID = nextOfKin.CamperID,
                NextOfKinID = nextOfKin.NextOfKinID,
                IsPresent = isPresent,
                TimeStamp = DateTime.UtcNow

            };
        }

        internal static CounselorHistory GetACounselorHistory(Counselor counselor)
        {
            var counselorHistory = new CounselorHistory()
            {
                FirstName = counselor.FirstName,
                LastName = counselor.LastNAme,
                PhoneNumber = counselor.PhoneNumber,
                SocialSecurityNumber = counselor.SocialSecurityNumber,
                CounselorID = counselor.CounselorID,
                TimeStamp = DateTime.UtcNow
            };

            try
            {
                using (var db = new CampSleepAwayContext())
                {
                    counselorHistory.CabinID = counselor.Cabin.CabinID;
                }

            }
            catch
            { 
            
            }

            return counselorHistory;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class EnrollmentDetails
    {
        public static int s_EnrollID=3000;
        public string EnrollID;
        public static int s_RegID=1000;
        public string RegID{get;}
        public static int s_CourseID=2000;
        public string CourseID{get;}
        public DateTime EnrollDate{get;set;}

        public EnrollmentDetails(string courseID,string regID,DateTime date)
        {
            s_EnrollID++;
            EnrollID="EMT"+s_EnrollID;
            CourseID=courseID;
            RegID=regID;
            
            EnrollDate=date;

        }
    }
}
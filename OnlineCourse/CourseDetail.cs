using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class CourseDetail
    {
        public static int s_CourseID=2000;
        public string CourseID;
        public string CourseName{get;set;}
        public string TrainerName{get;set;}
        public int Duration{get;set;}
        public int SeatAvailable{get;set;}

        public CourseDetail(string courseName,string trainerName,int duration,int seatsavailable)
        {
            s_CourseID++;
            CourseID="CS"+s_CourseID;
            CourseName=courseName;
            TrainerName=trainerName;
            Duration=duration;
            SeatAvailable=seatsavailable;
        }
    }
}
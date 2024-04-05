using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public enum Gender{select,Male,Female,Transgender}
    public class UserDetail
    {
        public static int s_RegID=1000;
        public string RegID;
        public string UserName{get;set;}
        public int Age{get;set;}
        public Gender Gender1{get;set;}
        public string Qualification{get;set;}
        public string MobNo{get;set;}
        public string MailID{get;set;}

        public UserDetail(string userName,int age,Gender gender,string qualification,string mobno,string mailID)
        {
            s_RegID++;
            RegID="SYNC"+s_RegID;
            UserName=userName;
            Age=age;
            Gender1=gender;
            Qualification=qualification;
            MobNo=mobno;
            MailID=mailID;
        }

    }
}
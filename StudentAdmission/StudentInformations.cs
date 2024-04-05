using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{

    
    public enum Gender{Select,Male,Female,TransGender}
    public class StudentInformations
    {
        public static int s_StudentID=3000;
        public String StudentName{get;set;}
        /// <summary>
        /// studentname property contains the name of the every student<see cref="StudentInformations"/> 
        /// </summary>
        /// <value></value>
        public String FatherName{get;set;}
        /// <summary>
        /// atherName property used to hold a fatherName of instance of<see cref="StudentInformations"/>
        /// </summary>
        /// <value></value>
        public DateTime DOB{get;set;}
        /// <summary>
        /// DOB property used to hold a datetime of instance of<see cref="StudentInformations"/>
        /// </summary>
        /// <value></value>
        public Gender Gender{get;set;}
        /// <summary>
        /// Gender property used to hold a gender of instance of<see cref="StudentInformations"/> 
        /// </summary>
        /// <value></value>
        public int Physics{get;set;}
        /// <summary>
        /// physics property used to hold a physics mark instance of<see cref="StudentInformations"/> 
        /// </summary>
        /// <value></value>
        public int Chemistry{get;set;}
        /// <summary>
        /// chemistry property used to hold a chemistry mark instance of<see cref="StudentInformations"/> 
        /// </summary>
        /// <value></value>
        public int Maths{get;set;}
        /// <summary>
        /// maths property used to hold a maths mark instance of<see cref="StudentInformations"/> 
        /// </summary>
        public String StudentID="SF";
        
        /// <summary>
        /// create an instance of student details
        /// </summary>
        /// <param name="studentName">Student name property used to assign its values to associated property</param>
        /// <param name="fatherName">father name property used to assign its values to associated property</param>
        /// <param name="dob">dob property property used to assign its values to associated property</param>
        /// <param name="gender">gender property property used to assign its values to associated property</param>
        /// <param name="physicsMarks">physics marks property used to assign its values to associated property</param>
        /// <param name="chemistryMarks">chemistry marks property used to assign its values to associated property</param>
        /// <param name="mathsMarks">math marks property used to assign its values to associated property</param> <summary>
        

        public StudentInformations(String studentName,String fatherName,DateTime dob,Gender gender,int physicsMarks,int chemistryMarks,int mathsMarks)
        {
            s_StudentID++;
            StudentID="SF"+s_StudentID;
            StudentName=studentName;
            FatherName=fatherName;
            DOB=dob;
            Gender=gender;
            Physics=physicsMarks;
            Chemistry=chemistryMarks;
            Maths=mathsMarks;
        }
        public StudentInformations()
        {

        }
  /// <summary>
  /// method checkeligibilty used to check whether the instance of<see cref="StudentInformations"/> 
  /// </summary>
  /// <param name="cutoff">Cutoff limit to find eligibility</param>
  /// <returns>returns true if eligible , else false</returns>
   public bool  CheckEligibility(double cutoff)
    {
        int total=Physics+Chemistry+Maths;
        double average=(double)total/3;
        return average>=cutoff;
    }
    }
}
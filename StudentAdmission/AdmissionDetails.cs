using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum AdmissionStatus { Select, Admitted, Cancelled }
    public class AdmissionDetails
    {
        public static int s_AdmissionID = 1000;
        public String AdmissionID;
        /// <summary>
        /// Admission id property hold a value of instance of <see cref="AdmissionDetails"/> 
        /// </summary>
        /// <value></value>

        public DateTime AdmissionDate { get; set; }
        /// <summary>
        /// admission date property hold a date of instance of <see cref="AdmissionDetails"/> 
        /// </summary>
        /// <value></value>

        public AdmissionStatus Status { get; set; }
        /// <summary>
        /// Admission status property hold a status of instance of <see cref="AdmissionDetails"/> 
        /// </summary>
        public static int s_StudentID = 3000;

        public String StudentID;
        /// <summary>
        /// Studentid is a property hold a id of instance of <see cref="AdmissionDetails"/> 
        /// </summary>
        public static int s_DepartmentID = 100;

        public String DepartmentID;
        /// <summary>
        /// Admission details constructor is used to initialize the parameter values to its properties
        /// </summary>
        /// <param name="studentID">studentId parameter used to assign its value to associated property</param>
        /// <param name="departmentID">department id parameter used to assign its value to associated property</param>
        /// <param name="admissiondate">admissiondate parameter used to assign its value to associated property</param>
        /// <param name="statusOfAdmission">status of admission parameter used to assign its value to associated property</param>
        public AdmissionDetails(String studentID, String departmentID, DateTime admissiondate, AdmissionStatus statusOfAdmission)
        {
            s_AdmissionID++;
            AdmissionID = "AID" + s_AdmissionID;
            s_StudentID++;
            StudentID = "SF" + s_AdmissionID;
             s_DepartmentID++;
             DepartmentID="DID"+s_DepartmentID;
            AdmissionDate = admissiondate;
            Status = statusOfAdmission;

        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{

    public class DepartmentDetails
    {
      public static int s_DepartmentID=100;
      /// <summary>
      /// dept id property used to hold a id of instance of<see cref="DepartmentDetails"/> 
      /// </summary>
      public  String DepartmentID;
      /// <summary>
      /// dept id property used to hold a id of instance of<see cref="DepartmentDetails"/>
      /// </summary>
      /// <value></value>
      public  String DepartmentName{get;set;}
      /// <summary>
      /// Department name property is used to hold the name of instance of <see cref="DepartmentDetails"/> 
      /// </summary>
      /// <value></value>
      public  int NumberOfSeat{get;set;}    
      
      /// <summary>
      /// Constructor departmentdetails used to initialize the parameter values to its properties
      /// </summary>
      /// <param name="departmentName">depatment name parameter used to assign its value to associated property </param>
      /// <param name="seatsAvailable">seats available parameter used to assign its value to associated property</param>//  

      public DepartmentDetails(String departmentName,int seatsAvailable)
      {
        s_DepartmentID++;
        DepartmentID="DID"+s_DepartmentID;
        DepartmentName=departmentName;
        NumberOfSeat=seatsAvailable;
      }   
      

    }
}
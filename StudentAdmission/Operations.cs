using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public class Operations
    {
        static List<StudentInformations> StudentInfo = new List<StudentInformations>();
        static StudentInformations currentStudent;
        static StudentInformations student;
        static StudentInformations studentObject12=new StudentInformations();


        static List<DepartmentDetails> DepartmentList = new List<DepartmentDetails>();
        static List<AdmissionDetails> AdmissionList = new List<AdmissionDetails>();

        public static void defaultValues()
        {
            StudentInfo.Add(new StudentInformations("Ravichandran", "Ettaiyappan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95));
            StudentInfo.Add(new StudentInformations("Baskaran", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95));

            DepartmentList.Add(new DepartmentDetails("EEE", 29));
            DepartmentList.Add(new DepartmentDetails("CSE", 29));
            DepartmentList.Add(new DepartmentDetails("MECH", 30));
            DepartmentList.Add(new DepartmentDetails("ECE", 30));

            AdmissionList.Add(new AdmissionDetails("SF3001", "DID101", new DateTime(2022, 05, 11), AdmissionStatus.Admitted));
            AdmissionList.Add(new AdmissionDetails("SF3002", "DID102", new DateTime(2022, 05, 12), AdmissionStatus.Admitted));

        }

        public static void Display()
        {
            foreach (StudentInformations studentObject in StudentInfo)
            {
                Console.WriteLine($"\nStudentName : {studentObject.StudentName}\nFatherName : {studentObject.FatherName}\nDateOfBirth : {studentObject.DOB.ToString("dd/MM/yyyy")}\nGender : {studentObject.Gender}\nPhysics marks : {studentObject.Physics}\nchemistryMarks : {studentObject.Chemistry}\nMathMarks : {studentObject.Maths}");
            }
            foreach (DepartmentDetails departmentObject in DepartmentList)
            {
                Console.WriteLine($"\nDepartment name : {departmentObject.DepartmentName}\nNumberofseat : {departmentObject.NumberOfSeat}");
            }
            foreach (AdmissionDetails admissionObj in AdmissionList)
            {
                Console.WriteLine($"\nStudentID : {admissionObj.StudentID}\nDepartmentID : {admissionObj.DepartmentID}\nAdmissionFDate : {admissionObj.AdmissionDate}\nAdmissionStatus : {admissionObj.Status}");
            }
        }
        public static void MainMenu()
        {
            String opinion;
            do
            {
                Console.Write($"Choose any option :\n1)Student Registration \n2)Student Login \n3)Department wise availability \n4)Exit");
                int selectOption = int.Parse(Console.ReadLine());
                switch (selectOption)
                {
                    case 1:
                        StudentRegistration();
                        break;
                    case 2:
                        StudentLogin();
                        break;
                    case 3:
                        DeptWiseSeatAvailability();
                        break;
                    case 4:
                        Console.WriteLine("Exit");
                        opinion = "no";
                        break;
                    default:
                        opinion = "no";
                        break;
                }
                Console.WriteLine("If you want to access the main menu ");
                opinion = Console.ReadLine().ToLower();
            } while (opinion == "yes");
        }
        public static void StudentRegistration()
        {
            String inputWord = "";
            do
            {
                Console.Write("Enter the Student Name : ");
                String studentName = Console.ReadLine();

                Console.Write("Enter the students father name : ");
                String fatherName = Console.ReadLine();

                Console.Write("Enter the Date Of birth : ");
                DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

                Console.Write("Enter the gender : ");
                Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);

                Console.Write("Enter the physics mark : ");
                int physicsMarks = int.Parse(Console.ReadLine());

                Console.Write("Enter the Chemistry marks : ");
                int chemistryMarks = int.Parse(Console.ReadLine());

                Console.Write("Enter the Maths Marks : ");
                int mathsMarks = int.Parse(Console.ReadLine());


                StudentInformations student = new StudentInformations(studentName, fatherName, dob, gender, physicsMarks, chemistryMarks, mathsMarks);
                StudentInfo.Add(student);
                Console.WriteLine($"\nSuccessfully added student details.....\nStudent id is : {student.StudentID}");

                Console.WriteLine("Do you want to add another details : ");
                inputWord = Console.ReadLine().ToLower();
            } while (inputWord == "yes");

        }
        public static void DeptWiseSeatAvailability()
        {
            foreach (DepartmentDetails vals in DepartmentList)
            {
                Console.Write($"deptName : {vals.DepartmentName}\nAvailability of seats : {vals.NumberOfSeat}");
            }
        }
        public static void StudentLogin()
        {
            Console.WriteLine("Enter the student ID : ");
            String searchID = Console.ReadLine();
            bool flag = false;

            foreach (StudentInformations students1 in StudentInfo)
            {
                if (searchID.Equals(students1.StudentID))
                {
                    flag = true;
                    currentStudent=students1;
                    SubMenu();
                    break;

                }
            }
            if (!flag)
            {
                Console.WriteLine("Invalid student id ");
            }

        }
        public static void SubMenu()
        {
            String option;
            do{
            Console.WriteLine("Choose anyone the option : \na)Check eligibility \nb)Show details \nc)Take admission \nd)Cancel admission \ne)show admission details \nf)Exit");
            char selectOption = Convert.ToChar(Console.ReadLine());
            switch (selectOption)
            {
                case 'a':
                    Console.WriteLine("Enter the cutoff");
                    double studentCutOff=Convert.ToDouble(Console.ReadLine());
                    studentObject12.CheckEligibility(studentCutOff);
                    break;

                case 'b':
                    ShowDetails();
                    break;

                case 'c':
                    TakeAdmission();
                    break;

                case 'd':
                    CancelAdmission();
                    break;

                case 'e':
                    ShowAdmissionDetails();
                    break;
                case 'f':
                    Console.WriteLine("Exit");
                    option="no";
                    break;
                default:
                    option="no";
                    break;

            }
            Console.WriteLine("If you want to access the submenu : ");
            option=Console.ReadLine();
            }while(option=="yes");

        }
        public static void ShowDetails()
        {
            foreach (StudentInformations values in StudentInfo)
            {
                Console.Write($"Name : {values.StudentName}\nFatherName : {values.FatherName}\nDateOfBirth : {values.DOB.ToString("dd/MM/yyyy")}\nGender : {values.Gender}\nPhysicsMarks : {values.Physics}\nChemistryMarks : {values.Chemistry}\nMathsMarks : {values.Maths}");
            }
        }
        public static void TakeAdmission()
        {

            foreach (DepartmentDetails department in DepartmentList)
            {
                Console.Write($"DepartmentName : {department.DepartmentName}\nSeatsAvailable : {department.NumberOfSeat}");
            }

            Console.WriteLine("select the  department ID : ");
            String selectDepartmentID = Console.ReadLine();

            //  DepartmentDetails deptobj=new DepartmentDetails(departmentName,seatsAvailable);
            // StudentInformations student=new StudentInformations(studentName,fatherName,dob,gender,physicsMarks,chemistryMarks,mathsMarks);

            foreach (DepartmentDetails dept in DepartmentList)
            {
                if (dept.DepartmentID.Equals(selectDepartmentID))
                {
                    if (student.CheckEligibility(75.0))
                    {
                        Console.WriteLine("He is eligible to take admission ");


                        if (dept.NumberOfSeat > 1)
                        {
                            int flag = 0;
                            foreach (AdmissionDetails admisionInfo in AdmissionList)
                            {
                                if (admisionInfo.StudentID.Equals(student.StudentID))
                                {
                                    if (admisionInfo.Status == AdmissionStatus.Cancelled)
                                    {
                                        flag = 1;
                                        admisionInfo.Status = AdmissionStatus.Admitted;
                                        dept.NumberOfSeat--;
                                        admisionInfo.AdmissionDate = DateTime.Now;
                                        dept.DepartmentID = selectDepartmentID;
                                    }
                                }
                            }
                            if (flag == 0)
                            {
                                AdmissionDetails obj = new AdmissionDetails(student.StudentID, dept.DepartmentID, DateTime.Now, AdmissionStatus.Admitted);
                                AdmissionList.Add(obj);
                            }

                        }

                    }
                }
            }
        }
            public static void CancelAdmission()
             {
                foreach(AdmissionDetails values in AdmissionList)
                {
                    if(currentStudent.StudentID.Equals(values.StudentID))
                    Console.Write($"Student ID : {values.StudentID} \nDEpartment Id : {values.DepartmentID}\nDate : {values.AdmissionDate}\nAdmission status : {AdmissionStatus.Admitted}");
                    if(values.Status==AdmissionStatus.Admitted)
                    {
                        values.Status=AdmissionStatus.Cancelled;
                    }
                    foreach(DepartmentDetails seatCount in DepartmentList){
                    if(values.Status==AdmissionStatus.Cancelled)
                    {
                        seatCount.NumberOfSeat-=1;
                    }
                }
                }
                Console.WriteLine("Admission cancelled successfully");
               
             }

             
             public static void ShowAdmissionDetails()
             {
                   foreach(AdmissionDetails values in AdmissionList)
                {
                    Console.Write($"Student ID : {values.StudentID} \nDEpartment Id : {values.DepartmentID}\nDate : {values.AdmissionDate}\nAdmission status : {values.Status}");
             }
             }
    }
}
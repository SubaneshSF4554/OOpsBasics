using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineCourse
{
    public class Operations
    {
        static List<UserDetail> userList = new List<UserDetail>();
        static UserDetail curUser;
        static List<CourseDetail> courseList = new List<CourseDetail>();
        static List<EnrollmentDetails> enrollList = new List<EnrollmentDetails>();

        public static void AddDefault()
        {
            userList.Add(new UserDetail("Ravichandran", 30, Gender.Male, "ME", "9938388333", "ravi@gmail.com"));
            userList.Add(new UserDetail("Priyadharshini", 25, Gender.Female, "BE", "9944444445", "priya@gmail.com"));

            courseList.Add(new CourseDetail("C#", "Baskaran", 5, 0));
            courseList.Add(new CourseDetail("HTML", "Ravi", 2, 5));
            courseList.Add(new CourseDetail("CSS", "Priyadharshini", 2, 3));
            courseList.Add(new CourseDetail("JS", "Baskaran", 3, 1));
            courseList.Add(new CourseDetail("TS", "Ravi", 1, 2));

            enrollList.Add(new EnrollmentDetails("CS2001", "SYNC1001", new DateTime(2024, 01, 28)));
            enrollList.Add(new EnrollmentDetails("CS2003", "SYNC1001", new DateTime(2024, 02, 15)));
            enrollList.Add(new EnrollmentDetails("CS2004", "SYNC1002", new DateTime(2024, 02, 18)));
            enrollList.Add(new EnrollmentDetails("CS2002", "SYNC1002", new DateTime(2024, 02, 20)));
        }
        public static void Display()
        {
            foreach (UserDetail user in userList)
            {
                Console.WriteLine($"UserName : {user.UserName}\nAge : {user.Age}\nGender : {user.Gender1}\nQualification : {user.Qualification}\nMobNo : {user.MobNo}\nMailID : {user.MailID}\n");
            }
            foreach (CourseDetail course in courseList)
            {
                Console.WriteLine($"CourseName : {course.CourseName}\nTrainerName : {course.TrainerName}\nDuration : {course.Duration}\nSeatsAvailable : {course.SeatAvailable}\n");
            }
            foreach (EnrollmentDetails enroll in enrollList)
            {
                Console.WriteLine($"RegID : {enroll.RegID}\nCourseID : {enroll.CourseID}\nDate : {enroll.EnrollDate.ToString("dd/MM/yyyy")}\n");
            }

        }

        public static void MainMenu()
        {
            Console.WriteLine("--------------Main Menu-------------");
            string opinion = "";
            do
            {
                Console.WriteLine("Choose any one from the options : \n1)User registration \n2)User Login \n3)Exit\n");
                int option;
                bool temp = int.TryParse(Console.ReadLine(), out option);
                while (!temp)
                {
                    temp = int.TryParse(Console.ReadLine(), out option);
                }
                switch (option)
                {
                    case 1:
                        UserRegistration();
                        break;
                    case 2:
                        UserLogIn();
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        opinion = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input ");
                        break;

                }
                Console.WriteLine("If you want again process the MainMenu say yes or no : ");
                opinion = Console.ReadLine().ToLower();
            } while (opinion == "yes");
        }
        public static void UserRegistration()
        {
            Console.Write("Enter the User Name : ");
            string userName = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the user's Age : ");
            int age;
            bool temp = int.TryParse(Console.ReadLine(), out age);
            while (!temp)
            {
                temp = int.TryParse(Console.ReadLine(), out age);
            }
            Console.WriteLine();

            Console.Write("Enter the Gender : ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine();

            Console.Write("Enter the Qualification of the user : ");
            string qualification = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the Mobile Number of the user : ");
            string mobno = Console.ReadLine();
            Console.WriteLine();

            Console.Write("Enter the GmailID of the user : ");
            string mailID = Console.ReadLine();
            Console.WriteLine();


            UserDetail userObj = new UserDetail(userName, age, gender, qualification, mobno, mailID);
            userList.Add(userObj);

            Console.WriteLine($"User Registration ID is : {userObj.RegID}");

        }

        public static void UserLogIn()
        {
            Console.WriteLine("You are in LogIn process");
            Console.WriteLine("Enter the userID for validating :");
            string userRegID = Console.ReadLine().ToUpper();
            bool flag = false;
            foreach (UserDetail user1 in userList)
            {
                if (userRegID.Equals(user1.RegID))
                {
                    Console.WriteLine("Valid User ID");
                    flag = true;
                    curUser = user1;
                    SubMenu();

                }
            }
            if (!flag)
            {
                Console.WriteLine("Invalid User ID .\n Please enter valid one");
            }

        }
        public static void SubMenu()
        {
            string option = "";
            do
            {
                Console.WriteLine("Choose any one from the list : \na)Enroll course \nb)View Enrollment History \nc)Next Enrollment \nd)Exit");
                char choice = Convert.ToChar(Console.ReadLine().ToLower());
                switch (choice)
                {
                    case 'a':
                        EnrollCourse();
                        break;
                    case 'b':
                        ViewEnrollHistory();
                        break;
                    case 'c':
                        NextEnrollment();
                        break;
                    case 'd':
                        Console.WriteLine("Exit");
                        option = "no";
                        break;
                    default:
                        Console.WriteLine("Enter a valid input");
                        break;

                }
                Console.WriteLine("If you want to again access the submenu : ");
                option = Console.ReadLine().ToLower();
            } while (option == "yes");
        }

        public static void EnrollCourse()
        {
            foreach (CourseDetail course in courseList)
            {
                Console.WriteLine($"CourseID : {course.CourseID} \nCourseName : {course.CourseName}\nTrainerName : {course.TrainerName}\nDuration : {course.Duration}\nSeatsAvailable : {course.SeatAvailable}");
            }
            Console.WriteLine("Enter the courseID :");
            string searchID = Console.ReadLine().ToUpper();
            bool flag = false;
            foreach (CourseDetail course in courseList)
            {
                if (searchID.Equals(course.CourseID))
                {
                    if (course.SeatAvailable > 0)
                    {
                        flag = true;
                        Console.WriteLine("Seats available for enroll the course");
                        int count = 0;
                        foreach (EnrollmentDetails enroll in enrollList)
                        {

                            if (curUser.RegID.Equals(enroll.RegID))
                            {
                                count++;

                            }
                            if (count < 2)
                            {
                                Console.WriteLine("User can enroll that course");
                                EnrollmentDetails newEnroll = new EnrollmentDetails(enroll.CourseID, curUser.RegID, DateTime.Now);
                                enrollList.Add(newEnroll);
                            }
                            else if (count == 2)
                            {
                                int num1 = 0, num2 = 0;
                                Console.WriteLine("Enter the enrolled course : ");
                                string course1 = Console.ReadLine().ToUpper();
                                string course2 = Console.ReadLine().ToUpper();
                                if (course1.Equals(course.CourseName))
                                {
                                    num1 = course.Duration;
                                }
                                else if (course2.Equals(course.CourseName))
                                {
                                    num2 = course.Duration;
                                }
                                DateTime date;
                                if (num1 < num2)
                                {
                                    date = enroll.EnrollDate.AddDays(num1);
                                }
                                else
                                {
                                    date = enroll.EnrollDate.AddDays(num2);
                                }


                                Console.WriteLine("You have already enrolled two course.You can enroll next course on" + date.ToString("dd/MM/yyyy"));
                            }
                        }
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("Seats are not available for the current course");
            }

        }
        public static void ViewEnrollHistory()
        {
            foreach (EnrollmentDetails enrollment in enrollList)
            {
                if (curUser.RegID.Equals(enrollment.RegID))
                {
                    Console.Write($"Course ID : {enrollment.CourseID}\nRegisterID : {enrollment.RegID}\nDate : {enrollment.EnrollDate.ToString("dd/MM/yyyy")}\n");
                }
            }

        }
        public static void NextEnrollment()
        {
            foreach (EnrollmentDetails enroll1 in enrollList)
            {
                if (curUser.RegID.Equals(enroll1.RegID))
                {
                    foreach (CourseDetail course1 in courseList)
                    {

                    
                        }
                    }
                }
            }
        }
    }

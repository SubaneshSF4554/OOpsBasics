using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Security;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class Operations
    {
        //Create the List for store the values
        static List<UserDetails> userList = new List<UserDetails>();
        static List<MedicineDetails> medicineList = new List<MedicineDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();

        static UserDetails currentUser;
        static MedicineDetails currentMedicine;
        static OrderDetails orderobj;

        //Default method for get a default methods 
        public static void DefaultValues()
        {
            //Add the default values by using the list
            userList.Add(new UserDetails("Ravi", 33, "Theni", "9877774440", 400.00));
            userList.Add(new UserDetails("Baskaran", 33, "Chennai", "8847757470", 500.00));

            medicineList.Add(new MedicineDetails("Paracitomal", 40, 5, new DateTime(2023, 12, 30)));
            medicineList.Add(new MedicineDetails("Calpol", 10, 5, new DateTime(2023, 11, 30)));
            medicineList.Add(new MedicineDetails("Gelucil", 3, 40, new DateTime(2024, 04, 30)));
            medicineList.Add(new MedicineDetails("Metrogel", 5, 40, new DateTime(2024, 12, 30)));
            medicineList.Add(new MedicineDetails("Povidin Iodin", 10, 40, new DateTime(2026, 10, 30)));

            orderList.Add(new OrderDetails("UID1001", "MD2001", 3, 15, new DateTime(2023, 11, 13), OrderStatus.Purchased));
            orderList.Add(new OrderDetails("UID1001", "MD2002", 2, 10, new DateTime(2023, 11, 13), OrderStatus.Cancelled));
            orderList.Add(new OrderDetails("UID1001", "MD2004", 2, 100, new DateTime(2023, 11, 13), OrderStatus.Purchased));
            orderList.Add(new OrderDetails("UID1002", "MD2003", 3, 120, new DateTime(2023, 01, 15), OrderStatus.Cancelled));
            orderList.Add(new OrderDetails("UID1002", "MD2005", 5, 250, new DateTime(2023, 01, 15), OrderStatus.Purchased));
            orderList.Add(new OrderDetails("UID1002", "MD2002", 3, 15, new DateTime(2023, 01, 15), OrderStatus.Purchased));

        }

        //display method for display all the default values 
        public static void display()
        {
            //traversing the user list for displaying
            foreach (UserDetails userObject1 in userList)
            {
                Console.WriteLine($"Username : {userObject1.UserName}\nAge : {userObject1.Age}\nCity : {userObject1.City}\nPhoneNumber : {userObject1.PhoneNumber}\nBalance : {userObject1.Balance}\n\n");
            }
            //traversing the medicine details for the displaying
            foreach (MedicineDetails medicineObj1 in medicineList)
            {
                Console.WriteLine($"MedicineName : {medicineObj1.MedicineName}\nAvailableCount : {medicineObj1.AvailableCount}\nPrice : {medicineObj1.Price}\nDateofExpiry : {medicineObj1.DateOfExpiry.ToString("dd/MM/yyyy")}\n\n");
            }
            //traversing the order details for displaying
            foreach (OrderDetails orderObject1 in orderList)
            {
                Console.WriteLine($"UserID : {orderObject1.UserId}\nMedicine ID : {orderObject1.MedicineId}\nMedicineCount : {orderObject1.MedicineCount}\nTotalPrice : {orderObject1.TotalPrice}\norderDate : {orderObject1.OrderDate.ToString("dd/MM/yyyy")}\nOrderStatus : {orderObject1.Orderstatus}\n");
            }
        }

        //Mainmneu method for show the deatils of the option for the user
        public static void MainMenu()
        {
            String userOption = "";
            do
            {
                Console.WriteLine("------mainMenu------");
                Console.WriteLine();
                Console.WriteLine("Choose any one of the option : \n1)User Registration \n2)User Login \n3)Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        UserRegistration();
                        break;
                    case 2:
                        UserLogin();
                        break;
                    case 3:
                        Console.WriteLine("Exit");
                        userOption = "no";
                        break;
                    default:
                        Console.WriteLine("Enter the valid input options");
                        userOption = "no";
                        break;
                }
                Console.WriteLine();
                Console.WriteLine("If you want again access the MainMenu : ");
                userOption = Console.ReadLine().ToLower();
            } while (userOption == "yes");
        }

        //User registration method for get a input from the user
        public static void UserRegistration()
        {
            string opinion = "";
            do
            {
                Console.WriteLine("Enter the userName : ");
                String userName = Console.ReadLine();

                Console.WriteLine("Enter the age of the user : ");
                int age = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the city of the user : ");
                String city = Console.ReadLine();

                Console.WriteLine("Enter the phoneNumber of the User : ");
                String phoneNumber = Console.ReadLine();

                Console.WriteLine("Enter the balance amount of the user : ");
                double balance = Convert.ToDouble(Console.ReadLine());

                //create an object for the userDetails class
                UserDetails obj1 = new UserDetails(userName, age, city, phoneNumber, balance);

                //Add the user detail to the list
                userList.Add(obj1);
                //print the UserID
                Console.WriteLine($"Your ID is {obj1.UserID}");

                Console.WriteLine("If you want to again access the registration : ");
                opinion = Console.ReadLine().ToLower();
            } while (opinion == "yes");
        }
        public static void UserLogin()
        {
            Console.WriteLine("Now you are in the login page \n");
            //ask the user input for validating the userID
            Console.WriteLine("Enter the UserID for searching : ");
            String searchID = Console.ReadLine();
            bool flag = false;
            //to validate the user id by the traversing the userdetails list
            foreach (UserDetails userObj2 in userList)
            {
                //validating the userid
                if (searchID.Equals(userObj2.UserID))
                {
                    flag = true;
                    currentUser=userObj2;
                    SubMenu();
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Invalid User ID Please enter a valid one ");
            }
        }
        //submenu method 
        public static void SubMenu()
        {
            String wish="";
            do{
            Console.WriteLine("Choose any one SubMenu from the below list : \na)ShowMedicineList \nb)PurchaseMedicine \nc)CancelPurchase \nd)Show Purchase History \ne)Recharge \nf)Show WalletBalance \ng)Exit");
            char selectchar=char.Parse(Console.ReadLine().ToLower());
            switch(selectchar)
            {
                case 'a':
                   ShowMedicineList();
                   break;
                case 'b':
                   PurchaseMedicine();
                   break; 
                case 'c':
                   CancelPurchase();
                   break;
                case 'd':
                   ShowPurchaseHistory();
                   break;
                case 'e':
                   Recharge();
                   break;
                case 'f':
                   ShowWalletBalance();
                   break;
                case 'g':
                   Console.WriteLine("Exit");
                   wish="no";
                   break;
                default:
                   Console.WriteLine("Enter the valid input ");
                   wish="no";
                   break;
            }
            Console.WriteLine("If you want to again access the SUBMENU : ");
            wish=Console.ReadLine().ToLower();
            }while(wish=="yes");
        }

        public static void ShowMedicineList()
        {
             //traversing the medicine details for the displaying
            foreach (MedicineDetails medicineObj1 in medicineList)
            {
                Console.WriteLine($"MedicineName : {medicineObj1.MedicineName}\nAvailableCount : {medicineObj1.AvailableCount}\nPrice : {medicineObj1.Price}\nDateofExpiry : {medicineObj1.DateOfExpiry.ToString("dd/MM/yyyy")}\n\n");
            }
        }
        public static void PurchaseMedicine()
        {
            //show the list of medicine details by traversing the medicine details
            foreach (MedicineDetails medicineObj1 in medicineList)
            {
                Console.WriteLine($"MedicineName : {medicineObj1.MedicineName}\nAvailableCount : {medicineObj1.AvailableCount}\nPrice : {medicineObj1.Price}\nDateofExpiry : {medicineObj1.DateOfExpiry.ToString("dd/MM/yyyy")}\n\n");
            }

            //Ask the user to select the medicine by using medicineID
            Console.WriteLine("/nEnter the medicine ID : ");
            String searchID1=Console.ReadLine();
            //ask the number of counts of that medicine he wants to buy
            Console.WriteLine("\nEnter the number of count of that medicine : ");
            int searchCount=int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the date : ");
            DateTime date=DateTime.ParseExact(Console.ReadLine(),"dd/MM/yyyy",null);
            //validate the medicineID by the travsersing medical list
            bool flag=false;
            foreach(MedicineDetails medicineobj3 in medicineList)
            {
                //validating the id
                if(searchID1.Equals(medicineobj3.MedicineID))
                {
                    if(searchCount<medicineobj3.AvailableCount)
                    {
                        //check the date for expiring the medicine
                        TimeSpan span=date-medicineobj3.DateOfExpiry;
                        double result=span.TotalDays;
                        Console.WriteLine(result);
                        if(result<0)
                        {
                            flag=true;
                            //current logged medicine
                            currentMedicine=medicineobj3;
                            Console.WriteLine("Medicine is available ");
                            //check the currentlogged user balance is enough for buy a medicine
                            if(currentUser.Balance>=currentMedicine.Price*currentMedicine.AvailableCount)
                            {
                                Console.WriteLine("Yes user have the amount for purchasing the medicine");
                                //check deduct balance by using call the deduct balance method
                                UserDetails.DeductBalance(currentMedicine.Price*currentMedicine.AvailableCount);
                                //calculate the total amount of the purchased medicines
                                double total=currentMedicine.Price*currentMedicine.AvailableCount;
                                Console.WriteLine("Total amount for purchase medicines are ; "+total);
                                //set the date is now
                                orderobj.OrderDate=DateTime.Now;
                                //set the order status is purchased
                                orderobj.Orderstatus=OrderStatus.Purchased;
                                Console.WriteLine("Medicine was purchased successfully");
                                                           

                            }
                        }

                    }
                }
            }
            if(!flag)
            {
                Console.WriteLine("Medicine is not available ");
            }
             
        }
        public static void CancelPurchase()
        {
             foreach (OrderDetails orderObject1 in orderList)
            { 
                //check the current user id to the order detail user id and then order status is purchased
               if(currentUser.UserID==orderObject1.UserId && orderObject1.Orderstatus==OrderStatus.Purchased)
               {
                   Console.WriteLine($"UserID : {orderObject1.UserId}\nMedicine ID : {orderObject1.MedicineId}\nMedicineCount : {orderObject1.MedicineCount}\nTotalPrice : {orderObject1.TotalPrice}\norderDate : {orderObject1.OrderDate.ToString("dd/MM/yyyy")}\nOrderStatus : {orderObject1.Orderstatus}\n");
               }

            }
            //ask the order id to the user for validate
            Console.WriteLine("Enter the order ID for validate : ");
            String searchID2=Console.ReadLine();
             foreach (OrderDetails orderObject1 in orderList)
            { 
                if(searchID2.Equals(orderObject1.OrderID) && orderObject1.Orderstatus==OrderStatus.Purchased)
                {
                  //if the order id is matched then increse the count of the medicine
                  currentMedicine.AvailableCount++;
                  //update the order status is cancelled
                  orderObject1.Orderstatus=OrderStatus.Cancelled;
                }
            }

            //if present then check its order status


        }
        public static void ShowPurchaseHistory()
        {
             foreach(OrderDetails orderObj1 in orderList)
             {
                if(currentUser.UserID==orderObj1.UserId)
                {
                    Console.WriteLine($"UserID : {orderObj1.UserId}\nMedicine ID : {orderObj1.MedicineId}\nMedicineCount : {orderObj1.MedicineCount}\nTotalPrice : {orderObj1.TotalPrice}\norderDate : {orderObj1.OrderDate.ToString("dd/MM/yyyy")}\nOrderStatus : {orderObj1.Orderstatus}\n");

                }
             }
        }
        public static void Recharge()
        {
            //ask the recharge amount to the user for recharging
            Console.WriteLine("Enter the amount for the recharge : ");
            double rechargeAmount=double.Parse(Console.ReadLine());
            UserDetails.WalletRecharge(rechargeAmount);
            

        }
        public static void ShowWalletBalance()
        {
            Console.WriteLine("Enter the amount : ");
            double deduct=double.Parse(Console.ReadLine());
            UserDetails.DeductBalance(deduct);
           
        }
    }
}
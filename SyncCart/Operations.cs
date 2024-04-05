using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{


    public class Operations
    {
        static List<CustomerDetails> customerList = new List<CustomerDetails>();
        static List<ProductDetails> productList = new List<ProductDetails>();
        static List<OrderDetails> orderList = new List<OrderDetails>();
        static CustomerDetails currentCustomer;

        //adding default details for customers

        //Adding default details for products
        //Adding default details for orders 
        public static void AddDefaultDetails()
        {
            customerList.Add(new CustomerDetails("Ravi", "Chennai", "9885858588", "ravi@mail.com", 5000));
            customerList.Add(new CustomerDetails("Baskaran", "Chennai", "9888475757", "baskaran@mail.com", 6000));

            productList.Add(new ProductDetails("Mobile(Samsung)", 10, 10000.0, 3));
            productList.Add(new ProductDetails("Tablet(Lenova)", 5, 15000.0, 2));
            productList.Add(new ProductDetails("Camera(sony)", 3, 20000.0, 4));
            productList.Add(new ProductDetails("iphone", 5, 50000.0, 6));
            productList.Add(new ProductDetails("Laptop(Lenova 13)", 3, 40000, 3));
            productList.Add(new ProductDetails("Headphone (Boat)", 5, 1000.0, 2));
            productList.Add(new ProductDetails("Speakers(Boat)", 4, 500.0, 2));

            orderList.Add(new OrderDetails("CID1001", "PID101", 2000.0, DateTime.Now, 2, OrderStatus.Ordered));
            orderList.Add(new OrderDetails("CID1001", "PID103", 4000.0, DateTime.Now, 2, OrderStatus.Ordered));
        }

        public static void DisplayDefaultDetails()
        {
            String Line = "------------------------------------------------------------------------------------";
            Console.WriteLine(Line);
            Console.WriteLine($"{"Customer ID",-10} | {"CustomerName",-10} | {"City",-10} | {"GmailId",-10} | {"WalletBalance",-10}");
            Console.WriteLine(Line);
            foreach (CustomerDetails customerobj1 in customerList)
            {
                Console.WriteLine($"{customerobj1.CustomerID,-11} | {customerobj1.CustomerName,-11} |  {customerobj1.CityName,-11} | {customerobj1.GmailID,-11} | {customerobj1.WalletBalance,-11}");
            }
            Console.WriteLine(Line);
            //Console.WriteLine($"{"Product ID,-10"} | {"Product Name,-10"} | {"productAvailablity,-10"} | {} ")
            foreach (ProductDetails productobj1 in productList)
            {
                Console.WriteLine($"ProductName : {productobj1.ProductName}\nAvailable stock : {productobj1.AvailableStock}\nProductPrice : {productobj1.ProductPrice}\nShippingDuration : {productobj1.ShippingDuration}");
            }
            foreach (OrderDetails orderobj1 in orderList)
            {
                Console.WriteLine($"CustomerID : {orderobj1.CustomerID1}\nProduct ID: {orderobj1.ProductID1}\nTotal price : ");
            }
        }


        public static void MainMenu()
        {
            Console.WriteLine("SYNCCART");
            //Display main menu
            Console.WriteLine("MainMenu : ");
            //ask the user input

            String option = "yes";
            do
            {
                Console.Write("Enter any one option : \n1)Customer Registration   \n2)Login   \n3)Exit");
                Console.WriteLine();
                int mainMenuChoice = int.Parse(Console.ReadLine());
                switch (mainMenuChoice)
                {
                    case 1:
                        CustomerRegistration();
                        Console.WriteLine("You have selected the Registration");
                        break;
                    case 2:
                        Login();
                        Console.WriteLine("You have selected the Login option ");
                        break;
                    case 3:
                        Console.WriteLine("Now you are selected Exit option");
                        option = "no";
                        break;
                    default:
                        Console.WriteLine("invalid Number enter the valid number ");
                        break;
                }

            } while (option == "yes");

        }
        //Registration
        public static void CustomerRegistration()
        {
            Console.WriteLine("CustomerRegistration methods is called");

            //ask the details from the user or customer
            Console.WriteLine("Enter the Customer Name : ");
            String customerName = Console.ReadLine();

            Console.WriteLine("Enter the city name : ");
            String cityName = Console.ReadLine();

            Console.WriteLine("Enter the mobile Number : ");
            String mobileNumber = Console.ReadLine();

            Console.WriteLine("Enter the mail ID ; ");
            String gmailID = Console.ReadLine();

            Console.WriteLine("Enter the wallet balance : ");
            double balance = Convert.ToDouble(Console.ReadLine());

            //details create the object for the customer class

            CustomerDetails customerObj1 = new CustomerDetails(customerName, cityName, mobileNumber, gmailID, balance);

            //add the customer details to the customer details list
            customerList.Add(customerObj1);

            //display customer id to the user
            Console.WriteLine($"The customer id is : {customerObj1.CustomerID}");
        }
        public static void Login()
        {
            Console.WriteLine("Login methods is called");
            //ask the customer id from the user
            Console.WriteLine("Enter the customer ID : ");
            String searchID = Console.ReadLine();

            bool flag = false;
            //traverse the customer detail list
            foreach (CustomerDetails customerobj2 in customerList)
            {
                //check the customer id is valid is and in the list
                //if is valid show login successfull//if valid navigate to submenu


                if (searchID.Equals(customerobj2.CustomerID))
                {
                    flag = true;
                    Console.WriteLine("The customer id is valid");
                    currentCustomer = customerobj2;
                    SubMenu();
                    //customer Current
                    break;

                }
            }
            if ((!flag))
            //else show invalid customer id
            {
                Console.WriteLine("Invalid user ID");
            }

        }
        public static void SubMenu()
        {
            Console.WriteLine("Submenu called");
            String option = "yes";
            do
            {
                Console.Write("Enter any one option : \n1)purchase   \n2)order History \n3)Cancel order \n4)Wallet balance \n5)Wallet Recharge \n6)Exit");
                Console.WriteLine();
                int subMenuChoice = int.Parse(Console.ReadLine());
                switch (subMenuChoice)
                {
                    case 1:
                        Purchase();
                        Console.WriteLine("You have selected the Purchase");
                        break;
                    case 2:
                        OrderHistory();
                        Console.WriteLine("You have selected the order history");
                        break;
                    case 3:
                        CancelOrder();
                        Console.WriteLine("Now you are selected cancel order");

                        break;
                    case 4:
                        WalletBalance();
                        Console.WriteLine("you have to select the wallet balance");
                        break;
                    case 5:
                        WalletRecharge();
                        Console.WriteLine("You select the wallet recharge");
                        break;
                    case 6:
                        Console.WriteLine("Exit");
                        option = "no";
                        break;
                    default:
                        Console.WriteLine("invalid Number enter the valid number ");
                        break;
                }

            } while (option == "yes");

        }
        public static void Purchase()
        {
            //show the product details(list the product details)
            foreach (ProductDetails productobj1 in productList)
            {
                Console.WriteLine($"ProductName : {productobj1.ProductName}\nAvailable stock : {productobj1.AvailableStock}\nProductPrice : {productobj1.ProductPrice}\nShippingDuration : {productobj1.ShippingDuration}");
            }

            //select the product using product id
            Console.WriteLine("Enter the product id : ");
            String searchProductID = Console.ReadLine();
            //check the product id is valid or not
            bool isValidProductID = false;
            foreach (ProductDetails productObj in productList)
            {
                if (searchProductID.Equals(productObj.ProductID))
                {
                    isValidProductID = true;
                    //if it is valid ask the count of product
                    Console.WriteLine("Enter the number of quantity you want");
                    int quantity = int.Parse(Console.ReadLine());
                    if (quantity <= productObj.AvailableStock && quantity > 0)
                    {
                        Console.WriteLine("Product is available");
                        double totalAmount = quantity * productObj.ProductPrice + 50;

                        //checked the current logged in users wallet balance >=total

                        if (totalAmount <= currentCustomer.WalletBalance)
                        {
                            //if yes deduct the total price from the current customers wallet balance
                            currentCustomer.DeductBalance(totalAmount);
                            Console.WriteLine($"totalAmount:{totalAmount}\nWalletbalance : {currentCustomer.DeductBalance}");
                            //reduce the quantity from the task
                            productObj.AvailableStock -= quantity;
                            //create an object for the order details
                            OrderDetails order = new OrderDetails(currentCustomer.CustomerID, productObj.ProductID, totalAmount, DateTime.Now, quantity, OrderStatus.Ordered);
                            orderList.Add(order);
                            Console.WriteLine($"order placed successfully.your order id is {order.OrderID}");
                            //calculate the shipping duration display the delivary date to the customer
                            DateTime delivaryDate = DateTime.Now.AddDays(productObj.ShippingDuration);
                            Console.WriteLine($"Delivary date is : {delivaryDate}");



                        }
                        //else show "Insufficient balance"
                        else
                        {
                            Console.WriteLine("Insufficient Wallet Balance Please recharge your wallet and do purchase again");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Required quantity is not available and available quantity is : {productObj.AvailableStock}");
                    }

                }
            }
            //is invalid product "shpw invalid product id "
            if (!isValidProductID)
            {
                Console.WriteLine("Invalid product id");
            }


        }
        public static void OrderHistory()
        {
            bool flag = false;
            //traverse the order details list 
            foreach (OrderDetails orderddetailsobj2 in orderList)
            {
                //check customer id in the (order detaillist==current customers customerID)
                if (orderddetailsobj2.CustomerID1.Equals(currentCustomer.CustomerID))
                {
                    flag = true;
                    //if exists show the order details of the current logged customer
                    Console.WriteLine($"Customer id : {orderddetailsobj2.CustomerID1}\nProduct id : {orderddetailsobj2.ProductID1}\ntotal price :{orderddetailsobj2.TotalPrice}\nPurchase date : {orderddetailsobj2.PurchaseDare}\nQuantity : {orderddetailsobj2.QuantityOfProduct}\nOrder status : {orderddetailsobj2.orderStatus}");
                }

            }
            //if does not exist no order found 
            if (!flag)
            {
                Console.WriteLine("Order not found");
            }




        }
        public static void CancelOrder()
        {
            //traverse the orders list
            bool flag = false;
            foreach (OrderDetails orderddetailsobj2 in orderList)
            {
                if (orderddetailsobj2.CustomerID1.Equals(currentCustomer.CustomerID) && orderddetailsobj2.orderStatus.Equals(OrderStatus.Ordered))
                {
                    flag = true;
                    Console.WriteLine($"Customer id : {orderddetailsobj2.CustomerID1}\nProduct id : {orderddetailsobj2.ProductID1}\ntotal price :{orderddetailsobj2.TotalPrice}\nPurchase date : {orderddetailsobj2.PurchaseDare}\nQuantity : {orderddetailsobj2.QuantityOfProduct}\nOrder status : {orderddetailsobj2.orderStatus}");
                }

            }
            //if does not exist no order found 
            if (!flag)
            {
                Console.WriteLine("Enter the order ID ");
                String ORDERID = Console.ReadLine().ToLower();
            }

            //check whther is current users order and orderstatus is ordered
            foreach (OrderDetails orderddetailsobj2 in orderList)
            {
                if (orderddetailsobj2.CustomerID1.Equals(currentCustomer.CustomerID) && orderddetailsobj2.orderStatus.Equals(OrderStatus.Ordered))
                {
                    foreach (ProductDetails product in productList)
                    {
                        if (orderddetailsobj2.OrderID.Equals(product.ProductID))
                        {
                            //if order exist ask the order id from the user to be cancelled
                            product.AvailableStock = orderddetailsobj2.QuantityOfProduct;
                            //refund the total price to the customers wallet
                            currentCustomer.WalletRecharge(orderddetailsobj2.TotalPrice-50);
                            //change the order status to cancelled after change the cancelled order display this("Your order has been cancelled)
                            orderddetailsobj2.orderStatus=OrderStatus.Cancelled;
                            //display ur id is cancelled
                            Console.WriteLine($"");


                        }
                    }

                }

                //check whther the order id is valid by traversing the order
                //If order id is valid traverse the product details list and check the (product id==product id in the order)
                //if product exists increase the stock of the product in the ordered details
                // if not show the no orders found message
            }
        }
            public static void WalletBalance()
            {
                //show the wallet balance of the current logged in customer
                Console.WriteLine($"Your wallet balance is : {currentCustomer.WalletBalance}");
            }
            public static void WalletRecharge()
            {
                //ask the user he wished to recharge or not
                Console.WriteLine("Do you want to wished to recharge : ");
                String choose = Console.ReadLine().ToLower();


                //check whether he wished to recharge
                //if yes ask the recharge amount
                if (choose == "yes")
                {
                    Console.WriteLine("Enter the amount to be recharge : ");
                    double amount = Convert.ToDouble(Console.ReadLine());
                    if (amount > 0)
                    {
                        currentCustomer.WalletRecharge(amount);
                        WalletBalance();
                    }
                    else
                    {
                        Console.WriteLine("Invalid amount");
                    }
                }


                //pass the recharge amount to the current customers wallet recharge method 
                //display the updated wallet balance to the customer
            }








        }



    }


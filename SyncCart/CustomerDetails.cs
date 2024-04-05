using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace SyncCart
{
    public class CustomerDetails
    {
        public static int s_CustomerID=1000;
        /// <summary>
        /// customer id property is hold a id of instance of<see cref="CustomerDetails"/> 
        /// </summary>
        public String CustomerID;
        /// <summary>
        /// Customer name property is hold the name of instance of <see cref="CustomerDetails"/> 
        /// </summary>
        /// <value></value>
        public String CustomerName{get;set;}
        /// <summary>
        /// Cityname property is hold the name of instance of <see cref="CustomerDetails"/> 
        /// </summary>
        /// <value></value>
        public String CityName{get;set;}
        /// <summary>
        /// MobileNumber property hold the number of instance of<see cref="CustomerDetails"/> 
        /// </summary>
        /// <value></value>
        public String MobileNumber{get;set;}
        /// <summary>
        /// GmailID property is hold the gmail of instance of <see cref="CustomerDetails"/> 
        /// </summary>
        /// <value></value>
        public String GmailID{get;set;}
        
        //Important for important this for example individual purpose this two lines and WalletRecharge method also
         private double _WalletBalance;
         /// <summary>
         /// Wallletbalance property hold the balance of instance of <see cref="CustomerDetails"/> 
         /// </summary>
         /// <value></value>
        public double WalletBalance{get{return _WalletBalance;}}

       /// <summary>
       /// CustomerDetails constructor used to initialize the parameter to the properties
       /// </summary>
       /// <param name="customerName">customername parameter used to assign its value to associated property </param>
       /// <param name="cityName">cityname parameter used to assign its value to associated property</param>
       /// <param name="mobileNumber">mobile number parameter used to assign its value to associated property</param>
       /// <param name="gmailID">gmail id parameter used to assign its value to associated property</param>
       /// <param name="balance">balance parameter used to assign its value to associated property</param>

        public CustomerDetails(String customerName,String cityName,String mobileNumber,String gmailID,double balance)
        {
            s_CustomerID++;
            CustomerID="CID"+s_CustomerID;
            CustomerName=customerName;
            CityName=cityName;
            MobileNumber=mobileNumber;
            GmailID=gmailID;
            _WalletBalance=balance;
        }
        /// <summary>
        /// wallet recharge method is used to find the balanmce amount of the user
        /// </summary>
        /// <param name="rechargeamount"></param>
        public void WalletRecharge(double rechargeamount){
            _WalletBalance+=rechargeamount;
        }
        /// <summary>
        /// deduct balance method is used to find the balanmce amount of the user
        /// </summary>
        /// <param name="deductbalance"></param>
        public void DeductBalance(double deductbalance)
        {
            _WalletBalance-=deductbalance;
        }
    
}}
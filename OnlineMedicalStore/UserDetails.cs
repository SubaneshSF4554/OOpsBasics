using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class UserDetails
    {
        public static int s_UserID=1000;
        public String UserID;
        public String UserName{get;set;}
        public int Age{get;set;}
        public String City{get;set;}
        public String PhoneNumber{get;set;}
        private static double _Balance;
        public double Balance{get{return _Balance;}}

        public UserDetails(String userName,int age,String city,String phoneNumber,double balance)
        {
            s_UserID++;
            UserID="UID"+s_UserID;
            UserName=userName;
            Age=age;
            City=city;
            PhoneNumber=phoneNumber;
            _Balance=balance;
        }
        //Wallet recharge method 
        public static void WalletRecharge(double rechargeAmount)
        {
            _Balance+=rechargeAmount;
            Console.WriteLine(_Balance);
        }
        public static void DeductBalance(double deductbalance)
        {
            _Balance-=deductbalance;
            Console.WriteLine(_Balance);
        }

    }
}
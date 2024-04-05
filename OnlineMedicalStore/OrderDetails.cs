using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{public enum OrderStatus{Select,Purchased,Cancelled}
    public class OrderDetails
    {
        public static int s_OrderID=3000;
        public String OrderID;
        public static int s_UserId=1000;
        public String UserId;
        public static int s_MedicineId=2000;
        public String MedicineId;
        public int MedicineCount{get;set;}
        public int TotalPrice{get;set;}
        public DateTime OrderDate{get;set;}
        public OrderStatus Orderstatus{get;set;}

        public OrderDetails(String userid,String medicineid,int medicinecount,int totalprice,DateTime orderdate,OrderStatus status)
        {
            s_OrderID++;
            OrderID="OID"+s_OrderID;

            s_UserId++;
            UserId="UID"+s_UserId;
            s_MedicineId++;
            MedicineId="MD"+s_MedicineId;
            UserId=userid;
            MedicineId=medicineid;
            MedicineCount=medicinecount;
            TotalPrice=totalprice;
            OrderDate=orderdate;
            Orderstatus=status;
        }

    }
}
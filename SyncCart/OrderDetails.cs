using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public enum OrderStatus{Select,Default,Ordered,Cancelled}
    public class OrderDetails
    {
        public static int s_OrderID=1000;
        /// <summary>
        /// order id is a property hold the id of instance of <see cref="OrderDetails"/> 
        /// </summary>
        public String OrderID;
        public static int s_CustomerID=1000;
        /// <summary>
        /// customer id property hold the id of instance of <see cref="OrderDetails"/> 
        /// </summary>
        /// <value></value>

        public String CustomerID1{get;set;}
         public static int s_ProductID=100;
         /// <summary>
         /// product id property hold the id of instance of <see cref="OrderDetails"/> 
         /// </summary>
         /// <value></value>

        public String ProductID1{get;set;}
        /// <summary>
        /// total price property hold the price of instance of <see cref="OrderDetails"/> 
        /// </summary>
        /// <value></value>
        public double TotalPrice{get;set;}
        /// <summary>
        /// purchase date property hold the date of instance of <see cref="OrderDetails"/> 
        /// </summary>
        /// <value></value>
        public DateTime PurchaseDare{get;set;}
        /// <summary>
        /// quantity property hold the quantity of instance of <see cref="OrderDetails"/> 
        /// </summary>
        /// <value></value>
        public int QuantityOfProduct{get;set;}
        /// <summary>
        /// order status property hold the status of instance of <see cref="OrderDetails"/> 
        /// </summary>
        /// <value></value>
        public OrderStatus orderStatus{get;set;}
        /// <summary>
        /// orderdetails constructor is used to initialize the parameter to the properties
        /// </summary>
        /// <param name="CustomerID">customer id parameter used to assign its value to associated property</param>
        /// <param name="ProductID">product id parameter used to assign its value to associated property</param>
        /// <param name="totalPrice">total price parameter used to assign its value to associated property</param>
        /// <param name="purchaseDate">purchase date parameter used to assign its value to associated property</param>
        /// <param name="quantity">quantity parameter used to assign its value to associated property</param>
        /// <param name="status">status parameter used to assign its value to associated property</param>

        public OrderDetails(String CustomerID,String ProductID,double totalPrice,DateTime purchaseDate,int quantity,OrderStatus status)
        {
            s_OrderID++;
            OrderID="OID"+s_OrderID;
            s_CustomerID++;
            CustomerID1="CID"+s_CustomerID;
            s_ProductID++;
            ProductID1="PID"+s_ProductID;
            TotalPrice=totalPrice;
            PurchaseDare=purchaseDate;
            QuantityOfProduct=quantity;
            orderStatus=status;
                    }

    }
}
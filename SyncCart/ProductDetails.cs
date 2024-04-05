using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SyncCart
{
    public class ProductDetails
    {
        public static int s_ProductID=100;
        /// <summary>
        /// product id property hold the id of the instance of <see cref="ProductDetails"/> 
        /// </summary>
        public String ProductID;
        /// <summary>
        /// product name property hold the name of the instance of <see cref="ProductDetails"/> 
        /// </summary>
        /// <value></value>
        public String ProductName{get;set;}
        /// <summary>
        /// Available stock property is hold the stock of the instance of <see cref="ProductDetails"/> 
        /// </summary>
        /// <value></value>
        public int AvailableStock{get;set;}
        /// <summary>
        /// product price property is hold the price of the instance of <see cref="ProductDetails"/> 
        /// </summary>
        /// <value></value>
        public double ProductPrice{get;set;}
        /// <summary>
        /// shipping duration property is hold the date of instance of <see cref="ProductDetails"/> 
        /// </summary>
        /// <value></value>
        public int ShippingDuration{get;set;}
        /// <summary>
        /// productDetails constructor is used to initialize the parameter to the properties
        /// </summary>
        /// <param name="productName">productname wallet recharge method is used to find the balanmce amount of the user</param>
        /// <param name="availableStock">available stock wallet recharge method is used to find the balanmce amount of the user</param>
        /// <param name="productPrice">product price wallet recharge method is used to find the balanmce amount of the user</param>
        /// <param name="shippingDuration">shipping duration wallet recharge method is used to find the balanmce amount of the user</param>

        public ProductDetails(String productName,int availableStock,double productPrice,int shippingDuration)
        {
            s_ProductID++;
            ProductID="PID"+s_ProductID;
            ProductName=productName;
            AvailableStock=availableStock;
            ProductPrice=productPrice;
            ShippingDuration=shippingDuration;
        }
        
    }
}
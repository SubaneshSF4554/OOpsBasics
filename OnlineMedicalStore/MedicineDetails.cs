using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineMedicalStore
{
    public class MedicineDetails
    {
        public static int s_MedicineID=2000;
        public String MedicineID;
        public String MedicineName{get;set;}
        public int AvailableCount{get;set;}
        public int Price{get;set;}
        public DateTime DateOfExpiry{get;set;}

        public MedicineDetails(String medicineName,int availableCount,int price,DateTime dateofExpiry)
        {
            s_MedicineID++;
            MedicineID="MD"+s_MedicineID;
            MedicineName=medicineName;
            AvailableCount=availableCount;
            Price=price;
            DateOfExpiry=dateofExpiry;
        }
        
    }
}
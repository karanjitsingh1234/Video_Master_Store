using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Master_Store
{
    public class Customer
    {
        private String Customer_Name;
        private String Customer_Email;
        private String Customer_Phone;
        private String Customer_Address;

        private void setCustomerName(String Name) {
               this.Customer_Name=Name; 
        }

        public String getCustomerName() {
            return Customer_Name; 
        }

        private void setCustomerEmail(String Email)
        {
            this.Customer_Email =Email;
        }

        public String getCustomerEmail()
        {
            return Customer_Email;
        }

        private void setCustomerPhone(String Phone)
        {
            this.Customer_Phone = Phone;
        }

        public String getCustomerPhone()
        {
            return Customer_Phone;
        }

        private void setCustomerAddress(String address)
        {
            this.Customer_Address =address;
        }

        public String getCustomerAddress()
        {
            return Customer_Address;
        }

        public Customer(String Name,String Email,String Phone,String Address) {
            setCustomerName(Name);
            setCustomerEmail(Email);
            setCustomerPhone(Phone);
            setCustomerAddress(Address);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Master_Store
{
  public  class Rent
    {

        private int CustomerID;
        private int MovieId;
        private String BookingDate;
        private String returnDate;

        public void setCustomerID(int ID) {
            this.CustomerID = ID;
        }
        public int getCustomerID() {
            return CustomerID;
        }

        public void setMovieID(int ID)
        {
            this.MovieId = ID;
        }
        public int getMovieID()
        {
            return MovieId;
        }


        public void setDate(String Bookdate) {
            this.BookingDate = Bookdate;
        }
        public String getDate() {
            return BookingDate;
        }


        public void setreturnDate(String returndate)
        {
            this.returnDate = returndate;
        }
        public String getreturnDate()
        {
            return returnDate;
        }



        public Rent(int CustomerID,int MovieId,String issueDate,String returnDate) {
            setCustomerID(CustomerID);
            setMovieID(MovieId);
            setDate(issueDate);
            setreturnDate(returnDate);



        }



    }
}

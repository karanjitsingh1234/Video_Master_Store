using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Video_Master_Store
{
   public class Video
    {
        private String Name;
        private String Ratting;
        private int VideoYear;
        private int VideoCopies;



        private void setName(String Name ) {
            this.Name = Name;
        }
        public String getName() {
            return Name;
        }

        private void setRatting(String Ratting)
        {
            this.Ratting = Ratting;
        }
        public String getRatting()
        {
            return Ratting;
        }

        private void setYear(int Year)
        {
            this.VideoYear = Year;
        }
        public int getYear()
        {
            return VideoYear;
        }


        private void setCopies(int Copies)
        {
            this.VideoCopies =Copies;
        }
        public int getCopies()
        {
            return VideoCopies;
        }


        public Video(String Name,String Ratting,int Year,int Copies) {

            setName(Name);
            setRatting(Ratting);
            setYear(Year);
            setCopies(Copies);

        }

    }
}

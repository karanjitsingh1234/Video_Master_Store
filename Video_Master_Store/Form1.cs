using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Video_Master_Store
{
    public partial class Form1 : Form
    {
        int cost = 2;
        
        public Form1()
        {
            InitializeComponent();
        }




        private void button5_Click(object sender, EventArgs e)
        {
            if (!CustomerName.Text.ToString().Equals("") && !customerEmail.Text.ToString().Equals("") && !CustomerPhone.Text.ToString().Equals("") && !CustomerAddress.Text.ToString().Equals(""))
            {
                //pass the value to the database after verfication 
                Customer obj = new Customer(CustomerName.Text.ToString(), customerEmail.Text.ToString(), CustomerPhone.Text.ToString(), CustomerAddress.Text.ToString());
                String sqlcmd = "insert into Customer(CustomerName,CustomerEmail,CustomerPhone,CustomerAddress) values('" + obj.getCustomerName() + "','" + obj.getCustomerEmail() + "','" + obj.getCustomerPhone() + "','" + obj.getCustomerAddress() + "')";
                Connection instance_connection = new Connection();
                instance_connection.SqlQuery(sqlcmd);
                MessageBox.Show("Customer Record is saved ");

                CustomerAddress.Text = "";
                customerEmail.Text = "";
                CustomerName.Text = "";
                CustomerPhone.Text = "";

            }
            else
            {
                MessageBox.Show("Fill all the required detail to store ");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!Customer_ID.Text.ToString().Equals(""))
            {
                Connection instance_connection = new Connection();


                DataTable dtTable = new DataTable();
                dtTable = instance_connection.srchRecord("select * from Rent where CustomerID=" + Convert.ToInt32(Customer_ID.Text.ToString()) + " and MovieReturn='1'");
                if (dtTable.Rows.Count == 0)
                {


                    String sqlcmd = "delete from Customer where CustomerID=" + Convert.ToInt32(Customer_ID.Text.ToString()) + "";

                    instance_connection.SqlQuery(sqlcmd);
                    MessageBox.Show("Customer Record is deleted ");
                }
                else {
                    MessageBox.Show("first return the Video First ");
                }
                CustomerAddress.Text = "";
                customerEmail.Text = "";
                CustomerName.Text = "";
                CustomerPhone.Text = "";

            }
            else
            {
                MessageBox.Show("Select the Customer First then You can delete ");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!Customer_ID.Text.ToString().Equals("") && !CustomerName.Text.ToString().Equals("") && !customerEmail.Text.ToString().Equals("") && !CustomerPhone.Text.ToString().Equals("") && !CustomerAddress.Text.ToString().Equals(""))
            {
                String sqlcmd = "update Customer set CustomerName='" + CustomerName.Text.ToString() + "',CustomerEmail='" + customerEmail.Text.ToString() + "',CustomerPhone='" + CustomerPhone.Text.ToString() + "',CustomerAddress='" + CustomerAddress.Text.ToString() + "' where CustomerID="+Convert.ToInt32(Customer_ID.Text.ToString())+"";
                Connection instance_connection = new Connection();
                instance_connection.SqlQuery(sqlcmd);
                MessageBox.Show("Customer Record is Upadted ");
                CustomerAddress.Text = "";
                customerEmail.Text = "";
                CustomerName.Text = "";
                CustomerPhone.Text = "";

            }
            else {
                MessageBox.Show("Fill all details to upate the record of the Customer");
            }


        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (!MovieName.Text.ToString().Equals("") && !MovieRatting.Text.ToString().Equals("") && !MovieYear.Text.ToString().Equals("") && !MovieCopies.Text.ToString().Equals(""))
            {

                Video obj = new Video(MovieName.Text.ToString(),MovieRatting.Text.ToString(),Convert.ToInt32(MovieYear.Text.ToString()),Convert.ToInt32(MovieCopies.Text.ToString()));

                Connection instance_Connection = new Connection();

                // local variable to store the value of the cost 
                

                //get the curreent date and time 
                DateTime dateNow = DateTime.Now;

                // get the year 
                int Currentyear = dateNow.Year;

                //get the difference between year 
                int diffYear = Currentyear -obj.getYear();

                //get the difference if the difference is greater then 5 then the cost is 2 dollar otherwise 5 dollar 
                if (diffYear >= 5)
                {
                    cost = 2;
                }
                if (diffYear >= 0 && diffYear < 5)
                {
                    cost = 5;
                }

                //pass the query to store the data in the table of the database 
                String sqlcmd = "insert into Movie(MovieName,MovieRatting,MovieYear,MovieCost,MovieCopies) values('"+obj.getName()+"','"+obj.getRatting()+"',"+obj.getYear()+","+cost+","+obj.getCopies()+")";
                instance_Connection.SqlQuery(sqlcmd);
                MessageBox.Show("Movie Record is saved ");

                MovieName.Text = "";
                MovieRatting.Text = "";
                MovieYear.Text = "";
                MovieCopies.Text = "";




            }
            else {
                MessageBox.Show("Fill all the details of the video ");
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!Movie_ID.Text.ToString().Equals("")) {

                Connection instance_Connection = new Connection();
                DataTable dtTable = new DataTable();
                dtTable = instance_Connection.srchRecord("select * from Rent where MovieID="+Convert.ToInt32(Movie_ID.Text.ToString())+" and MovieReturn='1'");
                if (dtTable.Rows.Count == 0)
                {


                    String sqlcmd = "delete from Movie where MovieId=" + Convert.ToInt32(Movie_ID.Text.ToString()) + "";

                    instance_Connection.SqlQuery(sqlcmd);
                    MessageBox.Show("Movie is deleted from the Table ");
                }
                else {
                    MessageBox.Show("Video is booked ");
                }
                Movie_ID.Text = "";
                MovieName.Text = "";
                MovieRatting.Text = "";
                MovieYear.Text = "";
                MovieCopies.Text = "";


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // get the values to update the record of the Video
            if (!Movie_ID.Text.ToString().Equals("") && !MovieName.Text.ToString().Equals("") && !MovieRatting.Text.ToString().Equals("") && !MovieYear.Text.ToString().Equals("") && !MovieCopies.Text.ToString().Equals(""))
            {
                Connection instance_Connection = new Connection();
                String sqlcmd = "update Movie set MovieName='"+MovieName.Text.ToString()+"',MovieRatting='"+MovieRatting.Text+"',MovieYear="+Convert.ToInt32(MovieYear.Text.ToString())+",MovieCost="+cost+",MovieCopies="+Convert.ToInt32(MovieCopies.Text.ToString())+"";
                instance_Connection.SqlQuery(sqlcmd);

                MessageBox.Show("Video Record is Updated ");

                Movie_ID.Text = "";
                MovieName.Text = "";
                MovieRatting.Text = "";
                MovieYear.Text = "";
                MovieCopies.Text = "";


            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!Customer_ID.Text.ToString().Equals("") && !Movie_ID.Text.ToString().Equals(""))
            {
                Connection instance_Connection = new Connection();

                DataTable dtTable = new DataTable();
                // get the record of the customer whoc much video he has on rent 
                dtTable = instance_Connection.srchRecord("select * from Rent where CustomerID="+Convert.ToInt32(Customer_ID.Text.ToString())+" and MovieReturn='1'" ) ;
                if (dtTable.Rows.Count < 2) {
                    dtTable = new DataTable();
                    //get the no of copies form the Table 
                    dtTable = instance_Connection.srchRecord("select * from Movie where MovieID=" + Convert.ToInt32(Movie_ID.Text.ToString()) + "");
                    int copies = Convert.ToInt32(dtTable.Rows[dtTable.Rows.Count - 1]["MovieCopies"].ToString());

                    dtTable = new DataTable();
                    //comapre the video cd
                    dtTable = instance_Connection.srchRecord("Select * from Rent where MovieID=" + Convert.ToInt32(Movie_ID.Text.ToString()) + " and MovieReturn='1' ");
                    if (dtTable.Rows.Count < copies)
                    {
                        Rent obj_rent = new Rent(Convert.ToInt32(Customer_ID.Text.ToString()), Convert.ToInt32(Movie_ID.Text.ToString()), movieIssue.Text.ToString(), "1");

                        instance_Connection.SqlQuery("insert into Rent (MovieID,CustomerID,MovieIssue,MovieReturn) values (" + obj_rent.getMovieID() + "," + obj_rent.getCustomerID() + ",'" + obj_rent.getDate() + "','" + obj_rent.getreturnDate() + "')");

                        MessageBox.Show("Video is issued on rent ");

                    }
                    else {
                        MessageBox.Show("All Copies are booked ");
                    }
                }

              
                Movie_ID.Text = "";
                Customer_ID.Text = "";
                MovieName.Text = "";
                MovieRatting.Text = "";
                MovieYear.Text = "";
                MovieCopies.Text = "";
                CustomerAddress.Text = "";
                customerEmail.Text = "";
                CustomerName.Text = "";
                CustomerPhone.Text = "";

            }
            else {
                MessageBox.Show("Select the Movie aor Customer to book an movie on rent ");
            }
                


        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!Rent_ID.Text.ToString().Equals("")) {
                Connection instance_Connection = new Connection();
                String sqlcmd = "delete from Rent where RentId="+Convert.ToInt32(Rent_ID.Text.ToString())+"";
                instance_Connection.SqlQuery(sqlcmd);
                MessageBox.Show("Rental record is deleted from the record ");

                Movie_ID.Text = "";
                Customer_ID.Text = "";
                MovieName.Text = "";
                MovieRatting.Text = "";
                MovieYear.Text = "";
                MovieCopies.Text = "";
                CustomerAddress.Text = "";
                customerEmail.Text = "";
                CustomerName.Text = "";
                CustomerPhone.Text = "";
                Rent_ID.Text = "";

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

            //get the id first of the rental movie and then calculate the charges after that print the charges and then return the record 
            if (!Rent_ID.Text.ToString().Equals("")) {
                Connection instance_Connection = new Connection();

                DataTable dtTable = new DataTable();
                dtTable = instance_Connection.srchRecord("Select * from Movie where MovieID="+Convert.ToInt32(Movie_ID.Text.ToString())+"");
                cost =Convert.ToInt32( dtTable.Rows[dtTable.Rows.Count - 1]["MovieCost"].ToString());

                MessageBox.Show("Your Total");
                DateTime new_date = DateTime.Now;

                //convert the old date from string to Date fromat
                DateTime prev_date = Convert.ToDateTime(movieIssue.Text);


                //get the difference in the days fromat
                String Daysdiff = (new_date - prev_date).TotalDays.ToString();


                // calculate the round off value 
                Double DaysInterval = Math.Round(Convert.ToDouble(Daysdiff));



                int charges = Convert.ToInt32(DaysInterval) * cost;



                String sqlcmd = "update rent set MovieID="+Convert.ToInt32(Movie_ID.Text.ToString())+",CustomerID="+Convert.ToInt32(Customer_ID.Text.ToString())+",MovieIssue='"+movieIssue.Text.ToString()+"',MovieReturn='"+MovieReturn.Text.ToString()+"' where RentId="+Convert.ToInt32(Rent_ID.Text.ToString())+"";
                instance_Connection.SqlQuery(sqlcmd);
                MessageBox.Show("Your Total Charges is $"+charges);
                Movie_ID.Text = "";
                Customer_ID.Text = "";
                MovieName.Text = "";
                MovieRatting.Text = "";
                MovieYear.Text = "";
                MovieCopies.Text = "";
                CustomerAddress.Text = "";
                customerEmail.Text = "";
                CustomerName.Text = "";
                CustomerPhone.Text = "";
                Rent_ID.Text = "";





            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pass the record to the data grid view 
            dataTable dt = new dataTable();
            dt.data(table,"select * from Customer");
            option.Text = "customer";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //pass the record to the data grid view 
            dataTable dt = new dataTable();
            dt.data(table, "select * from Movie");
            option.Text = "movie";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //pass the record to the data grid view 
            dataTable dt = new dataTable();
            dt.data(table, "select * from Rent");
            option.Text = "rent";
        }

        private void table_DoubleClick(object sender, EventArgs e)
        {
            if (option.Text.ToString().Equals("customer")) {
                Customer_ID.Text = table.CurrentRow.Cells[0].Value.ToString();
                CustomerName.Text = table.CurrentRow.Cells[1].Value.ToString();
                customerEmail.Text = table.CurrentRow.Cells[2].Value.ToString();
                CustomerPhone.Text = table.CurrentRow.Cells[3].Value.ToString();
                CustomerAddress.Text = table.CurrentRow.Cells[4].Value.ToString();
            

            }
            if (option.Text.ToString().Equals("movie")) {
                    Movie_ID.Text = table.CurrentRow.Cells[0].Value.ToString();
                    MovieName.Text = table.CurrentRow.Cells[1].Value.ToString();
                MovieRatting.Text = table.CurrentRow.Cells[2].Value.ToString();
                MovieYear.Text=table.CurrentRow.Cells[3].Value.ToString();
                cost = Convert.ToInt32(table.CurrentRow.Cells[4].Value.ToString());
                MovieCopies.Text = table.CurrentRow.Cells[5].Value.ToString();

            }
            if (option.Text.ToString().Equals("rent")) {
                Rent_ID.Text = table.CurrentRow.Cells[0].Value.ToString();
                Movie_ID.Text = table.CurrentRow.Cells[1].Value.ToString();
                Customer_ID.Text = table.CurrentRow.Cells[2].Value.ToString();
                movieIssue.Text = table.CurrentRow.Cells[3].Value.ToString();

            }

            option.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            dataTable tbl = new dataTable();
            MessageBox.Show("Best Video is " + tbl.BestMovie());

        }

        private void button13_Click(object sender, EventArgs e)
        {
            dataTable tbl = new dataTable();
            MessageBox.Show("Best Cusotmer is " + tbl.BestCustomer());

        }
    }
}

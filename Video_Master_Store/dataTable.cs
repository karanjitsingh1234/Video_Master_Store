using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Video_Master_Store
{
    public class dataTable
    {
        Connection instance_Connection = new Connection();
        //pass the record 
        public void data(DataGridView dgv,String cmd) {
            DataTable tbl = new DataTable();
            tbl = instance_Connection.srchRecord(cmd);
            dgv.DataSource = tbl;
        }


        //get the name of the best customer 
        public String BestCustomer() {
            DataTable tblData = new DataTable();
            Connection obj = new Connection();

            tblData = obj.srchRecord("select * from Customer ");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = obj.srchRecord("select * from Rent where CustomerID=" + Convert.ToInt32(tblData.Rows[x]["CustomerID"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["CustomerName"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            return Title;

        }


        public String BestMovie() {

            DataTable tblData = new DataTable();
            Connection obj = new Connection();

            tblData = obj.srchRecord("select * from Movie");
            int x = 0, y = 0, cunt = 0;
            String Title = "";
            for (x = 0; x < tblData.Rows.Count; x++)
            {
                DataTable tblData1 = new DataTable();
                tblData1 = obj.srchRecord("select * from Rent where MovieID=" + Convert.ToInt32(tblData.Rows[x]["MovieID"].ToString()) + "");

                if (tblData1.Rows.Count > cunt)
                {
                    Title = tblData.Rows[x]["MovieName"].ToString();
                    cunt = tblData1.Rows.Count;
                }

            }

            return Title;
        }
    }
}

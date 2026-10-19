using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Start
{
    public partial class ManageSection : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //string connectionString = "Data Source = Ikram\\SQLExpress;Initial Catalog = Practice; "; login was failing with this connection string
                // I used Integrated Security = true, the error went away
                string connectionString =
                  "Data Source = Ikram\\SQLEXPRESS; Initial Catalog = Practice; Integrated Security = true;";
                SqlConnection connection = new SqlConnection(connectionString);
                string queryString = "Sp_Form_Sel";
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);//SqlDataAdapter: Represents a set of data commands and a database connection
                                                                     //that are used to fill the DataSet/DataTable and update a SQL Server database
                DataTable dt = new DataTable(); //Represents one table of in-memory data.

                adapter.Fill(dt);
                repeater.DataSource = dt;
                repeater.DataBind();
                connection.Close();
         

            }
            catch
            {

            }
        }
        public void RedirectToForm(object sender, CommandEventArgs e)
        {       
            int id = Convert.ToInt32(e.CommandArgument.ToString());
            Response.Redirect("./Default.aspx?ID=" +id);
        }
    }
}
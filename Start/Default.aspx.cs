using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
//using System.Windows.Forms;

namespace Start
{
    public partial class _Default : Page
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
                string queryString = "GetData";
                connection.Open();
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                repeater.DataSource = dt;
                repeater.DataBind();
                connection.Close();

            }
            catch
            {

            }

        }
        public void ToggleVisibility(object sender, EventArgs e)
        {
            container.Visible = !container.Visible;
            if (container.Visible == true)
            {
                showformbtn.Text = "Hide Form";
            }
            else showformbtn.Text = "Show Form";
        }
        public void SubmitDetails(object sender, EventArgs e)
        {
            //string connectionString =
            //    "Data Source=Ikram\\SQLEXPRESS;Initial Catalog=Practice;Integrated Security=True;";

            // Documentation approach contains using statement, I feel the code was more complicated, so I read an article of c-sharpcorner
            //// Create a sql connection
            //using (SqlConnection connection = new SqlConnection(connectionString)) 
            //{
            //    // Stored procedure to execute against a SQL Server database.
            //    using (SqlCommand command = new SqlCommand("[dbo].[InsertData]", connection))
            //    {
            //        command.CommandType = CommandType.StoredProcedure;  // It tells we are calling the stored procedure

            //        command.Parameters.AddWithValue("Name", name.Value);
            //        command.Parameters.AddWithValue("Gender", gender.Value);
            //        command.Parameters.AddWithValue("PhoneNumber", phonenumber.Value);
            //        command.Parameters.AddWithValue("Address", address.Value);

            //        connection.Open();

            //        int ireturn = command.ExecuteNonQuery();


            //    }

            // approach used in https://www.c-sharpcorner.com/article/using-stored-procedures-with-Asp-Net?srsltid=AU7gw4W9EKbOPzj9XjQPSeq6CMpFt6y3GLwpqaX5swpjkq68_QjiFb3-
            // i feel code is easy to understand without the using statement, if the code takes a lot of width it becomes bit difficult to understand
            // this approach is a result of c-sharpcorner website and a youtube video
            try
            {
                //Most database providers require a connection string to connect to the database. 
                string connectionString =
                  "Data Source=Ikram\\SQLEXPRESS;Initial Catalog=Practice;Integrated Security=True;"; // copied from Web.Config
                SqlConnection connection = new SqlConnection(connectionString);
                // SqlCommand Class Represents stored procedure to execute against a SQL Server database.
                string queryString = "InsertData";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.StoredProcedure;

                // command.Parameters and passing value one by one was used in youtube video as well
                //command.Paramters: Represents a collection of parameters associated with a SqlCommand
                string name, gender, phonenumber, address;
                name = name1.Value;
                gender = gender1.Value;
                phonenumber = phonenumber1.Value;
                address = address1.Value;
                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("Gender", gender);
                command.Parameters.AddWithValue("PhoneNumber", phonenumber);
                command.Parameters.AddWithValue("Address", address);

                connection.Open(); // Switches on the connection

                int ireturn = command.ExecuteNonQuery();
                if (ireturn > 0)
                {
                    name1.Value = "";
                    gender1.Value = "";
                    phonenumber1.Value = "";
                    address1.Value = "";
                }

                // Turns off the connection

                connection.Close();
            }
            catch (Exception ex)
            {
                //MeesageBox.Show(ex.Message);
            }

        }

    }

}
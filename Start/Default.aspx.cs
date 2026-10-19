using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
//using System.Windows.Forms;

namespace Start
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    //Most database providers require a connection string to connect to the database. 
                    string connectionString =
                      "Data Source=Ikram\\SQLEXPRESS;Initial Catalog=Practice;Integrated Security=True;"; // copied from Web.Config
                    int id = Convert.ToInt32(Request.QueryString["ID"]);
                    SqlConnection connection = new SqlConnection(connectionString);
                    // SqlCommand Class Represents stored procedure to execute against a SQL Server database.
                    string queryString = "Sp_Get_Item_ByID";   // Select * from Form where ID = @ID
                    connection.Open();
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.AddWithValue("ID", id);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);//SqlDataAdapter: Represents a set of data commands and a database connection
                                                                         //that are used to fill the DataSet/DataTable and update a SQL Server database
                    DataTable dt = new DataTable(); //Represents one table of in-memory data.
                    adapter.Fill(dt);
                    DataRow dt1 = dt.Rows[0];  // A data row is an individual data source record.
                    name1.Value = dt1["Name"].ToString();
                    phonenumber1.Value = dt1["PhoneNumber"].ToString();
                    // First convert datetime to datetime 
                    DateTime dob = Convert.ToDateTime(dt1["DateofBirth"]);
                    //string dob1 = dob.ToString("yyyy-dd-MM");
                    string dob1 = dob.ToString("yyyy-MM-dd");
                    date1.Value = dob1;
                    gender2.Value = dt1["Gender"].ToString();
                    email1.Value = dt1["EmailAddress"].ToString();
                    walk_indays.Value = dt1["Go_For_Walk_In_Days"].ToString();
                    // If TakingAnyMedication contains Yes, check the radio with label Yes
                    if (dt1["TakingAnyMedication"].ToString() == "Yes")
                        medication_yes.Checked = true;
                    else
                        medication_no.Checked = true;
                    medicationTaken.Value = dt1["IfTakingMedication_Names"].ToString();
                    if (dt1["AnyMedicalAllergies"].ToString() == "Yes")
                        med_allergy_yes.Checked = true;
                    else
                        med_allergy_no.Checked = true;
                    med_allergies_.Value = dt1["MedicalAllergiesList"].ToString();
                    submitbtn.Visible = false;
                    updatebtn.Visible = true;
                    deletebtn.Visible = true;
                    connection.Close();

                }
            }

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
                string queryString = "Sp_Form_Ins";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.CommandType = CommandType.StoredProcedure;

                // command.Parameters and passing value one by one was used in youtube video as well
                //command.Paramters: Represents a collection of parameters associated with a SqlCommand
                string name, gender, phonenumber, emailaddress;
                string takingmeds, meds_taken, med_allergies, havemed_allergy;
                DateTime dob;
                int walk;
                //DateTime dateofbirth;
                name = name1.Value;
                gender = gender2.Value;
                phonenumber = phonenumber1.Value;
                emailaddress = email1.Value;
                dob = Convert.ToDateTime(date1.Value);
                walk = Convert.ToInt16(walk_indays.Value);

                meds_taken = medicationTaken.Value;  // to derive text from
                med_allergies = med_allergies_.Value; // named it med_allergies_ because med_allergies is a variable declared on line 98.
                if (medication_yes.Checked == true)
                    takingmeds = "Yes";
                else  // inspired from asp.net documentation 
                    takingmeds = "No";
                if (med_allergy_yes.Checked == true)
                    havemed_allergy = "Yes";
                // why used else instead of else if, read line 136.
                else   //use of unassigned variable, the compiler
                    havemed_allergy = "No";
                //address = address1.Value;
                //command.Parameters.AddWithValue() Adds a value to the end of the SqlParameterCollection.
                command.Parameters.AddWithValue("Name", name);
                command.Parameters.AddWithValue("PhoneNumber", phonenumber);
                command.Parameters.AddWithValue("DateofBirth", dob); // the value inside "" should match the parameters name inside the Stored Procedure.
                command.Parameters.AddWithValue("Gender", gender);
                command.Parameters.AddWithValue("EmailAddress", emailaddress);
                command.Parameters.AddWithValue("Go_For_Walk_In_Days", walk);
                command.Parameters.AddWithValue("TakingMedication", takingmeds); // use of unassigned local variable, removed else if statement used else.
                command.Parameters.AddWithValue("IfTaking_Medication_Names", meds_taken);
                command.Parameters.AddWithValue("AnyMedicalAllergies", havemed_allergy);
                command.Parameters.AddWithValue("MedicalAllergiesList", med_allergies);
                //https://stackoverflow.com/questions/5710485/what-does-use-of-unassigned-local-variable-mean , to make the compiler understand , that one
                // of the if conditions are going to be executed and takingmeds and havemed_allergy are going to be assigned a value.
                // So, we have to make the compiler understand.

                connection.Open(); // Switches on the connection

                int ireturn = command.ExecuteNonQuery();
                //if (ireturn > 0)
                //{
                //    name1.Value = "";
                //    gender2.Value = "";
                //    phonenumber1.Value = "";
                //    email1.Value = "";
                //    medication_yes.Checked = false;
                //    medication_no.Checked = false;
                //    med_allergy_yes.Checked = false;
                //    med_allergy_no.Checked = false;
                //    medicationTaken.Value = "";
                //    med_allergies_.Value = "";
                //    Response.Redirect("ManageSection.aspx?Succ=true");
                //}
                if (ireturn > 0)
                    Response.Redirect("ManageSection.aspx?Succ=Yes");
                connection.Close(); // Turns off the connection

            }
            catch (Exception ex)
            {
                //MeesageBox.Show(ex.Message);
            }

        }
        public void UpdateDetails(object sender, EventArgs e)
        {
            //Most database providers require a connection string to connect to the database. 
            string connectionString =
              "Data Source=Ikram\\SQLEXPRESS;Initial Catalog=Practice;Integrated Security=True;"; // copied from Web.Config
            int id = Convert.ToInt32(Request.QueryString["ID"]);
            SqlConnection connection = new SqlConnection(connectionString);
            // SqlCommand Class Represents stored procedure to execute against a SQL Server database.
            string queryString = "Sp_Form_Upd";   // Select * from Form where ID = @ID
            connection.Open();
            SqlCommand command = new SqlCommand(queryString, connection);
            command.Parameters.AddWithValue("ID", id);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);//SqlDataAdapter: Represents a set of data commands and a database connection
            string name, gender, phonenumber, emailaddress;
            string takingmeds, meds_taken, med_allergies, havemed_allergy;
            DateTime dob;
            int walk;
            //DateTime dateofbirth;
            name = name1.Value;
            gender = gender2.Value;
            phonenumber = phonenumber1.Value;
            emailaddress = email1.Value;
            dob = Convert.ToDateTime(date1.Value);
            walk = Convert.ToInt16(walk_indays.Value);

            meds_taken = medicationTaken.Value;  // to derive text from
            med_allergies = med_allergies_.Value; // named it med_allergies_ because med_allergies is a variable declared on line 98.
            if (medication_yes.Checked == true)
                takingmeds = "Yes";
            else  // inspired from asp.net documentation 
                takingmeds = "No";
            if (med_allergy_yes.Checked == true)
                havemed_allergy = "Yes";
            // why used else instead of else if, read line 136.
            else   //use of unassigned variable, the compiler
                havemed_allergy = "No";
            //address = address1.Value;
            //that are used to fill the DataSet/DataTable and update a SQL Server database
            //command.Parameters.AddWithValue() Adds a value to the end of the SqlParameterCollection.
            command.Parameters.AddWithValue("Name", name); // The name of "Name" or the text inside " " should match the Parameters name in the stored procedure
            command.Parameters.AddWithValue("PhoneNumber", phonenumber);
            command.Parameters.AddWithValue("DateofBirth", dob); // the value inside "" should match the parameters name inside the Stored Procedure.
            command.Parameters.AddWithValue("Gender", gender);
            command.Parameters.AddWithValue("EmailAddress", emailaddress);
            command.Parameters.AddWithValue("Go_For_Walk_In_Days", walk);
            command.Parameters.AddWithValue("TakingMedication", takingmeds); // use of unassigned local variable, removed else if statement used else.
            command.Parameters.AddWithValue("IfTaking_Medication_Names", meds_taken);
            command.Parameters.AddWithValue("AnyMedicalAllergies", havemed_allergy);
            command.Parameters.AddWithValue("MedicalAllergiesList", med_allergies);
            int ireturn = command.ExecuteNonQuery();
            if (ireturn > 0)
                Response.Redirect("ManageSection.aspx?Succ=Yes");
            connection.Close();
        }
        public void DeleteRecord(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(Request.QueryString["ID"].ToString());
           
        }

    }

}
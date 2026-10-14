using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Start
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            object[] parrams = new object[4];
            parrams[0] = name.Value;
            parrams[1] = gender.Value;
            parrams[2] = phonenumber.Value;
            parrams[3] = address.Value;
            name.Value = "";
            gender.Value = "";
            phonenumber.Value = "";
            address.Value = "";
            int ireturn = DBase.ExecuteNonQuery("InsertData", parrams); // it was showing error earlier, I restarted the computer error got away.
            // show success message
            //if (ireturn > 0)

        }
    }
}
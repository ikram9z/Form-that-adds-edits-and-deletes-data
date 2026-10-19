<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Start._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" />
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <div class="heading">
                <h2>Health Examining Form
                </h2>
            </div>
            <div class="container1" id="container" runat="server" >
                <div>
                    <label>Enter Name</label>
                    <input type="text" id="name1" runat="server" />
                </div>
                <div>
                    <label>Phone Number</label>
                    <input type="text" id="phonenumber1" runat="server" />
                </div>
                <div>
                    <label>Enter date of birth</label>
                    <input type="date" id="date1" runat="server" />
                </div>
                <div>
                    <label>Please select Gender</label>
                    <%--  <select id="gender1" runat="server"> 
                        The base class includes the field 'gender1', but its type (System.Web.UI.HtmlControls.HtmlInputText)
                        is not compatible with the type of control (System.Web.UI.HtmlControls.HtmlSelect).
                        If I rename it to gender2 works fine
                    --%>
                    <select id="gender2" runat="server">
                        <option>Please choose an option</option>
                        <option value="male">Male</option>
                        <option value="female">Female</option>
                        <option value="transgender">Transgender</option>
                    </select>
                </div>
                <div>
                    <label>Email Address </label>
                    <input type="text" id="email1" runat="server" />
                </div>
                <div>
                    <label>How often do you go for a walk outside (In days , just a Dummy Question)</label>
                    <input type="text" id="walk_indays" runat="server" />
                </div>
                <div>
                    <label>Are you taking any medication</label>
                    <div class="medication">
                        <input type="radio" id="medication_yes" value="yes" runat="server" name="medication" />
                        <label>Yes</label>
                        <input type="radio" id="medication_no" value="no" runat="server" name="medication" />
                        <label>No</label>
                    </div>
                </div>
                <div>
                    <label>If, yes. Please list them</label>
                    <%--The HTML server controls are HTML elements that include a runat=server attribute.--%>
                    <input type="text" runat="server" id="medicationTaken" />
                </div>
                <div>
                    <label>Do, you have any medication allergies</label>
                    <div>
                        <input type="radio" id="med_allergy_yes" runat="server" name="allergies" /> <%-- If med_allergy_yes.Checked == true , med_allergy_ = "Yes" --%>
                        <label>Yes</label>
                        <input type="radio" id="med_allergy_no" runat="server" name="allergies" />
                        <label>No</label>
                    </div>
                </div>
                <div>
                    <label>If, yes. Please list them</label>
                    <input type="text" id="med_allergies_" runat="server" />
                </div>
                <asp:Button ID="submitbtn" class="submitbtn" OnClick="SubmitDetails" runat="server" Text="Submit Form"></asp:Button>
                <asp:Button ID="updatebtn"  OnClick="UpdateDetails" Visible="false" runat="server" Text="Update Form" />
                <asp:Button ID="deletebtn" OnClick="DeleteRecord" Visible="false" runat="server" Text="Delete Record" />
            </div>
        </section>
    </main>

</asp:Content>

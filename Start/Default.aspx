<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Start._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" />
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <div>
                <h3>Health Examining Form
                </h3>
            </div>
            <asp:Button ID="showformbtn" class="showformbtn" runat="server" OnClick="ToggleVisibility" Text="Show Form"></asp:Button>
            <div class="container1" id="container" runat="server" visible="false">
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
                        <input type="radio" id="medication_yes" runat="server" name="medication" />
                        <label>Yes</label>
                        <input type="radio" id="medication_no" runat="server" name="medication" />
                        <label>No</label>
                    </div>
                </div>
                <div>
                    <label>If, yes. Please list them</label>
                    <input type="text" />
                </div>
                <div>
                    <label>Do, you have any medication allergies</label>
                    <div>
                        <input type="radio" runat="server" name="allergies" />
                        <label>Yes</label>
                        <input type="radio" runat="server" name="allergies" />
                        <label>No</label>
                    </div>
                </div>
                <div>
                    <label>If, yes. Please list them</label>
                    <input type="text" name="medicationallergies" />
                </div>
                <asp:Button ID="submitbtn" class="submitbtn" OnClick="SubmitDetails" runat="server" Text="Submit Form"></asp:Button>
            </div>
        </section>
        <section>
            <asp:Repeater runat="server" ID="repeater">
                <HeaderTemplate>
                    <table>
                        <tr>
                            <th>Name</th>
                            <th>Gender</th>
                            <th>Phone Number</th>
                            <th>Address</th>
                            <th>Actions</th>
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Gender") %></td>
                        <td><%# Eval("PhoneNumber") %></td>
                        <td><%# Eval("Address") %></td>
                        <td>Edit</td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </section>
    </main>

</asp:Content>

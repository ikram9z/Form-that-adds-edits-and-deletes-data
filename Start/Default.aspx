<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Start._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" />
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <asp:Button ID="showformbtn" class="showformbtn" runat="server" OnClick="ToggleVisibility" Text="Show Form"></asp:Button>
            <div class="container1" id="container" runat="server" visible="false">
                <div>
                    <label>Enter Name</label>
                    <input type="text" id="name1" runat="server" />
                </div>
                <div>
                    <label>Enter Gender</label>
                    <input type="text" id="gender1" runat="server" />
                </div>
                <div>
                    <label>Enter phone number</label>
                    <input type="text" id="phonenumber1" runat="server" />
                </div>
                <div>
                    <label>Enter address</label>
                    <input type="text" id="address1" runat="server" />
                </div>
                <asp:Button ID="submitbtn" class="submitbtn" OnClick="SubmitDetails" runat="server" Text="Submit"></asp:Button>
            </div>
        </section>
        <section>
            <asp:Repeater runat="server" Id ="repeater">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <td>Name</td>
                            <td>Gender</td>
                            <td>Phone Number</td>
                            <td>Address</td>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Name") %></td>
                        <td><%# Eval("Gender") %></td>
                        <td><%# Eval("PhoneNumber") %></td>
                        <td><%# Eval("Address") %></td>                  
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </section>
    </main>

</asp:Content>

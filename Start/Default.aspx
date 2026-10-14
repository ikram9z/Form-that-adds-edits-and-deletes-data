<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Start._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" />
    <main>
        <section class="row" aria-labelledby="aspnetTitle">
            <asp:Button ID="showformbtn" class="showformbtn" runat="server" OnClick="ToggleVisibility" Text="Show Form"></asp:Button>
            <div class="container1" id="container" runat="server" visible="false">
                <div>
                    <label>Enter Name</label>
                    <input type="text" id="name" runat="server" />
                </div>
                <div>
                    <label>Enter Gender</label>
                    <input type="text" id="gender" runat="server" />
                </div>
                <div>
                    <label>Enter phone number</label>
                    <input type="text" id="phonenumber" runat="server" />
                </div>
                <div>
                    <label>Enter address</label>
                    <input type="text" id="address" runat="server" />
                </div>
                <asp:Button ID="submitbtn" class="submitbtn" OnClick="SubmitDetails" runat="server" Text="Submit"></asp:Button>
            </div>
        </section>
        <div class="datacontainer">
            <div>
                <label>Name</label>
            </div>
            <div>
                <label>Gender</label>
            </div>
            <div>
                <label>Phone Number</label>
            </div>
            <div>
                <label>Address</label>
            </div>
        </div>
    </main>

</asp:Content>

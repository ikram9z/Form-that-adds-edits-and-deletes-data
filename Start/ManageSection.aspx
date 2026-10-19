<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ManageSection.aspx.cs" Inherits="Start.ManageSection" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="style.css" rel="stylesheet" />
    <section>
        <asp:Repeater runat="server" ID="repeater">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>Name</th>
                        <th>Phone Number</th>
                        <th>Date of birth</th>
                        <th>Gender</th>
                        <th>Email Address</th>
                        <th>Walk in days</th>
                        <th>Taking any medication</th>

                        <%-- 
                        <th>If Taking Medication Names</th>
                        <th>Any medical allergies</th>
                        <th>Medical Allergies List</th>
                        --%>
                        <th>Actions</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Name") %></td>
                    <%--Value inside Eval should match the database column name <%# Eval("ColumnName") #%> --%>
                    <td><%# Eval("PhoneNumber") %></td>
                    <td><%# Eval("DateofBirth") %></td>
                    <td><%# Eval("Gender") %></td>
                    <td><%# Eval("EmailAddress") %></td>
                    <td><%# Eval("Go_For_Walk_In_Days") %></td>
                    <td><%# Eval("TakingAnyMedication") %> </td>
                    <td>
                        <%--Used LinkButton because it td onClick = "RedirectToForm" was not working --%>
                        <%--  CommandArgument="<%# Eval("ID")  %>" Parser Error Message: The server tag is not well formed
                            fix: You could not use double quotes within double quotes so use combination of single and double quotes.
                            Change 
                             CommandArgument="<%# Eval("ID")  %>
                            To
                             CommandArgument='<%# Eval("ID") %>'
                        --%>
                        <%-- No overload for 'RedirectToForm' matches delegate 'EventHandler'
                            <asp:LinkButton runat="server" OnClick="RedirectToForm" Text="Edit" CommandArgument='<%# Eval("ID") %>'></asp:LinkButton> --%>
                        <asp:LinkButton runat="server" OnCommand="RedirectToForm" CommandArgument='<%#Eval("ID") %>' Text="Edit"></asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </section>

</asp:Content>

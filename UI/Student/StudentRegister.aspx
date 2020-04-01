<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="StudentRegister.aspx.cs" Inherits="Student_StudentRegister" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>

        <tr>
            <td>
                 Send A Request For Attending WorkShop<br />
        <asp:TextBox ID="txtEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:Button ID="txtSubmit" runat="server" Text="Submit"  OnClick="txtSubmit_Click"></asp:Button>
            </td>
        </tr>
    </table>
</asp:Content>


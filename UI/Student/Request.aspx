<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="Request.aspx.cs" Inherits="Student_Request" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <table style="width: 89%; height: 250px;" class="auto-style1">
        <tr>
            <td style="text-align:center">
     <asp:GridView ID="grdWorkShopRequest" Width="100%" runat="server">
    </asp:GridView> <br />
                </td>
            </tr>
   
        </table>
</asp:Content>


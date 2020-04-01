<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="WorkShop.aspx.cs" Inherits="Student_WorkShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 89%; height: 250px;" class="auto-style1">
        <tr>
            <td  style="text-align:center">
     <asp:GridView ID="GridView1" runat="server"  Width="350px" AutoGenerateSelectButton="True" DataKeyNames="WorkShopId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"  Height="50px">
                     </asp:GridView>
                </td>
             </tr>
        </table>
   
</asp:Content>


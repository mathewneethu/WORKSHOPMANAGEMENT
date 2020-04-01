<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Approval.aspx.cs" Inherits="Admin_Approval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style3 {
            width: 1194px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
   <%--  <asp:GridView ID="grdWorkShopRequest" runat="server"  Style="text-align:left" ForeColor="#333333" GridLines="None" Width="350px" AutoGenerateSelectButton="True" CellPadding="10" DataKeyNames="UserId,WorkShopId"   Height="55px">
                         <AlternatingRowStyle BackColor="White" />
                         <EditRowStyle BackColor="#2461BF" />
                         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                         <RowStyle BackColor="#EFF3FB" />
                         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                         <SortedAscendingCellStyle BackColor="#F5F7FB" />
                         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                         <SortedDescendingCellStyle BackColor="#E9EBEF" />
                         <SortedDescendingHeaderStyle BackColor="#4870BE" />
                     </asp:GridView> <br />
     <asp:RadioButtonList ID="rblApproveReject" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="true">Approve</asp:ListItem>
                    <asp:ListItem Value="false">Reject</asp:ListItem>
                   
                </asp:RadioButtonList>
     <br />
    
     <asp:Button ID="BtnSubmit" runat="server" Text="Submit" OnClick="BtnSubmit_Click" />
     <br />
     --%>
    <table style="width: 89%; height: 250px;" class="auto-style1">
        <tr>
            <td style="text-align: center" class="auto-style3">
     <asp:GridView ID="grdWorkShopRequest" Width="110%" runat="server" AutoGenerateSelectButton="True" DataKeyNames="UserId,WorkShopId">
    </asp:GridView> <br />
                </td>
            </tr>
   
    <asp:RadioButtonList ID="rblApproveReject" runat="server" RepeatDirection="Horizontal" style="color: #FFFFFF">
        <asp:ListItem Value="true">Approve</asp:ListItem>
        <asp:ListItem Value="false">Reject</asp:ListItem>
    </asp:RadioButtonList>
      
    <asp:Button ID="BtnSubmit" runat="server" OnClick="BtnSubmit_Click" Text="Submit" />
        </table>
</asp:Content>


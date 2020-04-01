<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="Admin_Student" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
       <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%-- <asp:GridView ID="grdStudents" Width="100%" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    </asp:GridView>--%>
      <table style="width: 89%; height: 250px;" class="auto-style1">
          <tr>
            <td colspan="2" style="text-align: center">
      <asp:GridView ID="grdStudents" runat="server" CellPadding="6" AutoGenerateColumns="False" Width="1141px">  
            <Columns>  
                <asp:BoundField DataField="UserId" HeaderText="Id"/>  
                <asp:BoundField DataField="FirstName" HeaderText="FirstName"/>  
                <asp:BoundField DataField="LastName" HeaderText="LastName"/>  
                <asp:BoundField DataField="UserName_Email" HeaderText="UserEmail"/> 
                <asp:BoundField DataField="Mobile" HeaderText="Phone Number"/> 
                <asp:BoundField DataField="SkillsSet" HeaderText="Skills"/>
                <asp:BoundField DataField="UserGender" HeaderText="Gender"/>
                 
            </Columns>  
        </asp:GridView>  
                </td>
              </tr>
          </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Trainer.aspx.cs" Inherits="Admin_Trainer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
           
            
        }
        .auto-style2 {
            width: 100%;
            
            color:#fff;
        }
        .auto-style3 {
            width: 519px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 89%; height: 250px;" class="auto-style1">
        <tr>
            <td style="text-align: right" class="auto-style3">Trainer&#39;s First Name:</td>
            <td>
                <asp:TextBox ID="txtTrainerFirstName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">Trainer&#39;s Last Name:</td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">Trainer&#39;s Email:</td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="text-align: right" class="auto-style3">Trainer&#39;s Phone Number:</td>
            <td>
                <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="text-align: right" class="auto-style3">Trainer&#39;s Skills:</td>
            <td>
                <asp:TextBox ID="txtskillset" runat="server"></asp:TextBox>
            </td>
        </tr>
         <tr>
            <td style="text-align: right" class="auto-style3">Trainer&#39;s Experience:</td>
            <td>
                <asp:TextBox ID="txtExperience" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="text-align: right" class="auto-style3">
                &nbsp;</td>
            <td>
                <asp:Button ID="txtSave" runat="server" OnClick="txtSave_Click" Text="Save" />
                 <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click"  />
                      <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                 <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        </table>
    <table class="auto-style2">
        <tr>

            <td colspan="2" style="text-align: center" id="UserId">
               <%-- <asp:GridView ID="grdTrainers" Width="100%" runat="server" AutoGenerateSelectButton="True" DataKeyNames="UserId">
                </asp:GridView>--%>

                <asp:GridView ID="grdTrainers" runat="server" CellPadding="6" AutoGenerateSelectButton="True" DataKeyNames="UserId" AutoGenerateColumns="False" OnSelectedIndexChanged="grdTrainers_SelectedIndexChanged" Width="1204px">  
            <Columns>  
                <asp:BoundField DataField="UserId" HeaderText="Id"/>  
                <asp:BoundField DataField="FirstName" HeaderText="FirstName"/>  
                <asp:BoundField DataField="LastName" HeaderText="LastName"/>  
                 <asp:BoundField DataField="UserName_Email" HeaderText="UserEmail"/> 
                <asp:BoundField DataField="Mobile" HeaderText="Phone Number"/> 
                <asp:BoundField DataField="SkillsSet" HeaderText="Skills"/>
                <asp:BoundField DataField="Experience" HeaderText="Experience"/>  
            </Columns>  
        </asp:GridView>  
            </td>
        </tr>
    </table>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentMasterPage.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Student_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 366px;
        }
        .auto-style5 {
            width: 364px;
            color: #FFFFFF;
        }
        .auto-style6 {
            width: 364px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table>
        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">First Name:</td>
            <td><asp:TextBox ID="txtFirstName" runat="server" Width="315px"></asp:TextBox></td>
            </tr>

        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">Last Name:</td>
            <td><asp:TextBox ID="txtLastName" runat="server" Width="315px"></asp:TextBox></td>
            </tr>


         <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">UserGender:</td>
            <td>
                <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal" style="color: #FFFFFF">
                <asp:ListItem Value="M">Male</asp:ListItem>
                <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
           </tr>

         <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">Date Of Birth:</td>
            <td><asp:TextBox ID="txtDateofBirth" runat="server" Width="315px"></asp:TextBox></td>
            </tr>

        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">Contact Number:</td>
            <td><asp:TextBox ID="txtMobile" runat="server" Width="315px"></asp:TextBox></td>
            </tr>

        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">SkillSet:</td>
            <td><asp:TextBox ID="txtSkillSet" runat="server" Width="315px"></asp:TextBox></td>
            </tr>

         <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">UserName Email:</td>
            <td><asp:TextBox ID="txtUserNameEmail" runat="server" Width="315px"></asp:TextBox></td>
            </tr>

        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">Password:</td>
            <td><asp:TextBox ID="txtPassword" runat="server" Width="315px"></asp:TextBox></td></br>
            </tr>

         <tr>

            <td style="text-align:right;" class="auto-style6">
               
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                  <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                      <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                 <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
        </tr>

        
             
     
      

        </table>

    <table>

          <tr>
             <td style="text-align:center;" class="auto-style5">
                 <asp:GridView ID="gridStudent" runat="server"   AutoGenerateSelectButton="True" DataKeyNames="UserId" Width="359px" OnSelectedIndexChanged="gridStudent_SelectedIndexChanged">
                     </asp:GridView>
                 </td>
           
        </tr>

       
    </table>
</asp:Content>


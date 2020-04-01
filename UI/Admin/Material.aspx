<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Material.aspx.cs" Inherits="Admin_Material" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
        <style type="text/css">
        .auto-style1 {
           
            
        }
        .auto-style2 {
            width: 100%;
            
            color:#fff;
        }
            .auto-style3 {
                width: 565px;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 89%; height: 110px;"  class="auto-style2">
         <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style3">WorkSho:</td>
            <td><asp:DropDownList ID="ddlWorkShop" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style3">Description:</td>
            <td><asp:TextBox ID="txtDescription" runat="server" Width="223px"></asp:TextBox></td>

        </tr>

        <tr>
             <td style="text-align:right; font-weight: 700;" class="auto-style3">Material:</td>
            <td><asp:FileUpload ID="fuldMaterial" runat="server" Width="230px"/></td>
        </tr>
         <tr class="auto-style1">
             
                 <td style="text-align:right"" class="auto-style3">
                 <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" Width="54px"/><br />
                      <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                     </td>
                     </tr>
        </table>
    <table style="width: 994px"  class="auto-style2">
         <tr>
            
                
            <td>
                 <asp:GridView ID="GridMaterial" runat="server"  Style="text-align:center" Width="1125px" AutoGenerateSelectButton="True" AutoGenerateColumns="False" DataKeyNames="WorkShopId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="50px">
                         <Columns>
                             <asp:HyperLinkField />
                             <asp:BoundField DataField="MaterialId" HeaderText="MaterialId"/>  
                              <asp:BoundField DataField="WorkShopId" HeaderText="WorkShopId"/>  
                <asp:BoundField DataField="WorkShopTitle" HeaderText="WorkShopTitle"/>  
                <asp:BoundField DataField="MaterialDescription" HeaderText="Description"/>  
                 <asp:BoundField DataField="MaterialPath" HeaderText="MaterialPath"/> 

                         </Columns>
                     </asp:GridView>
           
       </td>
           
           
        </tr>
           
        </table>
</asp:Content>


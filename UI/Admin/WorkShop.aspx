<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="WorkShop.aspx.cs" Inherits="Admin_WorkShop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 366px;
            color:#fff;

        }
        .auto-style2 {
           width: 100%;
            
            color:#fff;
        }
        .auto-style3 {
            height: 14px;
        }
        .auto-style4 {
            width: 687px;
        }
        .auto-style5 {
            width: 533px;
            color: #FFFFFF;
            height: 14px;
        }
        .auto-style6 {
            width: 917px;
            color: #FFFFFF;
        }
        .auto-style7 {
            width: 533px;
            color: #FFFFFF;
        }
        .auto-style8 {
            width: 848px;
            color: #FFFFFF;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table style="width: 100%; height: 250px;">
        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style7">WorkShop Title:</td>
            <td><asp:TextBox ID="txtWorkShopTitle" runat="server" Width="315px"></asp:TextBox></td>
        </tr>

        <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style7">WorkShop Date:</td>
            <td><asp:TextBox ID="txtWorkShopDate" runat="server" Width="314px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style7">WorkShop Duration:</td>
            <td><asp:TextBox ID="txtWorkShopDuration" runat="server" Width="314px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style5">WorkShop Topics:</td>
            <td class="auto-style3"><asp:TextBox ID="txtWorkShopTopics" runat="server" TextMode="MultiLine" Width="29%"></asp:TextBox></td>
        </tr>
         </table>
    <table border="1">
        
         <tr>
            <td style="text-align:right; font-weight: 700;" class="auto-style8">

                Trainers</td>
             <td class="auto-style6">
                 <asp:CheckBoxList ID="ckbLTrainers" runat="server" style="text-align:left"></asp:CheckBoxList>
                </td>
        </tr>
         </table>
          
    <table>
             <tr class="auto-style1">
                 <td style="text-align:right" class="auto-style4">
                 <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click"/>
                      <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                      <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
                     <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                 </td>

                 
             </tr>
         </table>
       
    <table class="auto-style2">
        <tr>
            
            <td >
                 <%--<asp:GridView ID="GridView1" runat="server"  Style="text-align:right" Width="819px" AutoGenerateSelectButton="True" DataKeyNames="WorkShopId" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Height="50px">
                     </asp:GridView>--%>
                  <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" class="auto-style2" DataKeyNames="WorkShopId" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="text-align: center" Width="100%">
             <Columns>  
              <asp:BoundField DataField="WorkShopId" HeaderText="WorkShopId"/>  
                <asp:BoundField DataField="WorkShopTitle" HeaderText="WorkShopTitle"/>  
                <asp:BoundField DataField="WorkShopDate" DataFormatString="{0:d}" HeaderText="WorkShopDate"/>  
                 <asp:BoundField DataField="WorkShopDuration" HeaderText="WorkShopDuration"/> 
                <asp:BoundField DataField="WorkShopTopics" HeaderText="WorkShop Topics"/> 
               
                 </Columns>
        </asp:GridView>
                </td>
           
        </tr>
           
       
        <tr>
            <td >
                <br /><b>Trainers:</b><br />
               
                <asp:Button ID="btnAssign" runat="server" Text="Assign"  style="text-align:left" OnClick="btnAssign_Click"/>
                </td>
        </tr>
        
        </table>
</asp:Content>


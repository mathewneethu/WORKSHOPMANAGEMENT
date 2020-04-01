<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="WrokShopMasterDetailsScreen.aspx.cs" Inherits="Admin_WrokShopMasterDetailsScreen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
        .auto-style1 {
           
            
        }
        .auto-style2 {
            width: 100%;
            
            color:#fff;
        }
    </style>
    <script src="../Scripts/jquery-3.4.1.js"></script>
    <script src="../Scripts/jquery-ui-1.12.1.js"></script>
    <script>

        $(function () {
            $("#MyPopUp").dialog({ autoOpen: false });
            $("#btnAddTrainers").click(function (evt) {
                evt.preventDefault();
                $('#MyPopUp').dialog("open");
                $('#MyPopUp').parent().appendTo($("form:first"));
            });
        });
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <table style="width: 89%; height: 250px;" class="auto-style1">

        <tr>
            <td class="auto-style5">
            <asp:Label ID="lblWorkShopTitle" runat="server" Text="Label">WorkShopTitle:&nbsp</asp:Label>
            <asp:TextBox ID="txtWorkShopTitle" runat="server"></asp:TextBox>
                </td>
                       <td>

        <asp:Label ID="lblWorkShopDate" runat="server" Text="Label">WorkShopDate:&nbsp</asp:Label>
        <asp:TextBox ID="txtWorkShopDate" runat="server"></asp:TextBox>
                </td>

            <td>

        <asp:Label ID="lblWorkShopDuration" runat="server" Text="Label">WorkShopDuration:&nbsp</asp:Label>
        <asp:TextBox ID="txtWorkShopDuration" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
                 </td>
            <td>
        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                 <asp:Button ID="btnAddTrainers" runat="server" Text="Add" Enabled="false" ClientIDMode="Static"/>
                 </td>

         </tr>
       
        <tr>
            <td style="text-align:center" class="auto-style3" colspan="7">
                
        <asp:GridView ID="grdworkshop" runat="server"   Width="1177px" AutoGenerateSelectButton="True" DataKeyNames="WorkShopId" OnSelectedIndexChanged="grdworkshop_SelectedIndexChanged" Height="50px">
                     </asp:GridView>

            </td>
            </tr>
    </table> 
    <div id="MyPopUp" style="background-color:#FFFFFF; width=200px;color:#000000;">
        <asp:CheckBoxList ID="ckbLTrainers" runat="server"></asp:CheckBoxList>
        <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click"/>
        </br>
    </div>

</asp:Content>


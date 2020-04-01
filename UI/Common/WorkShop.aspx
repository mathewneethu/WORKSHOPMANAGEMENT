<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WorkShop.aspx.cs" Inherits="Common_WorkShop" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../default.css" rel="stylesheet" type="text/css" />
        <style type="text/css">
        .auto-style1 {
           
            
        }
        .auto-style2 {
            width: 100%;
            
            color:#fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="../Default.aspx">Back To Home</a>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateSelectButton="True" class="auto-style2" DataKeyNames="WorkShopId" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" style="text-align: center" Width="100%">
             <Columns>  
              <asp:BoundField DataField="WorkShopId" HeaderText="WorkShopId"/>  
                <asp:BoundField DataField="WorkShopTitle" HeaderText="WorkShopTitle"/>  
                <asp:BoundField DataField="WorkShopDate" DataFormatString="{0:d}" HeaderText="WorkShopDate"/>  
                 <asp:BoundField DataField="WorkShopDuration" HeaderText="WorkShopDuration"/> 
                <asp:BoundField DataField="WorkShopTopics" HeaderText="WorkShop Topics"/> 
               
                 </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>

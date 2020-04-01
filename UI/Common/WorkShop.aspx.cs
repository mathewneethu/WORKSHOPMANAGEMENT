using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Common_WorkShop : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetWorkShops();
        }
    }

    private void GetWorkShops()
    {
        WorkShopBusiness WB = new WorkShopBusiness();
        List<tbl_WorkShop> Ls = WB.GetWorkShopsForStudent();
        GridView1.DataSource = Ls;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int WorkShopId = int.Parse(GridView1.SelectedValue.ToString());
        Response.Redirect("Register.aspx?WorkShopId=" + WorkShopId);
    }
}
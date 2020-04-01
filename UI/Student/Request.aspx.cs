using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BOL;

public partial class Student_Request : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetWorkShopRequest();
        }
    }
    private void GetWorkShopRequest()
    {
        WorkShopBusiness WB = new WorkShopBusiness();
        List<WorkShopRequest> Ls = WB.GetWorkShopRequestForStudent();
        grdWorkShopRequest.DataSource = Ls;
        grdWorkShopRequest.DataBind();
    }
}
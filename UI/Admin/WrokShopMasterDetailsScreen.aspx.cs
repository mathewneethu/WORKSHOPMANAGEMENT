using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BOL;

public partial class Admin_WrokShopMasterDetailsScreen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetTrainers();
        }
    }
    private void GetTrainers()
    {
        UserBusiness UB = new UserBusiness();
        List<tbl_User> Ls = UB.GetTrainers();
        ckbLTrainers.DataSource = Ls;
        ckbLTrainers.DataTextField = "FirstName";
        ckbLTrainers.DataValueField = "UserId";
        ckbLTrainers.DataSource = Ls;
        ckbLTrainers.DataBind();


    } 
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        string Title = (txtWorkShopTitle.Text != "") ? txtWorkShopTitle.Text : null;
        DateTime? Date = null;
        if (txtWorkShopDate.Text != "")
        {
            Date = DateTime.Parse(txtWorkShopDate.Text);
        }
        string Duration = (txtWorkShopDuration.Text != "") ? txtWorkShopDuration.Text : null;

        WorkShopBusiness Wb = new WorkShopBusiness();
        var result = Wb.SearchWorkShop(Title,Date,Duration);

        grdworkshop.DataSource = result;
        grdworkshop.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<tbl_Trainer_WorkShop_Mapping> Ls = new List<tbl_Trainer_WorkShop_Mapping>();
        int WorkShopId = int.Parse(grdworkshop.SelectedValue.ToString());

        foreach(ListItem item in ckbLTrainers.Items)
        {
            if (item.Selected)
            {
                int TrainerId = int.Parse(item.Value);
                tbl_Trainer_WorkShop_Mapping twm = new tbl_Trainer_WorkShop_Mapping();
                twm.WorkShopId = WorkShopId;
                twm.TrainerId = TrainerId;
                Ls.Add(twm);
            }
        }
        if (Ls.Count > 0)
        {
            WorkShopBusiness WB = new WorkShopBusiness();
            WB.AssignTrainersToWorkShop(Ls);
        }
    }
    protected void grdworkshop_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnAddTrainers.Enabled = true;
    }
}
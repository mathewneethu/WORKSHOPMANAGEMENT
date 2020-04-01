using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

public partial class Admin_WorkShop : System.Web.UI.Page
{
    #region Events
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetWorkShops();
                GetTrainers();
            }
        }
        catch(Exception Ex)
        {
            Response.Write(Ex.Message+"Kindly Contact Admin!!");
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        tbl_WorkShop Wp = new tbl_WorkShop();
        Wp.WorkShopTitle = txtWorkShopTitle.Text;
        Wp.WorkShopDate = DateTime.Parse(txtWorkShopDate.Text);
        Wp.WorkShopTopics = txtWorkShopTopics.Text;
        Wp.WorkShopDuration = txtWorkShopDuration.Text;

        List<int> Ls = new List<int>();
        foreach (ListItem item in ckbLTrainers.Items)
        {
            int TrainerId;
            if (item.Selected)
            {
                TrainerId = int.Parse(item.Value);
                Ls.Add(TrainerId);
            }
        }
        WorkShopBusiness WB = new WorkShopBusiness();
        if (WB.InsertWorkShop(Wp, Ls))
        {
            lblMessage.Text = "Saved Successfully";
            ClearData();
        }
        GetWorkShops();

    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(GridView1.SelectedValue.ToString());
        WorkShopBusiness WB = new WorkShopBusiness();
        tbl_WorkShop Wp = WB.GetWorkShopById(id);
        txtWorkShopTitle.Text = Wp.WorkShopTitle;
        txtWorkShopDate.Text = Wp.WorkShopDate.Date.ToString();
        txtWorkShopDuration.Text = Wp.WorkShopDuration;
        txtWorkShopTopics.Text = Wp.WorkShopTopics;
        ckbLTrainers.ClearSelection();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tbl_WorkShop Wp = new tbl_WorkShop();
        Wp.WorkShopTitle = txtWorkShopTitle.Text;
        Wp.WorkShopDate = DateTime.Parse(txtWorkShopDate.Text);
        Wp.WorkShopTopics = txtWorkShopTopics.Text;
        Wp.WorkShopDuration = txtWorkShopDuration.Text;

        WorkShopBusiness WB = new WorkShopBusiness();
        int id = int.Parse(GridView1.SelectedValue.ToString());
        if (WB.UpdateWorkShopById(Wp, id))
        {
            lblMessage.Text = "Updated Successfully";
            ClearData();
        }
        GetWorkShops();
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        WorkShopBusiness WB = new WorkShopBusiness();
        int id = int.Parse(GridView1.SelectedValue.ToString());
        if (WB.DeleteWorkShopById(id))
        {
            lblMessage.Text = "Deleted Successfully";
            ClearData();
        }
        GetWorkShops();
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void btnAssign_Click(object sender, EventArgs e)
    {
        List<tbl_Trainer_WorkShop_Mapping> Ls = new List<tbl_Trainer_WorkShop_Mapping>();
        int WorkshopId = int.Parse(GridView1.SelectedValue.ToString());
        foreach (ListItem item in ckbLTrainers.Items)
        {
            if (item.Selected)
            {
                int TrainerId = int.Parse(item.Value);
                tbl_Trainer_WorkShop_Mapping twm = new tbl_Trainer_WorkShop_Mapping();
                twm.WorkShopId = WorkshopId;
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
    #endregion

    #region PrivateMethods
    private void GetWorkShops()
    {
        WorkShopBusiness WB = new WorkShopBusiness();
        List<tbl_WorkShop> Ls = WB.GetWorkShops();
        GridView1.DataSource = Ls;
        GridView1.DataBind();
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
    private void ClearData()
    {
        txtWorkShopTitle.Text = "";
        txtWorkShopDate.Text = "";
        txtWorkShopDuration.Text = "";
        txtWorkShopTopics.Text = "";
        ckbLTrainers.ClearSelection();

    }
    #endregion
}
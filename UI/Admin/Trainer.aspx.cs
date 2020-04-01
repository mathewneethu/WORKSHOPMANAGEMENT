using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

public partial class Admin_Trainer : System.Web.UI.Page
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

        grdTrainers.DataSource = Ls;
        grdTrainers.DataBind();
    }
    protected void txtSave_Click(object sender, EventArgs e)
    {
        tbl_User U = new tbl_User();
        U.UserName_Email = txtEmail.Text;
        U.FirstName = txtTrainerFirstName.Text;
        U.LastName = txtLastName.Text;
        U.RoleId = 2;
        U.Mobile = txtMobileNo.Text;
        U.SkillsSet = txtskillset.Text;
        U.Experience = txtExperience.Text;

        UserBusiness UB = new UserBusiness();
        if (UB.CreateTrainer(U))
        {
            lblMessage.Text = "Saved Successfully";
            ClearData();
        }
        GetTrainers();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tbl_User U = new tbl_User();
        U.UserName_Email = txtEmail.Text;
        U.FirstName = txtTrainerFirstName.Text;
        U.LastName = txtLastName.Text;
        U.RoleId = 2;
        U.Mobile = txtMobileNo.Text;
        U.SkillsSet = txtskillset.Text;
        U.Experience = txtExperience.Text;

        UserBusiness UB = new UserBusiness();
        
        int id = int.Parse(grdTrainers.SelectedValue.ToString());
        if (UB.UpdateTrainerById(U, id))
        {
            lblMessage.Text = "Updated Successfully";
            ClearData();
        }
        GetTrainers();
    }

    protected void grdTrainers_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(grdTrainers.SelectedValue.ToString());
        UserBusiness UB = new UserBusiness();
        tbl_User U = UB.GetTrainerById(id);
        txtTrainerFirstName.Text = U.FirstName;
        txtLastName.Text = U.LastName;
        txtEmail.Text = U.UserName_Email;
        txtMobileNo.Text = U.Mobile;
        txtskillset.Text = U.SkillsSet;
        txtExperience.Text = U.Experience;

    }
    private void ClearData()
    {
        txtTrainerFirstName.Text = "";
        txtLastName.Text = "";
        txtEmail.Text = "";
        txtMobileNo.Text = "";
        txtskillset.Text = "";
        txtExperience.Text = "";
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        UserBusiness UB = new UserBusiness();
        int id = int.Parse(grdTrainers.SelectedValue.ToString());
        if (UB.DeleteProfileById(id))
        {
            lblMessage.Text = "Deleted Successfully";
            ClearData();
        }
        GetTrainers();
    }
}
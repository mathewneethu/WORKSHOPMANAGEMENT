using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

public partial class Student_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetStudentsList();
            }
        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message + "Kindly Contact Admin!!");
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        tbl_User U = new tbl_User();
        U.FirstName = txtFirstName.Text;
        U.LastName = txtLastName.Text;
        U.UserDob = DateTime.Parse(txtDateofBirth.Text);
        U.Mobile = txtMobile.Text;
        U.SkillsSet = txtSkillSet.Text;
        U.UserName_Email = txtUserNameEmail.Text;
        U.Password = txtPassword.Text;
        U.UserGender = rblGender.Text;
        
        UserBusiness UB = new UserBusiness();
        if (UB.InsertProfile(U))
        {
            Response.Write("Profile Created Successfully");
            ClearData();
        }
        GetStudentsList();
       
    }

    private void GetStudentsList()
    {
        UserBusiness UB = new UserBusiness();
        List<tbl_User> Ls = UB.GetStudentsList();
        gridStudent.DataSource = Ls;
        gridStudent.DataBind();
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        tbl_User U = new tbl_User();
        U.FirstName = txtFirstName.Text;
        U.LastName = txtLastName.Text;
        U.UserDob = DateTime.Parse(txtDateofBirth.Text);
        U.Mobile = txtMobile.Text;
        U.SkillsSet = txtSkillSet.Text;
        U.UserName_Email = txtUserNameEmail.Text;
        U.Password = txtPassword.Text;
        U.UserGender = rblGender.Text;

        UserBusiness UB = new UserBusiness();
        int id = int.Parse(gridStudent.SelectedValue.ToString());
        if (UB.UpdateProfileById(U, id))
        {
            lblMessage.Text = "Updated Successfully";
            ClearData();
        }
        GetStudentsList();
    }

    protected void gridStudent_SelectedIndexChanged(object sender, EventArgs e)
    {
        int id = int.Parse(gridStudent.SelectedValue.ToString());
        UserBusiness UB = new UserBusiness();
        tbl_User U = UB.GetProfileById(id);
        txtFirstName.Text = U.FirstName;
        txtLastName.Text = U.LastName;
        rblGender.Text = U.UserGender;
        txtDateofBirth.Text = U.UserDob.ToString();
        txtMobile.Text = U.Mobile;
        txtSkillSet.Text = U.SkillsSet;
        txtUserNameEmail.Text = U.UserName_Email;
        txtPassword.Text = U.Password;
       
    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        UserBusiness UB = new UserBusiness();
        int id = int.Parse(gridStudent.SelectedValue.ToString());
        if (UB.DeleteProfileById(id))
        {
            lblMessage.Text = "Deleted Successfully";
            ClearData();
        }
        GetStudentsList();
    }
    private void ClearData()
    {
        txtFirstName.Text = "";
        txtLastName.Text = "";
        rblGender.ClearSelection();
        txtDateofBirth.Text = "";
        txtMobile.Text = "";
        txtSkillSet.Text = "";
        txtUserNameEmail.Text = "";
        txtPassword.Text = "";
    }
}
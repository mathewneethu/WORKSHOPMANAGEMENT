using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BOL;
using BLL;

public partial class Admin_Material : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                GetWorkShops();
                GetMaterials();
            }
        }
        catch (Exception Ex)
        {
            Response.Write(Ex.Message + "Kindly Contact Admin!!");
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    private void GetWorkShops()
    {
        WorkShopBusiness WB = new WorkShopBusiness();
        List<tbl_WorkShop> Ls = WB.GetWorkShops();
        ddlWorkShop.DataSource = Ls;
        ddlWorkShop.DataValueField = "WorkShopId";
        ddlWorkShop.DataTextField = "WorkShopTitle";
        ddlWorkShop.DataBind();
    }
    private void GetMaterials()
    {
        MaterialBusiness MB = new MaterialBusiness();
        List<WorkShopMaterial> Ls = MB.GetMaterials();
        GridMaterial.DataSource = Ls;
        GridMaterial.DataBind();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (fuldMaterial.HasFile)
        {
            string path = Server.MapPath("~//Material//");
            fuldMaterial.SaveAs(path + fuldMaterial.FileName);
            tbl_Material M = new tbl_Material();
            M.WorkShopId = int.Parse(ddlWorkShop.SelectedValue);
            M.MaterialPath = "~//Material//" + fuldMaterial.FileName;
            M.MaterialDescription = txtDescription.Text;
            MaterialBusiness MB = new MaterialBusiness();
            MB.CreateMaterial(M);
            lblMessage.Text = "Uploaded Successfully";
          //  ClearData();
            GetMaterials();
        }
    }
    private void ClearData()
    {
        txtDescription.Text = "";
       // ddlWorkShop.Text = "";
    }
}
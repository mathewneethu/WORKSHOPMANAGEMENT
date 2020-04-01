using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using System.Data;
using System.Data.SqlClient;
namespace DAL
{
    public class MaterialDb : DALBase
    {
        public bool CreateMaterial(BOL.tbl_Material M)
        {
            string CmdStr = @"insert into tbl_Material(MaterialDescription,MaterialPath,WorkShopId)
                            values(@MaterialDescription,@MaterialPath,@WorkShopId)";
            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand Cmd = new SqlCommand(CmdStr, Con);
            Cmd.Parameters.AddWithValue("@MaterialDescription", M.MaterialDescription);
            Cmd.Parameters.AddWithValue("@MaterialPath", M.MaterialPath);
            Cmd.Parameters.AddWithValue("@WorkShopId",M.WorkShopId);
            Con.Open();
            Cmd.ExecuteNonQuery();
            Con.Close();
            return true;

        }
        public List<WorkShopMaterial> GetMaterials()
        {
            try
            {
                List<WorkShopMaterial> Ls;
                Ls = new List<WorkShopMaterial>();
                string cmdStr = @"SELECT  M.MaterialId,M.MaterialDescription,M. MaterialPath, W.WorkShopTitle,W.WorkShopId 
                                                FROM  tbl_Material M join tbl_Workshop W on M.WorkShopId=W.WorkShopId";
                SqlConnection con = new SqlConnection(ConStr);
                SqlCommand cmd = new SqlCommand(cmdStr, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    WorkShopMaterial Mt = new WorkShopMaterial();
                    Mt.MaterialId = int.Parse(dr["MaterialId"].ToString());
                    Mt.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                    Mt.WorkShopTitle = dr["WorkShopTitle"].ToString();
                    Mt.MaterialDescription = dr["MaterialDescription"].ToString();
                    Mt.MaterialPath = dr["MaterialPath"].ToString();
                    Ls.Add(Mt);
                }
                dr.Close();
                con.Close();
                return Ls;
            }
            catch
            {
                throw;
            }
        }
    }
}

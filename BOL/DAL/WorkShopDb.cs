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
    public class WorkShopDb:DALBase
    {
        #region Get
        public List<tbl_WorkShop> GetWorkShops()
        {
            List<tbl_WorkShop> Ls;
            Ls = new List<tbl_WorkShop>();


            string CmdStr = "select * from tbl_WorkShop";
            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand Cmd = new SqlCommand(CmdStr, Con);
            Con.Open();
            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                tbl_WorkShop Wp = new tbl_WorkShop();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();
                Ls.Add(Wp);
            }
            dr.Close();
            Con.Close();
            return Ls;
        }

        public List<tbl_WorkShop> GetWorkShopsForStudent()
        {
            List<tbl_WorkShop> Ls;
            Ls = new List<tbl_WorkShop>();


            string CmdStr = "SELECT WorkShopId,WorkShopTitle,WorkShopDuration, CAST(WorkShopDate As date) as WorkShopDate,WorkShopTopics FROM tbl_WorkShop";
            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand Cmd = new SqlCommand(CmdStr, Con);
            Con.Open();
            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                tbl_WorkShop Wp = new tbl_WorkShop();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();
                Ls.Add(Wp);
            }
            dr.Close();
            Con.Close();
            return Ls;
        }

        public List<WorkShopRequest> GetWorkShopRequest()
        {
            List<WorkShopRequest> Ls;
            Ls = new List<WorkShopRequest>();
            string CmdStr = @"SELECT tbl_User.UserId,tbl_User.UserName_Email,tbl_WorkShop.WorkShopId,tbl_WorkShop.WorkShopTitle,tbl_Student_WorkShop_Mapping.IsApproved
                              FROM tbl_Student_WorkShop_Mapping Left outer JOIN tbl_User ON tbl_User.UserId=tbl_Student_WorkShop_Mapping.StudentId Left outer JOIN
                              tbl_WorkShop ON tbl_Student_WorkShop_Mapping.WorkShopId=tbl_WorkShop.WorkShopId";
            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand Cmd = new SqlCommand(CmdStr, Con);
            Con.Open();
            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                WorkShopRequest Wp = new WorkShopRequest();
                Wp.UserId = int.Parse(dr["UserId"].ToString());
                Wp.UserName_Email = dr["UserName_Email"].ToString();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.IsApproved = (dr["IsApproved"].ToString() == "") ? false : bool.Parse(dr["IsApproved"].ToString());
                Ls.Add(Wp);
            }
            dr.Close();
            Con.Close();
            return Ls;
        }
        public List<WorkShopRequest> GetWorkShopRequestForStudent()
        {
            List<WorkShopRequest> Ls;
            Ls = new List<WorkShopRequest>();
            string CmdStr = @"SELECT tbl_User.UserId, tbl_User.UserName_Email,tbl_WorkShop.WorkShopId,tbl_WorkShop.WorkShopTitle,tbl_Student_WorkShop_Mapping.IsApproved
                              FROM tbl_Student_WorkShop_Mapping Left outer JOIN tbl_User ON tbl_User.UserId=tbl_Student_WorkShop_Mapping.StudentId Left outer JOIN
                              tbl_WorkShop ON tbl_Student_WorkShop_Mapping.WorkShopId=tbl_WorkShop.WorkShopId";
            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand Cmd = new SqlCommand(CmdStr, Con);
            Con.Open();
            SqlDataReader dr = Cmd.ExecuteReader();
            while (dr.Read())
            {
                WorkShopRequest Wp = new WorkShopRequest();
                Wp.UserId = int.Parse(dr["UserId"].ToString());
                Wp.UserName_Email = dr["UserName_Email"].ToString();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.IsApproved = (dr["IsApproved"].ToString() == "") ? false : bool.Parse(dr["IsApproved"].ToString());
                Ls.Add(Wp);
            }
            dr.Close();
            Con.Close();
            return Ls;
        }

        public tbl_WorkShop GetWorkShopById(int WorkShopId)
        {
            tbl_WorkShop Wp = null;

            string CmdStr = "select * from tbl_WorkShop where WorkShopId=@WorkShopId";
            SqlConnection Con = new SqlConnection(ConStr);
            SqlCommand Cmd = new SqlCommand(CmdStr, Con);
            Cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
            Con.Open();
            SqlDataReader dr = Cmd.ExecuteReader();
            if (dr.Read())
            {
                Wp = new tbl_WorkShop();
                Wp.WorkShopId = int.Parse(dr["WorkShopId"].ToString());
                Wp.WorkShopTitle = dr["WorkShopTitle"].ToString();
                Wp.WorkShopDate = DateTime.Parse(dr["WorkShopDate"].ToString());
                Wp.WorkShopDuration = dr["WorkShopDuration"].ToString();
                Wp.WorkShopTopics = dr["WorkShopTopics"].ToString();
            }
            dr.Close();
            Con.Close();
            return Wp;
        } 



        #endregion


        #region POST
        public bool InsertWorkShop(tbl_WorkShop WP, List<int> Ls)
        {

            SqlConnection Con = new SqlConnection(ConStr);

            string CmdStr = "insert into tbl_WorkShop values(@WorkShopTitle,@WorkShopDate,@WorkShopDuration,@WorkShopTopics,null,null,null,null);select Scope_Identity() as Id";
            string CmdStr2 = "insert into tbl_Trainer_WorkShop_Mapping values(@TrainerId,@WorkShopId,null,null,null,null)";
            Con.Open();
            SqlTransaction SqlTrans = Con.BeginTransaction();
            try
            {
                //Inserting WorkShop
                SqlCommand Cmd = new SqlCommand(CmdStr, Con, SqlTrans);
                Cmd.Parameters.AddWithValue("@WorkShopTitle", WP.WorkShopTitle);
                Cmd.Parameters.AddWithValue("@WorkShopDate", WP.WorkShopDate);
                Cmd.Parameters.AddWithValue("@WorkShopDuration", WP.WorkShopDuration);
                Cmd.Parameters.AddWithValue("@WorkShopTopics", WP.WorkShopTopics);
                SqlDataReader dr = Cmd.ExecuteReader();

                //Reading WorkShopId Returned from Scope_Identity
                int WorkShopId = 0;
                if (dr.Read())
                {
                    WorkShopId = int.Parse(dr[0].ToString());
                }

                dr.Close();

                //inserting multiple records to tbl_Trainer_WorkShop_Mapping
                if (WorkShopId != 0)
                {
                    foreach (var TrainerId in Ls)
                    {
                        SqlCommand Cmd2 = new SqlCommand(CmdStr2, Con, SqlTrans);
                        Cmd2.Parameters.AddWithValue("@TrainerId", TrainerId);
                        Cmd2.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                        Cmd2.ExecuteNonQuery();
                    }
                }

                SqlTrans.Commit();
                Con.Close();
                return true;
            }
            catch
            {
                SqlTrans.Rollback();
                return false;
            }
        }

        public bool UpdateWorkShopById(tbl_WorkShop Wp, int WorkShopId)
        {
            try
            {

                string CmdStr = "Update tbl_WorkShop set WorkShopTitle=@WorkShopTitle,WorkShopDate=@WorkShopDate,WorkShopDuration=@WorkShopDuration,WorkShopTopics=@WorkShopTopics where WorkShopId=@WorkShopId";
                SqlConnection Con = new SqlConnection(ConStr);
                SqlCommand Cmd = new SqlCommand(CmdStr, Con);
                Cmd.Parameters.AddWithValue("@WorkShopTitle", Wp.WorkShopTitle);
                Cmd.Parameters.AddWithValue("@WorkShopDate", Wp.WorkShopDate);
                Cmd.Parameters.AddWithValue("@WorkShopDuration", Wp.WorkShopDuration);
                Cmd.Parameters.AddWithValue("@WorkShopTopics", Wp.WorkShopTopics);
                Cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool AppOrRejectWorkShopRequest(tbl_Student_WorkShop_Mapping swp)
        {
            try
            {
                string CmdStr = @"Update tbl_Student_WorkShop_Mapping
                                  set IsApproved=@IsApproved
                                  where WorkShopId=@WorkShopId";
                SqlConnection Con = new SqlConnection(ConStr);
                SqlCommand Cmd = new SqlCommand(CmdStr, Con);
                Cmd.Parameters.AddWithValue("@IsApproved", swp.IsApproved == true ? 1 : 0);
                Cmd.Parameters.AddWithValue("@WorkShopId", swp.WorkShopId);
                Cmd.Parameters.AddWithValue("@StudentId", swp.StudentId);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteWorkShopById(int WorkShopId)
        {
            try
            {

                string CmdStr = "Delete from tbl_WorkShop where WorkShopId=@WorkShopId";
                SqlConnection Con = new SqlConnection(ConStr);
                SqlCommand Cmd = new SqlCommand(CmdStr, Con);
                Cmd.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                Con.Open();
                Cmd.ExecuteNonQuery();
                Con.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool AssignTrainersToWorkShop(List<tbl_Trainer_WorkShop_Mapping> Ls)
        {

            SqlConnection Con = new SqlConnection(ConStr);
            Con.Open();
            SqlTransaction SqlTrans = Con.BeginTransaction();
            try
            {

                foreach (var item in Ls)
                {
                    string CmdStr = "insert into tbl_Trainer_WorkShop_Mapping values(@TrainerId,@WorkShopId,null,null,null,null)";

                    SqlCommand Cmd = new SqlCommand(CmdStr, Con, SqlTrans);
                    Cmd.Parameters.AddWithValue("@TrainerId", item.TrainerId);
                    Cmd.Parameters.AddWithValue("@WorkShopId", item.WorkShopId);
                    Cmd.ExecuteNonQuery();

                }
                SqlTrans.Commit();
                Con.Close();
                return true;
            }
            catch
            {
                SqlTrans.Rollback();
                return false;
            }
        }  
        #endregion

    }
}

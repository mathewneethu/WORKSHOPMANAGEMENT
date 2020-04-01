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
  public   class UserDb:DALBase
    {
     
      public List<tbl_User> GetTrainers()
      {
          try
          {
              List<tbl_User> Ls;
              Ls = new List<tbl_User>();


              string CmdStr = @"select tbl_User.UserId,tbl_User.FirstName,tbl_User.LastName,tbl_User.UserName_Email,tbl_User.Mobile,tbl_User.SkillsSet,tbl_User.Experience
                                from tbl_User inner join tbl_Role on tbl_User.RoleId=tbl_Role.RoleId where (tbl_Role.RoleName='Trainer')";
              SqlConnection Con = new SqlConnection(ConStr);
              SqlCommand Cmd = new SqlCommand(CmdStr, Con);
              Con.Open();
              SqlDataReader dr = Cmd.ExecuteReader();
              while (dr.Read())
              {
                  tbl_User Tr = new tbl_User();
                  Tr.UserId = int.Parse(dr["UserId"].ToString());
                  Tr.FirstName = dr["FirstName"].ToString();
                  Tr.LastName = dr["LastName"].ToString();
                  Tr.UserName_Email = dr["UserName_Email"].ToString();
                  Tr.Mobile = dr["Mobile"].ToString();
                  Tr.SkillsSet = dr["SkillsSet"].ToString();
                  Tr.Experience = dr["Experience"].ToString();
                  Ls.Add(Tr);
              }
              dr.Close();
              Con.Close();
              return Ls;
          }
          catch
          {
              throw;
          }
      }

      public bool CreateUserRequest(tbl_User U, int WorkShopId)
      {

          SqlConnection Con = new SqlConnection(ConStr);
          Con.Open();
          SqlTransaction SqlTrans = Con.BeginTransaction();
          string CmdStr = @"insert into tbl_User (UserName_Email,RoleId) values(@UserName_Email,3);
                                            select Scope_Identity() as Id";
          string CmdStr2 = "insert into tbl_Student_WorkShop_Mapping values(@StudentId,@WorkShopId,0) ";
          
          
          try
          {
              //Inserting WorkShop
              SqlCommand cmd = new SqlCommand(CmdStr, Con, SqlTrans);
              cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
              SqlDataReader dr = cmd.ExecuteReader();
              //Reading StudentId Returned from Scope_Identity
              int StudentId = 0;
              if (dr.Read())
              {
                  StudentId = int.Parse(dr[0].ToString());
              }

              dr.Close();

              //inserting multiple records to tbl_Trainer_WorkShop_Mapping
              
                      SqlCommand cmd2 = new SqlCommand(CmdStr2, Con, SqlTrans);
                      cmd2.Parameters.AddWithValue("@StudentId", StudentId);
                      cmd2.Parameters.AddWithValue("@WorkShopId", WorkShopId);
                      cmd2.ExecuteNonQuery();
                

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

      public bool CreateUserRequestCurrentUser(tbl_User U, int WorkShopId)
      {

          SqlConnection Con = new SqlConnection(ConStr);
          Con.Open();
          SqlTransaction SqlTrans = Con.BeginTransaction();
          string CmdStr = @"insert into tbl_User (UserName_Email,RoleId) values(@UserName_Email,3);
                                            select Scope_Identity() as Id";
          string CmdStr2 = "insert into tbl_Student_WorkShop_Mapping values(@StudentId,@WorkShopId,0) ";


          try
          {
              //Inserting WorkShop
              SqlCommand cmd = new SqlCommand(CmdStr, Con, SqlTrans);
              cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
              SqlDataReader dr = cmd.ExecuteReader();
              //Reading StudentId Returned from Scope_Identity
              int StudentId = 0;
              if (dr.Read())
              {
                  StudentId = int.Parse(dr[0].ToString());
              }

              dr.Close();

              //inserting multiple records to tbl_Trainer_WorkShop_Mapping

              SqlCommand cmd2 = new SqlCommand(CmdStr2, Con, SqlTrans);
              cmd2.Parameters.AddWithValue("@StudentId", StudentId);
              cmd2.Parameters.AddWithValue("@WorkShopId", WorkShopId);
              cmd2.ExecuteNonQuery();


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

      public bool ValidateUser(tbl_User U)
      {
          string CmdStr = @"SELECT * FROM tbl_User WHERE (UserName_Email=@UserName_Email and Password=@Password)";
          SqlConnection Con = new SqlConnection(ConStr);
          SqlCommand Cmd = new SqlCommand(CmdStr, Con);
          Cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
          Cmd.Parameters.AddWithValue("@Password", U.Password);
          Con.Open();
          SqlDataReader dr = Cmd.ExecuteReader();
          if(dr.Read())
          {
              U.UserId = int.Parse(dr["UserId"].ToString());
              U.RoleId = int.Parse(dr["RoleId"].ToString());
          }
          dr.Close();
          Con.Close();
          if (U.UserId != 0)
              return true;
          else
              return false;

      }

      public bool CreateTrainer(tbl_User U)
      {
          string cmdStr = @"insert into  tbl_User (UserName_Email,FirstName,LastName,RoleId,SkillsSet,Experience,Mobile)
                                            values  (@UserName_Email,@FirstName,@LastName,@RoleId,@SkillsSet,@Experience,@Mobile)";
          SqlConnection con = new SqlConnection(ConStr);
          SqlCommand cmd = new SqlCommand(cmdStr, con);
          cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
          cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
          cmd.Parameters.AddWithValue("@LastName", U.LastName);
          cmd.Parameters.AddWithValue("@RoleId", U.RoleId);
          cmd.Parameters.AddWithValue("@Mobile", U.Mobile);
          cmd.Parameters.AddWithValue("@SkillsSet", U.SkillsSet); 
          cmd.Parameters.AddWithValue("@Experience", U.Experience);
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
          return true;
      }

      public bool InsertProfile(tbl_User U)
      {
          string cmdStr = @"insert into  tbl_User (FirstName,LastName,RoleId,SkillsSet,Mobile,UserName_Email,Password,UserDob,UserGender)
                                            values  (@FirstName,@LastName,@RoleId,@SkillsSet,@Mobile,@UserName_Email,@Password,@UserDob,@UserGender)";
          SqlConnection con = new SqlConnection(ConStr);
          SqlCommand cmd = new SqlCommand(cmdStr, con);
          cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
          cmd.Parameters.AddWithValue("@LastName", U.LastName);
          cmd.Parameters.AddWithValue("@RoleId", 3);
          cmd.Parameters.AddWithValue("@SkillsSet", U.SkillsSet);
          cmd.Parameters.AddWithValue("@Mobile", U.Mobile);
          cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
          cmd.Parameters.AddWithValue("@Password", U.Password);
          cmd.Parameters.AddWithValue("@UserDob", U.UserDob);
          cmd.Parameters.AddWithValue("@UserGender", U.UserGender);

          
         
          
          con.Open();
          cmd.ExecuteNonQuery();
          con.Close();
          return true;
      }

      public List<tbl_User> GetStudents()
      {
          try
          {
              List<tbl_User> Ls;
              Ls = new List<tbl_User>();
//              string cmdStr = @"SELECT * FROM tbl_User INNER JOIN
//                                            tbl_Role ON tbl_User.RoleId = tbl_Role.RoleId
//                                            WHERE (tbl_Role.RoleName = 'Student')";
              string cmdStr = @"select tbl_User.UserId,tbl_User.FirstName,tbl_User.LastName,tbl_User.UserName_Email,tbl_User.Mobile,tbl_User.SkillsSet,tbl_User.UserGender
                                from tbl_User inner join tbl_Role on tbl_User.RoleId=tbl_Role.RoleId where (tbl_Role.RoleName='Student')";
              SqlConnection con = new SqlConnection(ConStr);
              SqlCommand cmd = new SqlCommand(cmdStr, con);
              con.Open();
              SqlDataReader dr = cmd.ExecuteReader();
              while (dr.Read())
              {
                  tbl_User Tr = new tbl_User();
                  Tr.UserId = int.Parse(dr["UserId"].ToString());
                  Tr.FirstName = dr["FirstName"].ToString();
                  Tr.LastName = dr["LastName"].ToString();
                  Tr.UserName_Email = dr["UserName_Email"].ToString();
                  Tr.Mobile = dr["Mobile"].ToString();
                  Tr.SkillsSet = dr["SkillsSet"].ToString();
                  //Tr.UserGender = dr["UserGender"].ToString();
                  if (dr["UserGender"] == "F")
                  {
                      Tr.UserGender = "Female";
                  }
                  else
                  {
                      Tr.UserGender = "Male";
                  
                  }
                  Ls.Add(Tr);
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

      public List<tbl_User> GetStudentsList()
      {
          List<tbl_User> Ls;
          Ls = new List<tbl_User>();


          string CmdStr = @"select tbl_User.UserId,tbl_User.FirstName,tbl_User.LastName,tbl_User.UserDob,  tbl_User.Password, tbl_User.UserName_Email,tbl_User.Mobile,tbl_User.SkillsSet,tbl_User.UserGender,tbl_Role.RoleId
                                from tbl_User inner join tbl_Role on tbl_User.RoleId=tbl_Role.RoleId where (tbl_Role.RoleName='Student')";
          SqlConnection Con = new SqlConnection(ConStr);
          SqlCommand Cmd = new SqlCommand(CmdStr, Con);
          Con.Open();
          SqlDataReader dr = Cmd.ExecuteReader();
          while (dr.Read())
          {
              tbl_User Wp = new tbl_User();
              Wp.UserId = int.Parse(dr["UserId"].ToString());
              Wp.FirstName = dr["FirstName"].ToString();
              Wp.LastName = dr["LastName"].ToString();
              if (dr["UserDob"].ToString() != "")
              {
                  Wp.UserDob = DateTime.Parse(dr["UserDob"].ToString());
              }
              
              Wp.Password = dr["Password"].ToString();
              Wp.UserName_Email = dr["UserName_Email"].ToString();
              Wp.Mobile = dr["Mobile"].ToString();
              Wp.SkillsSet = dr["SkillsSet"].ToString();
              if (dr["UserGender"].ToString() == "F")
              {
                  Wp.UserGender = "Female";
              }
              else
              {
                  Wp.UserGender = "Male";
              }
              Wp.RoleId =int.Parse(dr["RoleId"].ToString());
              Ls.Add(Wp);
          }
          dr.Close();
          Con.Close();
          return Ls;
      }

      public bool UpdateProfileById(tbl_User U, int UserId)
      {
          try
          {

              string CmdStr = @"Update tbl_User set 
                                FirstName=@FirstName,
                                LastName=@LastName,
                                RoleId=@RoleId,
                                SkillsSet=@SkillsSet,
                                Mobile=@Mobile,
                                UserName_Email=@UserName_Email,
                                Password=@Password,
                                UserDob=@UserDob,
                                UserGender=@UserGender
                                where UserId=@UserId;";
              SqlConnection Con = new SqlConnection(ConStr);
              SqlCommand Cmd = new SqlCommand(CmdStr, Con);
              Cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
              Cmd.Parameters.AddWithValue("@LastName", U.LastName);
              Cmd.Parameters.AddWithValue("@RoleId", 3);
              Cmd.Parameters.AddWithValue("@SkillsSet", U.SkillsSet);
              Cmd.Parameters.AddWithValue("@Mobile", U.Mobile);
              Cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
              Cmd.Parameters.AddWithValue("@Password", U.Password);
              Cmd.Parameters.AddWithValue("@UserDob", U.UserDob);
              Cmd.Parameters.AddWithValue("@UserGender", U.UserGender);
              Cmd.Parameters.AddWithValue("@UserId", UserId);
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

      public bool UpdateTrainerById(tbl_User U, int UserId)
      {
          try
          {

              string CmdStr = @"Update tbl_User set 
                                FirstName=@FirstName,
                                LastName=@LastName,
								UserName_Email=@UserName_Email,
								Mobile=@Mobile,
								SkillsSet=@SkillsSet,
                                Experience=@Experience
                                where UserId=@UserId;";
              SqlConnection Con = new SqlConnection(ConStr);
              SqlCommand Cmd = new SqlCommand(CmdStr, Con);
              Cmd.Parameters.AddWithValue("@FirstName", U.FirstName);
              Cmd.Parameters.AddWithValue("@LastName", U.LastName);
              Cmd.Parameters.AddWithValue("@SkillsSet", U.SkillsSet);
              Cmd.Parameters.AddWithValue("@Experience", U.Experience);
              Cmd.Parameters.AddWithValue("@Mobile", U.Mobile);
              Cmd.Parameters.AddWithValue("@UserName_Email", U.UserName_Email);
              Cmd.Parameters.AddWithValue("@UserId", UserId);
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

      public tbl_User GetProfileById(int UserId)
      {
          tbl_User Wp = null;

          string CmdStr = @"select tbl_User.UserId,tbl_User.FirstName,tbl_User.LastName,
                            tbl_User.UserName_Email,CAST(tbl_User.UserDob As date) as UserDob,
                            tbl_User.Password, tbl_User.Mobile,tbl_User.SkillsSet,tbl_User.UserGender,tbl_User.RoleId
                            from tbl_User inner join tbl_Role on tbl_User.RoleId=tbl_Role.RoleId
                            where (tbl_Role.RoleName='Student') AND tbl_User.UserId=@UserId";
          SqlConnection Con = new SqlConnection(ConStr);
          SqlCommand Cmd = new SqlCommand(CmdStr, Con);
          Cmd.Parameters.AddWithValue("@UserId", UserId);
          Con.Open();
          SqlDataReader dr = Cmd.ExecuteReader();
          if (dr.Read())
          {
              Wp = new tbl_User();
              Wp.UserId = int.Parse(dr["UserId"].ToString());
              Wp.FirstName = dr["FirstName"].ToString();
              Wp.LastName = dr["LastName"].ToString();
              Wp.RoleId = int.Parse(dr["RoleId"].ToString());
              Wp.SkillsSet = dr["SkillsSet"].ToString();
              Wp.Mobile = dr["Mobile"].ToString();
              Wp.UserName_Email = dr["UserName_Email"].ToString();
              Wp.Password = dr["Password"].ToString();
              if (dr["UserDob"].ToString() != "")
              {
                  Wp.UserDob = DateTime.Parse(dr["UserDob"].ToString());
              }

              Wp.UserGender = dr["UserGender"].ToString();

          }
          dr.Close();
          Con.Close();
          return Wp;
      }

      public tbl_User GetTrainerById(int UserId)
      {
          tbl_User Wp = null;

          string CmdStr = @"select tbl_User.UserId,tbl_User.FirstName,tbl_User.LastName,
                            tbl_User.UserName_Email,
                            tbl_User.Mobile,tbl_User.SkillsSet,tbl_User.Experience, tbl_User.RoleId
                            from tbl_User inner join tbl_Role on tbl_User.RoleId=tbl_Role.RoleId
                            where (tbl_Role.RoleName='Trainer') AND tbl_User.UserId=@UserId";
          SqlConnection Con = new SqlConnection(ConStr);
          SqlCommand Cmd = new SqlCommand(CmdStr, Con);
          Cmd.Parameters.AddWithValue("@UserId", UserId);
          Con.Open();
          SqlDataReader dr = Cmd.ExecuteReader();
          if (dr.Read())
          {
              Wp = new tbl_User();
              Wp.UserId = int.Parse(dr["UserId"].ToString());
              Wp.FirstName = dr["FirstName"].ToString();
              Wp.LastName = dr["LastName"].ToString();
              Wp.RoleId = int.Parse(dr["RoleId"].ToString());
              Wp.SkillsSet = dr["SkillsSet"].ToString();
              Wp.Mobile = dr["Mobile"].ToString();
              Wp.UserName_Email = dr["UserName_Email"].ToString();
              Wp.Experience = dr["Experience"].ToString();
             
          }
          dr.Close();
          Con.Close();
          return Wp;
      }

      public bool DeleteProfileById(int UserId)
      {
          try
          {

              string CmdStr = "Delete from tbl_User where UserId=@UserId";
              SqlConnection Con = new SqlConnection(ConStr);
              SqlCommand Cmd = new SqlCommand(CmdStr, Con);
              Cmd.Parameters.AddWithValue("@UserId", UserId);
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
    }
}

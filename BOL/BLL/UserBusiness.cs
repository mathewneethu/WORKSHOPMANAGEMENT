using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
  public  class UserBusiness:BLLBase
    {
      public List<tbl_User> GetTrainers()
      {
          try
          {
              UserDb UD = new UserDb();
              List<tbl_User> Ls = UD.GetTrainers();
              return Ls;
          }
          catch
          {
              throw;
          }
      }
      public bool CreateUserRequest(tbl_User U, int  WorkShopId)
      {

          UserDb UD = new UserDb();
          UD.CreateUserRequest(U,WorkShopId);
          return true;
      }

      public bool InsertProfile(tbl_User U)
      {
          //WorkShopDate should be greater than Current Date
          UserDb UD = new UserDb();
          UD.InsertProfile(U);
          return true;
      }

      //public List<tbl_User> GetStudents()
      //{
      //    UserDb UD = new UserDb();
      //    return UD.GetStudents();
         
      //}

      public bool DeleteProfileById(int UserId)
      {
          UserDb UD = new UserDb();
          UD.DeleteProfileById(UserId);
          return true;

      }

      public tbl_User GetProfileById(int UserId)
      {
          UserDb UD = new UserDb();
          tbl_User Wp = UD.GetProfileById(UserId);
          return Wp;
      }

      public tbl_User GetTrainerById(int UserId)
      {
          UserDb UD = new UserDb();
          tbl_User Wp = UD.GetTrainerById(UserId);
          return Wp;
      }

      public bool UpdateProfileById(tbl_User U, int UserId)
      {
               UserDb UD = new UserDb();
               UD.UpdateProfileById(U, UserId);
                return true;
          
      }


      public bool UpdateTrainerById(tbl_User U, int UserId)
      {
          UserDb UD = new UserDb();
          UD.UpdateTrainerById(U, UserId);
          return true;

      }
      public List<tbl_User> GetStudentsList()
      {
          UserDb UD = new UserDb();
          return UD.GetStudentsList();
      }

      public bool CreateUserRequestCurrentUser(tbl_User U, int WorkShopId)
      {

          UserDb UD = new UserDb();
          UD.CreateUserRequestCurrentUser(U, WorkShopId);
          return true;
      }

      public bool ValidateUser(tbl_User U)
      {
          UserDb UD = new UserDb();
          return UD.ValidateUser(U);
      }

      public bool CreateTrainer(tbl_User U)
      {
          UserDb UD = new UserDb();
          return UD.CreateTrainer(U);
      }

      public List<tbl_User> GetStudents()
      {
          try
          {
              UserDb UD = new UserDb();
              List<tbl_User> Ls = UD.GetStudents();
              return Ls;
          }
          catch
          {
              throw;
          }
      }
    }
}

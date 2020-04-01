using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
  public  class WorkShopBusiness:BLLBase
    {
      WorkShopDb WD;
      public WorkShopBusiness()
      {
          WD = new WorkShopDb();
      }
      public bool InsertWorkShop(tbl_WorkShop Wp,List<int> Ls)
      { 
      //WorkShopDate should be greater than Current Date
          if (Wp.WorkShopDate > DateTime.Now)
          {
            
              WD.InsertWorkShop(Wp, Ls);
              return true;
          }
          else
          {

              return false;
          }
      }

      public List<tbl_WorkShop> GetWorkShops()
      {
         
          return WD.GetWorkShops();
      }

      public List<tbl_WorkShop> GetWorkShopsForStudent()
      {

          return WD.GetWorkShopsForStudent();
      }


      public tbl_WorkShop GetWorkShopById(int WorkShopId)
      {
         
          tbl_WorkShop Wp = WD.GetWorkShopById(WorkShopId);
          return Wp;
      }

      public bool UpdateWorkShopById(tbl_WorkShop Wp, int WorkShopId)
      {
        
          //if (Wp.WorkShopDate > DateTime.Now)
          //{
              WD.UpdateWorkShopById(Wp, WorkShopId);
              return true;
          //}
          //else
          //{
          //    return false;
          //}
      }

      public bool DeleteWorkShopById(int WorkShopId)
      {
          
          WD.DeleteWorkShopById(WorkShopId);
          return true;
      
      }

      public bool AssignTrainersToWorkShop(List<tbl_Trainer_WorkShop_Mapping> Ls)
      {
         
          WD.AssignTrainersToWorkShop(Ls);
          return true;
      }

      public List<WorkShopRequest> GetWorkShopRequest()
      {
          return WD.GetWorkShopRequest();
      }
      public List<WorkShopRequest> GetWorkShopRequestForStudent()
      {
          return WD.GetWorkShopRequestForStudent();
      }

      public bool AppOrRejectWorkShopRequest(tbl_Student_WorkShop_Mapping swp)
      {
          return WD.AppOrRejectWorkShopRequest(swp);
      }

      public List<tbl_WorkShop> SearchWorkShop(string Title, DateTime? Date, string Duration)
      {
          var Ls = WD.GetWorkShops();
          //if (Title == null && Date == null && Duration == null)
          //{
          //    return Ls;
          //}
          //else if (Title != null && Date == null && Duration == null)
          //{
          //    return Ls.Where(x => x.WorkShopTitle.Contains(Title)).ToList();
          //}
          //else if (Title == null && Date != null && Duration == null)
          //{
          //    return Ls.Where(x => x.WorkShopDate==Date).ToList();
          //}
          //else if (Title == null && Date == null && Duration != null)
          //{
          //    return Ls.Where(x => x.WorkShopDuration.Contains(Duration)).ToList();
          //}
          //else if (Title != null && Date != null && Duration == null)
          //{
          //    return Ls.Where(x => x.WorkShopTitle.Contains(Title) && x.WorkShopDate == Date).ToList();
          //}
          //else if (Title == null && Date != null && Duration != null)
          //{
          //    return Ls.Where(x => x.WorkShopTitle.Contains(Title) && x.WorkShopDuration.Contains(Duration)).ToList();
          //}
          //else
          //{
          //    return Ls;
          //}
          return Ls.Where(z => (string.IsNullOrEmpty(Title) ? true : z.WorkShopTitle.Contains(Title)) &&
                             (Date == null ? true : z.WorkShopDate == Date) &&
                             (string.IsNullOrEmpty(Duration) ? true : z.WorkShopDuration.Contains(Duration))).ToList();

      }
    }
}

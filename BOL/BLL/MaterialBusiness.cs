using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class MaterialBusiness : BLLBase
    {
        public void CreateMaterial(tbl_Material M)
        {
            MaterialDb MD = new MaterialDb();
            MD.CreateMaterial(M);
        }
        public List<WorkShopMaterial> GetMaterials()
        {
            MaterialDb MD = new MaterialDb();
            return MD.GetMaterials(); 
        }
    }
}

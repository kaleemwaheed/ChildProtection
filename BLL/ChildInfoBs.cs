using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class ChildInfoBs
    {
        private ChildInfoDB objDb;

        public ChildInfoBs()
        {
            objDb = new ChildInfoDB();
        }

        public IEnumerable<tbl_ChildInfo> GetALL()
        {
            return objDb.GetALL();
        }

        public tbl_ChildInfo GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_ChildInfo url)
        {
            objDb.Insert(url);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_ChildInfo url)
        {
            objDb.Update(url);
        }
    }
}

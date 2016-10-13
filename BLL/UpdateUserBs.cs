using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;

namespace BLL
{
   public  class UpdateUserBs
    {
        private UpdateUserDAL objDb;

        public UpdateUserBs()
        {
            objDb = new UpdateUserDAL();
        }

        public IEnumerable<tbl_User> GetALL()
        {
            return objDb.GetALL();
        }

        public tbl_User GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_User url)
        {
            objDb.Insert(url);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_User url)
        {
            objDb.Update(url);
        }
    }
}
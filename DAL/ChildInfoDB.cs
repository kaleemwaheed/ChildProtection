using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ChildInfoDB
    {
        private ChildProtectionDbEntities db;

        public ChildInfoDB()
        {
            db = new ChildProtectionDbEntities();
        }

        public IEnumerable<tbl_ChildInfo> GetALL()
        {
            return db.tbl_ChildInfo.ToList();
        }
       
        public tbl_ChildInfo GetByID(int Id)
        {
            return db.tbl_ChildInfo.Find(Id);
        }
        public void Insert(tbl_ChildInfo url)
        {
            db.tbl_ChildInfo.Add(url);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_ChildInfo url = db.tbl_ChildInfo.Find(Id);
            db.tbl_ChildInfo.Remove(url);
            Save();
        }
        public void Update(tbl_ChildInfo url)
        {
            db.Entry(url).State = EntityState.Modified;
            db.Configuration.ValidateOnSaveEnabled = false;
            Save();
            db.Configuration.ValidateOnSaveEnabled = true;
        }
        public void Save()
        {

            db.SaveChanges();
        }
    }
}

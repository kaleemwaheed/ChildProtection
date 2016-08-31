using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDB
    {
        private ChildProtectionDbEntities db;

        public UserDB()
        {
            db = new ChildProtectionDbEntities();
        }

        public IEnumerable<tbl_User> GetALL()
        {
            return db.tbl_User.ToList();
        }

        public tbl_User GetByID(int Id)
        {
            return db.tbl_User.Find(Id);
        }
        public void Insert(tbl_User url)
        {
            db.tbl_User.Add(url);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_User url = db.tbl_User.Find(Id);
            db.tbl_User.Remove(url);
            Save();
        }
        public void Update(tbl_User url)
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

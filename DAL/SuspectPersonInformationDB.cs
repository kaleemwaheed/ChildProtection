using BOL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class SuspectPersonInformationDB
    {
        private ChildProtectionDbEntities db;

        public SuspectPersonInformationDB()
        {
            db = new ChildProtectionDbEntities();
        }

        public IEnumerable<tbl_SuspectPersonInformation> GetALL()
        {
            return db.tbl_SuspectPersonInformation.ToList();
        }

        public tbl_SuspectPersonInformation GetByID(int Id)
        {
            return db.tbl_SuspectPersonInformation.Find(Id);
        }
        public void Insert(tbl_SuspectPersonInformation url)
        {
            db.tbl_SuspectPersonInformation.Add(url);
            Save();
        }
        public void Delete(int Id)
        {
            tbl_SuspectPersonInformation url = db.tbl_SuspectPersonInformation.Find(Id);
            db.tbl_SuspectPersonInformation.Remove(url);
            Save();
        }
        public void Update(tbl_SuspectPersonInformation url)
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


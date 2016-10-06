using BOL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SuspectPersonInformationBs
    {
        private SuspectPersonInformationDB objDb;

        public SuspectPersonInformationBs()
        {
            objDb = new SuspectPersonInformationDB();
        }

        public IEnumerable<tbl_SuspectPersonInformation> GetALL()
        {
            return objDb.GetALL();
        }

        public tbl_SuspectPersonInformation GetByID(int Id)
        {
            return objDb.GetByID(Id);
        }
        public void Insert(tbl_SuspectPersonInformation url)
        {
            objDb.Insert(url);
        }
        public void Delete(int Id)
        {
            objDb.Delete(Id);
        }
        public void Update(tbl_SuspectPersonInformation url)
        {
            objDb.Update(url);
        }
    }
}


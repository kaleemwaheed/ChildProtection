using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BaseBs
    {
        public ChildInfoBs childInfoBs { get; set; }
        public UserBs userBs { get; set; }
        
        public BaseBs()
        {
            childInfoBs = new ChildInfoBs();
            userBs = new UserBs();        }
    }
}

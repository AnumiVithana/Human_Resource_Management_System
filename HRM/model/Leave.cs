using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model
{
    public class Leave
    {
        public int id;
        public int employee_id;
        public string leave_type = "";
        public string reason = "";
        public Byte status;
        public string dateRequested = "";
        
     
    }
}

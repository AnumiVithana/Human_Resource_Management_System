using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Model
{
    public class Attendance
    {
        public int id;
        public string date = "";
        public int employeeId;
        public string checkInTime = "";
        public string checkOutTime = "";
        public int workedHovers;
        public string description = "";


    }
}

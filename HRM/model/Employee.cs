using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.models
{
    //this class will be use to store the clients data
    public class Employee
    {
        public int id;
        public string first_name = "";
        public string last_name = "";
        public string pw_hash = "";
        public string department = "";
        public string position = "";
        public string contact_no = "";
        public string email = "";
        public string dob = "";
        public string gender = "";
    }
}

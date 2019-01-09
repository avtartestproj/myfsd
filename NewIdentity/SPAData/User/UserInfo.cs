using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class UserInfo
    {

        public int User_ID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Employee_ID { get; set; }
        public int Project_ID { get; set; }

        public int Task_ID { get; set; }

        public List<UserInfo> Users { get; set; }

    }

}

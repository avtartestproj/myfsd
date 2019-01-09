using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class ProjectInfo
    {

        public int Project_ID { get; set; }

        public string Project { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public int Priority { get; set; }

        public List<UserInfo> Users { get; set; }
        public List<ProjectInfo> Projects { get; set; }

        public int Manager_ID { get; set; }

       public int TotalNoOfTasks { get; set; }

       public int CompletedNoOfTasks { get; set; }


    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class TaskInfo
    {

        public int Project_ID { get; set; }

        public int Parent_ID { get; set; }
        public string Task { get; set; }
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public int Task_Id { get; set; }
        public List<UserInfo> Users { get; set; }
        public List<ProjectInfo> Projects { get; set; }

        public List<TaskInfo> Tasks { get; set; }
        public bool Status { get; set; }
        public string ProjectName{ get; set; }

        public string ParentTaskName { get; set; }

    }

    public class ParentTaskInfo
    {

        public int ParentTask_ID { get; set; }

        public string Parent_Task { get; set; }
        
    }
}

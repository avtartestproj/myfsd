using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class TaskInfoManager
    {
        public List<TaskInfo> GetAllProjects()
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();

            List<TaskInfo> ret = new List<TaskInfo>();

            //TODO - Add Empower Data Fetch Call method here


            //MyServiceReference.UserProfile[] UserPro = serviceClient.GetAllUsers();
            MyServiceReference.ProjectTaskInfo[] projTasks = serviceClient.GetAllTasks();

            foreach (MyServiceReference.ProjectTaskInfo task in projTasks)
            {
                ret.Add(new TaskInfo()
                {
                    Task  = task.Task,
                    StartDate = task.StartDate,
                    EndDate = task.EndDate,
                    Priority = task.Priority

                });
            }

            // ret = prd.Count >= 5 ? prd : CreateMockData();

            //if (!string.IsNullOrEmpty())
            //{
            //    ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName.ToLower()));
            //}
            return ret;
        }

        public TaskInfoManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool validate(TaskInfo entity, string mode)
        {
            bool isvalid = true;

            return isvalid;
        }



        public TaskInfo GetTaskByID(int TaskId)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            TaskInfo lstTask = new TaskInfo();
            SPAData.MyServiceReference.ProjectTaskInfo _ret = serviceClient.GetTaskById(TaskId);
            lstTask.Project_ID = _ret.Project_ID;
            lstTask.Task_Id  = TaskId;
            lstTask.StartDate = _ret.StartDate;
            lstTask.EndDate = _ret.EndDate;
            lstTask.Priority = _ret.Priority;
            lstTask.Status = _ret.Status;
            lstTask.Parent_ID = _ret.Parent_ID;
            lstTask.Task = _ret.Task;


            return lstTask;
        }

        public TaskInfo GetTaskInfo(int projectID)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            TaskInfo lst = new TaskInfo();
            //db call get data
            //lst = CreateMockData();
            //lst = (TrainingProduct)serviceClient.GetAllProductsById(ProductID);
            //ret = lstp => p.ProductID == ProductID);

           ///* SPAData.*/MyServiceReference.ProjectTaskInfo _ret = serviceClient.TaskById(projectID);
            //lst.UserId = _ret.UserId;
            //lst.UserName = _ret.UserName;
            //lst.Password = _ret.Password;
            //lst.IsActive = (bool)_ret.IsActive;

            return lst;

        }
        public bool Update(TaskInfo entity,string specialMode)//, out List<TrainingProduct> lstupdated)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            bool ret = false;
            List<TaskInfo> lst = new List<TaskInfo>();
            TaskInfo tempProd = new TaskInfo();
            
            ret = validate(entity, "Update");
            if (ret)
            {
                if (specialMode == "suspend")
                {
                    entity.Status = true;
                    serviceClient.UpdateTask(entity.Task_Id, entity.Status);
                }
                else
                {
                    serviceClient.UpdateTaskDetails(entity.Task_Id,entity.Parent_ID,entity.Project_ID,entity.Task,entity.StartDate,entity.EndDate,entity.Priority,entity.Status);
                }

            }

            lst.Add(tempProd);
            // lstupdated = lst;
            return ret;
        }



        public bool Insert(TaskInfo entity,bool isParentTask, int TaskUser_Id)//, out List<TrainingProduct> lst)
        {

            List<TaskInfo> lstProdAdd = new List<TaskInfo>();
            //lstProdAdd = new List<TrainingProduct>();
            
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();


            bool ret = false;
            ret = true;// validate(entity, "add");
            if (ret)
            {
                if (isParentTask)
                {
                    serviceClient.AddParentTask(entity.Task);
                }
                else
                {
                    serviceClient.AddTask(entity.Parent_ID, entity.Project_ID, entity.Task, entity.StartDate, entity.EndDate,entity.Priority, entity.Status, TaskUser_Id);
                }

         


            }

            return ret;
        }
        public bool Delete(TaskInfo entity, out List<TaskInfo> lstupdated)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            bool ret = false;
            List<TaskInfo> lst = new List<TaskInfo>();
            TaskInfo tempProd = new TaskInfo();
            ret = validate(entity, "delete");
            if (ret)
            {

                serviceClient.DeleteUserById(entity.Project_ID);

            }
            lstupdated = lst;
            return ret;
        }
        public List<TaskInfo> Get(TaskInfo entity, List<TaskInfo> prd, string mode = "")
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();

            List<TaskInfo> ret = new List<TaskInfo>();


            ProjectInfoManager pinfoManager = new SPAData.ProjectInfoManager();
           List<ProjectInfo> _projectInfo = pinfoManager.GetAllProjects();
            TaskInfoManager mgrTaskinfoManager = new SPAData.TaskInfoManager();
            List<ParentTaskInfo> _parentTaskInfo = mgrTaskinfoManager.GetAllParentTask();
            MyServiceReference.ProjectTaskInfo[] TaskInfo = serviceClient.GetAllTasks();

            foreach (MyServiceReference.ProjectTaskInfo _task in TaskInfo)
            {
                ret.Add(new TaskInfo()
                {
                    Task = _task.Task,
                    Parent_ID = _task.Parent_ID,
                    Priority = _task.Priority,
                    StartDate = _task.StartDate,
                    EndDate = _task.EndDate,
                    Task_Id = _task.Task_Id,
                    Project_ID = _task.Project_ID,
                    Status = _task.Status,

                });
            }
            ProjectInfo result;
            ParentTaskInfo _result = new ParentTaskInfo();
            foreach (TaskInfo _Task in ret)
            {
                result = _projectInfo.First(item => item.Project_ID == _Task.Project_ID);
                _Task.ProjectName = result.Project;
                
            }
            foreach (TaskInfo _Task in ret)
            {
                if(_Task.Parent_ID >0)
                _result = _parentTaskInfo.First(item => item.ParentTask_ID == _Task.Parent_ID);
                _Task.ParentTaskName = _result.Parent_Task;

            }
            if (!string.IsNullOrEmpty(entity.ProjectName))
            {
                ret = ret.FindAll(p => p.ProjectName.ToLower().StartsWith(entity.ProjectName.ToLower()));
            }
            return ret;
        }
        public List<ParentTaskInfo> GetAllParentTask()
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();

            List<ParentTaskInfo> ret = new List<ParentTaskInfo>();

            //TODO - Add Empower Data Fetch Call method here


            //MyServiceReference.UserProfile[] UserPro = serviceClient.GetAllUsers();
            MyServiceReference.ParentTaskInfo[] parentTaskInfo = serviceClient.GetAllParentTasks();

            foreach (MyServiceReference.ParentTaskInfo _task in parentTaskInfo)
            {
                ret.Add(new ParentTaskInfo()
                {
                    ParentTask_ID = _task.ParentTask_Id,
                    Parent_Task = _task.ParentTaskName
                });
            }

            // ret = prd.Count >= 5 ? prd : CreateMockData();

            //if (!string.IsNullOrEmpty())
            //{
            //    ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName.ToLower()));
            //}
            return ret;
        }
        public List<UserInfo> Get(UserInfo entity, List<UserInfo> prd, string mode = "")
        {

            List<UserInfo> ret = new List<UserInfo>();

            //TODO - Add Empower Data Fetch Call method here
            UserInfoManager urMGr = new UserInfoManager();
            List<UserInfo> usrInfo = urMGr.Get(entity, prd, mode);
            return usrInfo;

        }
        public List<UserInfo> GetAllUsers()
        {


            //TODO - Add Empower Data Fetch Call method here
            UserInfoManager urMGr = new UserInfoManager();
            List<UserInfo> usrInfo = urMGr.GetAllUsers();
            return usrInfo;
        }

        public List<UserInfo> GetProjectManager(int projectId)
        {


            //TODO - Add Empower Data Fetch Call method here
            UserInfoManager urMGr = new UserInfoManager();
            List<UserInfo> usrInfo = urMGr.GetAllUsers();
            return usrInfo.Where(a => a.Project_ID == projectId).ToList();

        }
    }
}

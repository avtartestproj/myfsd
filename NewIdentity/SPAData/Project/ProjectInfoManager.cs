using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class ProjectInfoManager
    {
        public List<ProjectInfo> GetAllProjects()
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();

            List<ProjectInfo> ret = new List<ProjectInfo>();
         
            //TODO - Add Empower Data Fetch Call method here


            //MyServiceReference.UserProfile[] UserPro = serviceClient.GetAllUsers();
            MyServiceReference.ProjectInfo[] ProjInfo = serviceClient.GetAllProjects();

            foreach (MyServiceReference.ProjectInfo _User in ProjInfo)
            {
                ret.Add(new ProjectInfo()
                {
                    Project = _User.Project,
                    StartDate = _User.StartDate,
                    EndDate = _User.EndDate,
                    Priority = _User.Priority,
                    Project_ID = _User.Project_ID
                     
                });
            }

            // ret = prd.Count >= 5 ? prd : CreateMockData();

            //if (!string.IsNullOrEmpty())
            //{
            //    ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName.ToLower()));
            //}
            return ret;
        }

        public ProjectInfoManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool validate(ProjectInfo entity, string mode)
        {
            bool isvalid = false;
            ValidationErrors.Clear();
//            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            if (mode.ToLower() == "delete")
            {

                ProjectInfo lst = new ProjectInfo();
                int ucount = GetTotalNoTask(entity.Project_ID);
                if (ucount > 0)
                {
                   ValidationErrors.Add(new KeyValuePair<string, string>(ucount + "TaskDependencyError", "Project has " + ucount + " tasks hence cannot be deleted "));
                }

                if (ValidationErrors.Count <= 0)
                {
                    isvalid = true;
                }
              
            }
            else if (mode.ToLower() == "add")
            {
                List<ProjectInfo> checklst = GetAllProjects();
                {
                    foreach (ProjectInfo usr in checklst)
                    {
                        if (usr.Project == entity.Project)
                        {
                            isvalid = false;
                        }
                        else { isvalid = true; }
                    }
                }

            }
            else { isvalid = true; }

            return isvalid; //(ValidationErrors.Count == 0);
        }


        public ProjectInfo Get(int ProjectID)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            ProjectInfo lst = new ProjectInfo();
            SPAData.MyServiceReference.ProjectInfo _ret = serviceClient.GetProjectById(ProjectID);
            lst.Project_ID = _ret.Project_ID;
            lst.Project = _ret.Project;

            lst.StartDate = _ret.StartDate;
            lst.EndDate = _ret.EndDate;
            lst.Priority = _ret.Priority;
            return lst;

            

        }
        public ProjectInfo GetProjectInfo(int projectID)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            ProjectInfo lst = new ProjectInfo();
            //db call get data
            //lst = CreateMockData();
            //lst = (TrainingProduct)serviceClient.GetAllProductsById(ProductID);
            //ret = lstp => p.ProductID == ProductID);

            SPAData.MyServiceReference.ProjectInfo _ret = serviceClient.GetProjectById(projectID);
            //lst.UserId = _ret.UserId;
            //lst.UserName = _ret.UserName;
            //lst.Password = _ret.Password;
            //lst.IsActive = (bool)_ret.IsActive;

            return lst;

        }
        public bool Update(ProjectInfo entity)//, out List<TrainingProduct> lstupdated)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            bool ret = false;
            List<ProjectInfo> lst = new List<ProjectInfo>();
            ProjectInfo tempProd = new ProjectInfo();
            ret = validate(entity, "Update");
            if (ret)
            {
                // lst = CreateMockData();
                tempProd = lst.Find(p => p.Project_ID == entity.Project_ID);
                lst.Remove(tempProd);
                tempProd = new ProjectInfo();
                tempProd.Project_ID = entity.Project_ID;
                tempProd.Project = entity.Project;
                tempProd.StartDate = entity.StartDate;
                tempProd.EndDate = entity.EndDate;
                tempProd.Priority = entity.Priority;
                
                //update in DB
                serviceClient.UpdateProjectUserInfo(entity.Project_ID, entity.Project,entity.StartDate,entity.EndDate,entity.Priority, entity.Manager_ID);

            }

            lst.Add(tempProd);
            // lstupdated = lst;
            return ret;
        }



        public bool Insert(ProjectInfo entity)//, out List<TrainingProduct> lst)
        {

            List<ProjectInfo> lstProdAdd = new List<ProjectInfo>();
            //lstProdAdd = new List<TrainingProduct>();
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();


            bool ret = false;
            ret = validate(entity, "add");
            if (ret)
            {
                serviceClient.AddProjectInfo(entity.Project, entity.StartDate, entity.EndDate, entity.Priority, entity.Manager_ID);


            }

            return ret;
        }
        public bool Delete(ProjectInfo entity, out List<ProjectInfo> lstupdated)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            bool ret = false;
            List<ProjectInfo> lst = new List<ProjectInfo>();
            ProjectInfo tempProd = new ProjectInfo();
            ret = validate(entity, "delete");
            if (ret)
            {

                serviceClient.DeleteProjectById(entity.Project_ID);

            }
            lstupdated = lst;
            return ret;
        }
        public List<ProjectInfo> Get(ProjectInfo entity, List<ProjectInfo> prd, string mode = "")
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            //if (mode.ToLower() == "delete")
            //{
            //    return prd;
            //}
            List<ProjectInfo> ret = new List<ProjectInfo>();

            //TODO - Add Empower Data Fetch Call method here
            UserInfoManager urMGr = new UserInfoManager();
            List<UserInfo> usrInfo = urMGr.GetAllUsers();

            MyServiceReference.ProjectInfo[] Projects = serviceClient.GetAllProjects();

            foreach (var _Project in Projects)
            {
                ret.Add(new ProjectInfo()
                {

                    Project_ID = _Project.Project_ID,
                    EndDate = _Project.EndDate,
                    StartDate = _Project.StartDate,
                    Priority = _Project.Priority,
                    Project = _Project.Project,
                     Users = usrInfo,
                    TotalNoOfTasks  = GetTotalNoTask(_Project.Project_ID),
                    CompletedNoOfTasks = GetTotalNoTaskCompleted(_Project.Project_ID)
                    
                });
            }

           
        
            // ret = prd.Count >= 5 ? prd : CreateMockData();

            if (!string.IsNullOrEmpty(entity.Project))
            {
                ret = ret.FindAll(p => p.Project.ToLower().StartsWith(entity.Project.ToLower()));
            }
            MyServiceReference.UserInfo[] Users = serviceClient.GetAllUsers();
       
            return ret;
        }
        private int GetTotalNoTask(int ProjectID)
        {

            TaskInfoManager mgr = new TaskInfoManager();
            TaskInfo tsearchentity = new TaskInfo();
            List<TaskInfo> result = new List<TaskInfo>();
            List<TaskInfo> resulttask;
            resulttask = mgr.Get(tsearchentity, result);
            //             = parentTaskInfo.First(item => item.ParentTask_ID == ParentTaskId);
            int taskcount = resulttask.Where(s => s != null && s.Project_ID == ProjectID).Count();
            return taskcount;
        }

        private int GetTotalNoTaskCompleted(int ProjectID)
        {
            TaskInfoManager mgr = new TaskInfoManager();
            TaskInfo tsearchentity = new TaskInfo();
            List<TaskInfo> result = new List<TaskInfo>();
            List<TaskInfo> resulttask;
            resulttask = mgr.Get(tsearchentity, result);
            //             = parentTaskInfo.First(item => item.ParentTask_ID == ParentTaskId);
            int taskcount = resulttask.Where(s => s != null && s.Status == true && s.Project_ID == ProjectID).Count();
            return taskcount;
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

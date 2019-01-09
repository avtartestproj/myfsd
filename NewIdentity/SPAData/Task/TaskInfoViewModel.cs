using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class TaskInfoViewModel
    {


        //public List<TaskInfo> Users { get; set; }

        public List<UserInfo> Users { get; set; }
        public bool IsViewTask { get; set; }
        public TaskInfoViewModel()
        {
            try
            {
                initialize();
                TasksInfo = new List<TaskInfo>();
                
                SearchEntity = new TaskInfo();
                Entity = new TaskInfo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // EventCommand = "List";
            //try
            //{
            //    Users = new List<UserProfile>();
            //    Users.Add(new UserProfile { UserId = 1, IsActive = true, Password = "abc", UserName = "test" });
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            // EventCommand = "List";
        }
        public List<TaskInfo> TasksInfo { get; set; }
        public List<ProjectInfo> ProjectsInfo { get; set; }

        public List<ParentTaskInfo> parentTaskInfo { get; set; }
        private void initialize()
        {
            try
            {
                EventCommand = "list";
                EventArgument = string.Empty;
                ValidationErrors = new List<KeyValuePair<string, string>>();
                ListMode();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Manager_Name { get; set; }
        public int TaskUser_Id { get; set; }

        public bool IsParentTask { get; set; }
        public string Parent_Task { get; set; }

        public int Parent_TaskID { get; set; }
        public string Project_Name { get; set; }
        public TaskInfo Entity { get; set; }
        public bool IsValid { get; set; }
        public string SortBy { get; set; }
        public string Mode { get; set; }
        public bool IsDetailAreaVisibie { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool isSearchAreaVisible { get; set; }
        public TaskInfo SearchEntity { get; set; }


        public UserInfo SearchUserEntity { get; set; }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public string EventArgument { get; set; }
        public void HandleRequest()
        {
            DBLogErrorInfo.LogErrorInfo_in_DB("Inside View Model - HandleRequest Initiated", "Info");
            try
            {
                if (string.IsNullOrEmpty(EventCommand))
                {
                    EventCommand = "list";
                }
                DBLogErrorInfo.LogErrorInfo_in_DB("Inside View Model - Eventcommand " + Convert.ToString(EventCommand).ToUpper() + " Execution Start", "Info");
                switch (Convert.ToString(EventCommand).ToLower())
                {
                    case "list":
                    case "search":
                        Get();
                      
                        Get(ProjectsInfo);
                        GetAllParentTasks();
                        GetUser();
                        break;
                    case "searchuser":
                        GetUser();
                        break;

                    case "resetsearch":
                        ResetSearch();
                        Get(sortby: SortBy);
                        break;
                    case "sort":
                        //ResetSearch();
                        Get(sortby: SortBy);
                        break;
                    case "add":
                        Add();
                        Get(ProjectsInfo);
                        GetAllParentTasks();
                        GetUser();
                        break;


                    case "save":
                        Save(EventArgument);
                        if (IsValid)
                        {
                            Get();
                        }
                        ListMode();
                        break;

                    case "edit":
                        IsValid = true;
                        Edit();
                        break;

                    case "cancel":
                        ListMode();
                        Get();
                        Get(ProjectsInfo);
                        GetAllParentTasks();
                        GetUser();
                        break;

                    case "delete":
                        ResetSearch();
                        Delete();
                        break;
                    case "suspend":
                        ResetSearch();
                        suspend();
                        break;
                    default:
                        break;
                }
                DBLogErrorInfo.LogErrorInfo_in_DB("Inside View Model - Eventcommand " + Convert.ToString(EventCommand).ToUpper() + " Execution End", "Info");
                DBLogErrorInfo.LogErrorInfo_in_DB("Inside View Model - HandleRequest Completed", "Info");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ListMode()
        {
            try
            {
                if (ValidationErrors.Count > 0)
                {
                    IsValid = false;
                }
                else
                {
                    IsValid = true;
                }
                IsListAreaVisible = true;
                isSearchAreaVisible = true;
                IsDetailAreaVisibie = false;

                Entity = new TaskInfo();
                //Entity.User_ID;
                // Entity.Project_ID = "";
                // Entity.StartDate= "";
                //Entity.EndDate = null;
                //Entity.Task_ID;
                //Entity.Project_ID
                //Entity.IsActive = true;
                Mode = "List";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Save(string evntArgument)
        {
            try
            {
                //List<TrainingProduct> lstproduct = new List<TrainingProduct>();
                TaskInfoManager mgr = new TaskInfoManager();
                if (string.IsNullOrEmpty(EventCommand))
                {
                    EventCommand = "list";
                }
                if(Convert.ToString(EventCommand).ToLower() =="save" && evntArgument.ToLower() != "edit")
                //if (Mode == "Add")
                {
                    Entity.Parent_ID = Parent_TaskID;
                    mgr.Insert(Entity, IsParentTask, TaskUser_Id);
                    //mgr.Insert(Entity, out lstproduct);
                    //Products = lstproduct;

                }
                else
                {
                    //mgr.Update(Entity, out lstproduct);
                    mgr.Update(Entity,"");
                    //Products = lstproduct;
                }
                ValidationErrors = mgr.ValidationErrors;
                if (ValidationErrors.Count > 0)
                {
                    IsValid = false;
                }

                if (!IsValid)
                {
                    if (Mode == "Add")
                    {
                        AddMode();
                    }
                    else
                    {
                        EditMode();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void Add()
        {
            IsValid = true;
            Entity = new TaskInfo();
            //Entity.User_ID;
            Entity.Project_ID = 0;
            Entity.Task = "";
            Entity.Priority = 0;
            Entity.StartDate = DateTime.Now;
            Entity.EndDate = DateTime.Now;
            //Entity.Task_ID;
            //Entity.Project_ID
            //Entity.IsActive = true;
            AddMode();
        }

        private void Edit()
        {
            TaskInfoManager mgr = new TaskInfoManager();
            //Entity = mgr.Get(Convert.ToInt32(EventArgument));
            Entity = mgr.GetTaskByID(Convert.ToInt32(EventArgument));
            Project_Name = Entity.ProjectName;
            Project_Name = GetProjectNamebyID(Entity.Project_ID);
            Manager_Name = GetUserNamebyProjectandTaskID(Entity.Project_ID, Entity.Task_Id);
            if (Entity.Parent_ID > 0) {
                Parent_Task = GetParentTasksbyID(Entity.Parent_ID);
                Parent_TaskID = Entity.Parent_ID;
                IsParentTask = true;
            
            }
            {
                IsParentTask = false;
            }
            List<UserInfo> pminfo = mgr.GetProjectManager(Entity.Project_ID);

            IsViewTask = false;
            EditMode();
        }

        private void Delete()
        {
            TaskInfoManager mgr = new TaskInfoManager();

            List<TaskInfo> lstUsers = new List<TaskInfo>();
            Entity = new TaskInfo();
            Entity.Project_ID = Convert.ToInt32(EventArgument);
            if (mgr.validate(Entity, "delete"))
            {
                mgr.Delete(Entity, out lstUsers);
                TasksInfo = lstUsers;
                Get("Delete");
            }
            else
            {
                IsValid = false;
            }
            ValidationErrors = mgr.ValidationErrors;
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }
            ListMode();
        }
        private void suspend()
        {
            TaskInfoManager mgr = new TaskInfoManager();

            List<TaskInfo> lstUsers = new List<TaskInfo>();
            Entity = new TaskInfo();
            Entity.Task_Id = Convert.ToInt32(EventArgument);
            //if (mgr.validate(Entity, "delete"))
            {
                Entity= mgr.GetTaskByID(Entity.Task_Id);
                Entity.Status = true;
                mgr.Update(Entity,"suspend");
            }
            //else
           // {
           //     IsValid = false;
           // }
            ValidationErrors = mgr.ValidationErrors;
            if (ValidationErrors.Count > 0)
            {
                IsValid = false;
            }
            ListMode();
        }
        private void AddMode()
        {
            IsListAreaVisible = false;
            isSearchAreaVisible = false;
            IsDetailAreaVisibie = true;
            Mode = "Add";

        }

        private void EditMode()
        {
            IsListAreaVisible = false;
            isSearchAreaVisible = false;
            IsDetailAreaVisibie = true;
            Mode = "Edit";

        }
        private void ResetSearch()
        {
            SearchEntity = new TaskInfo();
        }
        public string EventCommand { get; set; }
        private void Get(string mode = "", string sortby = "")
        {

            TaskInfoManager mgr = new TaskInfoManager();
            List<TaskInfo> SortedProjectList;
            TasksInfo = mgr.Get(SearchEntity, TasksInfo, mode);
            string sortbycommand = string.IsNullOrEmpty(sortby) ? "" : Convert.ToString(sortby).ToLower();

            switch (sortbycommand)

            {
                case "startdate":
                    SortedProjectList = TasksInfo.OrderBy(o => o.StartDate).ToList();
                    TasksInfo = SortedProjectList;
                    break;
                case "enddate":
                    SortedProjectList = TasksInfo.OrderBy(o => o.EndDate).ToList();
                    TasksInfo = SortedProjectList;
                    break;
                case "priority":
                    SortedProjectList = TasksInfo.OrderBy(o => o.Priority).ToList();
                    TasksInfo = SortedProjectList;
                    break;
                default:
                    break;


            }
            //projectsInfo = students.OrderByDescending(s => s.LastName);
        }
        private void Get(List<ProjectInfo> projinfo)
        {

            ProjectInfoManager mgr = new ProjectInfoManager();
            ProjectInfo prsearchEntity = new ProjectInfo();
            projinfo = mgr.Get(prsearchEntity, projinfo, "");
            ProjectsInfo = projinfo;

            //projectsInfo = students.OrderByDescending(s => s.LastName);
        }
        private void GetUser(string mode = "")
        {

            TaskInfoManager mgr = new TaskInfoManager();
            SearchUserEntity = new UserInfo();
            Users = mgr.Get(SearchUserEntity, Users, mode);

        }

        private void GetAllParentTasks(string mode = "")
        {

            TaskInfoManager mgr = new TaskInfoManager();
            parentTaskInfo = mgr.GetAllParentTask();
        }

        private string GetParentTasksbyID(int ParentTaskId)
        {

            TaskInfoManager mgr = new TaskInfoManager();
            parentTaskInfo = mgr.GetAllParentTask();
            ParentTaskInfo result;
            result = parentTaskInfo.First(item => item.ParentTask_ID == ParentTaskId);
            return result.Parent_Task;
        }

        private string GetProjectNamebyID(int ProjectId)
        {

            ProjectInfoManager mgr = new ProjectInfoManager();
            ProjectInfo prjinfo = mgr.Get(ProjectId);
            return prjinfo.Project;
        }
        private string GetUserNamebyProjectandTaskID(int ProjectId,int TaskId)
        {
            string rtnName = string.Empty;
            UserInfoManager mgr = new UserInfoManager();
            List<UserInfo> prjinfo = mgr.GetAllUsers();
            UserInfo result;
            result = prjinfo.FirstOrDefault(p => p.Project_ID == ProjectId && p.Task_ID == TaskId);
            if (result!=null)
            {
                rtnName = result.FirstName + " " + result.LastName;
            }
            return rtnName;
        }
    }
}

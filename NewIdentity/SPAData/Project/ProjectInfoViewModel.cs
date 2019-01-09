using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class ProjectInfoViewModel
    {


        //public List<ProjectInfo> Users { get; set; }

        public List<UserInfo> Users { get; set; }
        public ProjectInfoViewModel()
        {
            try
            {
                initialize();
                ProjectsInfo = new List<ProjectInfo>();
                SearchEntity = new ProjectInfo();
                Entity = new ProjectInfo();
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
        public List<ProjectInfo> ProjectsInfo { get; set; }

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
        public ProjectInfo Entity { get; set; }
        public bool IsValid { get; set; }
        public string SortBy { get; set; }
        public string Mode { get; set; }
        public bool IsDetailAreaVisibie { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool isSearchAreaVisible { get; set; }
        public ProjectInfo SearchEntity { get; set; }
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
                        GetUser();
                        break;
                    case "searchuser":
                        IsValid = true;
                        GetUser();
                        break;

                    case "resetsearch":
                       // IsValid = true;
                        ResetSearch();
                        Get(sortby:SortBy);
                        break;

                    case "add":
                        Add();
                        GetUser();
                        break;


                    case "save":
                        Save();
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
                        break;

                    case "delete":
                        ResetSearch();
                        Delete();
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

                Entity = new ProjectInfo();
                Manager_Name = "";
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
        private void Save()
        {
            try
            {
                //List<TrainingProduct> lstproduct = new List<TrainingProduct>();
                ProjectInfoManager mgr = new ProjectInfoManager();

                if (Mode == "Add")
                {
                    mgr.Insert(Entity);
                    //mgr.Insert(Entity, out lstproduct);
                    //Products = lstproduct;

                }
                else
                {
                    //mgr.Update(Entity, out lstproduct);
                    mgr.Update(Entity);
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
            Entity = new ProjectInfo();
            //Entity.User_ID;
            Entity.Project_ID = 0;
            Entity.Project= "";
            Entity.Priority= 0;
            Entity.StartDate = DateTime.Now;
            Entity.EndDate= DateTime.Now;
            Manager_Name = "";
            Entity.Manager_ID = 0;
            //Entity.Task_ID;
            //Entity.Project_ID
            //Entity.IsActive = true;
            AddMode();
        }

        private void Edit()
        {
            ProjectInfoManager mgr = new ProjectInfoManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            List<UserInfo> pminfo =   mgr.GetProjectManager(Entity.Project_ID);
            Entity.Manager_ID = pminfo[0].User_ID;
            Manager_Name = pminfo[0].FirstName + " " + pminfo[0].LastName;
            EditMode();
        }

        private void Delete()
        {
            ProjectInfoManager mgr = new ProjectInfoManager();

            List<ProjectInfo> lstUsers = new List<ProjectInfo>();
            Entity = new ProjectInfo();
            Entity.Project_ID = Convert.ToInt32(EventArgument);
            if (mgr.validate(Entity, "delete"))
            {
                mgr.Delete(Entity, out lstUsers);
                ProjectsInfo = lstUsers;
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
            SearchEntity = new ProjectInfo();
        }
        public string EventCommand { get; set; }
        private void Get(string mode = "", string sortby ="" )
        {

            ProjectInfoManager mgr = new ProjectInfoManager();
            List<ProjectInfo> SortedProjectList;
            ProjectsInfo = mgr.Get(SearchEntity, ProjectsInfo, mode);
           
            string sortbycommand = string.IsNullOrEmpty(sortby) ? "" : Convert.ToString(sortby).ToLower();

            switch (sortbycommand)
                
                {
                case "startdate":
                   SortedProjectList = ProjectsInfo.OrderBy(o => o.StartDate).ToList();
                    ProjectsInfo = SortedProjectList;
                    break;
                case "enddate":
                    SortedProjectList = ProjectsInfo.OrderBy(o => o.EndDate).ToList();
                    ProjectsInfo = SortedProjectList;
                    break;
                case "priority":
                    SortedProjectList = ProjectsInfo.OrderBy(o => o.Priority).ToList();
                    ProjectsInfo = SortedProjectList;
                    break;
           default:
                    break;
                   
                   
                }
            //projectsInfo = students.OrderByDescending(s => s.LastName);
        }

        
        private void GetUser(string mode = "")
        {

            ProjectInfoManager mgr = new ProjectInfoManager();
            if (SearchUserEntity == null)
            {
                SearchUserEntity = new UserInfo();
            }
           Users = mgr.Get(SearchUserEntity,Users, mode);
           
        }
    }
}

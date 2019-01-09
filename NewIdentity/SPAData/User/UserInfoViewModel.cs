using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class UserInfoViewModel
    {


        public List<UserInfo> Users { get; set; }
        public UserInfoViewModel()
        {
            try
            {
                initialize();
                UserProfiles = new List<UserInfo>();
                SearchEntity = new UserInfo();
                Entity = new UserInfo();
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
        public List<UserInfo> UserProfiles { get; set; }

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

        public UserInfo Entity { get; set; }
        public bool IsValid { get; set; }

        public string Mode { get; set; }
        public bool IsDetailAreaVisibie { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool isSearchAreaVisible { get; set; }
        public UserInfo SearchEntity { get; set; }

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
                        break;
                    case "resetsearch":
                        ResetSearch();
                        Get();
                        break;

                    case "add":
                        Add();
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
               
                Entity = new UserInfo();
                //Entity.User_ID;
                Entity.FirstName = "";
                Entity.LastName = "";
                Entity.Employee_ID = "";
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
                UserInfoManager mgr = new UserInfoManager();

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
            Entity = new UserInfo();
            //Entity.User_ID;
            Entity.FirstName = "";
            Entity.LastName = "";
            Entity.Employee_ID = "";
            //Entity.Task_ID;
            //Entity.Project_ID
            //Entity.IsActive = true;
            AddMode();
        }

        private void Edit()
        {
            UserInfoManager mgr = new UserInfoManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            EditMode();
        }

        private void Delete()
        {
            UserInfoManager mgr = new UserInfoManager();

            List<UserInfo> lstUsers = new List<UserInfo>();
            Entity = new UserInfo();
            Entity.User_ID = Convert.ToInt32(EventArgument);
            if (mgr.validate(Entity, "delete"))
            {
                mgr.Delete(Entity, out lstUsers);
                UserProfiles = lstUsers;
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
            SearchEntity = new UserInfo();
        }
        public string EventCommand { get; set; }
        private void Get(string mode = "")
        {

            UserInfoManager mgr = new UserInfoManager();
            UserProfiles = mgr.Get(SearchEntity, UserProfiles, mode);
        }
    }
}

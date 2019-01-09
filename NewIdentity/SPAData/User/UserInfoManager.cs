using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPAData
{
    public class UserInfoManager
    {
        public List<UserInfo> GetAllUsers()
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
        
            List<UserInfo> ret = new List<UserInfo>();

            //TODO - Add Empower Data Fetch Call method here


            //MyServiceReference.UserProfile[] UserPro = serviceClient.GetAllUsers();
            MyServiceReference.UserInfo[] UserPro = serviceClient.GetAllUsers();

            foreach (MyServiceReference.UserInfo _User in UserPro)
            {
                ret.Add(new UserInfo()
                {
                    User_ID = _User.User_ID,
                    FirstName = _User.FirstName,
                    LastName = _User.LastName,
                Project_ID = _User.Project_ID,
                 Employee_ID = _User.Employee_ID,
                  Task_ID = _User.Task_ID,
                   
                });
            }

            // ret = prd.Count >= 5 ? prd : CreateMockData();

            //if (!string.IsNullOrEmpty())
            //{
            //    ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName.ToLower()));
            //}
            return ret;
        }

        public UserInfoManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }
        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public bool validate(UserInfo entity, string mode)
        {
            bool isvalid = false;
            ValidationErrors.Clear();
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            if (mode.ToLower() == "delete")
            {

                UserInfo lst = new UserInfo();
                MyServiceReference.UserInfo usrinfo = serviceClient.GetAllUsersById(entity.User_ID);
                if(usrinfo.Project_ID != 0 && usrinfo.Task_ID != 0)
                //int ucount = serviceClient.CheckUserDependencyById(entity.User_ID);
     //           if (ucount > 0)
                {
                    //MyServiceReference.UserInfo usrinfo = serviceClient.GetAllUsersById(entity.User_ID);
                    ValidationErrors.Add(new KeyValuePair<string, string>(usrinfo.FirstName + "UserDepencyError","User has Project and Task Mapped hence User" + usrinfo.FirstName + " cannot be deleted"));
                }

                if (ValidationErrors.Count <= 0)
                {
                    isvalid = true;
                }
            }
            else if (mode.ToLower() == "add")
            {
                List<UserInfo> checklst = GetAllUsers();
                {
                    foreach (UserInfo usr in checklst)
                    {
                        if (usr.User_ID == entity.User_ID)
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


        public UserInfo Get(int userId)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            UserInfo lst = new UserInfo();
            //db call get data
            //lst = CreateMockData();
            //lst = (TrainingProduct)serviceClient.GetAllProductsById(ProductID);
            //ret = lstp => p.ProductID == ProductID);

            SPAData.MyServiceReference.UserInfo _ret = serviceClient.GetAllUsersById(userId);
            lst.User_ID = _ret.User_ID;
            lst.FirstName = _ret.FirstName;

            lst.LastName = _ret.LastName;
            lst.Project_ID = _ret.Project_ID;
            lst.Employee_ID = _ret.Employee_ID;
            lst.Task_ID = _ret.Task_ID;
            return lst;

        }
        public UserInfo GetUserInfo(int userId)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            UserInfo lst = new UserInfo();
            //db call get data
            //lst = CreateMockData();
            //lst = (TrainingProduct)serviceClient.GetAllProductsById(ProductID);
            //ret = lstp => p.ProductID == ProductID);

            SPAData.MyServiceReference.UserInfo _ret = serviceClient.GetAllUsersById(userId);
            //lst.UserId = _ret.UserId;
            //lst.UserName = _ret.UserName;
            //lst.Password = _ret.Password;
            //lst.IsActive = (bool)_ret.IsActive;

            return lst;

        }
        public bool Update(UserInfo entity)//, out List<TrainingProduct> lstupdated)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            bool ret = false;
            List<UserInfo> lst = new List<UserInfo>();
            UserInfo tempProd = new UserInfo();
            ret = validate(entity, "Update");
            if (ret)
            {
                // lst = CreateMockData();
                tempProd = lst.Find(p => p.User_ID == entity.User_ID);
                lst.Remove(tempProd);
                tempProd = new UserInfo();
                tempProd.User_ID = entity.User_ID;
                tempProd.FirstName = entity.FirstName;
                tempProd.LastName = entity.LastName;
                tempProd.Project_ID = entity.Project_ID;
                tempProd.Employee_ID = entity.Employee_ID;
                tempProd.Task_ID = entity.Task_ID;
                //update in DB
                serviceClient.UpdateUser(entity.User_ID, entity.FirstName, entity.LastName , entity.Project_ID, entity.Employee_ID, entity.Task_ID);

            }

            lst.Add(tempProd);
            // lstupdated = lst;
            return ret;
        }



        public bool Insert(UserInfo entity)//, out List<TrainingProduct> lst)
        {

            List<UserInfo> lstProdAdd = new List<UserInfo>();
            //lstProdAdd = new List<TrainingProduct>();
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();


            bool ret = false;
            ret = validate(entity, "add");
            if (ret)
            {
                serviceClient.AddUserInfo(entity.FirstName, entity.LastName, entity.Employee_ID,entity.Project_ID,entity.Task_ID);


            }

            return ret;
        }
        public bool Delete(UserInfo entity, out List<UserInfo> lstupdated)
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            bool ret = false;
            List<UserInfo> lst = new List<UserInfo>();
            UserInfo tempProd = new UserInfo();
            ret = validate(entity, "delete");
            if (ret)
            {

                serviceClient.DeleteUserById(entity.User_ID);

            }
            lstupdated = lst;
            return ret;
        }
        public List<UserInfo> Get(UserInfo entity, List<UserInfo> prd, string mode = "")
        {
            MyServiceReference.MyServiceClient serviceClient = new MyServiceReference.MyServiceClient();
            //if (mode.ToLower() == "delete")
            //{
            //    return prd;
            //}
            List<UserInfo> ret = new List<UserInfo>();

            //TODO - Add Empower Data Fetch Call method here


            //MyServiceReference.UserProfile[] Users = serviceClient.GetAllUsers();
            MyServiceReference.UserInfo[] Users = serviceClient.GetAllUsers();

            foreach (var _User in Users)
            {
                ret.Add(new UserInfo()
                {

                    User_ID = _User.User_ID,
                    FirstName = _User.FirstName,
                    LastName = _User.LastName,
                    Project_ID = _User.Project_ID,
                    Employee_ID = _User.Employee_ID,
                    Task_ID = _User.Task_ID,
                  
                });
            }

            // ret = prd.Count >= 5 ? prd : CreateMockData();

            if (!string.IsNullOrEmpty(entity.FirstName))
            {
                ret = ret.FindAll(p => p.FirstName.ToLower().StartsWith(entity.FirstName.ToLower()));
            }
            return ret;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Entity.Validation;
using System.Data.Entity.Core.Objects;

namespace WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
       

        public List<UserInfo> GetAllUsers()
        {
           
            List<UserInfo> UserLst1 = new List<UserInfo>();
            using (ProductDBEntities tstDb = new ProductDBEntities())
            {
                //ProductDBEntities tstDb = new ProductDBEntities();
                var lstUser = from k in tstDb.TblUsers select k;
                foreach (var item in lstUser)
                {
                    UserInfo upr = new UserInfo();
                    upr.User_ID = item.User_ID;
                    upr.FirstName = item.FirstName;
                    upr.LastName = item.LastName;
                    upr.Project_ID = item.Project_ID;
                    upr.Employee_ID = item.EmployeeID;
                    upr.Task_ID = item.Task_ID;
                    //   tstDb.Entry(upr).State = EntityState.Detached;
                    UserLst1.Add(upr);

                }
            }

            return UserLst1;
        }

        public List<ProjectInfo> GetAllProjects()
        {
            List<ProjectInfo> UserLst = new List<ProjectInfo>();
            List<ProjectInfo> UserLst1 = new List<ProjectInfo>();
            using (ProductDBEntities tstDb = new ProductDBEntities())
            {
                //ProductDBEntities tstDb = new ProductDBEntities();
                var lstUser = from k in tstDb.TblProjects select k;
                foreach (var item in lstUser)
                {
                    ProjectInfo upr = new ProjectInfo();
                    upr.Project_ID = item.Project_ID;
                    upr.Project = item.Project;
                    upr.StartDate = item.StartDate;
                    upr.EndDate = item.EndDate;
                    upr.Priority = item.Priority;
                    
                    UserLst1.Add(upr);

                }

            }

            return UserLst1;
        }

        public List<ProjectTaskInfo> GetAllTasks()
        {
            List<ProjectTaskInfo> TaskList = new List<ProjectTaskInfo>();

           using (ProductDBEntities tstDb = new ProductDBEntities())
            {
                //ProductDBEntities tstDb = new ProductDBEntities();
                var lstTask = from k in tstDb.TblTasks select k;
                foreach (var item in lstTask)
                {
                    ProjectTaskInfo _task = new ProjectTaskInfo();
                    _task.Task_Id = item.Task_ID;
                    _task.Project_ID = item.Project_ID;
                    _task.Task = item.Task;
                    _task.StartDate = item.StartDate;
                    _task.EndDate = item.EndDate;
                    _task.Priority = item.Priority;
                    _task.Parent_ID = item.Parent_ID;
                    _task.Project_ID = item.Project_ID;
                    _task.Status = item.Status;
                    TaskList.Add(_task);

                }

            }

            return TaskList;
        }

        public List<ParentTaskInfo> GetAllParentTasks()
        {
            List<ParentTaskInfo> ParentTaskList = new List<ParentTaskInfo>();

            using (ProductDBEntities tstDb = new ProductDBEntities())
            {
                //ProductDBEntities tstDb = new ProductDBEntities();
                var lstTask = from k in tstDb.TblParentTasks select k;
                foreach (var item in lstTask)
                {
                    ParentTaskInfo _task = new ParentTaskInfo();
                    _task.ParentTask_Id = item.Parent_ID;
                    _task.ParentTaskName = item.Parent_Task;
                    ParentTaskList.Add(_task);

                }

            }

            return ParentTaskList;
        }
        

       

        public int LogErrorinDB(string error_info_Message, string error_info_Type)
        {
            int Retval = -1;
            try
            {

                using (var context = new ProductDBEntities())

                {

                    ErrorInfoDetail errorInfo = new ErrorInfoDetail();

                    errorInfo.ErrorInfoMessage = error_info_Message;
                    errorInfo.ErrorInfoType = error_info_Type;
                    context.ErrorInfoDetails.Add(errorInfo);
                    Retval = context.SaveChanges();
                }


            }
            catch (DbEntityValidationException EX)
            {
                foreach (DbEntityValidationResult entityErr in
                  EX.EntityValidationErrors)
                {

                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine("Error: {0}", error.ErrorMessage);
                    }
                }
            }
            return Retval;



        }

     

        

        public UserInfo GetAllUsersById(int id)
        {
            ProductDBEntities tstDb = new ProductDBEntities();
            var lstUsr = from k in tstDb.TblUsers where k.User_ID == id select k;
            UserInfo userProfile = new UserInfo();
            foreach (var item in lstUsr)
            {
                userProfile.User_ID = item.User_ID;
                userProfile.FirstName = item.FirstName;
                userProfile.LastName = item.LastName;
                userProfile.Project_ID = item.Project_ID;
                userProfile.Employee_ID = item.EmployeeID;
                userProfile.Task_ID = item.Task_ID;

            }

            return userProfile;
        }

        public ProjectInfo GetProjectById(int id)
        {
            ProductDBEntities tstDb = new ProductDBEntities();
            var lstUsr = from k in tstDb.TblProjects where k.Project_ID == id select k;
            ProjectInfo ProjInfo = new ProjectInfo();
            foreach (var item in lstUsr)
            {
                ProjInfo.Project_ID = item.Project_ID;
                ProjInfo.Project = item.Project;
                ProjInfo.StartDate = item.StartDate;
                ProjInfo.EndDate = item.EndDate;
                ProjInfo.Priority= item.Priority;
               

            }

            return ProjInfo;
        }

        public ProjectTaskInfo GetTaskById(int Taskid)
        {
            ProductDBEntities tstDb = new ProductDBEntities();
            var lstUsr = from k in tstDb.TblTasks where k.Task_ID == Taskid select k;
            ProjectTaskInfo TaskInfo = new ProjectTaskInfo();
            foreach (var item in lstUsr)
            {
                TaskInfo.Project_ID = item.Project_ID;
                TaskInfo.StartDate = item.StartDate;
                TaskInfo.EndDate = item.EndDate;
                TaskInfo.Priority = item.Priority;
                TaskInfo.Task = item.Task;
                TaskInfo.Parent_ID = item.Parent_ID;
                TaskInfo.Status = item.Status;
            }

            return TaskInfo;
        }
   
      
        public int UpdateUser(int UserId, string FirstName, string LastName, int Project_ID, string Employee_ID,int TaskID)
        {
            int Retval = -1;
            ProductDBEntities tstDb = new ProductDBEntities();
            UserInfo tempProd = new UserInfo(); ;
            tempProd.User_ID = UserId;
            tempProd.FirstName = FirstName;
            tempProd.LastName = LastName;
            tempProd.Project_ID = Project_ID;
            tempProd.Employee_ID = Employee_ID;
            tempProd.Task_ID = TaskID;



            TblUser result = tstDb.TblUsers.SingleOrDefault(b => b.User_ID == UserId);

            if (result != null)
            {
                result.User_ID = UserId;
                result.FirstName = FirstName;
                result.LastName = LastName;
                result.Project_ID = Project_ID;
                result.EmployeeID = Employee_ID;
                result.Task_ID = TaskID;
                tstDb.Entry(result).State = EntityState.Modified;
                Retval = tstDb.SaveChanges();
            }
            return Retval;
        }

        public int UpdateTask(int TaskId,bool taskStatus)
        {
            int Retval = -1;
            ProductDBEntities tstDb = new ProductDBEntities();
            ProjectTaskInfo tempProd = new ProjectTaskInfo(); ;



            TblTask result = tstDb.TblTasks.SingleOrDefault(b => b.Task_ID == TaskId);

            if (result != null)
            {
                result.Status = taskStatus;
                tstDb.Entry(result).State = EntityState.Modified;
                Retval = tstDb.SaveChanges();
            }
            return Retval;
        }
        public int UpdateTaskDetails(int TaskId,int ParentId, int ProjectId, string Task, DateTime StartDate, DateTime EndDate, int Priority, bool status)
        {
            int Retval = -1;
            ProductDBEntities tstDb = new ProductDBEntities();
            ProjectTaskInfo tempProd = new ProjectTaskInfo(); ;



            TblTask result = tstDb.TblTasks.SingleOrDefault(b => b.Task_ID == TaskId);

            if (result != null)
            {
                result.Parent_ID = ParentId;
                result.Project_ID = ProjectId;
                result.Task = Task;
                result.StartDate = StartDate;
                result.EndDate = EndDate;
                result.Priority = Priority;
                result.Status = status;
                tstDb.Entry(result).State = EntityState.Modified;
                Retval = tstDb.SaveChanges();
            }
            return Retval;
        }
        public int DeleteUserById(int UserId)
        {
            int Retval = -1;
         
            ProductDBEntities tstDb = new ProductDBEntities();
            TblUser userProfile = new TblUser();
            userProfile.User_ID = UserId;
            tstDb.Entry(userProfile).State = EntityState.Deleted;
            Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int DeleteProjectById(int ProjectId)
        {
            int Retval = -1;

            ProductDBEntities tstDb = new ProductDBEntities();
            TblProject projInfo = new TblProject();
            projInfo.Project_ID = ProjectId;
            tstDb.Entry(projInfo).State = EntityState.Deleted;
            Retval = tstDb.SaveChanges();


            TblUser resultuser = tstDb.TblUsers.SingleOrDefault(b => b.Project_ID == ProjectId);

            if (resultuser != null)
            {
                resultuser.User_ID = resultuser.User_ID;
                resultuser.Project_ID = 0;
                tstDb.Entry(resultuser).State = EntityState.Modified;
                Retval = tstDb.SaveChanges();
            }
            return Retval;
           
        }

        public int CheckUserDependencyById(int UserId)
        {
            int Retval = -1;
            ProductDBEntities tstDb = new ProductDBEntities();
            ObjectResult<Nullable<int>> usercount = tstDb.sp_CheckifUserUsed(UserId);
            foreach (Nullable<int> result in usercount)
            {

                Retval = result.Value;
                break;
            }
            return Retval;

        }

        public int AddUserInfo(string FirstName, string LastName, string EmployeeID, int Project_ID, int Task_ID)
        {
            int Retval = -1;

            try
            {
                TblUser usrprfl = new TblUser();

                usrprfl.FirstName = FirstName;
                usrprfl.LastName = LastName;
                usrprfl.EmployeeID = EmployeeID;
                usrprfl.Project_ID = Project_ID;
                usrprfl.Task_ID = Task_ID;
                var context = new ProductDBEntities();
                context.TblUsers.Add(usrprfl);
                context.Entry(usrprfl).State = EntityState.Added;
                Retval = context.SaveChanges(); // this is where the error msg is being thrown.





            }
            catch (DbEntityValidationException EX)
            {
                foreach (DbEntityValidationResult entityErr in
                  EX.EntityValidationErrors)
                {

                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine("Error: {0}", error.ErrorMessage);
                    }
                }
            }
            return Retval;
        }

        public int AddProjectInfo(string project, DateTime StartDate, DateTime EndDate, int Priority, int User_ID)
        {

            int newPK = -1;
            using (var context = new ProductDBEntities())
            {
                TblProject Projectinfo = new TblProject()
                {
                    Project = project,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Priority = Priority,
                };
                context.TblProjects.Add(Projectinfo);
                context.Entry(Projectinfo).State = EntityState.Added;
                context.SaveChanges();
                context.Entry(Projectinfo).GetDatabaseValues();
                //int newPK = Projectinfo.Project_ID;
                newPK = context.TblProjects.Max(p => p.Project_ID);
            }
            UserInfo detailmyuser = GetAllUsersById(User_ID);
          

            int ret = UpdateUser(User_ID, detailmyuser.FirstName, detailmyuser.LastName, newPK, detailmyuser.Employee_ID, 0);


        

            return ret;
        }
        
        public int UpdateProjectUserInfo(int ProjectID, string project, DateTime startDate, DateTime endDate, int priority, int userID)
        {

            int Retval = -1;
            ProductDBEntities tstDb = new ProductDBEntities();
            ProjectInfo tempProd = new ProjectInfo(); ;
            tempProd.Project_ID = ProjectID;
            tempProd.Project = project;
            tempProd.StartDate = startDate;
            tempProd.EndDate = endDate;
            tempProd.Project_ID = priority;




            TblProject result = tstDb.TblProjects.SingleOrDefault(b => b.Project_ID == ProjectID);

            if (result != null)
            {
                //result.Project_ID = UserId;
                result.Project = project;
                result.StartDate = startDate;
                result.EndDate = endDate;
                result.Priority = priority;
                tstDb.Entry(result).State = EntityState.Modified;
                Retval = tstDb.SaveChanges();
            }
            //return Retval;

            TblUser resultuser = tstDb.TblUsers.SingleOrDefault(b => b.User_ID  == userID);

            if (resultuser != null)
            {
                resultuser.User_ID = resultuser.User_ID;
                //resultuser.FirstName = resultuser.User_ID;
                //resultuser.LastName = LastName;
                resultuser.Project_ID = ProjectID;
                //resultuser.EmployeeID = Employee_ID;
                //resultuser.Task_ID = TaskID;
                tstDb.Entry(resultuser).State = EntityState.Modified;
                Retval = tstDb.SaveChanges();
            }
            return Retval;


        }

        public int AddParentTask(string Taskname)
        {
            int Retval = -1;
         
            try
            {
                TblParentTask usrprfl = new TblParentTask();

                usrprfl.Parent_Task= Taskname;
                var context = new ProductDBEntities();
                context.TblParentTasks.Add(usrprfl);
                context.Entry(usrprfl).State = EntityState.Added;
                Retval = context.SaveChanges(); // this is where the error msg is being thrown.





            }
            catch (DbEntityValidationException EX)
            {
                foreach (DbEntityValidationResult entityErr in
                  EX.EntityValidationErrors)
                {

                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine("Error: {0}", error.ErrorMessage);
                    }
                }
            }
            return Retval;
        }

        public int AddTask(int ParentId, int ProjectId, string Task, DateTime StartDate, DateTime EndDate, int Priority, bool status, int UserID)
        {
            int Retval = -1;

            try
            {
                TblTask usrTask = new TblTask();
                usrTask.Parent_ID = ParentId;
                usrTask.Project_ID = ProjectId;
                usrTask.Task = Task;
                usrTask.StartDate = StartDate;
                usrTask.EndDate = EndDate;
                usrTask.Priority = Priority;
                usrTask.Status = status;

                var context = new ProductDBEntities();
                context.TblTasks.Add(usrTask);
                context.Entry(usrTask).State = EntityState.Added;
                Retval = context.SaveChanges();
                int newTaskId = -1;
                newTaskId = context.TblTasks.Max(p => p.Task_ID);
                
                UserInfo detailmyuser = GetAllUsersById(UserID);
                int ret = UpdateUser(UserID, detailmyuser.FirstName, detailmyuser.LastName, ProjectId, detailmyuser.Employee_ID, newTaskId);


                //context.SaveChanges();

                return ret;
                ///
            }
            catch (DbEntityValidationException EX)
            {
                foreach (DbEntityValidationResult entityErr in
                  EX.EntityValidationErrors)
                {

                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine("Error: {0}", error.ErrorMessage);
                    }
                }
            }
            return Retval;
        }
    }
}


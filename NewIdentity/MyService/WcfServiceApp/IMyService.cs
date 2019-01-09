using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IMyService" in both code and config file together.
    [ServiceContract]
    public interface IMyService
    {
        #region Logging
        [OperationContract]
        int LogErrorinDB(string error_info_Message, string error_info_Type);
        #endregion


       
        #region UserInfo

        [OperationContract]
        List<UserInfo> GetAllUsers();
        [OperationContract]
        int AddUserInfo(string FirstName, string LastName, string EmployeeID, int Project_ID, int Task_ID);
        [OperationContract]
        int UpdateUser(int UserId, string FirstName, string LastName, int Project_ID, string Employee_ID, int TaskID);
        #endregion UserInfo
        [OperationContract]
        ProjectInfo GetProjectById(int id);
        [OperationContract]
        UserInfo GetAllUsersById(int id);
        [OperationContract]
        List<ProjectInfo> GetAllProjects();
        [OperationContract]
        List<ProjectTaskInfo> GetAllTasks();
        [OperationContract]
        ProjectTaskInfo GetTaskById(int id);
       




        [OperationContract]
        int AddProjectInfo(string Project, DateTime StartDate, DateTime EndDate, int Priority, int User_ID);
        [OperationContract]
        int UpdateTask(int TaskId, bool taskStatus);
            [OperationContract]
        int UpdateProjectUserInfo(int Project_ID, string project, DateTime StartDate, DateTime EndDate, int Priority, int User_ID);
       
        [OperationContract]
        int DeleteProjectById(int ProjectId);
        [OperationContract]
        int AddParentTask(string Taskname);

        [OperationContract]
        int AddTask(int ParentId, int ProjectId,string Task , DateTime StartDate, DateTime EndDate, int Priority , bool status,int UserID);
        [OperationContract]
        int UpdateTaskDetails(int TaskId, int ParentId, int ProjectId, string Task, DateTime StartDate, DateTime EndDate, int Priority, bool status);


        [OperationContract]
        int DeleteUserById(int UserId);

        [OperationContract]
        int CheckUserDependencyById(int UserId);
        [OperationContract]
        List<ParentTaskInfo> GetAllParentTasks();
    }

   

   


    [DataContract]
    public class ParentTaskInfo
    {
        [DataMember]
        public int ParentTask_Id { get; set; }
        [DataMember]
        public string ParentTaskName { get; set; }
       
    }
    [DataContract]
    public class ProjectTaskInfo
    {
        [DataMember]
        public int Project_ID { get; set; }
        [DataMember]
        public int Parent_ID { get; set; }
        [DataMember]
        public string Task { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public bool Status { get; set; }
        [DataMember]
        public int Task_Id { get; set; }
    }

    [DataContract]
    public class UserInfo
    {
      
        [DataMember]
        public int User_ID { get; set; }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }
        [DataMember]
        public string Employee_ID { get; set; }
        [DataMember]
        public int Project_ID { get; set; }
        [DataMember]
        public int Task_ID { get; set; }


    }

    [DataContract]
    public class ProjectInfo
    {
        [DataMember]
        public int Project_ID { get; set; }
        [DataMember]
        public string Project { get; set; }
        [DataMember]
        public DateTime StartDate { get; set; }
        [DataMember]
        public DateTime EndDate { get; set; }
        [DataMember]
        public int Priority { get; set; }
        [DataMember]
        public List<UserInfo> Users { get; set; }
        [DataMember]
        public int Manager_ID { get; set; }

    }
    
}

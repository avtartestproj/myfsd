﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SPAData.MyServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="UserInfo", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceApp")]
    [System.SerializableAttribute()]
    public partial class UserInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string Employee_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FirstNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string LastNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Project_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Task_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int User_IDField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Employee_ID {
            get {
                return this.Employee_IDField;
            }
            set {
                if ((object.ReferenceEquals(this.Employee_IDField, value) != true)) {
                    this.Employee_IDField = value;
                    this.RaisePropertyChanged("Employee_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Project_ID {
            get {
                return this.Project_IDField;
            }
            set {
                if ((this.Project_IDField.Equals(value) != true)) {
                    this.Project_IDField = value;
                    this.RaisePropertyChanged("Project_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Task_ID {
            get {
                return this.Task_IDField;
            }
            set {
                if ((this.Task_IDField.Equals(value) != true)) {
                    this.Task_IDField = value;
                    this.RaisePropertyChanged("Task_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int User_ID {
            get {
                return this.User_IDField;
            }
            set {
                if ((this.User_IDField.Equals(value) != true)) {
                    this.User_IDField = value;
                    this.RaisePropertyChanged("User_ID");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProjectInfo", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceApp")]
    [System.SerializableAttribute()]
    public partial class ProjectInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Manager_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ProjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Project_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private SPAData.MyServiceReference.UserInfo[] UsersField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Manager_ID {
            get {
                return this.Manager_IDField;
            }
            set {
                if ((this.Manager_IDField.Equals(value) != true)) {
                    this.Manager_IDField = value;
                    this.RaisePropertyChanged("Manager_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Project {
            get {
                return this.ProjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ProjectField, value) != true)) {
                    this.ProjectField = value;
                    this.RaisePropertyChanged("Project");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Project_ID {
            get {
                return this.Project_IDField;
            }
            set {
                if ((this.Project_IDField.Equals(value) != true)) {
                    this.Project_IDField = value;
                    this.RaisePropertyChanged("Project_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public SPAData.MyServiceReference.UserInfo[] Users {
            get {
                return this.UsersField;
            }
            set {
                if ((object.ReferenceEquals(this.UsersField, value) != true)) {
                    this.UsersField = value;
                    this.RaisePropertyChanged("Users");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProjectTaskInfo", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceApp")]
    [System.SerializableAttribute()]
    public partial class ProjectTaskInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime EndDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Parent_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PriorityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Project_IDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime StartDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TaskField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int Task_IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime EndDate {
            get {
                return this.EndDateField;
            }
            set {
                if ((this.EndDateField.Equals(value) != true)) {
                    this.EndDateField = value;
                    this.RaisePropertyChanged("EndDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Parent_ID {
            get {
                return this.Parent_IDField;
            }
            set {
                if ((this.Parent_IDField.Equals(value) != true)) {
                    this.Parent_IDField = value;
                    this.RaisePropertyChanged("Parent_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Priority {
            get {
                return this.PriorityField;
            }
            set {
                if ((this.PriorityField.Equals(value) != true)) {
                    this.PriorityField = value;
                    this.RaisePropertyChanged("Priority");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Project_ID {
            get {
                return this.Project_IDField;
            }
            set {
                if ((this.Project_IDField.Equals(value) != true)) {
                    this.Project_IDField = value;
                    this.RaisePropertyChanged("Project_ID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime StartDate {
            get {
                return this.StartDateField;
            }
            set {
                if ((this.StartDateField.Equals(value) != true)) {
                    this.StartDateField = value;
                    this.RaisePropertyChanged("StartDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Task {
            get {
                return this.TaskField;
            }
            set {
                if ((object.ReferenceEquals(this.TaskField, value) != true)) {
                    this.TaskField = value;
                    this.RaisePropertyChanged("Task");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Task_Id {
            get {
                return this.Task_IdField;
            }
            set {
                if ((this.Task_IdField.Equals(value) != true)) {
                    this.Task_IdField = value;
                    this.RaisePropertyChanged("Task_Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ParentTaskInfo", Namespace="http://schemas.datacontract.org/2004/07/WcfServiceApp")]
    [System.SerializableAttribute()]
    public partial class ParentTaskInfo : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ParentTaskNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ParentTask_IdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ParentTaskName {
            get {
                return this.ParentTaskNameField;
            }
            set {
                if ((object.ReferenceEquals(this.ParentTaskNameField, value) != true)) {
                    this.ParentTaskNameField = value;
                    this.RaisePropertyChanged("ParentTaskName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ParentTask_Id {
            get {
                return this.ParentTask_IdField;
            }
            set {
                if ((this.ParentTask_IdField.Equals(value) != true)) {
                    this.ParentTask_IdField = value;
                    this.RaisePropertyChanged("ParentTask_Id");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MyServiceReference.IMyService")]
    public interface IMyService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/LogErrorinDB", ReplyAction="http://tempuri.org/IMyService/LogErrorinDBResponse")]
        int LogErrorinDB(string error_info_Message, string error_info_Type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/LogErrorinDB", ReplyAction="http://tempuri.org/IMyService/LogErrorinDBResponse")]
        System.Threading.Tasks.Task<int> LogErrorinDBAsync(string error_info_Message, string error_info_Type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllUsers", ReplyAction="http://tempuri.org/IMyService/GetAllUsersResponse")]
        SPAData.MyServiceReference.UserInfo[] GetAllUsers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllUsers", ReplyAction="http://tempuri.org/IMyService/GetAllUsersResponse")]
        System.Threading.Tasks.Task<SPAData.MyServiceReference.UserInfo[]> GetAllUsersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddUserInfo", ReplyAction="http://tempuri.org/IMyService/AddUserInfoResponse")]
        int AddUserInfo(string FirstName, string LastName, string EmployeeID, int Project_ID, int Task_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddUserInfo", ReplyAction="http://tempuri.org/IMyService/AddUserInfoResponse")]
        System.Threading.Tasks.Task<int> AddUserInfoAsync(string FirstName, string LastName, string EmployeeID, int Project_ID, int Task_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateUser", ReplyAction="http://tempuri.org/IMyService/UpdateUserResponse")]
        int UpdateUser(int UserId, string FirstName, string LastName, int Project_ID, string Employee_ID, int TaskID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateUser", ReplyAction="http://tempuri.org/IMyService/UpdateUserResponse")]
        System.Threading.Tasks.Task<int> UpdateUserAsync(int UserId, string FirstName, string LastName, int Project_ID, string Employee_ID, int TaskID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetProjectById", ReplyAction="http://tempuri.org/IMyService/GetProjectByIdResponse")]
        SPAData.MyServiceReference.ProjectInfo GetProjectById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetProjectById", ReplyAction="http://tempuri.org/IMyService/GetProjectByIdResponse")]
        System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectInfo> GetProjectByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllUsersById", ReplyAction="http://tempuri.org/IMyService/GetAllUsersByIdResponse")]
        SPAData.MyServiceReference.UserInfo GetAllUsersById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllUsersById", ReplyAction="http://tempuri.org/IMyService/GetAllUsersByIdResponse")]
        System.Threading.Tasks.Task<SPAData.MyServiceReference.UserInfo> GetAllUsersByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllProjects", ReplyAction="http://tempuri.org/IMyService/GetAllProjectsResponse")]
        SPAData.MyServiceReference.ProjectInfo[] GetAllProjects();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllProjects", ReplyAction="http://tempuri.org/IMyService/GetAllProjectsResponse")]
        System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectInfo[]> GetAllProjectsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllTasks", ReplyAction="http://tempuri.org/IMyService/GetAllTasksResponse")]
        SPAData.MyServiceReference.ProjectTaskInfo[] GetAllTasks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllTasks", ReplyAction="http://tempuri.org/IMyService/GetAllTasksResponse")]
        System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectTaskInfo[]> GetAllTasksAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetTaskById", ReplyAction="http://tempuri.org/IMyService/GetTaskByIdResponse")]
        SPAData.MyServiceReference.ProjectTaskInfo GetTaskById(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetTaskById", ReplyAction="http://tempuri.org/IMyService/GetTaskByIdResponse")]
        System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectTaskInfo> GetTaskByIdAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddProjectInfo", ReplyAction="http://tempuri.org/IMyService/AddProjectInfoResponse")]
        int AddProjectInfo(string Project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddProjectInfo", ReplyAction="http://tempuri.org/IMyService/AddProjectInfoResponse")]
        System.Threading.Tasks.Task<int> AddProjectInfoAsync(string Project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateTask", ReplyAction="http://tempuri.org/IMyService/UpdateTaskResponse")]
        int UpdateTask(int TaskId, bool taskStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateTask", ReplyAction="http://tempuri.org/IMyService/UpdateTaskResponse")]
        System.Threading.Tasks.Task<int> UpdateTaskAsync(int TaskId, bool taskStatus);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateProjectUserInfo", ReplyAction="http://tempuri.org/IMyService/UpdateProjectUserInfoResponse")]
        int UpdateProjectUserInfo(int Project_ID, string project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateProjectUserInfo", ReplyAction="http://tempuri.org/IMyService/UpdateProjectUserInfoResponse")]
        System.Threading.Tasks.Task<int> UpdateProjectUserInfoAsync(int Project_ID, string project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/DeleteProjectById", ReplyAction="http://tempuri.org/IMyService/DeleteProjectByIdResponse")]
        int DeleteProjectById(int ProjectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/DeleteProjectById", ReplyAction="http://tempuri.org/IMyService/DeleteProjectByIdResponse")]
        System.Threading.Tasks.Task<int> DeleteProjectByIdAsync(int ProjectId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddParentTask", ReplyAction="http://tempuri.org/IMyService/AddParentTaskResponse")]
        int AddParentTask(string Taskname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddParentTask", ReplyAction="http://tempuri.org/IMyService/AddParentTaskResponse")]
        System.Threading.Tasks.Task<int> AddParentTaskAsync(string Taskname);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddTask", ReplyAction="http://tempuri.org/IMyService/AddTaskResponse")]
        int AddTask(int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status, int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/AddTask", ReplyAction="http://tempuri.org/IMyService/AddTaskResponse")]
        System.Threading.Tasks.Task<int> AddTaskAsync(int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status, int UserID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateTaskDetails", ReplyAction="http://tempuri.org/IMyService/UpdateTaskDetailsResponse")]
        int UpdateTaskDetails(int TaskId, int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/UpdateTaskDetails", ReplyAction="http://tempuri.org/IMyService/UpdateTaskDetailsResponse")]
        System.Threading.Tasks.Task<int> UpdateTaskDetailsAsync(int TaskId, int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/DeleteUserById", ReplyAction="http://tempuri.org/IMyService/DeleteUserByIdResponse")]
        int DeleteUserById(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/DeleteUserById", ReplyAction="http://tempuri.org/IMyService/DeleteUserByIdResponse")]
        System.Threading.Tasks.Task<int> DeleteUserByIdAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/CheckUserDependencyById", ReplyAction="http://tempuri.org/IMyService/CheckUserDependencyByIdResponse")]
        int CheckUserDependencyById(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/CheckUserDependencyById", ReplyAction="http://tempuri.org/IMyService/CheckUserDependencyByIdResponse")]
        System.Threading.Tasks.Task<int> CheckUserDependencyByIdAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllParentTasks", ReplyAction="http://tempuri.org/IMyService/GetAllParentTasksResponse")]
        SPAData.MyServiceReference.ParentTaskInfo[] GetAllParentTasks();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMyService/GetAllParentTasks", ReplyAction="http://tempuri.org/IMyService/GetAllParentTasksResponse")]
        System.Threading.Tasks.Task<SPAData.MyServiceReference.ParentTaskInfo[]> GetAllParentTasksAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMyServiceChannel : SPAData.MyServiceReference.IMyService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MyServiceClient : System.ServiceModel.ClientBase<SPAData.MyServiceReference.IMyService>, SPAData.MyServiceReference.IMyService {
        
        public MyServiceClient() {
        }
        
        public MyServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MyServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MyServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int LogErrorinDB(string error_info_Message, string error_info_Type) {
            return base.Channel.LogErrorinDB(error_info_Message, error_info_Type);
        }
        
        public System.Threading.Tasks.Task<int> LogErrorinDBAsync(string error_info_Message, string error_info_Type) {
            return base.Channel.LogErrorinDBAsync(error_info_Message, error_info_Type);
        }
        
        public SPAData.MyServiceReference.UserInfo[] GetAllUsers() {
            return base.Channel.GetAllUsers();
        }
        
        public System.Threading.Tasks.Task<SPAData.MyServiceReference.UserInfo[]> GetAllUsersAsync() {
            return base.Channel.GetAllUsersAsync();
        }
        
        public int AddUserInfo(string FirstName, string LastName, string EmployeeID, int Project_ID, int Task_ID) {
            return base.Channel.AddUserInfo(FirstName, LastName, EmployeeID, Project_ID, Task_ID);
        }
        
        public System.Threading.Tasks.Task<int> AddUserInfoAsync(string FirstName, string LastName, string EmployeeID, int Project_ID, int Task_ID) {
            return base.Channel.AddUserInfoAsync(FirstName, LastName, EmployeeID, Project_ID, Task_ID);
        }
        
        public int UpdateUser(int UserId, string FirstName, string LastName, int Project_ID, string Employee_ID, int TaskID) {
            return base.Channel.UpdateUser(UserId, FirstName, LastName, Project_ID, Employee_ID, TaskID);
        }
        
        public System.Threading.Tasks.Task<int> UpdateUserAsync(int UserId, string FirstName, string LastName, int Project_ID, string Employee_ID, int TaskID) {
            return base.Channel.UpdateUserAsync(UserId, FirstName, LastName, Project_ID, Employee_ID, TaskID);
        }
        
        public SPAData.MyServiceReference.ProjectInfo GetProjectById(int id) {
            return base.Channel.GetProjectById(id);
        }
        
        public System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectInfo> GetProjectByIdAsync(int id) {
            return base.Channel.GetProjectByIdAsync(id);
        }
        
        public SPAData.MyServiceReference.UserInfo GetAllUsersById(int id) {
            return base.Channel.GetAllUsersById(id);
        }
        
        public System.Threading.Tasks.Task<SPAData.MyServiceReference.UserInfo> GetAllUsersByIdAsync(int id) {
            return base.Channel.GetAllUsersByIdAsync(id);
        }
        
        public SPAData.MyServiceReference.ProjectInfo[] GetAllProjects() {
            return base.Channel.GetAllProjects();
        }
        
        public System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectInfo[]> GetAllProjectsAsync() {
            return base.Channel.GetAllProjectsAsync();
        }
        
        public SPAData.MyServiceReference.ProjectTaskInfo[] GetAllTasks() {
            return base.Channel.GetAllTasks();
        }
        
        public System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectTaskInfo[]> GetAllTasksAsync() {
            return base.Channel.GetAllTasksAsync();
        }
        
        public SPAData.MyServiceReference.ProjectTaskInfo GetTaskById(int id) {
            return base.Channel.GetTaskById(id);
        }
        
        public System.Threading.Tasks.Task<SPAData.MyServiceReference.ProjectTaskInfo> GetTaskByIdAsync(int id) {
            return base.Channel.GetTaskByIdAsync(id);
        }
        
        public int AddProjectInfo(string Project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID) {
            return base.Channel.AddProjectInfo(Project, StartDate, EndDate, Priority, User_ID);
        }
        
        public System.Threading.Tasks.Task<int> AddProjectInfoAsync(string Project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID) {
            return base.Channel.AddProjectInfoAsync(Project, StartDate, EndDate, Priority, User_ID);
        }
        
        public int UpdateTask(int TaskId, bool taskStatus) {
            return base.Channel.UpdateTask(TaskId, taskStatus);
        }
        
        public System.Threading.Tasks.Task<int> UpdateTaskAsync(int TaskId, bool taskStatus) {
            return base.Channel.UpdateTaskAsync(TaskId, taskStatus);
        }
        
        public int UpdateProjectUserInfo(int Project_ID, string project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID) {
            return base.Channel.UpdateProjectUserInfo(Project_ID, project, StartDate, EndDate, Priority, User_ID);
        }
        
        public System.Threading.Tasks.Task<int> UpdateProjectUserInfoAsync(int Project_ID, string project, System.DateTime StartDate, System.DateTime EndDate, int Priority, int User_ID) {
            return base.Channel.UpdateProjectUserInfoAsync(Project_ID, project, StartDate, EndDate, Priority, User_ID);
        }
        
        public int DeleteProjectById(int ProjectId) {
            return base.Channel.DeleteProjectById(ProjectId);
        }
        
        public System.Threading.Tasks.Task<int> DeleteProjectByIdAsync(int ProjectId) {
            return base.Channel.DeleteProjectByIdAsync(ProjectId);
        }
        
        public int AddParentTask(string Taskname) {
            return base.Channel.AddParentTask(Taskname);
        }
        
        public System.Threading.Tasks.Task<int> AddParentTaskAsync(string Taskname) {
            return base.Channel.AddParentTaskAsync(Taskname);
        }
        
        public int AddTask(int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status, int UserID) {
            return base.Channel.AddTask(ParentId, ProjectId, Task, StartDate, EndDate, Priority, status, UserID);
        }
        
        public System.Threading.Tasks.Task<int> AddTaskAsync(int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status, int UserID) {
            return base.Channel.AddTaskAsync(ParentId, ProjectId, Task, StartDate, EndDate, Priority, status, UserID);
        }
        
        public int UpdateTaskDetails(int TaskId, int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status) {
            return base.Channel.UpdateTaskDetails(TaskId, ParentId, ProjectId, Task, StartDate, EndDate, Priority, status);
        }
        
        public System.Threading.Tasks.Task<int> UpdateTaskDetailsAsync(int TaskId, int ParentId, int ProjectId, string Task, System.DateTime StartDate, System.DateTime EndDate, int Priority, bool status) {
            return base.Channel.UpdateTaskDetailsAsync(TaskId, ParentId, ProjectId, Task, StartDate, EndDate, Priority, status);
        }
        
        public int DeleteUserById(int UserId) {
            return base.Channel.DeleteUserById(UserId);
        }
        
        public System.Threading.Tasks.Task<int> DeleteUserByIdAsync(int UserId) {
            return base.Channel.DeleteUserByIdAsync(UserId);
        }
        
        public int CheckUserDependencyById(int UserId) {
            return base.Channel.CheckUserDependencyById(UserId);
        }
        
        public System.Threading.Tasks.Task<int> CheckUserDependencyByIdAsync(int UserId) {
            return base.Channel.CheckUserDependencyByIdAsync(UserId);
        }
        
        public SPAData.MyServiceReference.ParentTaskInfo[] GetAllParentTasks() {
            return base.Channel.GetAllParentTasks();
        }
        
        public System.Threading.Tasks.Task<SPAData.MyServiceReference.ParentTaskInfo[]> GetAllParentTasksAsync() {
            return base.Channel.GetAllParentTasksAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using MyLogger;
namespace SPAData
{
    public class TrainingProductViewModel
    {
        public List<TrainingProduct> Products { get; set; }
        public TrainingProductViewModel()
        {
            Log.Info("Model Initialized");
            initialize();
            Products = new List<TrainingProduct>();
            SearchEntity = new TrainingProduct();
            Entity = new TrainingProduct();
           // EventCommand = "List";
        }

        private void initialize()
        {
            EventCommand = "list";
            EventArgument = string.Empty;
            ValidationErrors = new List<KeyValuePair<string, string>>();
            ListMode();
        }

        public TrainingProduct Entity { get; set; }
        public bool IsValid { get; set; }

        public string Mode { get; set; }
        public bool IsDetailAreaVisibie { get; set; }
        public bool IsListAreaVisible { get; set; }
        public bool isSearchAreaVisible { get; set; }
        public TrainingProduct SearchEntity { get; set; }

        public List<KeyValuePair<string, string>> ValidationErrors { get; set; }

        public string EventArgument  { get; set; }
        public void HandleRequest()
        {
            try
            {
                Log.Info("Handle Request called for command " + Convert.ToString(EventCommand).ToLower());
                if (string.IsNullOrEmpty(EventCommand))
                {
                    EventCommand = "list";
                }

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
            }catch (Exception ex)
            {
                Log.Error(ex.Message + ex.StackTrace);
                throw;
            }
        }

        private void ListMode()
        {
            IsValid = true;
            IsListAreaVisible = true;
            isSearchAreaVisible = true;
            IsDetailAreaVisibie = false;
            Mode = "List";

        }
        private void Save()
        {
            
            List<TrainingProduct> lstproduct = new List<TrainingProduct>();
            TrainingProductManager mgr = new TrainingProductManager();

            if (Mode == "Add")
            {
                mgr.Insert(Entity,out lstproduct);
                Products = lstproduct;

            }
            else {
                mgr.Update(Entity,out lstproduct);
                Products = lstproduct;
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
        private void Add()
        {
            IsValid = true;
            Entity = new TrainingProduct();
            Entity.IntroductionDate = DateTime.Now;
            Entity.Url = "testurl";
            Entity.Price = 0;
            AddMode();
        }

        private void Edit()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Entity = mgr.Get(Convert.ToInt32(EventArgument));
            EditMode();
        }

        private void Delete()
        {
            TrainingProductManager mgr = new TrainingProductManager();
            List<TrainingProduct> lstproduct = new List<TrainingProduct>();
            Entity = new TrainingProduct();
            Entity.ProductID = Convert.ToInt32(EventArgument);
            mgr.Delete(Entity,out lstproduct);
            Products = lstproduct;
            Get("Delete");
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
            SearchEntity = new TrainingProduct();
        }
        public string EventCommand { get; set; }
        private void Get(string mode ="")
        {
            TrainingProductManager mgr = new TrainingProductManager();
            Products = mgr.Get(SearchEntity,Products,mode);
        }

    }
}

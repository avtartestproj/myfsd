using SPAData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewIdentity.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            try
            {

                DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - Home Page Loaded ...", "Info");
                ProjectInfoViewModel vm = new ProjectInfoViewModel();
                DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - View Model Created...", "Info");
                DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - HandleRequest called...", "Info");
                //if (Session["MyUserId"] != null)
                {
                    // ViewBag.MyUserId = Session["MyUserId"];
                    //vm.Entity.User_ID = Convert.ToInt32(Convert.ToString(Session["User_ID"]));

                    // ViewBag.UserName = Session["UserName"];
                    //vm.Entity.FirstName = Convert.ToString(Session["FirstName"]);
                }
                vm.HandleRequest();
                DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - HandleRequest Completed...", "Info");
                return View(vm);
            }
            catch (Exception ex)
            {
                DBLogErrorInfo.LogErrorInfo_in_DB(ex.Message, "Error");
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }

        [HttpPost]
        public ActionResult Index(ProjectInfoViewModel vm)
        {

            vm.IsValid = ModelState.IsValid;
            //ViewBag.startDate = DateTime.Now;
            //ViewBag.endDate = DateTime.Now;
            //vm.Entity.UserId = Convert.ToInt32(Convert.ToString(Session["MyUserId"]));
            //vm.Entity.UserName = Convert.ToString(Session["UserName"]);
            vm.HandleRequest();
            if (vm.IsValid)
            {
                ModelState.Clear();
            }
            else
            {
                foreach (KeyValuePair<String, string> item in vm.ValidationErrors)
                {
                    ModelState.AddModelError(item.Key, item.Value);
                }
            }

            return View(vm);
        }
    }
}
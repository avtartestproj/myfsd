using SPAData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace NewIdentity.Controllers
{
    public class TaskController : Controller
    {
        // GET: Task
        public ActionResult Index(bool isViewTask)
        {
            TaskInfoViewModel vm = new TaskInfoViewModel();
            vm.HandleRequest();
            vm.IsViewTask = isViewTask;
            return View(vm);
        }
        public ActionResult ViewTask()
        {
            TaskInfoViewModel vm = new TaskInfoViewModel();
            vm.HandleRequest();

            return View(vm);
        }
        [HttpPost]
        public ActionResult Index(TaskInfoViewModel vm)
        {


            vm.IsValid = ModelState.IsValid;
            
            vm.HandleRequest();
            if (vm.IsValid)
            {
                //ModelState.Clear();
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
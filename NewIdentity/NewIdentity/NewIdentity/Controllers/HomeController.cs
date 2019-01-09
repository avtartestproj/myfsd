using SPAData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewIdentity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                //if (Session["MyUserId"] == null)
                //{
                //    return RedirectToAction("Contact", "Home");
                //}
                //DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - Home Page Loaded ...", "Info");
                //UserProfileViewModel vm = new UserProfileViewModel();
                //DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - View Model Created...", "Info");
                //DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - HandleRequest called...", "Info");
                //if (Session["MyUserId"] != null)
                //{
                //    ViewBag.MyUserId = Session["MyUserId"];
                //    vm.Entity.UserId = Convert.ToInt32(Convert.ToString(Session["MyUserId"]));

                //    ViewBag.UserName = Session["UserName"];
                //    vm.Entity.UserName = Convert.ToString(Session["UserName"]);
                //}
                //vm.HandleRequest();
                //DBLogErrorInfo.LogErrorInfo_in_DB("Inside controller - HandleRequest Completed...", "Info");
                //return View(vm);
                return View();
            }
            catch (Exception ex)
            {
                DBLogErrorInfo.LogErrorInfo_in_DB(ex.Message, "Error");
                return View("Error", new HandleErrorInfo(ex, "EmployeeInfo", "Create"));
            }
        }


        //[HttpPost]
        //public ActionResult Index(UserProfileViewModel vm)
        //{

        //    vm.IsValid = ModelState.IsValid;

        //    //vm.Entity.UserId = Convert.ToInt32(Convert.ToString(Session["MyUserId"]));
        //    //vm.Entity.UserName = Convert.ToString(Session["UserName"]);
        //    vm.HandleRequest();
        //    if (vm.IsValid)
        //    {
        //        ModelState.Clear();
        //    }
        //    else
        //    {
        //        foreach (KeyValuePair<String, string> item in vm.ValidationErrors)
        //        {
        //            ModelState.AddModelError(item.Key, item.Value);
        //        }
        //    }

        //    return View(vm);
        //}
        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}


        //public ActionResult Contact()
        //{
        //    //ViewBag.Message = "Your application description page.";

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Contact(UserProfile objUser)
        //{
        //    int userid = 0;
        //    ViewBag.Message = "Your login page.";
        //    //if (ModelState.IsValid)
        //    //  {
        //    //using (DB_Entities db = new DB_Entities())
        //    //{
        //    //    var obj = db.UserProfiles.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password)).FirstOrDefault();
        //    //    if (obj != null)
        //    //    {
        //    UserManager UM = new UserManager();
        //    List<UserProfile> lstUsers = UM.GetAllUsers();
        //    if (lstUsers.Count > 0)

        //    {
        //        var obj = lstUsers.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password));
        //        if (obj != null)
        //        {
        //            //var r = lstUsers.SingleOrDefault(x => x.UserName == objUser.UserName);
        //            var r = lstUsers.FirstOrDefault(x => x.UserName == objUser.UserName);
        //            //lstUsers.Where(a => a.UserName.Equals(objUser.UserName) && a.Password.Equals(objUser.Password));
        //            foreach (UserProfile u in lstUsers)
        //            {
        //                if (u.UserName == objUser.UserName)
        //                {
        //                    userid = u.UserId;
        //                    break;
        //                }

        //            }

                    
        //            bool ispass = r != null && r.Password == objUser.Password;
        //            if (ispass)
        //            {
        //                Session["MyUserId"] = userid;
        //                Session["UserName"] = objUser.UserName.ToString();
        //                return RedirectToAction("Index", "SPA");
        //            }
        //            else
        //            {
        //                return RedirectToAction("Contact", "Home");
        //            }
        //        }
        //        else
        //        {
        //            return RedirectToAction("Contact", "Home");
        //        }
        //    }
        //    else
        //    {
        //        return RedirectToAction("Contact", "Home");
        //    }
        //}
           
        
        //public ActionResult ChangeLanguage(string lang)
        //{
        //    new Language().SetLanguage(lang);
        //    return RedirectToAction("Index", "SPA");
        //}

        //public ActionResult LView()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}
    }
}
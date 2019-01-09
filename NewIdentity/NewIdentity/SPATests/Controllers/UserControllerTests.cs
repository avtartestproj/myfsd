using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewIdentity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPAData;
using System.Web.Mvc;

namespace NewIdentity.Controllers.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //TestControllerBuilder builder = new TestControllerBuilder();
            //  builder.InitializeController(usercontroller);
            var usercontroller = new UserController();
            UserInfoViewModel usp1 = new UserInfoViewModel();
            UserInfo usp = new UserInfo();
           usp.User_ID = 1111;
           usp.FirstName = "Avtar";
            usp.LastName = "Avtar";
            usp.Employee_ID = "777";
            usp.Project_ID = 0;
            usp.Task_ID = 0;
            usp1.Entity = usp;
            var uresult = (ActionResult)usercontroller.Index(usp1);
           var controller = new UserController();
            var result = (ViewResult) controller.Index();
           // Assert.AreEqual("LIST", ((SPAData.UserInfoViewModel)result.Model).EventCommand.ToUpper());
           // Assert.AreNotEqual(0, ((SPAData.UserInfoViewModel)result.Model).Users.Count);
        }
        [TestMethod()]
        public void Index_List_Test()
        {
            var controller = new UserController();
            var result = (ViewResult)controller.Index();
            Assert.AreEqual("LIST", ((SPAData.UserInfoViewModel)result.Model).EventCommand.ToUpper());
            Assert.AreNotEqual(0, ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count);

        }

        [TestMethod()]
        public void User_Save_Test()
        {
            var controller = new UserController();
            UserInfoViewModel vm = new UserInfoViewModel();
            int intialcount = vm.UserProfiles.Count;
            var result = (ViewResult)controller.Index();
            int countbeforeInsert = ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count;
            vm.EventCommand = "save";
            vm.Mode = "Add";
            UserInfo myTestEntity = new UserInfo();
            myTestEntity.FirstName = "Test FirstName";
            myTestEntity.LastName = "Test LastName";
            myTestEntity.Employee_ID = "007";
            myTestEntity.Project_ID= 0;
            myTestEntity.Task_ID = 0;
            vm.Entity = myTestEntity;
            result = (ViewResult)controller.Index(vm);
            Assert.AreEqual(0, intialcount);
            Assert.AreNotEqual(0, countbeforeInsert);
            Assert.AreEqual(countbeforeInsert + 1, ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count);


        }

        [TestMethod()]
        public void User_Update_Test()
        {
            var controller = new UserController();
            UserInfoViewModel vm = new UserInfoViewModel();
            int intialcount = vm.UserProfiles.Count;
            var result = (ViewResult)controller.Index();
            int countbeforeInsert = ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count;
            vm.EventCommand = "save";
            vm.Mode = "Add";
            UserInfo myTestEntity = new UserInfo();
            myTestEntity.FirstName = "Test myFirstName";
            myTestEntity.LastName = "Test Update LastName";
            myTestEntity.Employee_ID = "007";
            myTestEntity.Project_ID = 0;
            myTestEntity.Task_ID = 0;
            vm.Entity = myTestEntity;
            result = (ViewResult)controller.Index(vm);
            Assert.AreEqual(0, intialcount);
            Assert.AreNotEqual(0, countbeforeInsert);
            Assert.AreEqual(countbeforeInsert + 1, ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count);
            List<UserInfo> _products = ((SPAData.UserInfoViewModel)result.Model).UserProfiles;
            UserInfo prod = (UserInfo)_products.First(p => p.FirstName == "Test myFirstName");

            vm.EventCommand = "edit";
            vm.EventArgument = prod.User_ID.ToString();
            vm.Mode = "List";
            vm.Entity = prod;
            //TrainingProduct[] Tp = (List<TrainingProduct>((SPAData.TrainingProductViewModel)result.Model).Products).Items[8]);
            result = (ViewResult)controller.Index(vm);

            UserInfo updateprod = ((SPAData.UserInfoViewModel)result.Model).Entity;
            updateprod.FirstName = "Test myFirstName Edited" + DateTime.Now.ToString();
            myTestEntity.LastName = "Test LastName updated";
            myTestEntity.Employee_ID = "007";
            myTestEntity.Project_ID = 0;
            myTestEntity.Task_ID = 0;
            vm.EventCommand = "save";
            vm.EventArgument = prod.User_ID.ToString();
            vm.Mode = "edit";
            vm.Entity = updateprod;
            result = (ViewResult)controller.Index(vm);

            UserInfo searchE = new UserInfo();
            searchE.FirstName = updateprod.FirstName;
            vm.EventCommand = "search";
            vm.SearchEntity = searchE;
            result = (ViewResult)controller.Index(vm);
            //Assert.AreEqual("LIST", ((SPAData.TrainingProductViewModel)result.Model).EventCommand.ToUpper());
            Assert.AreEqual(1, ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count);

        }

        [TestMethod()]
        public void User_Delete_Test()
        {
            var controller = new UserController();
            UserInfoViewModel vm = new UserInfoViewModel();
            int intialcount = vm.UserProfiles.Count;
            var result = (ViewResult)controller.Index();
            int countbeforeInsert = ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count;
            vm.EventCommand = "save";
            vm.Mode = "Add";
            UserInfo myTestEntity = new UserInfo();
            myTestEntity.FirstName = "Test Name for Deletion" + DateTime.Now.ToString();
            myTestEntity.LastName = "Test LastName updated";
            myTestEntity.Employee_ID = "007";
            myTestEntity.Project_ID = 0;
            myTestEntity.Task_ID = 0;
            vm.Entity = myTestEntity;
            result = (ViewResult)controller.Index(vm);
            Assert.AreEqual(0, intialcount);
            Assert.AreNotEqual(0, countbeforeInsert);
            Assert.AreEqual(countbeforeInsert + 1, ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count);
            List<UserInfo> _products = ((SPAData.UserInfoViewModel)result.Model).UserProfiles;
            UserInfo prod = (UserInfo)_products.First(p => p.FirstName == myTestEntity.FirstName);


            UserInfo searchE = new UserInfo();
            searchE.FirstName = myTestEntity.FirstName;
            vm.EventCommand = "search";
            vm.SearchEntity = searchE;
            result = (ViewResult)controller.Index(vm);
            Assert.AreEqual(1, ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count);

            vm.EventCommand = "delete";
            vm.EventArgument = prod.User_ID.ToString();
            vm.Entity = prod;
            result = (ViewResult)controller.Index(vm);


            searchE.FirstName = myTestEntity.FirstName;
            vm.EventCommand = "search";
            vm.SearchEntity = searchE;
            result = (ViewResult)controller.Index(vm);
            Assert.AreEqual(0, ((SPAData.UserInfoViewModel)result.Model).UserProfiles.Count);

        }
    }
}

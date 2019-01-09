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
    public class ProjectControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            //TestControllerBuilder builder = new TestControllerBuilder();
            //  builder.InitializeController(usercontroller);
            var projcontroller = new ProjectController();
            ProjectInfoViewModel prjVM = new ProjectInfoViewModel();
            ProjectInfo prjInfo = new ProjectInfo();
            prjInfo.Project = "Test Proj";
            prjInfo.StartDate = DateTime.Now;
            prjInfo.EndDate = DateTime.Now.AddDays(1);
            prjInfo.Priority = 1;

            prjVM.Entity = prjInfo;
            var uresult = (ActionResult)projcontroller.Index(prjVM);
            var controller = new ProjectController();
            var result = (ViewResult)controller.Index();
             Assert.AreEqual("LIST", ((SPAData.ProjectInfoViewModel)result.Model).EventCommand.ToUpper());
             Assert.AreNotEqual(0, ((SPAData.ProjectInfoViewModel)result.Model).ProjectsInfo.Count);
        }
        [TestMethod()]
        public void Project_List_Test()
        {
            var controller = new ProjectController();
            var result = (ViewResult)controller.Index();
            Assert.AreEqual("LIST", ((SPAData.ProjectInfoViewModel)result.Model).EventCommand.ToUpper());
            Assert.AreNotEqual(0, ((SPAData.ProjectInfoViewModel)result.Model).ProjectsInfo.Count);

        }

        [TestMethod()]
        public void Project_Save_Test()
        {
            var controller = new ProjectController();
            ProjectInfoViewModel vm = new ProjectInfoViewModel();
            int intialcount = vm.ProjectsInfo.Count;
            var result = (ViewResult)controller.Index();
            int countbeforeInsert = ((SPAData.ProjectInfoViewModel)result.Model).ProjectsInfo.Count;
            vm.EventCommand = "save";
            vm.Mode = "Add";
            ProjectInfo myTestEntity = new ProjectInfo();
            myTestEntity.Project = "Test Proj" + DateTime.Now.ToString();
            myTestEntity.StartDate = DateTime.Now;
            myTestEntity.EndDate = DateTime.Now.AddDays(1);
            myTestEntity.Priority = 1;
            vm.Entity = myTestEntity;
            result = (ViewResult)controller.Index(vm);
            Assert.AreEqual(0, intialcount);
            Assert.AreNotEqual(0, countbeforeInsert);
            Assert.AreEqual(countbeforeInsert + 1, ((SPAData.ProjectInfoViewModel)result.Model).ProjectsInfo.Count);


        }

       
    }
}

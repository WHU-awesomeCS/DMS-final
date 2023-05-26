using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DormitoryManagementSystem.Controllers;
using DormitoryManagementSystem.ViewModel.申请.FrameworkWorkstageVMs;
using DormitoryManagementSystem.Model;
using DormitoryManagementSystem.DataAccess;


namespace DormitoryManagementSystem.Test
{
    [TestClass]
    public class FrameworkWorkstageApiTest
    {
        private FrameworkWorkstageController _controller;
        private string _seed;

        public FrameworkWorkstageApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<FrameworkWorkstageController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new FrameworkWorkstageSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            FrameworkWorkstageVM vm = _controller.Wtm.CreateVM<FrameworkWorkstageVM>();
            FrameworkWorkstage v = new FrameworkWorkstage();
            
            v.ID = 49;
            v.FCode = "0bEJpXfeq98Hksf";
            v.FName = "aM";
            v.FMark = "zGb2LcUG46UZQ";
            v.workstageType = DormitoryManagementSystem.Model.WorkstageType.无;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkWorkstage>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 49);
                Assert.AreEqual(data.FCode, "0bEJpXfeq98Hksf");
                Assert.AreEqual(data.FName, "aM");
                Assert.AreEqual(data.FMark, "zGb2LcUG46UZQ");
                Assert.AreEqual(data.workstageType, DormitoryManagementSystem.Model.WorkstageType.无);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            FrameworkWorkstage v = new FrameworkWorkstage();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 49;
                v.FCode = "0bEJpXfeq98Hksf";
                v.FName = "aM";
                v.FMark = "zGb2LcUG46UZQ";
                v.workstageType = DormitoryManagementSystem.Model.WorkstageType.无;
                context.Set<FrameworkWorkstage>().Add(v);
                context.SaveChanges();
            }

            FrameworkWorkstageVM vm = _controller.Wtm.CreateVM<FrameworkWorkstageVM>();
            var oldID = v.ID;
            v = new FrameworkWorkstage();
            v.ID = oldID;
       		
            v.FCode = "31yGNf1xCjoX1lwGR";
            v.FName = "hbjVhwJ3VyP9FU";
            v.FMark = "qPj8wGxzLXo";
            v.workstageType = DormitoryManagementSystem.Model.WorkstageType.解绑;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.FCode", "");
            vm.FC.Add("Entity.FName", "");
            vm.FC.Add("Entity.FMark", "");
            vm.FC.Add("Entity.workstageType", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkWorkstage>().Find(v.ID);
 				
                Assert.AreEqual(data.FCode, "31yGNf1xCjoX1lwGR");
                Assert.AreEqual(data.FName, "hbjVhwJ3VyP9FU");
                Assert.AreEqual(data.FMark, "qPj8wGxzLXo");
                Assert.AreEqual(data.workstageType, DormitoryManagementSystem.Model.WorkstageType.解绑);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            FrameworkWorkstage v = new FrameworkWorkstage();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 49;
                v.FCode = "0bEJpXfeq98Hksf";
                v.FName = "aM";
                v.FMark = "zGb2LcUG46UZQ";
                v.workstageType = DormitoryManagementSystem.Model.WorkstageType.无;
                context.Set<FrameworkWorkstage>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            FrameworkWorkstage v1 = new FrameworkWorkstage();
            FrameworkWorkstage v2 = new FrameworkWorkstage();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 49;
                v1.FCode = "0bEJpXfeq98Hksf";
                v1.FName = "aM";
                v1.FMark = "zGb2LcUG46UZQ";
                v1.workstageType = DormitoryManagementSystem.Model.WorkstageType.无;
                v2.ID = 70;
                v2.FCode = "31yGNf1xCjoX1lwGR";
                v2.FName = "hbjVhwJ3VyP9FU";
                v2.FMark = "qPj8wGxzLXo";
                v2.workstageType = DormitoryManagementSystem.Model.WorkstageType.解绑;
                context.Set<FrameworkWorkstage>().Add(v1);
                context.Set<FrameworkWorkstage>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<FrameworkWorkstage>().Find(v1.ID);
                var data2 = context.Set<FrameworkWorkstage>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}

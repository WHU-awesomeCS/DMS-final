using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DormitoryManagementSystem.Controllers;
using DormitoryManagementSystem.ViewModel.访客.FrameworkOrderVMs;
using DormitoryManagementSystem.Model;
using DormitoryManagementSystem.DataAccess;


namespace DormitoryManagementSystem.Test
{
    [TestClass]
    public class FrameworkOrderApiTest
    {
        private FrameworkOrderController _controller;
        private string _seed;

        public FrameworkOrderApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<FrameworkOrderController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new FrameworkOrderSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            FrameworkOrderVM vm = _controller.Wtm.CreateVM<FrameworkOrderVM>();
            FrameworkOrder v = new FrameworkOrder();
            
            v.ID = 61;
            v.FProductionCode = "Usc";
            v.FProductItemId = "ONGWpRXjpXos6Vd";
            v.FOrderStatus = DormitoryManagementSystem.Model.FOrderStatus.初始状态;
            v.FPlanNumber = 34;
            v.FPlanTime = DateTime.Parse("2023-07-18 14:23:07");
            v.FFinishTime = DateTime.Parse("2022-03-07 14:23:07");
            v.FOkNumber = 90;
            v.FNgNumber = 2;
            v.FWorkingNumber = 23;
            v.FScrapNumber = 22;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkOrder>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 61);
                Assert.AreEqual(data.FProductionCode, "Usc");
                Assert.AreEqual(data.FProductItemId, "ONGWpRXjpXos6Vd");
                Assert.AreEqual(data.FOrderStatus, DormitoryManagementSystem.Model.FOrderStatus.初始状态);
                Assert.AreEqual(data.FPlanNumber, 34);
                Assert.AreEqual(data.FPlanTime, DateTime.Parse("2023-07-18 14:23:07"));
                Assert.AreEqual(data.FFinishTime, DateTime.Parse("2022-03-07 14:23:07"));
                Assert.AreEqual(data.FOkNumber, 90);
                Assert.AreEqual(data.FNgNumber, 2);
                Assert.AreEqual(data.FWorkingNumber, 23);
                Assert.AreEqual(data.FScrapNumber, 22);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            FrameworkOrder v = new FrameworkOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 61;
                v.FProductionCode = "Usc";
                v.FProductItemId = "ONGWpRXjpXos6Vd";
                v.FOrderStatus = DormitoryManagementSystem.Model.FOrderStatus.初始状态;
                v.FPlanNumber = 34;
                v.FPlanTime = DateTime.Parse("2023-07-18 14:23:07");
                v.FFinishTime = DateTime.Parse("2022-03-07 14:23:07");
                v.FOkNumber = 90;
                v.FNgNumber = 2;
                v.FWorkingNumber = 23;
                v.FScrapNumber = 22;
                context.Set<FrameworkOrder>().Add(v);
                context.SaveChanges();
            }

            FrameworkOrderVM vm = _controller.Wtm.CreateVM<FrameworkOrderVM>();
            var oldID = v.ID;
            v = new FrameworkOrder();
            v.ID = oldID;
       		
            v.FProductionCode = "Xr04d22C1Pfz";
            v.FProductItemId = "Z14I0";
            v.FOrderStatus = DormitoryManagementSystem.Model.FOrderStatus.清料状态;
            v.FPlanNumber = 26;
            v.FPlanTime = DateTime.Parse("2022-08-06 14:23:07");
            v.FFinishTime = DateTime.Parse("2023-06-29 14:23:07");
            v.FOkNumber = 82;
            v.FNgNumber = 25;
            v.FWorkingNumber = 57;
            v.FScrapNumber = 71;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.FProductionCode", "");
            vm.FC.Add("Entity.FProductItemId", "");
            vm.FC.Add("Entity.FOrderStatus", "");
            vm.FC.Add("Entity.FPlanNumber", "");
            vm.FC.Add("Entity.FPlanTime", "");
            vm.FC.Add("Entity.FFinishTime", "");
            vm.FC.Add("Entity.FOkNumber", "");
            vm.FC.Add("Entity.FNgNumber", "");
            vm.FC.Add("Entity.FWorkingNumber", "");
            vm.FC.Add("Entity.FScrapNumber", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkOrder>().Find(v.ID);
 				
                Assert.AreEqual(data.FProductionCode, "Xr04d22C1Pfz");
                Assert.AreEqual(data.FProductItemId, "Z14I0");
                Assert.AreEqual(data.FOrderStatus, DormitoryManagementSystem.Model.FOrderStatus.清料状态);
                Assert.AreEqual(data.FPlanNumber, 26);
                Assert.AreEqual(data.FPlanTime, DateTime.Parse("2022-08-06 14:23:07"));
                Assert.AreEqual(data.FFinishTime, DateTime.Parse("2023-06-29 14:23:07"));
                Assert.AreEqual(data.FOkNumber, 82);
                Assert.AreEqual(data.FNgNumber, 25);
                Assert.AreEqual(data.FWorkingNumber, 57);
                Assert.AreEqual(data.FScrapNumber, 71);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            FrameworkOrder v = new FrameworkOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 61;
                v.FProductionCode = "Usc";
                v.FProductItemId = "ONGWpRXjpXos6Vd";
                v.FOrderStatus = DormitoryManagementSystem.Model.FOrderStatus.初始状态;
                v.FPlanNumber = 34;
                v.FPlanTime = DateTime.Parse("2023-07-18 14:23:07");
                v.FFinishTime = DateTime.Parse("2022-03-07 14:23:07");
                v.FOkNumber = 90;
                v.FNgNumber = 2;
                v.FWorkingNumber = 23;
                v.FScrapNumber = 22;
                context.Set<FrameworkOrder>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            FrameworkOrder v1 = new FrameworkOrder();
            FrameworkOrder v2 = new FrameworkOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 61;
                v1.FProductionCode = "Usc";
                v1.FProductItemId = "ONGWpRXjpXos6Vd";
                v1.FOrderStatus = DormitoryManagementSystem.Model.FOrderStatus.初始状态;
                v1.FPlanNumber = 34;
                v1.FPlanTime = DateTime.Parse("2023-07-18 14:23:07");
                v1.FFinishTime = DateTime.Parse("2022-03-07 14:23:07");
                v1.FOkNumber = 90;
                v1.FNgNumber = 2;
                v1.FWorkingNumber = 23;
                v1.FScrapNumber = 22;
                v2.ID = 89;
                v2.FProductionCode = "Xr04d22C1Pfz";
                v2.FProductItemId = "Z14I0";
                v2.FOrderStatus = DormitoryManagementSystem.Model.FOrderStatus.清料状态;
                v2.FPlanNumber = 26;
                v2.FPlanTime = DateTime.Parse("2022-08-06 14:23:07");
                v2.FFinishTime = DateTime.Parse("2023-06-29 14:23:07");
                v2.FOkNumber = 82;
                v2.FNgNumber = 25;
                v2.FWorkingNumber = 57;
                v2.FScrapNumber = 71;
                context.Set<FrameworkOrder>().Add(v1);
                context.Set<FrameworkOrder>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<FrameworkOrder>().Find(v1.ID);
                var data2 = context.Set<FrameworkOrder>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DormitoryManagementSystem.Controllers;
using DormitoryManagementSystem.ViewModel.申请.FrameworkWorkLineVMs;
using DormitoryManagementSystem.Model;
using DormitoryManagementSystem.DataAccess;


namespace DormitoryManagementSystem.Test
{
    [TestClass]
    public class FrameworkWorkLineApiTest
    {
        private FrameworkWorkLineController _controller;
        private string _seed;

        public FrameworkWorkLineApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<FrameworkWorkLineController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new FrameworkWorkLineSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            FrameworkWorkLineVM vm = _controller.Wtm.CreateVM<FrameworkWorkLineVM>();
            FrameworkWorkLine v = new FrameworkWorkLine();
            
            v.ID = 88;
            v.FCode = "X037eNvx53XRIBerD";
            v.FName = "jwggygqD6";
            v.FMark = "axiifwlSPIHFPPj0BxP";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkWorkLine>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 88);
                Assert.AreEqual(data.FCode, "X037eNvx53XRIBerD");
                Assert.AreEqual(data.FName, "jwggygqD6");
                Assert.AreEqual(data.FMark, "axiifwlSPIHFPPj0BxP");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            FrameworkWorkLine v = new FrameworkWorkLine();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 88;
                v.FCode = "X037eNvx53XRIBerD";
                v.FName = "jwggygqD6";
                v.FMark = "axiifwlSPIHFPPj0BxP";
                context.Set<FrameworkWorkLine>().Add(v);
                context.SaveChanges();
            }

            FrameworkWorkLineVM vm = _controller.Wtm.CreateVM<FrameworkWorkLineVM>();
            var oldID = v.ID;
            v = new FrameworkWorkLine();
            v.ID = oldID;
       		
            v.FCode = "IrPPHLs0drBqBt";
            v.FName = "W4DZB";
            v.FMark = "p6CsxeB8wPk71x32R6d";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.FCode", "");
            vm.FC.Add("Entity.FName", "");
            vm.FC.Add("Entity.FMark", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkWorkLine>().Find(v.ID);
 				
                Assert.AreEqual(data.FCode, "IrPPHLs0drBqBt");
                Assert.AreEqual(data.FName, "W4DZB");
                Assert.AreEqual(data.FMark, "p6CsxeB8wPk71x32R6d");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            FrameworkWorkLine v = new FrameworkWorkLine();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 88;
                v.FCode = "X037eNvx53XRIBerD";
                v.FName = "jwggygqD6";
                v.FMark = "axiifwlSPIHFPPj0BxP";
                context.Set<FrameworkWorkLine>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            FrameworkWorkLine v1 = new FrameworkWorkLine();
            FrameworkWorkLine v2 = new FrameworkWorkLine();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 88;
                v1.FCode = "X037eNvx53XRIBerD";
                v1.FName = "jwggygqD6";
                v1.FMark = "axiifwlSPIHFPPj0BxP";
                v2.ID = 1;
                v2.FCode = "IrPPHLs0drBqBt";
                v2.FName = "W4DZB";
                v2.FMark = "p6CsxeB8wPk71x32R6d";
                context.Set<FrameworkWorkLine>().Add(v1);
                context.Set<FrameworkWorkLine>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<FrameworkWorkLine>().Find(v1.ID);
                var data2 = context.Set<FrameworkWorkLine>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}

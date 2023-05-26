using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DormitoryManagementSystem.Controllers;
using DormitoryManagementSystem.ViewModel.查询.FrameworkProductTypeVMs;
using DormitoryManagementSystem.Model;
using DormitoryManagementSystem.DataAccess;


namespace DormitoryManagementSystem.Test
{
    [TestClass]
    public class FrameworkProductTypeApiTest
    {
        private FrameworkProductTypeController _controller;
        private string _seed;

        public FrameworkProductTypeApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<FrameworkProductTypeController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new FrameworkProductTypeSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            FrameworkProductTypeVM vm = _controller.Wtm.CreateVM<FrameworkProductTypeVM>();
            FrameworkProductType v = new FrameworkProductType();
            
            v.ID = 69;
            v.FName = "3QX";
            v.FCode = "yOF6U";
            v.FMark = "BQ9tjXUAp2E";
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkProductType>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 69);
                Assert.AreEqual(data.FName, "3QX");
                Assert.AreEqual(data.FCode, "yOF6U");
                Assert.AreEqual(data.FMark, "BQ9tjXUAp2E");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            FrameworkProductType v = new FrameworkProductType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 69;
                v.FName = "3QX";
                v.FCode = "yOF6U";
                v.FMark = "BQ9tjXUAp2E";
                context.Set<FrameworkProductType>().Add(v);
                context.SaveChanges();
            }

            FrameworkProductTypeVM vm = _controller.Wtm.CreateVM<FrameworkProductTypeVM>();
            var oldID = v.ID;
            v = new FrameworkProductType();
            v.ID = oldID;
       		
            v.FName = "q";
            v.FCode = "w7psD6DzwtfX0";
            v.FMark = "SJi8sC3qOW9nlop57";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.FName", "");
            vm.FC.Add("Entity.FCode", "");
            vm.FC.Add("Entity.FMark", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkProductType>().Find(v.ID);
 				
                Assert.AreEqual(data.FName, "q");
                Assert.AreEqual(data.FCode, "w7psD6DzwtfX0");
                Assert.AreEqual(data.FMark, "SJi8sC3qOW9nlop57");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            FrameworkProductType v = new FrameworkProductType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 69;
                v.FName = "3QX";
                v.FCode = "yOF6U";
                v.FMark = "BQ9tjXUAp2E";
                context.Set<FrameworkProductType>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            FrameworkProductType v1 = new FrameworkProductType();
            FrameworkProductType v2 = new FrameworkProductType();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 69;
                v1.FName = "3QX";
                v1.FCode = "yOF6U";
                v1.FMark = "BQ9tjXUAp2E";
                v2.ID = 57;
                v2.FName = "q";
                v2.FCode = "w7psD6DzwtfX0";
                v2.FMark = "SJi8sC3qOW9nlop57";
                context.Set<FrameworkProductType>().Add(v1);
                context.Set<FrameworkProductType>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<FrameworkProductType>().Find(v1.ID);
                var data2 = context.Set<FrameworkProductType>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}

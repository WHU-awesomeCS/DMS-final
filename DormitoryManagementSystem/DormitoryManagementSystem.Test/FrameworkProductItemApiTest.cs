using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using DormitoryManagementSystem.Controllers;
using DormitoryManagementSystem.ViewModel.查询.FrameworkProductItemVMs;
using DormitoryManagementSystem.Model;
using DormitoryManagementSystem.DataAccess;


namespace DormitoryManagementSystem.Test
{
    [TestClass]
    public class FrameworkProductItemApiTest
    {
        private FrameworkProductItemController _controller;
        private string _seed;

        public FrameworkProductItemApiTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateApi<FrameworkProductItemController>(new DataContext(_seed, DBTypeEnum.Memory), "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            ContentResult rv = _controller.Search(new FrameworkProductItemSearcher()) as ContentResult;
            Assert.IsTrue(string.IsNullOrEmpty(rv.Content)==false);
        }

        [TestMethod]
        public void CreateTest()
        {
            FrameworkProductItemVM vm = _controller.Wtm.CreateVM<FrameworkProductItemVM>();
            FrameworkProductItem v = new FrameworkProductItem();
            
            v.ID = 68;
            v.FName = "aPsjdo43cNyyxrsM";
            v.FCode = "qLCeTZwDjUfA7WJ";
            v.FProductTypeId = 12;
            v.FWorkLineId = 45;
            vm.Entity = v;
            var rv = _controller.Add(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkProductItem>().Find(v.ID);
                
                Assert.AreEqual(data.ID, 68);
                Assert.AreEqual(data.FName, "aPsjdo43cNyyxrsM");
                Assert.AreEqual(data.FCode, "qLCeTZwDjUfA7WJ");
                Assert.AreEqual(data.FProductTypeId, 12);
                Assert.AreEqual(data.FWorkLineId, 45);
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }
        }

        [TestMethod]
        public void EditTest()
        {
            FrameworkProductItem v = new FrameworkProductItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 68;
                v.FName = "aPsjdo43cNyyxrsM";
                v.FCode = "qLCeTZwDjUfA7WJ";
                v.FProductTypeId = 12;
                v.FWorkLineId = 45;
                context.Set<FrameworkProductItem>().Add(v);
                context.SaveChanges();
            }

            FrameworkProductItemVM vm = _controller.Wtm.CreateVM<FrameworkProductItemVM>();
            var oldID = v.ID;
            v = new FrameworkProductItem();
            v.ID = oldID;
       		
            v.FName = "kL";
            v.FCode = "hqi2rhPdk9";
            v.FProductTypeId = 13;
            v.FWorkLineId = 15;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.FName", "");
            vm.FC.Add("Entity.FCode", "");
            vm.FC.Add("Entity.FProductTypeId", "");
            vm.FC.Add("Entity.FWorkLineId", "");
            var rv = _controller.Edit(vm);
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<FrameworkProductItem>().Find(v.ID);
 				
                Assert.AreEqual(data.FName, "kL");
                Assert.AreEqual(data.FCode, "hqi2rhPdk9");
                Assert.AreEqual(data.FProductTypeId, 13);
                Assert.AreEqual(data.FWorkLineId, 15);
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }

		[TestMethod]
        public void GetTest()
        {
            FrameworkProductItem v = new FrameworkProductItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 68;
                v.FName = "aPsjdo43cNyyxrsM";
                v.FCode = "qLCeTZwDjUfA7WJ";
                v.FProductTypeId = 12;
                v.FWorkLineId = 45;
                context.Set<FrameworkProductItem>().Add(v);
                context.SaveChanges();
            }
            var rv = _controller.Get(v.ID.ToString());
            Assert.IsNotNull(rv);
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            FrameworkProductItem v1 = new FrameworkProductItem();
            FrameworkProductItem v2 = new FrameworkProductItem();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 68;
                v1.FName = "aPsjdo43cNyyxrsM";
                v1.FCode = "qLCeTZwDjUfA7WJ";
                v1.FProductTypeId = 12;
                v1.FWorkLineId = 45;
                v2.ID = 20;
                v2.FName = "kL";
                v2.FCode = "hqi2rhPdk9";
                v2.FProductTypeId = 13;
                v2.FWorkLineId = 15;
                context.Set<FrameworkProductItem>().Add(v1);
                context.Set<FrameworkProductItem>().Add(v2);
                context.SaveChanges();
            }

            var rv = _controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv, typeof(OkObjectResult));

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data1 = context.Set<FrameworkProductItem>().Find(v1.ID);
                var data2 = context.Set<FrameworkProductItem>().Find(v2.ID);
                Assert.AreEqual(data1, null);
            Assert.AreEqual(data2, null);
            }

            rv = _controller.BatchDelete(new string[] {});
            Assert.IsInstanceOfType(rv, typeof(OkResult));

        }


    }
}

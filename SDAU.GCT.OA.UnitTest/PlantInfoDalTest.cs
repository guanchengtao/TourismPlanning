using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SDAU.GCT.OA.DAL;
using SDAU.GCT.OA.Model;
using SDAU.GCT.OA.UI.Portal.Controllers;

namespace SDAU.GCT.OA.UnitTest
{
    [TestClass]
    public class PlantInfoDalTest
    {
        [TestMethod]
        public void TestGetPlants()
        {
            //测试环境
            PlantInfoDal dal = new PlantInfoDal();
            var temp = dal.GetEntities(u => true).ToDictionary(x => x.Id, x => x.PlantName);

        }

        [TestMethod]
        public void TestGetPlants1()
        {
            using (Model1Container context = new Model1Container())
            {
                var temp = context.PlantInfo.Where(u => u.DelFlag == 1);
                foreach (var item in temp)
                {
                    Console.WriteLine(item);
                }
            }
        }
        [TestMethod]
        public void TestGetPlants2()
        {
            using (Model1Container context = new Model1Container())
            {
                var temp = context.ActionInfo.Where(u => u.DelFlag == 1).AsEnumerable();
            }

        }

        [TestMethod]
        public void TestAddPlant()
        {
            using (Model1Container context = new Model1Container())
            {
                var plantInfos = new List<PlantInfo>(){};
                for (int i = 0; i < 100; i++)
                {
                    var PlantInfo = new PlantInfo()
                    {
                        PlantName = $"{i}{i}{i}",
                        JingDu = $"{i}",
                        WeiDu = $"{i}",
                        PlantDetail = Guid.NewGuid().ToString().Substring(0, 10),
                        Xiaoqu = Guid.NewGuid().ToString().Substring(0,10),
                        DelFlag = 1,
                        SubTime = DateTime.Now
                    };
                    Thread.Sleep(100);
                    plantInfos.Add(PlantInfo);
                }
                try
                {
                    context.PlantInfo.AddRange(plantInfos);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
          
        }

        [TestMethod]
        public void TestDelPlant()
        {
            new PlantInfoDal().DeleteSingle(3);
        }

        [TestMethod]
        public void TestUpdatePlant()
        {
            PlantInfo oldUser = new PlantInfoDal().GetEntities(u => u.Id == 3).FirstOrDefault();
            //查出来一个旧的权限实体，直接在上面修改
            //oldUser.UserName = ActionInfo.UserName;
            //oldUser.UserPwd = ActionInfo.UserPwd;
            oldUser.DelFlag = 0;
            bool updateflag = new PlantInfoDal().Update(oldUser);
        }


    }
}

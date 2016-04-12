using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using BusinessLogic.Layer.ManagerObjects;
using BusinessLogic.Layer.BusinessObjects;
using BusinessLogic.Layer.Base;

namespace BusinessLogic.Layer.UnitTests
{
	[TestFixture]
    public partial class MajorTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetMajorManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IMajorManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Major CreateNewMajor()
		{
			BusinessLogic.Layer.BusinessObjects.Major entity = new BusinessLogic.Layer.BusinessObjects.Major();
			
			
			entity.MajorMember = "Test Test ";
			entity.Level = "Test Test T";
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Major GetFirstMajor()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Major> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Major entity = CreateNewMajor();
				
                object result = manager.Save(entity);

                Assert.IsNotNull(result);
            }
            catch(Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Read()
        {
            try
            {
                BusinessLogic.Layer.BusinessObjects.Major entityA = CreateNewMajor();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Major entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA, entityB);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
		[Test]
		public void Update()
        {
            try
            {
                BusinessLogic.Layer.BusinessObjects.Major entityA = GetFirstMajor();
				
				entityA.MajorMember = "Test Test ";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Major entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.MajorMember, entityB.MajorMember);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
        [Test]
        public void Delete()
        {
            try
            {
                BusinessLogic.Layer.BusinessObjects.Major entity = GetFirstMajor();
				
                manager.Delete(entity);

                entity = manager.GetById(entity.Id);
                Assert.IsNull(entity);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
	}
}


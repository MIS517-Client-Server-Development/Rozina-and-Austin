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
    public partial class AdminTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetAdminManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IAdminManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Admin CreateNewAdmin()
		{
			BusinessLogic.Layer.BusinessObjects.Admin entity = new BusinessLogic.Layer.BusinessObjects.Admin();
			
			
			entity.Firstname = "Test Test Test Tes";
			entity.Lastname = "Test Tes";
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Admin GetFirstAdmin()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Admin> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Admin entity = CreateNewAdmin();
				
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
                BusinessLogic.Layer.BusinessObjects.Admin entityA = CreateNewAdmin();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Admin entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Admin entityA = GetFirstAdmin();
				
				entityA.Firstname = "Te";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Admin entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.Firstname, entityB.Firstname);
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
                BusinessLogic.Layer.BusinessObjects.Admin entity = GetFirstAdmin();
				
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


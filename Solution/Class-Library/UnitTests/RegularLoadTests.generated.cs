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
    public partial class RegularLoadTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetRegularLoadManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IRegularLoadManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.RegularLoad CreateNewRegularLoad()
		{
			BusinessLogic.Layer.BusinessObjects.RegularLoad entity = new BusinessLogic.Layer.BusinessObjects.RegularLoad();
			
			
			entity.ProgramID = 22;
			entity.MajorID = 62;
			entity.Year = 85;
			entity.Semester = "Test Test Test Test Test Test Test ";
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.RegularLoad GetFirstRegularLoad()
        {
            IList<BusinessLogic.Layer.BusinessObjects.RegularLoad> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.RegularLoad entity = CreateNewRegularLoad();
				
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
                BusinessLogic.Layer.BusinessObjects.RegularLoad entityA = CreateNewRegularLoad();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.RegularLoad entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.RegularLoad entityA = GetFirstRegularLoad();
				
				entityA.ProgramID = 90;
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.RegularLoad entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.ProgramID, entityB.ProgramID);
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
                BusinessLogic.Layer.BusinessObjects.RegularLoad entity = GetFirstRegularLoad();
				
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


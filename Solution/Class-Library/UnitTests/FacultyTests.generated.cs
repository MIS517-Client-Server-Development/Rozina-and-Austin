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
    public partial class FacultyTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetFacultyManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IFacultyManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Faculty CreateNewFaculty()
		{
			BusinessLogic.Layer.BusinessObjects.Faculty entity = new BusinessLogic.Layer.BusinessObjects.Faculty();
			
			
			entity.Firstname = "Tes";
			entity.Lastname = "Test Test Test ";
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Faculty GetFirstFaculty()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Faculty> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Faculty entity = CreateNewFaculty();
				
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
                BusinessLogic.Layer.BusinessObjects.Faculty entityA = CreateNewFaculty();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Faculty entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Faculty entityA = GetFirstFaculty();
				
				entityA.Firstname = "Test Test Test";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Faculty entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Faculty entity = GetFirstFaculty();
				
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


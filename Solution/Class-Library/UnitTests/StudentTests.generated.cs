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
    public partial class StudentTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetStudentManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IStudentManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Student CreateNewStudent()
		{
			BusinessLogic.Layer.BusinessObjects.Student entity = new BusinessLogic.Layer.BusinessObjects.Student();
			
			
			entity.LastName = "Test Test Test Test Test Test Test Test Tes";
			entity.FirstName = "Test Test Test Test Test Tes";
			entity.MiddleName = "Test Test Test Test Test Test Test Tes";
			entity.Gender = "Tes";
			entity.Address = "Test Test ";
			entity.ParentGuardian = "Test Test Test Tes";
			entity.DateofBirth = System.DateTime.Now;
			entity.PlaceofBirth = "Test Test ";
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Student GetFirstStudent()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Student> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Student entity = CreateNewStudent();
				
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
                BusinessLogic.Layer.BusinessObjects.Student entityA = CreateNewStudent();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Student entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Student entityA = GetFirstStudent();
				
				entityA.LastName = "Test Test Test Test Test Test ";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Student entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.LastName, entityB.LastName);
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
                BusinessLogic.Layer.BusinessObjects.Student entity = GetFirstStudent();
				
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


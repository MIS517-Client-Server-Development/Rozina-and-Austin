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
    public partial class AccountTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetAccountManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IAccountManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Account CreateNewAccount()
		{
			BusinessLogic.Layer.BusinessObjects.Account entity = new BusinessLogic.Layer.BusinessObjects.Account();
			
			// You may need to maually enter this key if there is a constraint violation.
			entity.Id = "Test Test Test ";
			
			entity.Password = "Test Te";
			
			using(BusinessLogic.Layer.ManagerObjects.IAdminManager adminManager = managerFactory.GetAdminManager())
			    entity.Admin = adminManager.GetAll(1)[0];
			
			using(BusinessLogic.Layer.ManagerObjects.IFacultyManager facultyManager = managerFactory.GetFacultyManager())
			    entity.Faculty = facultyManager.GetAll(1)[0];
			
			using(BusinessLogic.Layer.ManagerObjects.IStudentManager studentManager = managerFactory.GetStudentManager())
			    entity.Student = studentManager.GetAll(1)[0];
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Account GetFirstAccount()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Account> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Account entity = CreateNewAccount();
				
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
                BusinessLogic.Layer.BusinessObjects.Account entityA = CreateNewAccount();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Account entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Account entityA = GetFirstAccount();
				
				entityA.Password = "Test Test";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Account entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.Password, entityB.Password);
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
                BusinessLogic.Layer.BusinessObjects.Account entity = GetFirstAccount();
				
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


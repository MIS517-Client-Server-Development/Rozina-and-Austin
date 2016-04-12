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
    public partial class SchYrSemTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetSchYrSemManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.ISchYrSemManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.SchYrSem CreateNewSchYrSem()
		{
			BusinessLogic.Layer.BusinessObjects.SchYrSem entity = new BusinessLogic.Layer.BusinessObjects.SchYrSem();
			
			
			entity.SchYr = "Test Test Test Test Test Test Test Test Test T";
			entity.Sem = "Test Test Te";
			entity.Year = "Test Test Test Test Test Test Te";
			entity.Section = "Test Test Test Test ";
			entity.Override = "Test Test Tes";
			entity.Regular = true;
			entity.Enrolled = true;
			entity.ProgramAlias = 95;
			entity.Remarks = "Test Test ";
			
			using(BusinessLogic.Layer.ManagerObjects.IMajorManager majorManager = managerFactory.GetMajorManager())
			    entity.Major = majorManager.GetAll(1)[0];
			
			using(BusinessLogic.Layer.ManagerObjects.IProgramManager programManager = managerFactory.GetProgramManager())
			    entity.Program = programManager.GetAll(1)[0];
			
			using(BusinessLogic.Layer.ManagerObjects.IStudentManager studentManager = managerFactory.GetStudentManager())
			    entity.Student = studentManager.GetAll(1)[0];
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.SchYrSem GetFirstSchYrSem()
        {
            IList<BusinessLogic.Layer.BusinessObjects.SchYrSem> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.SchYrSem entity = CreateNewSchYrSem();
				
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
                BusinessLogic.Layer.BusinessObjects.SchYrSem entityA = CreateNewSchYrSem();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.SchYrSem entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.SchYrSem entityA = GetFirstSchYrSem();
				
				entityA.SchYr = "Test Test Test";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.SchYrSem entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.SchYr, entityB.SchYr);
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
                BusinessLogic.Layer.BusinessObjects.SchYrSem entity = GetFirstSchYrSem();
				
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


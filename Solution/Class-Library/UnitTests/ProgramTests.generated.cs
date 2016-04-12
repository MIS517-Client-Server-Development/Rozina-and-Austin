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
    public partial class ProgramTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetProgramManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IProgramManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Program CreateNewProgram()
		{
			BusinessLogic.Layer.BusinessObjects.Program entity = new BusinessLogic.Layer.BusinessObjects.Program();
			
			
			entity.ProgramTitle = "Test Test Test Test Test Test Te";
			entity.ProgramDesc = "Test Test Test Test Test Test Test Test Test T";
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Program GetFirstProgram()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Program> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Program entity = CreateNewProgram();
				
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
                BusinessLogic.Layer.BusinessObjects.Program entityA = CreateNewProgram();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Program entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Program entityA = GetFirstProgram();
				
				entityA.ProgramTitle = "Test Test Test Test T";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Program entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.ProgramTitle, entityB.ProgramTitle);
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
                BusinessLogic.Layer.BusinessObjects.Program entity = GetFirstProgram();
				
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


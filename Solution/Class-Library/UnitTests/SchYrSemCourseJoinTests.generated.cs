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
    public partial class SchYrSemCourseJoinTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetSchYrSemCourseJoinManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.ISchYrSemCourseJoinManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin CreateNewSchYrSemCourseJoin()
		{
			BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin entity = new BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin();
			
			
			entity.CourseID = 65;
			entity.Annotation = "Test Test ";
			entity.MidTerm = default(Double);
			entity.EndTerm = default(Double);
			entity.Final = default(Double);
			entity.ProgramID = 86;
			entity.Year = "Test";
			entity.Section = "Test Test Test Test Test Test Test Test Tes";
			
			using(BusinessLogic.Layer.ManagerObjects.ISchYrSemManager schYrSemManager = managerFactory.GetSchYrSemManager())
			    entity.SchYrSem = schYrSemManager.GetAll(1)[0];
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin GetFirstSchYrSemCourseJoin()
        {
            IList<BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin entity = CreateNewSchYrSemCourseJoin();
				
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
                BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin entityA = CreateNewSchYrSemCourseJoin();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin entityA = GetFirstSchYrSemCourseJoin();
				
				entityA.CourseID = 18;
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.CourseID, entityB.CourseID);
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
                BusinessLogic.Layer.BusinessObjects.SchYrSemCourseJoin entity = GetFirstSchYrSemCourseJoin();
				
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


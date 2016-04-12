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
    public partial class CourseTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetCourseManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.ICourseManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Course CreateNewCourse()
		{
			BusinessLogic.Layer.BusinessObjects.Course entity = new BusinessLogic.Layer.BusinessObjects.Course();
			
			
			entity.CourseCode = "Test Test Test Tes";
			entity.CourseTitle = "Test Test ";
			entity.CourseDesc = "Test Test Test Test Test Test Test Test Te";
			entity.Unit = default(Double);
			entity.HoursWeek = 27;
			entity.Program = "T";
			entity.PreRequesite = 49;
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Course GetFirstCourse()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Course> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Course entity = CreateNewCourse();
				
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
                BusinessLogic.Layer.BusinessObjects.Course entityA = CreateNewCourse();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Course entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Course entityA = GetFirstCourse();
				
				entityA.CourseCode = "Te";
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Course entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.CourseCode, entityB.CourseCode);
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
                BusinessLogic.Layer.BusinessObjects.Course entity = GetFirstCourse();
				
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


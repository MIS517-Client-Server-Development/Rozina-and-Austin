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
    public partial class GradeTests : UnitTestbase
    {
        [SetUp]
        public void SetUp()
        {
            manager = managerFactory.GetGradeManager();
            manager.Session.BeginTransaction();
        }

        [TearDown]
        public void TearDown()
        {
            manager.Session.RollbackTransaction();
            manager.Dispose();
        }
        
        protected BusinessLogic.Layer.ManagerObjects.IGradeManager manager;
		
		protected BusinessLogic.Layer.BusinessObjects.Grade CreateNewGrade()
		{
			BusinessLogic.Layer.BusinessObjects.Grade entity = new BusinessLogic.Layer.BusinessObjects.Grade();
			
			
			entity.GradeMember = default(Double);
			
			using(BusinessLogic.Layer.ManagerObjects.ICourseManager courseManager = managerFactory.GetCourseManager())
			    entity.Course = courseManager.GetAll(1)[0];
			
			using(BusinessLogic.Layer.ManagerObjects.IFacultyManager facultyManager = managerFactory.GetFacultyManager())
			    entity.Faculty = facultyManager.GetAll(1)[0];
			
			using(BusinessLogic.Layer.ManagerObjects.IStudentManager studentManager = managerFactory.GetStudentManager())
			    entity.Student = studentManager.GetAll(1)[0];
			
			return entity;
		}
		protected BusinessLogic.Layer.BusinessObjects.Grade GetFirstGrade()
        {
            IList<BusinessLogic.Layer.BusinessObjects.Grade> entityList = manager.GetAll(1);
            if (entityList.Count == 0)
                Assert.Fail("All tables must have at least one row for unit tests to succeed.");
            return entityList[0];
        }
		
		[Test]
        public void Create()
        {
            try
            {
				BusinessLogic.Layer.BusinessObjects.Grade entity = CreateNewGrade();
				
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
                BusinessLogic.Layer.BusinessObjects.Grade entityA = CreateNewGrade();
				manager.Save(entityA);

                BusinessLogic.Layer.BusinessObjects.Grade entityB = manager.GetById(entityA.Id);

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
                BusinessLogic.Layer.BusinessObjects.Grade entityA = GetFirstGrade();
				
				entityA.GradeMember = default(Double);
				
				manager.Update(entityA);

                BusinessLogic.Layer.BusinessObjects.Grade entityB = manager.GetById(entityA.Id);

                Assert.AreEqual(entityA.GradeMember, entityB.GradeMember);
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
                BusinessLogic.Layer.BusinessObjects.Grade entity = GetFirstGrade();
				
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


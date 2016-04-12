using System;
using System.Collections.Generic;
using System.Text;

using BusinessLogic.Layer.Base;

namespace BusinessLogic.Layer.ManagerObjects
{
    public interface IManagerFactory
    {
		// Get Methods
		IAccountManager GetAccountManager();
		IAccountManager GetAccountManager(INHibernateSession session);
		IAdminManager GetAdminManager();
		IAdminManager GetAdminManager(INHibernateSession session);
		ICourseManager GetCourseManager();
		ICourseManager GetCourseManager(INHibernateSession session);
		IFacultyManager GetFacultyManager();
		IFacultyManager GetFacultyManager(INHibernateSession session);
		IGradeManager GetGradeManager();
		IGradeManager GetGradeManager(INHibernateSession session);
		IMajorManager GetMajorManager();
		IMajorManager GetMajorManager(INHibernateSession session);
		IProgramManager GetProgramManager();
		IProgramManager GetProgramManager(INHibernateSession session);
		IRegularLoadManager GetRegularLoadManager();
		IRegularLoadManager GetRegularLoadManager(INHibernateSession session);
		ISchYrSemManager GetSchYrSemManager();
		ISchYrSemManager GetSchYrSemManager(INHibernateSession session);
		ISchYrSemCourseJoinManager GetSchYrSemCourseJoinManager();
		ISchYrSemCourseJoinManager GetSchYrSemCourseJoinManager(INHibernateSession session);
		IStudentManager GetStudentManager();
		IStudentManager GetStudentManager(INHibernateSession session);
    }

    public class ManagerFactory : IManagerFactory
    {
        #region Constructors

        public ManagerFactory()
        {
        }

        #endregion

        #region Get Methods

		public IAccountManager GetAccountManager()
        {
            return new AccountManager();
        }
		public IAccountManager GetAccountManager(INHibernateSession session)
        {
            return new AccountManager(session);
        }
		public IAdminManager GetAdminManager()
        {
            return new AdminManager();
        }
		public IAdminManager GetAdminManager(INHibernateSession session)
        {
            return new AdminManager(session);
        }
		public ICourseManager GetCourseManager()
        {
            return new CourseManager();
        }
		public ICourseManager GetCourseManager(INHibernateSession session)
        {
            return new CourseManager(session);
        }
		public IFacultyManager GetFacultyManager()
        {
            return new FacultyManager();
        }
		public IFacultyManager GetFacultyManager(INHibernateSession session)
        {
            return new FacultyManager(session);
        }
		public IGradeManager GetGradeManager()
        {
            return new GradeManager();
        }
		public IGradeManager GetGradeManager(INHibernateSession session)
        {
            return new GradeManager(session);
        }
		public IMajorManager GetMajorManager()
        {
            return new MajorManager();
        }
		public IMajorManager GetMajorManager(INHibernateSession session)
        {
            return new MajorManager(session);
        }
		public IProgramManager GetProgramManager()
        {
            return new ProgramManager();
        }
		public IProgramManager GetProgramManager(INHibernateSession session)
        {
            return new ProgramManager(session);
        }
		public IRegularLoadManager GetRegularLoadManager()
        {
            return new RegularLoadManager();
        }
		public IRegularLoadManager GetRegularLoadManager(INHibernateSession session)
        {
            return new RegularLoadManager(session);
        }
		public ISchYrSemManager GetSchYrSemManager()
        {
            return new SchYrSemManager();
        }
		public ISchYrSemManager GetSchYrSemManager(INHibernateSession session)
        {
            return new SchYrSemManager(session);
        }
		public ISchYrSemCourseJoinManager GetSchYrSemCourseJoinManager()
        {
            return new SchYrSemCourseJoinManager();
        }
		public ISchYrSemCourseJoinManager GetSchYrSemCourseJoinManager(INHibernateSession session)
        {
            return new SchYrSemCourseJoinManager(session);
        }
		public IStudentManager GetStudentManager()
        {
            return new StudentManager();
        }
		public IStudentManager GetStudentManager(INHibernateSession session)
        {
            return new StudentManager(session);
        }
        
        #endregion
    }
}

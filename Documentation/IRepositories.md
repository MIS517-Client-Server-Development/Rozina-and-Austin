LOCATION
========

Solution Folder: IREPOSITORY

----


IAdminRepository
================

    public interface IAdminRepository
    {
        Admin GetAdminInfo(int adminId, ref List<string> errors);

        void UpdateAdminInfo(Admin admin, ref List<string> errors);
    }



IAuthorizeRepository
====================

    public interface IAuthorizeRepository
    {
        Logon Authenticate(string email, string password, ref List<string> errors);
    }


ICourseRepository
=================

    public interface ICourseRepository
    {
        List<Course> GetCourseList(ref List<string> errors);

        Course GetCourse(int id, ref List<string> errors);

        void InsertCourse(Course c, ref List<string> errors);

        void UpdateCourse(Course c, ref List<string> errors);

        void DeleteCourse(int id, ref List<string> errors);

        void UpdatePreReq(int id, string prereq, ref List<string> errors);
    }



IEnrollmentRepository
=======================

    public interface IEnrollmentRepository
    {
        List<Enrollment> GetEnrollmentList(int student_id,ref List<string> errors);

        void InsertEnrollment(Enrollment e, ref List<string> errors);

        void DeleteEnrollment(int student_id, int schedule_id, ref List<string> errors);

    }



IScheduleRepository
===================

    public interface IScheduleRepository
    {
        List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors);
    }




IStudentRepository
==================

    public interface IStudentRepository
    {
        void InsertStudent(Student student, ref List<string> errors);

        void UpdateStudent(Student student, ref List<string> errors);

        void DeleteStudent(string id, ref List<string> errors);

        Student GetStudentDetail(string id, ref List<string> errors);

        List<Student> GetStudentList(ref List<string> errors);

        void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors);

        void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors);

        List<Enrollment> GetEnrollments(string studentId, ref List<string> errors);
    }




















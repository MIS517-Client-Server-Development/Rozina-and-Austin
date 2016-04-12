WEB APPLICATION DOCUMENTATION
=============================

---

---

# MODELS

---

---

TEAM MEMBERS: ROZINA AND AUSTIN
-------------------------------

**LOCATION:** ApplicationLayer/Models



Admin Class (Admin.cs)
----------------------


    public class Admin
    {
        public int AdminId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }


Course Class (Course.cs)
------------------------


    public class Course
    {
        public int CourseId { get; set; }

		public string CourseNumber { get; set; }

        public string CourseTitle { get; set; }

        public string Description { get; set; }

        public string prereq { get; set; }

        public int unit { get; set; }

        

        public override string ToString()
        {
            return this.CourseId + "-" +  this.CourseTitle + 
			"-" + this.Description + "-" + this.prereq + "-" + this.unit;
        }
    }




Instructor To Course Class (Instructor_To_Course.cs)
------------------------------------------------

	public class Instructor_To_Course
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public int InstructorId { get; set; }
        

        public override string ToString()
        {
            return this.CourseId + "-" +  this.CourseTitle + 
			"-" + this.InstructorId;
        }
    }


Student To Course Class (Student_To_Course.cs)
----------------------------------------------

	public class Student_To_Course
    {
        public int CourseId { get; set; }

        public string CourseTitle { get; set; }

        public int StudentId { get; set; }
        

        public override string ToString()
        {
            return this.CourseId + "-" +  this.CourseTitle + 
			"-" + this.InstructorId;
        }
    }






Enrollment Class (Enrollment.cs)
--------------------------------


    public class Enrollment
    {
        public string StudentId { get; set; }

        public int ScheduleId { get; set; }

    }



Logon Class (Logon.cs)
----------------------


    public class Logon
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Id { get; set; }

        public string Role { get; set; }

        public override string ToString()
        {
            return this.UserName + "-" + this.Id + "-" + this.Role;
        }
    }



Schedule Class (Schedule.cs)
----------------------------


    public class Schedule
    {
        public int ScheduleId { get; set; }

        public string Year { get; set; }

        public string Quarter { get; set; }

        public string Session { get; set; }

        public string Course { get; set; }

        public override string ToString()
        {
            return this.ScheduleId + "-" 
			+ this.Year + "-" + this.Quarter + 
			+ "-" + this.Session + "-" + this.Course;
        }
    }



Student Class (Student.cs)
--------------------------


    public class Student
    {
        public string StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Schedule> Enrolled { get; set; }

        public override string ToString()
        {
            return this.StudentId + "-"
                + this.FirstName + "-"
                + this.LastName + "-"
                + this.Email + "-"
                + this.Password + "-";
        }
    }


Instructor Class (Instructor.cs)
--------------------------------

	public class Instructor
    {
        public string InstructorId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public override string ToString()
        {
            return this.InstructorId + "-"
                + this.FirstName + "-"
                + this.LastName + "-"
                + this.Email + "-"
                + this.Password + "-";
        }
    }
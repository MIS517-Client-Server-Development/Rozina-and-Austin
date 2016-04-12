LOCATION
========

Solution Folder: 

----

Admin Repository
================

	public class AdminRepository : BaseRepository, IAdminRepository
    {
        private const string update = "update_Admin";
        private const string get = "get_Admin";

        public void UpdateAdminInfo(Admin a, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(update, conn);

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 10));
               




                adapter.SelectCommand.Parameters["@admin_id"].Value = a.Id;
                adapter.SelectCommand.Parameters["@first_name"].Value = a.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = a.LastName;
               
              



                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);


            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public Admin GetAdminInfo(int a_id, ref List<string> errors)
        {
           
            var conn = new SqlConnection(ConnectionString);
            Admin admin = null;

            try
            {
                var adapter = new SqlDataAdapter(get, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@admin_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@admin_id"].Value = a_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                admin = new Admin
                              {
                                  Id = Convert.ToInt32(dataSet.Tables[0].Rows[0]["admin_id"].ToString()),
                                  FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString(),
                                  LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString(),
                               
                                  Email = dataSet.Tables[0].Rows[0]["email"].ToString(),
                                  Password = dataSet.Tables[0].Rows[0]["password"].ToString(),
                              
                              };
            
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return admin;
        
        }


    }



----


Authorize Repository
================

 	public class AuthorizeRepository : BaseRepository, IAuthorizeRepository
    {
        private const string GetLoginInfoProcedure = "spGetLoginInfo";

       public Logon Authenticate(string email, string password, ref List<string> errors)
        {
            var logon = new Logon { Id = string.Empty, Role = "invalid" };

            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(GetLoginInfoProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));

                adapter.SelectCommand.Parameters["@email"].Value = email;
                adapter.SelectCommand.Parameters["@password"].Value = password;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count > 0)
                {
                    logon.Role = dataSet.Tables[0].Rows[0]["role"].ToString();
                    logon.Id = dataSet.Tables[0].Rows[0]["id"].ToString();
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return logon;
        }
    }





----


Course Repository
================

	public class CourseRepository : BaseRepository, ICourseRepository
    {
        private const string GetCourseListProcedure = "spGetCourseList";
        private const string InsertCourseP = "insert_course";
        private const string DeleteCourseP = "delete_course";
        private const string UpdateCourseP = "update_course";
        private const string GetCourseP = "get_Course";

        //
        private const string PreReqUpdate = "prereq_update";

        //insert data for course
        public void InsertCourse(Course c, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(InsertCourseP, conn);

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, -1));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prereq", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@unit", SqlDbType.Int));




                adapter.SelectCommand.Parameters["@course_id"].Value = c.CourseId;
                adapter.SelectCommand.Parameters["@course_title"].Value = c.Title;
                adapter.SelectCommand.Parameters["@course_level"].Value = c.CourseLevel;
                adapter.SelectCommand.Parameters["@course_description"].Value = c.Description;
                adapter.SelectCommand.Parameters["@prereq"].Value = c.prereq;
                adapter.SelectCommand.Parameters["@unit"].Value = c.unit;



                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);


            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

        }

        //update data for course
        public void UpdateCourse(Course c, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(UpdateCourseP, conn);

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_title", SqlDbType.VarChar, 100));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_level", SqlDbType.VarChar, 10));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_description", SqlDbType.VarChar, -1));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@prereq", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@unit", SqlDbType.Int));




                adapter.SelectCommand.Parameters["@course_id"].Value = c.CourseId;
                adapter.SelectCommand.Parameters["@course_title"].Value = c.Title;
                adapter.SelectCommand.Parameters["@course_level"].Value = c.CourseLevel;
                adapter.SelectCommand.Parameters["@course_description"].Value = c.Description;
                adapter.SelectCommand.Parameters["@prereq"].Value = c.prereq;
                adapter.SelectCommand.Parameters["@unit"].Value = c.unit;



                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);


            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        //delete data fro course
        public void DeleteCourse(int id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteCourseP, conn)
                {
                    SelectCommand =
                    {
                        CommandType =CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }


        public List<Course> GetCourseList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var courseList = new List<Course>();

            try
            {
                var adapter = new SqlDataAdapter(GetCourseListProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var pre="None";
                    var u=0;

                    if (dataSet.Tables[0].Rows[i]["prereq"].Equals(null))
                    {
                        pre = "None";
                    }
                    else
                    {
                        pre = dataSet.Tables[0].Rows[i]["prereq"].ToString();

                    }

                    if (dataSet.Tables[0].Rows[i]["unit"].Equals(null))
                    {

                        u = 0;
                    }
                    else
                    {

                        u = Convert.ToInt32(dataSet.Tables[0].Rows[i]["unit"].ToString());
                    }

                    var course = new Course
                                     {
                                         CourseId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["course_id"].ToString()),
                                         Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(),
                                         CourseLevel =(CourseLevel)Enum.Parse(typeof(CourseLevel),
										dataSet.Tables[0].Rows[i]["course_level"].ToString()),
                                         Description = dataSet.Tables[0].Rows[i]["course_description"].ToString(),
                                         prereq = pre,
                                         unit = u
                                     };
                    courseList.Add(course);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return courseList;
        }

        //update PreReq
        public void UpdatePreReq(int course_id, string prereq, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            
            try
            {
                var adapter = new SqlDataAdapter(PreReqUpdate, conn);



                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));
                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@grade", SqlDbType.VarChar, 25));
                adapter.SelectCommand.Parameters["@prereq"].Value = prereq;


                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);


            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }


        }

        //getCourse
        public Course GetCourse(int course_id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Course course = null;

            try
            {
                var adapter = new SqlDataAdapter(GetCourseP, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };

                adapter.SelectCommand.Parameters.Add(new SqlParameter("@course_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@course_id"].Value = course_id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

             
                    var pre = "None";
                    var u = 0;

                    if (dataSet.Tables[0].Rows[0]["prereq"].Equals(null))
                    {
                        pre = "None";
                    }
                    else
                    {
                        pre = dataSet.Tables[0].Rows[0]["prereq"].ToString();

                    }

                    if (dataSet.Tables[0].Rows[0]["unit"].Equals(null))
                    {

                        u = 0;
                    }
                    else
                    {

                        u = Convert.ToInt32(dataSet.Tables[0].Rows[0]["unit"].ToString());
                    }

                    course = new Course
                    {
                        CourseId = Convert.ToInt32(dataSet.Tables[0].Rows[0]["course_id"].ToString()),
                        Title = dataSet.Tables[0].Rows[0]["course_title"].ToString(),
                        CourseLevel = (CourseLevel)Enum.Parse(typeof(CourseLevel), 
						dataSet.Tables[0].Rows[0]["course_level"].ToString()),
                        Description = dataSet.Tables[0].Rows[0]["course_description"].ToString(),
                        prereq = pre,
                        unit = u
                    };
                  
                
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return course;
        }

    }




----


Base Repository
================

	public class BaseRepository
    {
        public static string ConnectionString 
        {
            get 
            {
                return ConfigurationManager.AppSettings["dsn"];
            }
        }
    }





----



Schedule Repository
================

	public class ScheduleRepository : BaseRepository, IScheduleRepository
    {
        private const string GetScheduleListProcedure = "spGetScheduleList";

        public List<Schedule> GetScheduleList(string year, string quarter, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var scheduleList = new List<Schedule>();

            try
            {
                var adapter = new SqlDataAdapter(GetScheduleListProcedure, conn);

                if (year.Length > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@year", SqlDbType.Int));
                    adapter.SelectCommand.Parameters["@year"].Value = year;
                }

                if (quarter.Length > 0)
                {
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@quarter", SqlDbType.VarChar, 25));
                    adapter.SelectCommand.Parameters["@quarter"].Value = quarter;
                }

                adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var schedule = new Schedule
                    {
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()), 
                        Year = dataSet.Tables[0].Rows[i]["year"].ToString(), 
                        Quarter = dataSet.Tables[0].Rows[i]["quarter"].ToString(), 
                        Session = dataSet.Tables[0].Rows[i]["session"].ToString(), 
                        Course = new Course
                        {
                            CourseId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["course_id"].ToString()), 
                            Title = dataSet.Tables[0].Rows[i]["course_title"].ToString(), 
                            Description = dataSet.Tables[0].Rows[i]["course_description"].ToString(), 
                        }
                    };
                    scheduleList.Add(schedule);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return scheduleList;
        }
    }





----


Student Repository
================

	public class StudentRepository : BaseRepository, IStudentRepository
    {
        private const string InsertStudentInfoProcedure = "spInsertStudentInfo";
        private const string UpdateStudentInfoProcedure = "spUpdateStudentInfo";
        private const string DeleteStudentInfoProcedure = "spDeleteStudentInfo";
        private const string GetStudentListProcedure = "spGetStudentList";
        private const string GetStudentInfoProcedure = "spGetStudentInfo";
        private const string InsertStudentScheduleProcedure = "spInsertStudentSchedule";
        private const string DeleteStudentScheduleProcedure = "spDeleteStudentSchedule";
        private const string GetEnrollment = "get_Enrollment";

        public void InsertStudent(Student student, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(InsertStudentInfoProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ssn", SqlDbType.VarChar, 9));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shoe_size", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@weight", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = student.StudentId;
                adapter.SelectCommand.Parameters["@ssn"].Value = student.SSN;
                adapter.SelectCommand.Parameters["@first_name"].Value = student.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = student.LastName;
                adapter.SelectCommand.Parameters["@email"].Value = student.Email;
                adapter.SelectCommand.Parameters["@password"].Value = student.Password;
                adapter.SelectCommand.Parameters["@shoe_size"].Value = student.ShoeSize;
                adapter.SelectCommand.Parameters["@weight"].Value = student.Weight;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void UpdateStudent(Student student, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            try
            {
                var adapter = new SqlDataAdapter(UpdateStudentInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@ssn", SqlDbType.VarChar, 9));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@first_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@last_name", SqlDbType.VarChar, 50));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 64));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@shoe_size", SqlDbType.Float));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@weight", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = student.StudentId;
                adapter.SelectCommand.Parameters["@ssn"].Value = student.SSN;
                adapter.SelectCommand.Parameters["@first_name"].Value = student.FirstName;
                adapter.SelectCommand.Parameters["@last_name"].Value = student.LastName;
                adapter.SelectCommand.Parameters["@email"].Value = student.Email;
                adapter.SelectCommand.Parameters["@password"].Value = student.Password;
                adapter.SelectCommand.Parameters["@shoe_size"].Value = student.ShoeSize;
                adapter.SelectCommand.Parameters["@weight"].Value = student.Weight;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DeleteStudent(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteStudentInfoProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@student_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public Student GetStudentDetail(string id, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            Student student = null;

            try
            {
                var adapter = new SqlDataAdapter(GetStudentInfoProcedure, conn)
                {
                    SelectCommand = { CommandType = CommandType.StoredProcedure }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@student_id"].Value = id;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                student = new Student
                              {
                                  StudentId = dataSet.Tables[0].Rows[0]["student_id"].ToString(),
                                  FirstName = dataSet.Tables[0].Rows[0]["first_name"].ToString(),
                                  LastName = dataSet.Tables[0].Rows[0]["last_name"].ToString(),
                                  SSN = dataSet.Tables[0].Rows[0]["ssn"].ToString(),
                                  Email = dataSet.Tables[0].Rows[0]["email"].ToString(),
                                  Password = dataSet.Tables[0].Rows[0]["password"].ToString(),
                                  ShoeSize =
                                      (float)Convert.ToDouble(dataSet.Tables[0].Rows[0]["shoe_size"].ToString()),
                                  Weight = Convert.ToInt32(dataSet.Tables[0].Rows[0]["weight"].ToString())
                              };

                if (dataSet.Tables[1] != null)
                {
                    student.Enrolled = new List<Schedule>();
                    for (var i = 0; i < dataSet.Tables[1].Rows.Count; i++)
                    {
                        var schedule = new Schedule();
                        var course = new Course
                                         {
                                             CourseId = Convert.ToInt32(dataSet.Tables[1].Rows[i]["course_id"].ToString()),
                                             Title = dataSet.Tables[1].Rows[i]["course_title"].ToString(),
                                             Description =
                                                 dataSet.Tables[1].Rows[i]["course_description"].ToString()
                                         };
                        schedule.Course = course;

                        schedule.Quarter = dataSet.Tables[1].Rows[i]["quarter"].ToString();
                        schedule.Year = dataSet.Tables[1].Rows[i]["year"].ToString();
                        schedule.Session = dataSet.Tables[1].Rows[i]["session"].ToString();
                        schedule.ScheduleId = Convert.ToInt32(dataSet.Tables[1].Rows[i]["schedule_id"].ToString());
                        student.Enrolled.Add(schedule);
                    }
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return student;
        }

        public List<Student> GetStudentList(ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var studentList = new List<Student>();

            try
            {
                var adapter = new SqlDataAdapter(GetStudentListProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType = CommandType.StoredProcedure
                                          }
                                  };

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var student = new Student
                                      {
                                          StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                                          FirstName = dataSet.Tables[0].Rows[i]["first_name"].ToString(),
                                          LastName = dataSet.Tables[0].Rows[i]["last_name"].ToString(),
                                          SSN = dataSet.Tables[0].Rows[i]["ssn"].ToString(),
                                          Email = dataSet.Tables[0].Rows[i]["email"].ToString(),
                                          Password = dataSet.Tables[0].Rows[i]["password"].ToString(),
                                          ShoeSize =
                                              (float)
                                              Convert.ToDouble(dataSet.Tables[0].Rows[i]["shoe_size"].ToString()),
                                          Weight = Convert.ToInt32(dataSet.Tables[0].Rows[i]["weight"].ToString())
                                      };
                    studentList.Add(student);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return studentList;
        }

        public void EnrollSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(InsertStudentScheduleProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType
                                                  =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public void DropEnrolledSchedule(string studentId, int scheduleId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);

            try
            {
                var adapter = new SqlDataAdapter(DeleteStudentScheduleProcedure, conn)
                                  {
                                      SelectCommand =
                                          {
                                              CommandType
                                                  =
                                                  CommandType
                                                  .StoredProcedure
                                          }
                                  };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@schedule_id", SqlDbType.Int));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;
                adapter.SelectCommand.Parameters["@schedule_id"].Value = scheduleId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public List<Enrollment> GetEnrollments(string studentId, ref List<string> errors)
        {
            var conn = new SqlConnection(ConnectionString);
            var enrollmentList = new List<Enrollment>();

            try
            {
                var adapter = new SqlDataAdapter(GetEnrollment, conn)
                {
                    SelectCommand =
                    {
                        CommandType = CommandType.StoredProcedure
                    }
                };
                adapter.SelectCommand.Parameters.Add(new SqlParameter("@student_id", SqlDbType.VarChar, 20));

                adapter.SelectCommand.Parameters["@student_id"].Value = studentId;

                var dataSet = new DataSet();
                adapter.Fill(dataSet);

                

                if (dataSet.Tables[0].Rows.Count == 0)
                {
                    return null;
                }

                for (var i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    var enrollment = new Enrollment
                    {
                        StudentId = dataSet.Tables[0].Rows[i]["student_id"].ToString(),
                        ScheduleId = Convert.ToInt32(dataSet.Tables[0].Rows[i]["schedule_id"].ToString()),
                        Grade = dataSet.Tables[0].Rows[i]["grade"].ToString(),
                        
                    };
                    enrollmentList.Add(enrollment);
                }
            }
            catch (Exception e)
            {
                errors.Add("Error: " + e);
            }
            finally
            {
                conn.Dispose();
            }

            return enrollmentList;

        }
    }




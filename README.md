# MIS517-StudentAttendanceManagementSystem

[![Join the chat at https://gitter.im/MIS517-Client-Server-Development/SAMS-Rozina-and-Austin](https://badges.gitter.im/MIS517-Client-Server-Development/SAMS-Rozina-and-Austin.svg)](https://gitter.im/MIS517-Client-Server-Development/SAMS-Rozina-and-Austin?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Goal
----

The objective of the project is to integrate the tools that we have covered in the course, including HTML, CSS, ASP.net and databases. A secondary objective is to provide you with an impressive item to add to your on-line portfolio, should you choose to build one. While working on this project, you will experience the “learning-by-doing” of how to design client/server applications for real-world problems.


Resources Used
--------------
- Microsoft Visual Studio 2012, 2015
- Github
- GitKraken GUI Client
- MySQL WorkBench - Database Design, EER Diagrams, SQL
- Microsoft Visio - for Data Flow Diagrams


The Project
-----------

A sample project is proposed below; however, students can develop their own project if they want to. The size of the project and the milestones should be similar to the one shown in the sample project. If you decide to do your own project, you need develop milestones by week 7 and discuss them with me before starting the project. If a project is not discussed, you are required to complete the project below.

The "standard" project will be to build part of a website for “**Student Attendance Management website**”. This website will be developed for recording the attendance of the students on the daily basis in the college. Here the Instructor, who is teaching the subjects and will be responsible for recording the attendance of the students. Each instructor will be given a separate username and password based on the subject they teach. This system will also help in evaluating attendance eligibility criteria of a student. The site will display the student’s attendance on monthly basis.

There will be a project plan with *milestones* and *deliverables.* The milestones serve as control points to verify the proper progress. The project will allow students to integrate many programming tools to achieve the goal. Some of those tools will be discussed in the class. Others can be obtained using the external resources.

Requirements
------------

The **Student Attendance Management site** allows the user to access his/her class information. Below are the details of the requirements.

1.  The main login screen should have username and password and buttons to allow the user to log in. It also provides a link or a button to allow the user to register a new user.

2.  When the user successfully login, the main screen will provide access to the instructor page.

3.  You will design a page for entering the student information.

4.  The website allows the instructor to find the students with the 5 fewest and 5 most absences.

5.  The website lets the instructor enter, review, update and delete the attendance of the students of the class.

6.  The user should be able to log out at any time. If the user logout, the application should take the user to the login screen.

Team requirements:
------------------

You may work in a team of 2 if you complete the following requirements also.

1.  You are required to use Github to manage the code for a team project. The project can either be a publicly available project or else the MIS517 professor must be added to the project. Each teammate should have their own github account and commits should be made from the account of the student making the changes. If only one account commits code, only one student will receive credit for completing the project.

2.  There will be an Admin page to create a new login entry for new teachers/classes.

3.  Design a *class* named ***Extra Credit.*** The class has a method called ***Calculate*** which computes extra credit (bonus) for students based on their attendance, using the following rules:

If the student attendance percent &gt;= 90% then the bonus =10 points o If the attendance &gt;=70 and &lt;90 then bonus =8

If the attendance &gt;=60 and &lt;70 then bonus =6

If the attendance &gt;50 and &lt;60 then bonus =2 o Otherwise bonus =0

The result should be stored in a new field in the student information table when the

Database Design
---------------

The database should have the following tables: 

1. *Login Table*

2. *Subject Table*



|           |               |                 |                    |
|-----------|---------------|-----------------|--------------------|
| **Field** | **Data Type** | **Constraints** | **Description**    |
| Scode     | Number        | Primary key     | Subject code       |
| Ssname    | Text          | Not Null        | Short subject name |


3.Instructor Table


|              |               |                 |                 |
|--------------|---------------|-----------------|-----------------|
| **Field**    | **Data Type** | **Constraints** | **Description** |
| InstructorID | Number        | Primary key     | Instructor id   |
| Scode        | Number        | Foreign key     | Subject code    |

4.Student Information Table

|            |               |                 |                       |
|------------|---------------|-----------------|-----------------------|
| **Field**  | **Data Type** | **Constraints** | **Description**       |
| RollNo     | Number        | Primary key     | Student roll number   |
| Name       | Text          | Not Null        | Student Name          |
| Department | Text          | Not Null        | Department name       |
| DOB        | Date          | Not Null        | Student date of birth |
| Address    | Text          | Not Null        | Student address       |
| MNo        | Text          | Not Null        | Student Mobil no.     |
| EID        | Text          | Not Null        | Student Email         |
| Notes      | Text          | -               |                       |

5.Attendance table

|            |               |                 |                              |
|------------|---------------|-----------------|------------------------------|
| **Field**  | **Data Type** | **Constraints** | **Description**              |
| ID         | Number        | Primary key     |                              |
| Date       | Date          | Not Null        | Enter day by day attendance  |
| Hour       | Number        | Not Null        | Set particular hour only     |
| Scode      | Number        | Not Null        | Subject code                 |
| RollNo     | Number        | Not Null        | Student roll number          |
| Attendance | Text          | -               | Enter present/absent details |

> Note: Feel free to add any tables or fields if needed.

## Project Grading

|            |                                   |              |
|------------|-----------------------------------|--------------|
| **Part**   | **Description**                   | **Points**   |
| 1          | GUI Design and overall appearance | 10           |
| 2          | Use of CSS and Master Page        | 10           |
| 3          | Completeness                      | 20           |
| 4          | Project compiles and runs         | 10           |
| 5          | Database Design and Management    | 10           |
| 6          | Documentation                     | 10           |
| 7          | Validation                        | 5            |
| 8          | Session Management                | 5            |
| 9          | Use of Rich Controls              | 5            |
| 10         | Security                          | 5            |
| 11         | Coding Style                      | 5            |
| **Total**  | **100%**                          | N/A    |


Project Milestones
------------------




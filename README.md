# MIS517-StudentEnrollmentManagementSystem

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

The "standard" project will be to build part of a website for “**Student Enrollment Management website**”. 

There will be a project plan with *milestones* and *deliverables.* The milestones serve as control points to verify the proper progress. The project will allow students to integrate many programming tools to achieve the goal. Some of those tools will be discussed in the class. Others can be obtained using the external resources.

Requirements
------------

The **Student Enrollment Management System** allows the user to access his/her class information. Below are the details of the requirements.

1.  The main login screen should have username and password and buttons to allow the user to log in. It also provides a link or a button to allow the user to register a new user.
2.  When the user successfully login, the main screen will provide access to the instructor page.
3. Instructor will be able to entering the student information.
4. Admins can create new courses
5. Students Can Enroll in a course listed under courses listings.
6. Departments offer certain courses.
7. Instructor (employees) are assigned to departments.
8.  The website lets the instructor enter, review, update and delete the enrollment of the students of the class.
9.  The website will allow students drop courses as well.
10. The user should be able to log out at any time. If the user logout, the application should take the user to the login screen.

Team requirements:
------------------

You may work in a team of 2 if you complete the following requirements also.

- You are required to use Github to manage the code for a team project. The project can either be a publicly available project or else the MIS517 professor must be added to the project. Each teammate should have their own github account and commits should be made from the account of the student making the changes. If only one account commits code, only one student will receive credit for completing the project.



Database Design
---------------

The database should have the following tables: 


## Login Table


## Admin Table

**Admin** ( Admin_ID, First_Name, Last_Name, Email, Password)

**PRIMARY KEY**: Admin_ID

**FOREIGN KEY**:

## Course Table

**Course** ( Course_ID, CourseNumber, CourseTitle, Description, Prereq, Units)

**PRIMARY KEY**: Course_ID

**FOREIGN KEY**:

## Instructor To Course Table

**Instructor_To_Course** (Course_ID, Instructor_ID, CourseTitle) 

**PRIMARY KEY**: 

**FOREIGN KEY**:

## Student To Course Table

**PRIMARY KEY**: 

**FOREIGN KEY**:

**Student_To_Course** (Course_ID, CourseTitle, Student_Id) 


## Enrollment Table

**PRIMARY KEY**: 

**FOREIGN KEY**:


## Schedule Table

**PRIMARY KEY**: 

**FOREIGN KEY**:

## Instructor Table


**PRIMARY KEY**: 

**FOREIGN KEY**:

## Student Table

**PRIMARY KEY**: 

**FOREIGN KEY**:

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




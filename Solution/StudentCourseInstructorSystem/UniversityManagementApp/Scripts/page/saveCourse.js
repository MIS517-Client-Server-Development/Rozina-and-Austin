$(function () {
    //Form Validation
    $("#CourseSave").validate({
        rules: {
            CourseCode: {
                required: true,
                minlength: 5
            },
            CourseName: "required",
            CourseCredit: {
                required: true,
                range: [0.5, 5.0]
            },
            CourseDescription: "required",
            DepartmentId: "required",
            SemesterId: "required"
        },
        messages: {
            CourseCode: {
                required: "Department Code is required",
                minlength: "Code is at least 5 characters."
            },
            CourseName: "Please enter Course name",
            CourseCredit: {
                required: "Credit field is required.",
                range: "Course Credit value is between 0.5 to 5.0"
            },
            CourseDescription: "Please enter Course Description",
            DepartmentId: "Please select a Department",
            SemesterId: "Please select a Semester"
        }
    });
});
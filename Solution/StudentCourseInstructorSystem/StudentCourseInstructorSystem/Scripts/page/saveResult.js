$(function () {
    var site_url = $('.navbar-brand').attr('href');

    $('#StudentId').on('change', function () {
        var StudentId = $(this).val();
        $('#StudentName, #StudentEmail, #DepartmentName').val('').attr('placeholder', 'loading...');
        $('#CourseId').html('<option value="">loading...</option>');
        if (StudentId > 0) {
            $.ajax({
                type: "POST",
                url: site_url + "Student/Get/",
                data: { StudentId: StudentId },
                cache: false,
                success: function (res) {
                    $('#StudentName, #StudentEmail, #DepartmentName').attr('placeholder', '');
                    $('#StudentName').val(res.StudentName);
                    $('#StudentEmail').val(res.StudentEmail);
                    $('#DepartmentName').val(res.DepartmentName);
                    GetAvailableEnrolledCourses(StudentId);
                    //StudentCourses(StudentId);
                }
            });
        } else {
            $('#StudentName, #StudentEmail, #DepartmentName').attr('placeholder', '');
            $('#CourseId').html('<option value="">Select Course</option>');
        }
    });

    var GetAvailableEnrolledCourses = function (StudentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Student/AvailableEnrolledCourses/",
            data: { StudentId: StudentId },
            cache: false,
            success: function (data) {
                $('#CourseId').html('<option value="">Select Course</option>');
                $.each(data, function (key, course) {
                    $('#CourseId').append('<option value="' + course.CourseId + '">' + course.CourseName + '</option>');
                });
            }
        });
    }

    var StudentCourses = function (StudentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Student/EnrolledCourses/",
            data: { StudentId: StudentId },
            cache: false,
            success: function (data) {
                $('#CourseId').html('<option value="">Select Course</option>');
                $.each(data, function (key, course) {
                    $('#CourseId').append('<option value="' + course.CourseId + '">' + course.CourseName + '</option>');
                });
            }
        });
    }

    //Form Validation
    $("#SaveResult").validate({
        rules: {
            StudentId: "required",
            CourseId: "required",
            GradeId: "required"
        },
        messages: {
            StudentId: "Select a Student",
            CourseId: "Select a Course",
            GradeId: "Select a Grade"
        }
    });
});
$(function () {
    var site_url = $('.navbar-brand').attr('href');
    var today = moment().format('YYYY-MM-DD');
    $('#EnrollmentDate').val(today);
    $('#EnrollmentDate').datepicker({
        format: "yyyy-mm-dd",
        todayBtn: "linked",
        orientation: "top left",
        autoclose: true,
        todayHighlight: true,
        toggleActive: true
    });

    $('#StudentId').on('change', function() {
        var StudentId = $(this).val();
        $('#StudentName, #StudentEmail, #DepartmentName').val('').attr('placeholder', 'loading...');
        $('#CourseId').html('<option value="">loading...</option>');
        if (StudentId > 0) {
            $.ajax({
                type: "POST",
                url: site_url + "student/get/",
                data: { StudentId: StudentId },
                cache: false,
                success: function (res) {
                    $('#StudentName, #StudentEmail, #DepartmentName').attr('placeholder', '');
                    $('#StudentName').val(res.StudentName);
                    $('#StudentEmail').val(res.StudentEmail);
                    $('#DepartmentName').val(res.DepartmentName);
                    GetAvailableCourses(StudentId, res.DepartmentId);
                    //DepartmentCourses(res.DepartmentId);
                }
            });
        } else {
            $('#StudentName, #StudentEmail, #DepartmentName').attr('placeholder', '');
            $('#CourseId').html('<option value="">Select Course</option>');
        }
    });

    var GetAvailableCourses = function(StudentId, DepartmentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Student/AvailableCourses/",
            data: { StudentId: StudentId, DepartmentId: DepartmentId },
            cache: false,
            success: function (data) {
                $('#CourseId').html('<option value="">Select Course</option>');
                $.each(data, function(key, course) {
                    $('#CourseId').append('<option value="' + course.CourseId + '">' + course.CourseName + '</option>');
                });
            }
        });
    }

    var DepartmentCourses = function (DepartmentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Student/DepartmentCourses/",
            data: { DepartmentId: DepartmentId },
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
    $("#StudentEnroll").validate({
        rules: {
            StudentId: "required",
            CourseId: "required",
            EnrollmentDate: {
                required: true,
                date: true
            }
        },
        messages: {
            StudentId: "Select a Student",
            CourseId: "Select a Course",
            EnrollmentDate: {
                required: "Enrollment Date is required",
                date: "Date is not valid"
            }
        }
    });
});
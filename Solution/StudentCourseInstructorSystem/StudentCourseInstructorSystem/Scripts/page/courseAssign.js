$(function () {
    var site_url = $('.navbar-brand').attr('href');

    $('#DepartmentId').on('change', function () {
        var DepartmentId = $(this).val();
        $('#CreditTaken, #RemainingCredit, #CourseName, #CourseCredit').val('');
        $('#TeacherId, #CourseId').html('<option value="">loading...</option>');
        if (DepartmentId > 0) {
            DepartmentTeachers(DepartmentId);
            //DepartmentCourses(DepartmentId);
            GetAvailableCourses(DepartmentId);
        } else {
            $('#TeacherId').html('<option value="">Select Teacher</option>');
            $('#CourseId').html('<option value="">Select Course</option>');
        }
    });

    $('#TeacherId').on('change', function () {
        $('#CreditTaken, #RemainingCredit').val('loading...');
        var TeacherId = $(this).val();
        var credit_taken = parseFloat($(this).find(':selected').data('credit_taken'));
        $('#CreditTaken').val(credit_taken);
        $.ajax({
            type: "POST",
            url: site_url + "Teacher/CreditUsed/",
            data: { TeacherId: TeacherId },
            cache: false,
            success: function (creditUsed) {
                var remainingCredit = (credit_taken - creditUsed);
                $('#RemainingCredit').val(remainingCredit);
            }
        });
    });

    $('#CourseId').on('change', function () {
        var name = $(this).find(':selected').data('name');
        var credit = $(this).find(':selected').data('credit');
        $('#CourseName').val(name);
        $('#CourseCredit').val(credit);
    });

    var DepartmentTeachers = function (DepartmentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Teacher/DepartmentTeachers/",
            data: { DepartmentId: DepartmentId },
            cache: false,
            success: function (data) {
                $('#TeacherId').html('<option value="">Select Teacher</option>');
                $.each(data, function (key, teacher) {
                    $('#TeacherId').append('<option data-credit_taken="' + teacher.CreditTaken + '" value="' + teacher.TeacherId + '">' + teacher.TeacherName + '</option>');
                });
            }
        });
    }

    var GetAvailableCourses = function (DepartmentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Teacher/AvailableCourses/",
            data: { DepartmentId: DepartmentId },
            cache: false,
            success: function (data) {
                $('#CourseId').html('<option value="">Select Course</option>');
                $.each(data, function (key, course) {
                    $('#CourseId').append('<option data-name="' + course.CourseName + '" data-credit="' + course.CourseCredit + '" value="' + course.CourseId + '">' + course.CourseCode + '</option>');
                });
            }
        });
    }

    var DepartmentCourses = function (DepartmentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Teacher/DepartmentCourses/",
            data: { DepartmentId: DepartmentId },
            cache: false,
            success: function (data) {
                $('#CourseId').html('<option value="">Select Course</option>');
                $.each(data, function (key, course) {
                    $('#CourseId').append('<option data-name="' + course.CourseName + '" data-credit="' + course.CourseCredit + '" value="' + course.CourseId + '">' + course.CourseCode + '</option>');
                });
            }
        });
    }

    //Form Validation
    $("#CourseAssign").validate({
        rules: {
            DepartmentId: "required",
            TeacherId: "required",
            CourseId: "required"
        },
        messages: {
            DepartmentId: "Select a Student",
            TeacherId: "Select a Teacher",
            CourseId: "Select a Course"
        },
        submitHandler: function(form) {
            var remainingCredit = parseFloat($('#RemainingCredit').val());
            var courseCredit = parseFloat($('#CourseCredit').val());
            if (remainingCredit > courseCredit) {
                form.submit();
            } else {
                $('#confirmModal').on('show.bs.modal', function (event) {
                    var teacherName = $("#TeacherId option:selected").text().trim();
                    var courseName = $('#CourseName').val().trim();
                    $(this).find('.modal-body').html('Remaining Credit of <b>Mr. ' + teacherName + '</b> is: <b>' + remainingCredit + '</b>, which is below the credit [<b>' + courseCredit + '</b>] of the Course <b>' + courseName + '</b>. Do you want to proceed?');
                });
                $('#confirmModal').modal('show');
                $('#confirm').click(function () {
                    form.submit();
                });
            }
        }
    });
});
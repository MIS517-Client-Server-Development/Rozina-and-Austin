$.validator.addMethod("greaterThan",
function (value, element, params) {
    var val = new Date('1/1/1991' + ' ' + value);
    var par = new Date('1/1/1991' + ' ' + $(params).val());
    if (!/Invalid|NaN/.test(new Date(val))) {
        return new Date(val) > new Date(par);
    }

    return isNaN(val) && isNaN(par)
        || (Number(val) > Number(par));
}, 'End Time must be greater than Start Time.');

$(function () {
    var site_url = $('.navbar-brand').attr('href');

    $('#StartTime').timepicker({
        template: false,
        showInputs: false,
        minuteStep: 5,
        defaultTime: false
    });

    $('#EndTime').timepicker({
        template: false,
        showInputs: false,
        minuteStep: 5,
        defaultTime: false
    });

    $('#DepartmentId').on('change', function () {
        var DepartmentId = $(this).val();
        $('#CourseId').html('<option value="">loading...</option>');
        if (DepartmentId > 0) {
            DepartmentCourses(DepartmentId);
        } else {
            $('#CourseId').html('<option value="">Select Course</option>');
        }
    });

    var DepartmentCourses = function (DepartmentId) {
        $.ajax({
            type: "POST",
            url: site_url + "Teacher/DepartmentCourses/",
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
    $("#AllocateClassrooms").validate({
        rules: {
            DepartmentId: "required",
            CourseId: "required",
            RoomId: "required",
            DayId: "required",
            StartTime: "required",
            EndTime: {
                required: true,
                greaterThan: "#StartTime"
            }
        },
        messages: {
            DepartmentId: "Select a Student",
            CourseId: "Select a Course",
            RoomId: "Select a Room",
            DayId: "Select a Day",
            StartTime: "Start Time is required"
        }
    });
});
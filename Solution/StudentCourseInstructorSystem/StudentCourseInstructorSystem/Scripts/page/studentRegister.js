$(function () {
    var site_url = $('.navbar-brand').attr('href');
    var today = moment().format('YYYY-MM-DD');
    $('#RegDate').val(today);
    $('#RegDate').datepicker({
        format: "yyyy-mm-dd",
        todayBtn: "linked",
        orientation: "top left",
        autoclose: true,
        todayHighlight: true,
        toggleActive: true
    });

    //Form Validation
    $("#RegisterStudent").validate({
        rules: {
            StudentName: "required",
            StudentEmail: {
                required: true,
                email: true
            },
            StudentContactNo: "required",
            RegDate: {
                required: true,
                date: true
            },
            StudentAddress: "required",
            DepartmentId: "required"
        },
        messages: {
            StudentName: "Please enter Student Name",
            StudentEmail: {
                required: "Email is required",
                email: "Email is not valid."
            },
            StudentContactNo: "Contact number is required",
            RegDate: {
                required: "Registration Date is required",
                date: "Date is not valid"
            },
            StudentAddress: "Address is required",
            DepartmentId: "Select a Department"
        },
        submitHandler: function (form) {
            $('#alert').empty();
            $('#SaveBtn').find('i').removeClass('fa-plus-square').addClass('fa-spinner fa-pulse');
            var formData = $(form).serialize();
            $.ajax({
                type: "POST",
                url: site_url + "Student/Save/",
                data: formData,
                cache: false,
                success: function (response) {
                    var class_name = response.Class.trim();
                    var msg = response.Message.trim();
                    if (class_name === 'success') {
                        $('#forRegNo').text(msg);
                        $('#forStudentName').text($('#StudentName').val().trim());
                        $('#forStudentEmail').text($('#StudentEmail').val().trim());
                        $('#forStudentContactNo').text($('#StudentContactNo').val().trim());
                        $('#forStudentAddress').text($('#StudentAddress').val().trim());
                        var dept = $("#DepartmentId option:selected").text().trim();
                        $('#forDepartment').text(dept);
                        var regDate = moment($('#RegDate').val(), 'YYYY-MM-DD').format('MMMM DD, YYYY');
                        $('#forRegDate').text(regDate);
                        $('#regSuccessfulModal').modal('show');
                        $(form).find("input[type=text], input[type=email], textarea").val("");
                        $('#DepartmentId').prop('selectedIndex', 0);
                        $('#RegDate').val(today);
                    } else {
                        var alertHtml = '<div class="alert alert-' + class_name + ' alert-dismissable">';
                        alertHtml += '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>';
                        alertHtml += msg + '</div>';
                        $('#alert').hide().html(alertHtml).fadeIn('slow');
                    }
                }
            }).done(function () {
                $('#SaveBtn').find('i').removeClass('fa-spinner fa-pulse').addClass('fa-plus-square');
            });
        }
    });
});
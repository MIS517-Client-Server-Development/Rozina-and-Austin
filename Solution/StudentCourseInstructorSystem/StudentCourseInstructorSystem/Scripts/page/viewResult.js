$(function () {
    var site_url = $('.navbar-brand').attr('href');

    $('#StudentId').on('change', function () {
        var StudentId = $(this).val();
        $('#StudentName, #StudentEmail, #DepartmentName').val('').attr('placeholder', 'loading...');
        $('#makePDF').prop('disabled', true);
        $('#search-reasult').html('<div class="loader">Searching...</div>');
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
                    GetResult(StudentId);
                }
            });
        } else {
            $('#StudentName, #StudentEmail, #DepartmentName').attr('placeholder', '');
            $('#search-reasult').html('');
        }
    });

    $('#makePDF').click(function () {
        window.location = site_url + "Result/GeneratePDF/?studentId=" + $('#StudentId').val();
    });

    var GetResult = function (StudentId) {
        setTimeout(function () {
            $.ajax({
                type: "POST",
                url: site_url + "Result/Get/",
                data: { StudentId: StudentId },
                cache: false,
                success: function (res) {
                    $('#search-reasult').html(res);
                    $('#makePDF').prop('disabled', false);
                }
            });
        }, 3000);
    }
});
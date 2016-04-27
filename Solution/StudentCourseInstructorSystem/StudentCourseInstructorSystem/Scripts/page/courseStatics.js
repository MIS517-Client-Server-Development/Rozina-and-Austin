$(function () {
    var site_url = $('.navbar-brand').attr('href');

    $('#DepartmentId').on('change', function () {
        var DepartmentId = $(this).val();
        $('#search-reasult').html('<div class="loader">Loading...</div>');
        if (DepartmentId > 0) {
            setTimeout(function() {
                $.ajax({
                    type: "POST",
                    url: site_url + "Course/StaticsView/",
                    data: { DepartmentId: DepartmentId },
                    cache: false,
                    success: function (res) {
                        $('#search-reasult').html(res);
                    }
                });
            }, 3000);
        } else {
            $('#search-reasult').html('');
        }
    });
});
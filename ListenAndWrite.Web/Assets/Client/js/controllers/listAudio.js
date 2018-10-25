var config = {
    pageSize: 10,
    pageIndex: 1,
}
var listAudio = {
    init: function () {
        listAudio.loadData();
        listAudio.registerEvents();
    },
    registerEvents: function () {
        
    },
    loadData: function () {
        $.ajax({
            url: '/Audio/LoadAudio',
            type: 'GET',
            dataType: 'json',
            data: {
                level: $('#level').val(),
                page: config.pageIndex,
                pageSize: config.pageSize
            },
            success: function (response) {
                if (response.TotalCount > 0) {
                    var data = response.Items;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        var minutes, seconds;
                        if (Math.floor(item.Duration / 60) < 10)
                            minutes = "0" + Math.floor(item.Duration / 60);
                        else
                            minutes = Math.floor(item.Duration / 60);
                        if ((item.Duration % 60) < 10)
                            seconds = "0" + item.Duration % 60;
                        else
                            seconds = item.Duration % 60;
                        
                        var myDate = new Date(item.CreatedDate.match(/\d+/)[0] * 1);
                        html += Mustache.render(template, {
                            AudioTitle: item.AudioTitle,
                            CreatedDate: myDate.getDate() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getFullYear(),
                            Level: item.Level,
                            Duration: minutes + ":" + seconds,
                            Id: item.Id
                            });
                    });
                    $('.archive-posts').html(html);
                    listAudio.paging(response.TotalCount, function () {
                        listAudio.loadData();
                    });
                    listAudio.registerEvents();
                }
                else {
                    $('.archive-posts').html("<h2>Không có dữ liệu</h2>")
                }

            }
        });
    },
    paging: function (totalRow, callback) {
        var totalPage = Math.ceil(totalRow / config.pageSize);
        $('#pagination').twbsPagination({
            totalPages: totalPage,
            first: "Đầu",
            next: "Tiếp",
            last: "Cuối",
            prev: "Trước",
            visiblePages: 10,
            onPageClick: function (event, page) {
                config.pageIndex = page;
                setTimeout(callback, 200);
            }
        });
    }
}
listAudio.init();
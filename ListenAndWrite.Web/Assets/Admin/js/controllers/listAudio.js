var config = {
    pageSize: 2,
    pageIndex: 1,
}
var listAudio = {
    init: function () {
        listAudio.loadData();
        listAudio.registerEvents();
    },
    registerEvents: function () {
        $('#btnClearTrack').click(function () {
            

        });
        $('#btnDel').off('click').on('click', function (e) {
            e.preventDefault();
            var r = confirm("Delete this audio ?");
            if (r == true) {
                var audioId = parseInt($(this).data('id'));
                listAudio.deleteAudio(audioId);
            }
            
        });
    },
    deleteAudio: function (audioId) {
        $.ajax({
            url: '/Admin/DeleteAudio',
            data: {
                audioId: audioId,
            },
            type: 'POST',
            dataType: 'json',
            success: function (response) {
                if (response.status) {
                    listAudio.loadData();
                }
            }
        });
    },
    loadData: function () {
        $.ajax({
            url: '/Admin/LoadAudio',
            type: 'GET',
            dataType: 'json',
            data: {
                page: config.pageIndex,
                pageSize: config.pageSize
            },
            success: function (response) {
                if (response.TotalCount >0) {
                    var data = response.Items;
                    var html = '';
                    var template = $('#data-template').html();
                    $.each(data, function (i, item) {
                        var myDate = new Date(item.CreatedDate.match(/\d+/)[0] * 1);
                        html += Mustache.render(template, {
                            Id: item.Id,
                            AudioTitle: item.AudioTitle,
                            CreatedDate: myDate.getDate() + "-" + (myDate.getMonth() + 1) + "-" + myDate.getFullYear(),
                            Status: item.Status == true ? "<span class=\"badge bg-green\">Actived</span>" : "<span class=\"badge bg-red\">Locked</span>"
                        });
                    });
                    html += "<div class=\"clearfix\"></div>";
                    $('#audioTable').html(html);
                    listAudio.paging(response.TotalCount, function () {
                        listAudio.loadData();
                    });
                    listAudio.registerEvents();
                }
                else {
                    $('#content').html("<h2>Không có dữ liệu</h2>")
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
var track = {
    init: function () {
        track.initDialog();
        track.registerEvent();
        track.loadTracks();
    },
    initDialog: function () {
        $('#dialog').dialog({
            autoOpen: false,
            modal: true,
            buttons: {
                'Create': track.createTrack,
                'Cancel': function () {
                    $('#dialog').dialog('close');
                    track.clearInputFields();
                }
            }
        });
    },
    registerEvent: function () {
        $('#btnAddTrack').click(function () {
            $('#dialog').dialog("open");
        });
        $('#btnClearTrack').click(function () {
            var r = confirm("Clear all track ?");
            if (r == true) {
                track.clearTrack();
            }

        });
    },
    clearTrack:function(){
        $.ajax({
            url: '/Admin/ClearTrack',
            data: {
                audioId: $('#audioId').val()
            },
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                track.loadTracks();
            }
        });
    },
    createTrack: function () {
        var emp = {};
        emp.AudioId = $('#audioId').val();
        emp.TimeStart = $('#txtTimeStart').val();
        emp.Duration = $('#txtDuration').val();
        emp.Answer = $('#txtAnswer').val();

        $.ajax({
            url: '/Admin/SaveTrack',
            method: 'post',
            data: '{ track:' + JSON.stringify(emp) + '}',
            contentType: 'application/json; charset=utf-8',
            dataType: 'json',
            success: function () {
                track.loadTracks();
                $('#dialog').dialog('close');
                track.clearInputFields();
            }
        });
    },
    loadTracks: function () {
        var tboby = $('#tracks tbody');
        tboby.empty();
        $.ajax({
            url: '/Admin/GetTracks',
            dataType: 'json',
            data: {
                audioId: $('#audioId').val()
            },
            success: function (response) {
                var data = response.data;
                $(data).each(function () {
                    var tr = $('<tr></tr>')
                    tr.append('<td>' + this.Order + '</td>')
                    tr.append('<td>' + this.TimeStart + '</td>')
                    tr.append('<td>' + this.Duration + '</td>')
                    tr.append('<td>' + this.Answer + '</td>')
                    tboby.append(tr);
                })
            }
        });
    },
    clearInputFields: function () {
        $('#dialog input[type="text"]').val('');
        $('#dialog input[type="number"]').val('');
    },
}
track.init();
var userAudio = {
    init: function () {
        
        userAudio.initDialog();
        userAudio.registerEvents();
    },
    registerEvents: function () {
        
        $('.btn-play').click(function () {
            $('#dialogPlay').append("<audio controls><source src=\"" + $(this).data('path') + "\" type=\"audio/mpeg\"></audio><hr>");
            $('#dialogPlay').data('text', $(this).data('text'));
            $('#dialogPlay').dialog('open');
        });
    },
    initDialog: function () {
        $('#dialogPlay').dialog({
            open: function (event, ui) { jQuery('.ui-dialog-titlebar-close').hide(); },
            width: 'auto',
            resizable: true,
            autoOpen: false,
            modal: true,
            buttons: {
                'Hint text': function () {
                    $('#dialogPlay').append("<textarea readonly rows=\"10\" cols=\"50\">" + $(this).data('text') + "</textarea >");
                },
                'Close': function () {
                    $('#dialogPlay').html("");
                    $('#dialogPlay').dialog('close');

                }
            }
        });
    }
}
userAudio.init();
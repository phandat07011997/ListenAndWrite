var currTrack = 1;
var timeStart = 0, duration = 0;
var numTrack = $('#numTrack').html();
var answer = '';
var myAudio = document.getElementById('audio');
var controller = 0;
var flag = true;
var audio = {
    init: function () {
        audio.getTrack(currTrack);
        audio.registerEvents();
    },
    registerEvents: function () {
        $('#btn-play').click(function () {
            if (flag) {
                audio.getTrack(currTrack);
                flag = false;
            }
            audio.playAudio();        // chạy audio
            controller = setInterval(audio.playAudio, (duration + 0.2) * 1000);       // lưu vị trí đang chạy của file audio
            $(this).attr('disabled', 'disabled');
            $('#stop').removeAttr('disabled');
        });
        $('#stop').click(function () {
            myAudio.pause();
            clearInterval(controller);
            $('#btn-play').removeAttr('disabled');
            $(this).attr('disabled', 'disabled');
            $('#hint').attr('disabled', 'disabled');
            $('#hintword').html('DatPQ');
        });
        $('.btn-next').click(function () {
            $('#chartContainer').hide();
            flag = true;
            $('#hint').attr('disabled', 'disabled');
            $('#hintword').html('');
            $('#stop').attr('disabled', 'disabled');
            myAudio.pause();            // dừng phát
            clearInterval(controller);      // xóa dữ liệu
            if ((currTrack + '') < numTrack)
                currTrack++;
            audio.getTrack(currTrack);   // lấy lại track hiện tại

            $('#currentTrack').html(currTrack);
            $('#btn-prev:disabled').removeAttr('disabled');               // 
            $('#btn-play').removeAttr('disabled');                      // hiện nút play
            console.log(numTrack);
            if ((currTrack + '') >= numTrack)                              // ẩn nút next nếu hết track
                $(this).attr('disabled', 'disabled');
            $('textarea').val('');                                          // xóa hết câu trả lời
            $('div#answer').html('');                                       // xóa hết đáp án

            $("#btn-next2").hide();

        });
    },
    getTrack: function (id) {
        $.ajax({
            url: '/Track/LoadTrack',
            type: 'GET',
            dataType: 'json',
            data: {
                audioId: $('#audioId').val(),
                track: currTrack
            },
            success: function (response) {
                var item = response.Item;
                timeStart = item.TimeStart;
                duration = item.Duration;
                answer = item.Answer;

            }
        });
        //var url = 'http://localhost:54941/Track/GetTrack?trackTitle=' + trackTitle;
        //$.ajaxSetup({ cache: false });       //to prevent cache
        //$.getJSON(url, function (data) {     // lấy dữ liệu từ CSDL
        //timeStart = data.TimeStart;
        //duration = data.Duration;
        //title = data.AudioTitle;
        //answer = data.Answer;
        //});

        //res = answer.toLowerCase().split("");
        //res2 = answer.toLowerCase().split("");
        //s = '';
        //index = res.indexOf(' ');
        //count = 0;
        //str = GoiY(index);
        //id = '';
        //faile = 0;
        //loi = 0;
        //score = res.length - answer.split(" ").length + 1;
    },
    playAudio:function(){
        myAudio.currentTime = timeStart;        // bắt đầu chạy từ đoạn nào
        myAudio.play();
    }



}
audio.init();
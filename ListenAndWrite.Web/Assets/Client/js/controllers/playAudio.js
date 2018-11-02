var currTrack = 1;
var timeStart = 0, duration = 0;
var numTrack = $('#numTrack').html();
var answer = '';
var myAudio = document.getElementById('audio');
var controller = 0;
var flag = true;
var sameWords='';
var result = '';
var scores = [];
var score = 0;
var numHint = 0;
$("#submit").attr('disabled', 'disabled');
$("#btn-next2").hide();
$("#btn-score").hide();
$('#hint').attr('disabled', 'disabled');
$("#btn-prev").attr('disabled', 'disabled');
$('#stop').attr('disabled', 'disabled');
$('#chartContainer').hide();
var audio = {
    init: function () {
        audio.initDialog();
        audio.getTrack(currTrack);
        audio.registerEvents();
    },
    registerEvents: function () {
        $('#hint').click(function () {
            var hintWords = answer.split(" ");
            if (numHint < hintWords.length) {
                $('#hintword').append(hintWords[numHint] + " ");
                numHint++;
            }
            
        });
        $('#btn-play').click(function () {
            if (scores[currTrack-1] != undefined) {
                $("#submit").attr('disabled', 'disabled');
            }
            else
                $("#submit").removeAttr('disabled');
            $('#hint').removeAttr('disabled');
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
            //$('#hintword').html('');
        });
        $('.btn-next').click(function () {
            $('#result').html("");
            
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
            flag = false;
            $('#currentTrack').html(currTrack);
            $('.btn-prev:disabled').removeAttr('disabled');               // 
            $('#btn-play').removeAttr('disabled');                      // hiện nút play
            console.log(numTrack);
            if ((currTrack + '') >= numTrack)                              // ẩn nút next nếu hết track
                $(this).attr('disabled', 'disabled');
            $('textarea').val('');                                          // xóa hết câu trả lời
            $('div#answer').html('');                                       // xóa hết đáp án

            $("#btn-next2").hide();
        });
        $('.btn-prev').click(function () {
            $('#result').html("");
            
            $('#chartContainer').hide();
            flag = true
            $('#hint').attr('disabled', 'disabled');
            $('#hintword').html('');
            $('#stop').attr('disabled', 'disabled');
            myAudio.pause();
            clearInterval(controller);
            if (currTrack > 1)
                currTrack--;
            audio.getTrack(currTrack);
            flag = false;
            $('#currentTrack').html(currTrack);
            $('.btn-next:disabled').removeAttr('disabled');
            $('#btn-play').removeAttr('disabled');
            if (currTrack <= 1)
                $(this).attr('disabled', 'disabled');
            $('textarea').val('');
            $('div#answer').html('');
            $("#btn-next2").hide();
        });
       $("#submit").click(function () {
            var input = $('#audioScript').val();
            var listILetters = input.toLowerCase().split("");
            $('#dialog').html("");
            for (var i = 0; i < listILetters.length; i++) {
                if (listILetters[i] == ' ')
                    $('#dialog').append("<span>&nbsp&nbsp&nbsp</span><input id=\"char"+i+"\" type=\"hidden\" value=\" \"/>");
                else if(listILetters[i] == 'a')
                    $('#dialog').append("<select id=\"char" + i + "\" style=\"width:40px;height:40px;\"><option value=\"a\">a</option><option value=\"â\">â</option><option value=\"à\">à</option></select>");
                else if (listILetters[i] == 'e')
                    $('#dialog').append("<select id=\"char" + i + "\" style=\"width:40px;height:40px;\"><option value=\"e\">e</option><option value=\"é\">é</option><option value=\"è\">è</option></select>");
                else if (listILetters[i] == 's')
                    $('#dialog').append("<select id=\"char" + i + "\" style=\"width:40px;height:40px;\"><option value=\"s\">s</option><option value=\"ç\">ç</option></select>");
                else if (listILetters[i] == 'u')
                    $('#dialog').append("<select id=\"char" + i + "\" style=\"width:40px;height:40px;\"><option value=\"u\">u</option><option value=\"ù\">ù</option></select>");
                else if (listILetters[i] == 'o')
                    $('#dialog').append("<select id=\"char" + i + "\" style=\"width:40px;height:40px;\"><option value=\"o\">o</option><option value=\"ô\">ô</option></select>");
                else if (listILetters[i] == 'i')
                    $('#dialog').append("<select id=\"char" + i + "\" style=\"width:40px;height:40px;\"><option value=\"i\">i</option><option value=\"î\">î</option></select>");
                else
                    $('#dialog').append("<input id=\"char" + i + "\" type=\"text\" style=\"height:40px;width:40px\" value=\"" + listILetters[i] + "\"/>");
            }
            $('#dialog').dialog("open");
            

            //last = input.charAt(input.length - 1);
            //if (res[0] == null) {
            //    myAudio.pause();            // dừng phát
            //    clearInterval(controller);
            //    if (currTrack == numTrack)          // nếu làm đến câu cuối thì hiện nút xem điểm
            //        $('#btn-score').show();
            //    if ((currTrack + '') < numTrack)
            //        $("#btn-next2").show();
            //    $('#goiy').html('');
            //    flag = true;
            //    $('#stop').attr('disabled', 'disabled');

            //    // điểm
            //    let a = (score * 10 - faile) / score;
            //    if (a < 0)
            //        a = 0;
            //    scores[currTrack - 1] = a;
            //    console.log(scores[currTrack - 1]);
            //}
        });

    },
    getTrack: function (id) {
        $.ajax({
            async: false,
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
        numHint = 0;
        score = answer.split(" ").length;
        if (scores[currTrack-1] != undefined) {
            $("#submit").attr('disabled', 'disabled');
            $('#result').append("<span style=\"color:blue;\">You have been answer this question</span><br/>Answer: <span style=\"color:blue;\">" + answer + "</span><br/>Point: <span style=\"color:blue;\">" + scores[currTrack - 1] + "/10</span>");
        }
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
    },
    compareInput: function (input, answer) {
        $.ajax({
            async:false,
            url: '/Track/CompareInput',
            type: 'GET',
            dataType: 'json',
            data: {
                input: input,
                answer: answer
            },
            success: function (response) {
                sameWords = response.SameWords;
            }
        });
    },
    initDialog: function () {
        $('#dialog').dialog({
            width: 'auto',
            resizable: true,
            autoOpen: false,
            modal: true,
            buttons: {
                'Submit': audio.finalSubmit,
                'Cancel': function () {
                    $('#dialog').html("");
                    $('#dialog').dialog('close');
                    
                }
            }
        });
    },
    finalSubmit: function () {
        var input = $('#audioScript').val();
        var listIWords = input.toLowerCase().split(" ");
        var lenghtOfInput = input.length;
        var finalInput = '';
        for (var i = 0; i < lenghtOfInput; i++) {
            
            var character = $('#char' + i).val();
            finalInput += character;
        }
        audio.compareInput(finalInput, answer);
        var listWords = sameWords.split(" ");
        var i = 0;
        var j = 0;
        result = "";
        for (i ; i < listIWords.length; i++) {
            if (j == listWords.length) {
                result += "<span style=\"color:red;font-size: 32px\"><strike>" + listIWords[i] + "</strike> </span>";
            }
            for (j; j < listWords.length ; j++) {
                if (listWords[j] == listIWords[i]) {
                    result += "<span style=\"color:blue;font-size: 32px\">" + listIWords[i] + " </span>";
                    j++;
                    break;
                }
                else {
                    result += "<span style=\"color:red;font-size: 32px\"><strike>" + listIWords[i] + "</strike> </span>";
                    break;
                }

            }

        }
        $('#result').html(result);
        $('#dialog').dialog('close');
        myAudio.pause();
        clearInterval(controller);
        if (currTrack == numTrack)          // nếu làm đến câu cuối thì hiện nút xem điểm
            $('#btn-score').show();
        if ((currTrack + '') < numTrack)
            $("#btn-next2").show();
        $('#goiy').html('');
        flag = true;
        $('#stop').attr('disabled', 'disabled');
        $("#submit").attr('disabled', 'disabled');

        // điểm
        
        let a = (sameWords.split(" ").length - numHint) * 10 / score;
        if (sameWords == "") a = 0;
        if (a < 0)
            a = 0;
        scores[currTrack - 1] = a;
        $('#result').append("<br/>Answer: <span style=\"color:blue;\">" + answer + "</span><br/>Point: <span style=\"color:blue;\">" + scores[currTrack - 1] + "/10</span>");

    }
    //compare: function (input, answer) {
    //    var F = [];
    //    var inputs = input.toLower().split(' ');
    //    var subStrs = answer.toLower().split(' ');
    //    var saves = [];
    //    for (int q = 0; q <= subStrs.Length; q++)
    //    {
    //        F[i, 0] = 0;
    //    }
    //    for (int i = 0; i <= inputs.Length; i++)
    //    {
    //        F[0, i] = 0;
    //    }

    //    for (int i = 0; i < subStrs.Length; i++)
    //    {
    //        for (int j = 0; j < inputs.Length; j++)
    //        {
    //            if (inputs[j] == subStrs[i])
    //            {
    //                F[i + 1, j + 1] = F[i, j] + 1;
    //                saves[F[i + 1, j + 1] - 1] = inputs[j];
    //            }
    //            else
    //            {
    //                F[i + 1, j + 1] = Math.Max(F[i + 1, j], F[i, j + 1]);
    //            }
    //        }
    //    }

    //    String save = String.Join(" ", saves, 0, F[subStrs.Length, inputs.Length]);
            
            
    //}


}
audio.init();
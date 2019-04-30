'use strict';

(function () {

    $(function () {
        $('#load-news').click(function () {
            $('#top-news').load('news.html');
        });
    });
    $(window).scroll(function (event) {
        var scroll = $(window).scrollTop();
       
        if (scroll >= 550) {

            $('#top-news').load('news.html');
               
        }
    });
})();
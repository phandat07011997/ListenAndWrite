/**
 * Escritor v1.0.0 - Blogging and Magazine Responsive HTML5 Template
 * @copyright 2018 PuffinThemes
 * @license ISC
 */
!function(){"use strict";$(".js-hot-posts").owlCarousel({loop:!0,margin:0,nav:!0,dots:!1,touchDrag:!1,rtl:!1,mouseDrag:!1,autoplay:!0,items:1,animateOut:"slideOutUp",animateIn:"slideInUp",navText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"]}),$(".js-load-more").owlCarousel({loop:!0,margin:0,nav:!0,dots:!1,touchDrag:!1,rtl:!1,mouseDrag:!1,autoplay:!0,items:1,animateOut:"fadeOut",animateIn:"fadeIn",navText:["<i class='fa fa-angle-left'></i>","<i class='fa fa-angle-right'></i>"]}),$("ul.menu.flex").flexMenu(),$("#JS-openButton").on("click",function(){$("body").addClass("JS-show-menu")}),$("#JS-closeButton").on("click",function(){$("body").removeClass("JS-show-menu")}),$(".JS-search-trigger").on("click",function(){$("body").addClass("JS-search-active").css({height:"100%",overflow:"hidden"})}),$(".JS-form-close").on("click",function(){$("body").removeClass("JS-search-active").css({height:"100%",overflow:"visible"})}),$(document).ready(function(){function t(){$("[data-sticky_column]").stick_in_parent({parent:"[data-sticky_parent]",offset_top:40}),$("[data-sticky_column]").on("sticky_kit:bottom",function(){$(this).parent().css("position","static")}).on("sticky_kit:unbottom",function(){$(this).parent().css("position","relative")})}function i(){$("[data-sticky_column]").trigger("sticky_kit:detach")}function n(){window.innerHeight?window.innerHeight:$(window).height(),o=window.innerWidth?window.innerWidth:$(window).width()}var o;t(),(o=$(window).width())<991?i():t(),n(),$(window).on("resize",function(){n(),o<991?i():t()})}),$(".play-lists").niceScroll({styler:"fb",cursorcolor:"#ea5050",cursorwidth:"5px",zindex:"9",mousescrollstep:20,background:"#f1f1f9"}),$(".zoom-gallery").magnificPopup({delegate:"a",type:"image",closeOnContentClick:!1,closeBtnInside:!1,mainClass:"mfp-with-zoom mfp-img-mobile",image:{verticalFit:!0},gallery:{enabled:!0},zoom:{enabled:!0,duration:300,opener:function(t){return t.find("img")}}})}(jQuery);
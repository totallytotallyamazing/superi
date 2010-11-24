/// <reference path="jquery.js" /

var BasePageExtender = {
    initialize: function BasePageExtender_initialize() {
        $(function () {
            $("#ourCoords, .editContentLink").fancybox(
            {
                hideOnContentClick: false,
                hideOnOverlayClick: false,
                showCloseButton: true,
                titlePosition: "over"
            });

            if (!isHomePage) {
                $("#logoBox").css("cursor", "pointer").click(function () { location.href = "/"; });
            }

            $("#searchField").watermark({ html: "Слово + Enter", cls: "watermark small" });
        });
    }
};


ProductClientExtensions = {
    validateQuestion: function () {
        var url = "/Captcha/ValidateCaptcha";
        var result = true;

        var captchaGuid = document.getElementById("captcha_guid").value;
        var body = null;
        eval('body = {' + encodeURIComponent("value") + ' : "' + encodeURIComponent($("#Captcha").val()) + '", "captcha-guid": "' + captchaGuid + '"}');


        var completedCallback = function (data) {
            var responseData = data;
            if (responseData != 'true') {
                result = false;
            }
        };

        $.ajax({ type: "POST", url: url, success: completedCallback, async: false, data: body });
        if (!result) {
            alert("Неправильно введены символы!");
            OnCaptchaValidationError();
        }
        return result;
    },

    questionSend: function () {
        $("#quickQuestion").empty();
        $("<div>Запрос отправлен</div>").appendTo("#quickQuestion");
    },

    updateMainImage: function (src) {
        var href = "/Content/ProductImages/" + src;
        $.get("/Graphics/ShowMain/" + src + "?alt=" + this.alt, function (data) {
            $(".productModal #imgProduct a.mi").html(data);
        });
    },

    bindFancy: function () {
        $(".productFancy").fancybox({
            titlePosition: "over",
            hideOnOverlayClick: false,
            autoScale: false,
            onComplete: function () {
                window.setTimeout($.fancybox.resize, 200);
                ProductClientExtensions.bindFancy();
                ImagePreviews.Initialize();
            }
        });
        $("#quickQuestionLink").click(function () {
            $("#quickQuestion").css("display", "block");
            $.fancybox.resize();
        });
    },

    _adjustDimensions: function () {
        ProductClientExtensions._adjustProductContainerHeight();
        $("#footer").hide();
        $("#footer").show();
    },

    _adjustProductContainerHeight: function () {
        var maxImgHeight = 0;
        $(".productItem .img").each(function () {
            if (this.offsetHeight > maxImgHeight)
                maxImgHeight = this.offsetHeight;
        });
        var maxTextHeight = 0;
        $(".productItem .text").each(function () {
            if (this.offsetHeight > maxTextHeight)
                maxTextHeight = this.offsetHeight;
        });

        $(".productItem .img").height(maxImgHeight);
        $(".productItem .text").height(maxTextHeight);
    },

//    _adjustProductContainerWidth: function () {
//        $(".productItem").each(function () {
//            var width = $(this).find("img").width();
//            if (width) {
//                $(this).width(width);
//            }
//        })
//    },

    initialize: function () {
        $(function () {
            $(window).load(ProductClientExtensions._adjustDimensions);
        })
    }
};

ImagePreviews = {
    Initialize: function () {
        $(function () {
            ImagePreviews._initPreviews();
        });
    },

    _initPreviews: function () {
        $(".imageItem img").click(function (ev, elem) {
            var src = this.src.substring(1 * this.src.lastIndexOf("/") + 1 * 1);
            ProductClientExtensions.updateMainImage(src);
            $(".fadeImage").fadeOut(0);
            $(this).next("div").css("display", "block").fadeTo(0, 0.5);

        });

        window.setTimeout(ImagePreviews._calculateDimensions, 500);
    },

    _calculateDimensions: function () {
        $(".fadeImage").each(function () {
            var width = $(this).prev("img").width();
            var height = $(this).prev("img").height() + 5;
            this.style.width = width + "px";
            this.style.height = height + "px";
            this.style.position = "relative";
            this.style.left = 0 + "px";
            this.style.top = -height + "px";
            $(this).fadeTo(0.3);
            this.style.background = "White";
            this.style.display = "none";
        });

        $(".fadeImage").eq(0).fadeTo(0, 0.5);
    }
};

ProductVariant = {
    Initialize: function () {
        $(function () {
            ProductVariant._initVariant();
        });
    },

    _initVariant: function () {
        $("td.productVariant .caption a").eq(0).addClass("current");
        $("td.productVariant .caption a").not(".current").click(ProductVariant._itemClick);
    },

    _itemClick: function () {
        $("td.productVariant .caption a").unbind("click").removeClass("current");
        $(this).addClass("current");
        $("td.productVariant .caption a").not(".current").click(ProductVariant._itemClick);

        var id = this.id.replace("pv_", "");
        var src = this.getAttribute("imgSource");
        ProductVariant._updateVariantSelection(id, src);
    },

    _updateVariantSelection: function (id, src) {
        ProductClientExtensions.updateMainImage(src);
    }
};

var Subscribe = {
    initialize: function () {
        $(function () {
            $("#subscribeMe").click(function () {
                Subscribe._showEditor();
            });
        })
    },

    _showEditor: function () {
        $("#bubbleText").empty();
        $('<input type="text" id="subscribeEmail" style="width:135px;" />').appendTo("#bubbleText");
        $('<input type="button" value="Подписаться" style="font-size:10px;" />').click(function () {
            var value = $("#subscribeEmail").val();
            var regex = /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/;
            if (regex.test(value)) {
                $.post("/Clients/Subscribe/" + $("#subscribeEmail").val(), function (data) {
                    $("#bubbleText").empty();
                    if (data == 0)
                        $('<span class="txtBubbleNew">Вы подписаны на новости!</span>').appendTo("#bubbleText");
                    else if (data == 1)
                        $('<span class="txtBubbleNew">Вы уже подписаны</span>').appendTo("#bubbleText");
                    else if (data == 2) {
                        $('<span class="txtBubbleNew">Произошла ошибка</span>').appendTo("#bubbleText");
                        $('<span class="txtBubbleNew">Попробуйте позже</span>').appendTo("#bubbleText");
                    }
                });
            }
            else {
                alert("Email введен неправильно");
            }
        }).appendTo("#bubbleText");
    }
};
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
        });
    }
};


ProductClientExtensions = {
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
    },

    _adjustedCount: 0,

    _adjustDimensions: function () {
        ProductClientExtensions._adjustProductContainerHeight();
        ProductClientExtensions._adjustProductContainerWidth();

        ProductClientExtensions._adjustedCount++;
        if (ProductClientExtensions._adjustedCount > 10) {
            window.clearInterval(ProductClientExtensions._intervalId);
        }

    },

    _adjustProductContainerHeight: function () {
        var maxHeight = 0;
        $(".productItem").each(function () {
            if (this.offsetHeight > maxHeight)
                maxHeight = this.offsetHeight;
        });
        $(".productItem").height(maxHeight);
    },

    _adjustProductContainerWidth: function () {
        $(".productItem").each(function () {
            var width = $(this).find("img").width();
            if (width) {
                $(this).width(width);
            }
        })
    },

    _intervalId: 0,

    initialize: function () {
        $(function () {
            ProductClientExtensions._intervalId = window.setInterval(ProductClientExtensions._adjustDimensions, 500);
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

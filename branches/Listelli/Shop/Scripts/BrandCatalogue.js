﻿/// <reference path="jquery.js"/>
/// <reference path="jquery.combobox.js"/>

var BrandCatalogue = {
    initialize: function () {
        $(function () {
            $('#selectBrand')
            .combobox({
                comboboxContainerClass: "cbBrandContainer",
                comboboxValueContainerClass: "cbBrandValueContainer",
                comboboxDropDownButtonClass: "cbBrandButton",
                comboboxDropDownClass: "cbBrandDropDown",
                comboboxValueContentClass: "cbBrandValueContent",
                animationType: "fade",
                width: "153px"
            });
            BrandCatalogue.fetchBrands();

            $(".cbBrandContainer ul li").click(function () {
                window.setTimeout(BrandCatalogue.fetchBrands, 100);
            })
        });
    },

    fetchBrands: function () {
        var element = document.getElementById("selectBrand")
        var id = element.options[element.selectedIndex].value;
        $.get("/BrandCatalog/Brands/BrandLinks/" + id, function (data) {
            $("#topMenu").html(data);
            //$("a.txtSubMenuItem").click(function () { debugger;  this.style.textDecoration = "none"; href = ""; return false; })
            $("a.txtSubMenuItem").click(function () { $("a.txtSubMenuItem").css("text-decoration", "underline"); this.style.textDecoration = "none"; this.blur(); });
        });
    },

    updateDockContent: function (params) {
        var data = null;
        if (params.get_object)
            data = params.get_object();
        else
            data = params;

        $("#dockWrapper").html(data.ThumbnailsLayout);

        if (data.ShowPrev)
            $("#leftArrow").css("visibility", "visible")
            .unbind()
            .click(function () { BrandCatalogue._changePage(data.BrandId, data.GroupId, data.Page * 1 - 1) });
        else
            $("#leftArrow").css("visibility", "hidden");

        if (data.ShowNext)
            $("#rightArrow").css("visibility", "visible")
            .unbind()
            .click(function () { BrandCatalogue._changePage(data.BrandId, data.GroupId, data.Page * 1 + 1) });
        else
            $("#rightArrow").css("visibility", "hidden");

        $(".txtPageName").html(data.BrandName);
        $(".txtDescription").html(data.BrandDescription);

        $("#thumbnails").show();

        $('#dock').Fisheye(
           {
               maxWidth: 20,
               items: 'a',
               itemsText: 'span',
               container: '.dock-container',
               itemWidth: 100,
               proximity: 30,
               alignment: 'left',
               valign: 'bottom',
               halign: 'center'
           });
        var imageArray = null;
        $(".dock-item").click(function () {
            //mainCatalogImage
            var imgAnchor = this;
            imageArray = data.ImageArray;
            $.post(this.href, function (data) {
                $("#mainCatalogImage").html(data);
                var index = 1 * imgAnchor.getAttribute("index");
                $(".fancyCustom").click(function () {
                    var specialArray = new Array();
                    for (var i = 0; i < imageArray.length; i++) {
                        specialArray[i] = imageArray[i];
                    }
                    $.fancybox(specialArray, { index: index, hideOnContentClick: true, showCloseButton: false, type: "image", padding:0, margin:20 });
                });
                $("#mainCatalogImage img").load(function () {
                    $("#contentBoxBrandCatalog").height(this.offsetHeight); ;
                });
            });
            $(".dock-item").removeClass("selecteditem");
            $(this).addClass("selecteditem");
            this.blur();
            return false;
        });
    },

    _changePage: function (brandId, groupId, page) {
        $.post("/BrandCatalog/Brands/Index?groupId=" + groupId + "&brandId=" + brandId + "&page=" + page, function (data) {
            BrandCatalogue.updateDockContent(data);
        });
    }
};



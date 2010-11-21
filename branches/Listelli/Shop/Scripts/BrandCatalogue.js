﻿/// <reference path="jquery.js"/>
/// <reference path="jquery.combobox.js"/>

var BrandCatalogue = {
    initialize: function () {
        $(function () {
            $("#contentBoxBrandCatalog").css("position", "static");
            window.setTimeout(function () {
                $("#contentBoxBrandCatalog").css("position", "static");
            }, 150);
            window.setTimeout(function () {
                $("#contentBoxBrandCatalog").css("position", "relative");
            }, 300);

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
        $.get("/BrandCatalog/Brands/BrandLinks/" + id, function (data) { $("#topMenu").html(data); });
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

        $(".dock-item").click(function () {
            //mainCatalogImage
            $.post(this.href, function (data) {
                $("#mainCatalogImage").html(data);
                window.setTimeout(function () {
                    $("#contentBoxBrandCatalog").css("position", "static");
                }, 150);
                window.setTimeout(function () {
                    $("#contentBoxBrandCatalog").css("position", "relative");
                }, 300);
            });
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



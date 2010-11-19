/// <reference path="jquery.js"/>
/// <reference path="jquery.combobox.js"/>

var BrandCatalogue = {
    initialize: function () {
        $(function () {
            $('#selectBrand').combobox({
                comboboxContainerClass: "cbBrandContainer",
                comboboxValueContainerClass: "cbBrandValueContainer",
                comboboxDropDownButtonClass: "cbBrandButton",
                comboboxDropDownClass: "cbBrandDropDown",
                comboboxValueContentClass: "cbBrandValueContent",
                animationType: "fade",
                width: "153px"
            })
            .change(function () {
                BrandCatalogue.fetchBrands();
            });
            BrandCatalogue.fetchBrands();
        });
    },

    fetchBrands: function () {
        var element = document.getElementById("selectBrand")
        var id = element.options[element.selectedIndex].value; 
        $.get("/BrandCatalog/Brands/BrandLinks/" + id, function (data) { $("#topMenu").html(data); });
    }
};


function updateDockContent() {
    window.setTimeout(function () {
        var width = 0;
        $("#dockContent img").each(function () { width += this.offsetWidth; });
        $("#dockContent").width(width + $("#dockContent img").size() * 5);
        $('#dock').Fisheye(
       {
           maxWidth: 30,
           items: 'a',
           itemsText: 'span',
           container: '.dock-container',
           itemWidth: 100,
           proximity: 60,
           alignment: 'left',
           valign: 'bottom',
           halign: 'center'
       }
    );
    }, 1000);
}
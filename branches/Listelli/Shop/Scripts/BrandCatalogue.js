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
        var element =  document.getElementById("selectBrand")
        var id = element.options[element.selectedIndex].value; ;
        $.get("/BrandCatalog/Brands/BrandLinks/" + id, function (data) { $("#topMenu").html(data); });
    }
};



/// <reference path="jquery.js"/>
/// <reference path="jquery.combobox.js"/>

/*

comboboxContainerClass
the CSS class name for the entire control
comboboxValueContainerClass
the CSS class name for the area that contains the selected value and the drop-down button
comboboxValueContentClass
the CSS class name for the selected value displayed
comboboxDropDownClass
the CSS class name for the drop down list container
comboboxDropDownButtonClass
the CSS class name for the drop down button 
comboboxDropDownItemClass
the CSS class name for an item in the drop down list 
comboboxDropDownItemHoverClass
the CSS class name for an item when the mouse is over
comboboxDropDownGroupItemHeaderClass
the CSS class name for the group header item in the drop down list 
comboboxDropDownGroupItemContainerClass
the CSS class name for the group section in the drop down list 
animationType
the CSS class name for the type of animation for the drop down list
width
the width of the combobox control
height
the maximum height of the drop-down list. 


*/

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
                });
        });
        
    }
}



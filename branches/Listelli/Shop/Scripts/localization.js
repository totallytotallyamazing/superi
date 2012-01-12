var Localization = {
    bindLocalizationSwitch: function () {
        $(function () {
            $("a[data-localization-for]")
            .click(function () {
                if ($(this).hasClass("current"))
                    return false;
                else {
                    var propertyKey = $(this).attr("data-localization-for");
                    var lang = $(this).attr("rel");
                    $(this).addClass("current").siblings("a").removeClass("current");
                    $("div[data-localization-for='" + propertyKey + "']").hide(0).filter("div[rel='" + lang + "']").show(0);
                }
            });
        });
    }
}
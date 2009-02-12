function processVideos(response) {
    //getSubMenu().css("display", "none").fadeIn(500);
    for (var i in response) {
        $.preloadImages("images/albumimages/" + response[i].Image);
//        if (i == 0) {
//            var item = createMenuItem(response[i].Name, imageSwappedVideo).attr({ source: response[i].Source, image: "images/VideoImages/" + response[i].Image });
//            item.children().attr("class", "subMenuItemActive");
//            appendSubMenuItem(item);
//        }
//        else {
            appendSubMenuItem(createMenuItem(response[i].Name, subMenuItemClickedVideo).attr({source: response[i].Source, image: "images/VideoImages/" + response[i].Image }));
   //     }
    }
   // imageSwappedVideo();
}

function subMenuItemClickedVideo(attrs){
    cleanUp();
    swapImage($(attrs.target).parent().attr("image"), imageSwappedVideo);
    updateSubMenuStyles();
    $(attrs.target).attr("class", "subMenuItemActive");
    updateSubMenuClickHandlers(subMenuItemClickedVideo);
}

function imageSwappedVideo(){
    var source = $(".subMenuItemActive").parent().attr("source");
    $(".videoPlaceHolder").draggable().css("display", "block").flash({ src: "Embed/player.swf", width: "480", height: "360", flashvars: { skin: "http://demo.akula.com.ua/tina/embed/stylish.swf", file: "../Videos/" + source} });
}

function onRetriveVideosFail(){

}
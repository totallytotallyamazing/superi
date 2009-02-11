function processAlbums(response) {
    //getSubMenu().css("display", "none").fadeIn(500);
    for (var i in response) {
        if (i == 0) {
            var item = createMenuItem(response[i].Name + "(" + response[i].Year + ")").attr({ albumId: response[i].ID, image: "images/albumimages/" + response[i].Image })
            item.children().attr("class", "subMenuItemActive");
            appendSubMenuItem(item);
        }
        else {
            appendSubMenuItem(createMenuItem(response[i].Name + "(" + response[i].Year + ")", subMenuItemClicked).attr({ albumId: response[i].ID, image: "images/albumimages/" + response[i].Image }));
        }
    }
    
}

function subMenuItemClicked(attrs) {
    swapImage($(attrs.target).parent().attr("image"), imageSwapped);
    updateSubMenuStyles();
    $(attrs.target).attr("class", "subMenuItemActive");
    updateSubMenuClickHandlers(subMenuItemClicked);
}

function imageSwapped() {
    
}

function onRetriveAlbumsFail() { 
}
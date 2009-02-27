var currentNewsPage = 1;

function processNews(response) {
    if (response > 1)
        initPages(response);
    else
        loadNews(1);
}

function initPages(pageCount) {
    for (var i = 1; i <= pageCount; i++) {
        if (i !== currentNewsPage)
            $("<a>").html(pageCount).appendTo("#newsBottomPager").click(pageChanged);
        else
            $("span").html(pageCount).appendTo("#newsBottomPager");
    }
}

function pageChanged(elem) {
    loadNews(+$(elem.target).html());
}

function loadNews(pageNumber) {
    var wRequest = new Sys.Net.WebRequest();
    wRequest.set_url("News.aspx?page=" + pageNumber);
    wRequest.set_httpVerb("GET");
    wRequest.set_userContext("user's context");
    wRequest.add_completed(OnWebRequestCompleted);
    wRequest.invoke();  
}

function OnWebRequestCompleted(executor, eventArgs) {
    $("#newsContent").empty();
    $("#newsContainer").css("display", "block");
    $(executor.get_responseData()).appendTo("#newsContent");
    $(".newsDetail span").click(detailsClicked);
}

function detailsClicked(el) {
    $("#newsTextContainer").html($(el.target).attr("details"));
    $("#newsTextContainer").dialog("open");
    $("#newsTextContainer").jScrollPane();
}

function onRetriveNewsFail() {
    alert("news failed");
}
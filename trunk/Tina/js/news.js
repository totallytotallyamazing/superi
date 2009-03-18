var currentNewsPage = 1;
var newsPageCount = 1;
function processNews(response) {

    appendSubMenuItem(createMenuItem("Архив", loadArchive));
    appendSubMenuItem(createMenuItem("Премии и награды", loadAwards));
    appendSubMenuItem(createMenuItem("Творчество", loadArt));
   // appendSubMenuItem(createMenuItem("Личное", loadPersonal));

    EndRequestHandler();
    newsPageCount = +response;
    if (response > 1)   
        initPages(newsPageCount);
    loadNews(1);
}

function loadAwards() {
    BeginRequestHandler();
    var wRequest = new Sys.Net.WebRequest();
    wRequest.set_url("Awards.htm");
    wRequest.set_httpVerb("GET");
    wRequest.set_userContext("user's context");
    wRequest.add_completed(AwardsRequestCompleted);
    wRequest.invoke();
}

function AwardsRequestCompleted(executor, eventArgs) {
    EndRequestHandler();
    $("#newsTextContainer").empty();
    $(executor.get_responseData()).appendTo("#newsTextContainer");
    $("#newsTextContainer").dialog("open");
    $("#newsTextContainer").jScrollPane();
}

function loadArt() {
    BeginRequestHandler();
    var wRequest = new Sys.Net.WebRequest();
    wRequest.set_url("Art.htm");
    wRequest.set_httpVerb("GET");
    wRequest.set_userContext("user's context");
    wRequest.add_completed(AwardsRequestCompleted);
    wRequest.invoke();
}

function loadPersonal() {
    BeginRequestHandler();
    var wRequest = new Sys.Net.WebRequest();
    wRequest.set_url("Personal.htm");
    wRequest.set_httpVerb("GET");
    wRequest.set_userContext("user's context");
    wRequest.add_completed(AwardsRequestCompleted);
    wRequest.invoke();
}

function loadArchive()
{
    BeginRequestHandler();
    var wRequest = new Sys.Net.WebRequest();
    wRequest.set_url("Archive.aspx");
    wRequest.set_httpVerb("GET");
    wRequest.set_userContext("user's context");
    wRequest.add_completed(ArchiveRequestCompleted);
    wRequest.invoke();
}

function ArchiveRequestCompleted(executor, eventArgs)
{
    EndRequestHandler();
    $("#newsTextContainer").empty();
    $(executor.get_responseData()).appendTo("#newsTextContainer");
    $("#archiveContainer").accordion({
			autoHeight:false,
			change: function(event, ui) {$("#newsTextContainer").jScrollPane(); }
		});
	$("#archiveContainer").accordion("option", "fillSpace");
    $("#newsTextContainer").dialog("open");
    $("#newsTextContainer").jScrollPane();
}



function initPages(pageCount) {
    $("#newsBottomPager").empty();
    for (var i = 1; i <= pageCount; i++) {
        if (i !== currentNewsPage)
            $("<a>").html(i).appendTo("#newsBottomPager").click(pageChanged).css("cursor", "pointer");
        else
            $("<span>").addClass("current").html(i).appendTo("#newsBottomPager");
    }
}

function pageChanged(elem) {
    currentNewsPage = +$(elem.target).html()
    loadNews(currentNewsPage);
    initPages(newsPageCount);
    
}

function loadNews(pageNumber) {
    var wRequest = new Sys.Net.WebRequest();
    wRequest.set_url("News.aspx?page=" + pageNumber);
    wRequest.set_httpVerb("GET");
    wRequest.set_userContext("user's context");
    wRequest.add_completed(OnWebRequestCompleted);
    BeginRequestHandler();
    wRequest.invoke();  
}

function OnWebRequestCompleted(executor, eventArgs) {
    EndRequestHandler();
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
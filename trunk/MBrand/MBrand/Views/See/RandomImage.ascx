<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<script type="text/javascript">
    var workIds = <%= ViewData["workIds"] %>
    var baseFolder = '<%= ViewData["baseFolder"] %>';
    
    var currentArrayIndex = -1;

    $(function() {
        $("#zoomLink").fancybox()

        $("#randomImageHolder div img").fadeTo(0, 0.5);
        $("#randomImageHolder div img").mouseover(function() {
            $(this).fadeTo("fast", 1);
        })
        .mouseout(function() { $(this).fadeTo("fast", 0.5); });
        updateNavigation();
        
        $("#forwardLink").click(function(){
            queryServer(true, forwardSuccess);
        });

        $("#backLink").click(function(){
            queryServer(false, backSuccess);
        });
        
        if(workIds.length > 0)
        $("#forwardLink").click();

    });

    function updateNavigation() {
        if (currentArrayIndex == 0) {
            $("#backLink").css("display", "none");
        }
        else {
            $("#backLink").css("display", "inline");
        }

        if (currentArrayIndex + 1 >= workIds.length) {
            $("#forwardLink").css("display", "none");
        }
        else {
            $("#forwardLink").css("display", "inline");
        }
        
        //$("#forwardLink").attr("href", "/See/ShowWork/" + workIds[+currentArrayIndex + 1]);
        //$("#backLink").attr("href", "/See/ShowWork/" + workIds[+currentArrayIndex + 1]);
    }

    function forwardSuccess(response) {
        currentArrayIndex++;
        updateNavigation();
        updateContent(response);
    }

    function backSuccess(response) {
        currentArrayIndex--;
        updateNavigation();
        updateContent(response);
    }
    
    function queryServer(fv, completed){
        var index = 0;
        if(fv){
            index = +currentArrayIndex + 1;
        }
        else{
            index = +currentArrayIndex - 1;
        }
        var webRequest = new Sys.Net.WebRequest();
        webRequest.set_url("/See/ShowWork/" + workIds[index]);
        webRequest.set_httpVerb("GET");
        
        webRequest.add_completed(completed);
        
        webRequest.invoke();  
    }
    
    function updateContent(response)
    {
        var item = response.get_object();//Sys.Serialization.JavaScriptSerializer.deserialize(response.get_data())
        var image = item.Image;
        var preview = item.Preview;
        var description = item.Description;
        
        $("#mainImage").attr("src", baseFolder + "preview/" + preview);
        if(image == null || image == ''){
           $get("zoomLink").style.display='none';
        }
        else{
            $get("zoomLink").href = baseFolder + image;
            $get("zoomLink").style.display='inline';
        }
        $("#description").html(description);

    }
 
</script>

<div id="randomImageHolder">
    <div id="forward">
        <a href="#" id="forwardLink">
            <%=Html.Image("~/Content/img/next.png")%>
        </a>
<%--        <%= Ajax.ActionLink("[replace]", "ShowWork", new { id = 0 }, 
                new AjaxOptions 
                {
                    OnSuccess = "forwardSuccess"
                }, 
                new { id="forwardLink"}
            )
            .Replace("[replace]", Html.Image("~/Content/img/next.png"))
        %>--%>
    </div>
    <div id="back">
        <a href="#" id="backLink">
            <%=Html.Image("~/Content/img/back.png") %>
        </a>
    </div>
    <div id="zoom">
        <a id="zoomLink" href="<%= ViewData["baseFolder"] + "" + ViewData["firstImage"]  %>">
            <%= Html.Image("~/Content/img/zoom.png", new { id="preview", style="border:none;"})%>
        </a>
    </div>
    <%= Html.Image("b", new { id = "mainImage" })%>
</div>
<div id="description">
</div>
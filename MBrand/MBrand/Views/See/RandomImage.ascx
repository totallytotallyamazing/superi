<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<script type="text/javascript">
    var workIds = <%= ViewData["workIds"] %>
    var baseFolder = '<%= ViewData["baseFolder"] %>';
    
    var currentArrayIndex = -1;

    $(function() {
        $("#zoomLink").fancybox()

        $("#randomImageHolder div img").fadeTo(0, 0.2);
        $("#randomImageHolder div img").mouseover(function() {
            $(this).fadeTo("fast", 1);
        })
        .mouseout(function() { $(this).fadeTo("fast", 0.2); });
        updateNavigation();
        if($("#forwardLink").css("display")!="none")
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
        
        $("#forwardLink").attr("href", "/See/ShowWork/" + workIds[+currentArrayIndex + 1]);
        $("#backLink").attr("href", "/See/ShowWork/" + workIds[+currentArrayIndex + 1]);
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
    
    function updateContent(response)
    {
        var item = Sys.Serialization.JavaScriptSerializer.deserialize(response.get_data())
        var image = item.Image;
        var preview = item.Preview;
        var description = item.Description;
        
        $("#mainImage").attr("src", baseFolder + "preview/" + preview);
        $get("zoomLink").href = baseFolder + image;
        $("#description").html(description);
        
        try{
            $get("forwardLink").href = "/See/ShowWork/" + workIds[1*currentArrayIndex + 1];
            $get("backLink").href = "/See/ShowWork/" + workIds[currentArrayIndex-1];
        }
        catch(ex){}
    }
 
</script>

<div id="randomImageHolder">
    <div id="forward">
        <%= Ajax.ActionLink("[replace]", "ShowWork", new { id = 0 }, 
                new AjaxOptions 
                {
                    OnSuccess = "forwardSuccess"
                }, 
                new { id="forwardLink"}
            )
            .Replace("[replace]", Html.Image("~/Content/img/next.png"))
        %>
    </div>
    <div id="back">
        <%= Ajax.ActionLink("[replace]", "ShowWork", new { id = 0 }, 
                new AjaxOptions 
                { 
                    OnSuccess = "backSuccess" 
                }, 
                new { id="backLink"}
            )
            .Replace("[replace]",Html.Image("~/Content/img/back.png") )%>
    </div>
    <div id="zoom">
        <a id="zoomLink" href="<%= ViewData["baseFolder"] + "" + ViewData["firstImage"]  %>">
            <%= Html.Image("~/Content/img/zoom.png", new { id="preview", style="border:none;"})%>
        </a>
    </div>
    <%= Html.Image(ViewData["baseFolder"] + "preview/" + ViewData["firstPreview"], new { id = "mainImage" })%>
</div>
<div id="description">
    <%= ViewData["firstDescription"] %>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<script type="text/javascript">
    var workIds = <%= ViewData["workIds"] %>
    var baseFolder = '<%= ViewData["baseFolder"] %>';
    
    var currentArrayIndex = 0;

    $(function() {
        $("#zoomLink").fancybox()

        $("#randomImageHolder div img").fadeTo(0, 0.2);
        $("#randomImageHolder div img").mouseover(function() {
            $(this).fadeTo("fast", 1);
        })
        .mouseout(function() { $(this).fadeTo("fast", 0.2); });
        updateNavigation();

    });

    function updateNavigation() {
        if (currentArrayIndex == 0) {
            $("#backLink").css("display", "none");
        }

        if (currentArrayIndex >= workIds.length) {
            $("#forwardLink").css("display", "none");
        }
        
        $("#forwardLink").attr("href", "/See/ShowWork/" + workIds[+currentArrayIndex + 1]);
        $("#backLink").attr("href", "/See/ShowWork/" + workIds[+currentArrayIndex + 1]);
    }

    function forwardSuccess(response) {
        debugger;
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
        
        $("#preview").attr("src", baseFolder + "preview/" + preview);
        $("#zoomLink").arrt("href", baseFolder + image);
        $("#description").html(description);
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
    <%= Html.Image(ViewData["baseFolder"] + "preview/" + ViewData["firstPreview"])%>
</div>
<div id="description">
    <%= ViewData["firstDescription"] %>
</div>

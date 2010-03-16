<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    1
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.RenderPartial("RoutesAdmin"); %>
<% using(Html.BeginForm("PersonalData", "Request", FormMethod.Post)){ %>
    <div id="contentBoxStep1">
        <br>
        <h2>
            <%= Html.ResourceString("AboutTheTrip")%>:
        </h2>
        <br />
        <% if ((bool)ViewData["hasItems"]) Html.RenderPartial("SelectedAds");
           else Html.RenderPartial("NoAdsSelected");%>
           
        <h3>
            <%= Html.ResourceString("StartingPoint") %> <span class="lessFont">(<%= Html.ResourceString("EnterCityName")%>): </span>
        </h3>
            <div class="textBoxWrapper">
                <%= Html.DropDownList("fromCityId") %>
            </div>
        <h3>
            <%= Html.ResourceString("WhereToGo")%> <span class="lessFont">(<%= Html.ResourceString("EnterCityName")%>): </span>
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextBox("toCity") %>
            <%= Html.Hidden("toCityId") %>
        </div>       
        <% Html.RenderPartial("Calculations"); %>
        <h3>
            <%= Html.ResourceString("MoreDetails") %>:
        </h3>
        <div class="textBoxWrapper">
            <%= Html.TextArea("moreDetails", null, 5, 5, null) %><br />
            <h6>
                <%= Html.ResourceString("MoreDetailsExplanation") %>
            </h6>
        </div>       
    </div>
    <div id="daliButton" align="center">
        <input type="submit" class="next" value=""  />
    </div>
<% } %>
     <div class="clearBoth">
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Request.css" />
    <%= Ajax.DynamicCssInclude(string.Format("/Content/LocaleDependent/{0}/Request.css", Dev.Helpers.LocaleHelper.GetCultureName())) %>

    <%if(!(bool)ViewData["hasItems"]){ %>
        <script type="text/javascript">
            $(function() {
                $("#content form input, #content form textarea, #content form select").attr("disabled", "disabled").addClass("disabled");
            })
        </script>
    <%} %>
    <%else{ %>
        <%= Ajax.DynamicCssInclude("/Content/ui/jquery.ui.css") %>
        <%= Ajax.ScriptInclude("/Scripts/jquery.ui.js") %>
        <script src="/Scripts/extended/ExtendedControls.js" type="text/javascript"></script>
        
        <script type="text/javascript">
            Sys.require(Sys.components.maskedEdit, function() {
                $("td input[type='text']").maskedEdit({
                    Mask: "99",
                    AcceptNegative: 0,
                    MaskType: Sys.Extended.UI.MaskedEditType.Number,
                    PromptChararacter: ""
                });
            });

            $(function() {
                $("#content form textarea, .next").not("#fromCityId, .selectedAds input").attr("disabled", "disabled").addClass("disabled");

                if ($("#toCity").val() != "") {
                    loadCalculationData();
                }
                if ($("#toCity").val() != "") {
                    $("#content form textarea, #content form input").removeAttr("disabled").removeClass("disabled"); ;
                }


                $("#toCity").autocomplete({
                    source: "/Request/PickCity",
                    select: function(event, ui) {
                        $("#" + event.target.id + "Id").val(ui.item.id);
                    }
                });


                $("#toCity").keyup(function() {
                    if ($("#toCity").val() != "") {
                        $("#content form textarea, #content form input").removeAttr("disabled").removeClass("disabled"); ;
                    }
                    else {
                        $("#content form input, #content form textarea").not("#fromCity, #toCity").attr("disabled", "disabled").addClass("disabled");
                    }
                });

                $("td input[type='text']").keyup(function(ev) {
                    var val = this.value.replace("_", "");
                    if (val != "") {
                        var id = this.id.split("-")[1];
                        $.get("/Request/UpdateQuantity/" + id + "?quantity=" + val);

                        window.setTimeout(loadCalculationData, 300);
                    }
                })
            });
        </script>
    <%} %>
    
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftSide" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
    <asp:Literal ID="Literal2" runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal3" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    1
</asp:Content>

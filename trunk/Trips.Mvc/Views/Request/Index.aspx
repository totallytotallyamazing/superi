<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <asp:Literal runat="server" Text="<%$ Resources:WebResources, Request %>"></asp:Literal>
    »
    <asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:WebResources, Step %>"></asp:Literal>
    1
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% using(Html.BeginForm()){ %>
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
                <%= Html.TextBox("fromCity") %>
                <%= Html.Hidden("fromCityId") %>
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
        <input type="submit"  />
    </div>
<% } %>
     <div class="clearBoth">
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/Request.css" />
    <%if(!(bool)ViewData["hasItems"]){ %>
        <script type="text/javascript">
            $(function() {
                $("#content form input, #content form textarea").attr("disabled", "disabled").addClass("disabled");
            })
        </script>
    <%} %>
    <%else{ %>
        <link rel="Stylesheet" href="/Content/ui/jquery.ui.css" />
        <script type="text/javascript" src="/Scripts/jquery.ui.js"></script>
        <script type="text/javascript">
            $(function() {
                $("#content form input, #content form textarea").not("#fromCity").attr("disabled", "disabled").addClass("disabled");

                $("#toCity, #fromCity").autocomplete({
                    source: "/Request/PickCity",
                    select: function(event, ui) {
                        $("#" + this.id + "Id").val(ui.id);
                    }
                });

                $("#fromCity").keyup(function() {
                    if ($("#fromCity").val() != "") {
                        $("#toCity").removeAttr("disabled");
                    }
                    else {
                        $("#content form input, #content form textarea").not("#fromCity").attr("disabled", "disabled").addClass("disabled");
                    }
                });

                $("#toCity").keyup(function() {
                    if ($("#toCity").val() != "") {
                        $("#content form textarea, #content form input").removeAttr("disabled");
                    }
                    else {
                        $("#content form input, #content form textarea").not("#fromCity, #toCity").attr("disabled", "disabled").addClass("disabled");
                    }
                });
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

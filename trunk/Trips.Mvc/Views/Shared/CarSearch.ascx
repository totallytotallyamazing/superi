<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<%= Ajax.DynamicCssInclude("/Content/ui/jquery.ui.css") %>
<%= Ajax.ScriptInclude("/Scripts/jquery.ui.js") %>

<div id="leftBoxCarSearch">
    <div id="carSearchHeader">
        <p>
            <asp:Literal runat="server" Text="<%$ Resources:WebResources, CarSearch %>"></asp:Literal>
        </p>
    </div>
    <div id="carSearchContent">
        <% using(Html.BeginForm("CarSearch", "Catalogue", FormMethod.Get)){ %>
            <input type="text" name="searchField" id="searchField" />
            <p>
                <input type="submit" class="find" value="" />
            </p>
        <%} %>
    </div>
    <div id="carSearchFooter">
    </div>
</div>

<script>
    $(function() {
        $("#searchField").autocomplete({
            source: "/Catalogue/SearchSuggestion"
        });
    })
</script>
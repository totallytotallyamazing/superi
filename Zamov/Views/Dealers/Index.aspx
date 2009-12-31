<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<DealerPresentation>>" %>

<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% int currentCategory = Convert.ToInt32(ViewContext.RouteData.Values["id"]); %>
    <script type="text/javascript">
        var intervalId = 0;
        var intervalCount = 0;
        $(function() {
            applyDropShadows(".dealerLogoLink", "shadow3");
//            if ($.browser.msie && $.browser.version !== "8.0") {
//                $(".topDealers").width($(mainContent).width() - 30);
//                $(window).resize(function() { $(".topDealers").width($(mainContent).width() - 30); });
//            }
//            else {
                $(".topDealers").css({ width: "97%", float: "left" });
            //}
        })

        function alignDealerOnline() {
            $(".dalerOnline").each(function() {
                var dealerImage = this.nextSibling;
                this.style.marginLeft = $(dealerImage.firstChild).width();
            })
            if (intervalCount > 100) {
                window.clearInterval(intervalId);
            }
            intervalCount++;
        }
    </script>

    <%
        var topDealers = Model.Where(d => d.TopDealer);
        var dealers = Model.Where(d => !d.TopDealer);

        if (topDealers.Count() > 0)
        {%>
    <div class="topDealers">
        <%      foreach (var item in topDealers)
                {%>
        <div class="dealerLogo">
            <%if (item.OnLine)
              { %>
            <div class="dalerOnline">
            </div>
            <%} %>
            <a class="dealerLogoLink" href="/Products/<%= item.StringId %>/<%= currentCategory %>">
                <%= Html.Image("~/Image/ShowLogo/" + item.Id, new { style="border:1px solid #ccc;" })%>
            </a>
            <br />
            <a style="clear:both; display:block;" href="/Products/<%= item.StringId %>/<%= currentCategory %>">
                <%= item.Name %>
            </a>
        </div>
    <%}%>
    </div>
    
    <%  }
    foreach (var item in dealers)
    {%>
    <div class="dealerLogo">
        <%if (item.OnLine)
          { %>
        <div class="dalerOnline">
        </div>
        <%} %>
        <a class="dealerLogoLink" href="/Products/<%= item.StringId + "/" + currentCategory  %>">
            <%= Html.Image("~/Image/ShowLogo/" + item.Id, new { style="border:1px solid #ccc;" })%>
        </a>
        <br />
        <a style="clear:both; display:block;" href="/Products/<%= item.StringId %>/<%= currentCategory %>">
            <%= item.Name %>
        </a>
    </div>
    <%}
    %>
    <div style="clear: both;">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterCss("~/Content/shadows.css")%>
    <%= Html.RegisterJS("dropshadow.js")%>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
    <% int expandedGroup = (int)ViewData["expandedGroup"]; %>
    <% int currentCategory = Convert.ToInt32(ViewContext.RouteData.Values["id"]); %>
    <% List<CategoryPresentation> categories = (List<CategoryPresentation>)ViewData["categories"]; %>
    <% Func<int, int, string> selectedStyle = (categoryId, id) =>
       {
           string result = "";
           if (categoryId == id)
               result = " selected";
           return result;
           
       }; %>
    <div class="menu">
        <div class="menuHeader">
            <%= Html.ResourceString("Categories") %>
        </div>
        <div class="menuItems">
            <% foreach (var menuItem in categories)
               {%>
               <div class="menuItem<%= selectedStyle(currentCategory, menuItem.Id) %>">
                <a href="/Dealers/Index/<%= menuItem.Id %>"><%= menuItem.Name %></a>
               </div>    
                 <%if(menuItem.Id == expandedGroup && menuItem.Children.Count>0){
                       foreach (var subItem in menuItem.Children)
                       {%>
                           
                   <div class="subMenuItem<%= selectedStyle(currentCategory, subItem.Id) %>">
                        <a href="/Dealers/Index/<%= subItem.Id %>"><%= subItem.Name%></a>
                   </div>    
                  <%   }%>  
                   
                 <%} %>
             <%} %>
        </div>
    </div>
</asp:Content>

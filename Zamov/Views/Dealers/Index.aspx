<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<DealerPresentation>>" %>

<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var intervalId = 0;
        var intervalCount = 0;
        $(function() {
            applyDropShadows(".dealerLogo a", "shadow3");
            if ($.browser.msie && $.browser.version !== "8.0") {
                $(".topDealers").width($(mainContent).width() - 30);
                $(window).resize(function() { $(".topDealers").width($(mainContent).width() - 30); });
            }
            else {
                $(".topDealers").css({ width: "97%", float: "left" });
            }
            intervalId = setInterval(alignDealerOnline, 100);
        })

        function alignDealerOnline() {
            $(".dalerOnline").each(function() {
                var top = $(this.parentNode).offset().top + 5;
                var left = $(this.parentNode).offset().left + $(this.parentNode).width() + 10;
                this.style.left = left + "px";
                this.style.top = top + "px";
                intervalCount++;
                if (intervalCount == 100) {
                    clearInterval(intervalId);
                }
            }
            );
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
            <a href="/Dealers/SelectDealer/<%= item.Id %>">
                <%= Html.Image("~/Image/ShowLogo/" + item.Id, new { style="border:1px solid #ccc;" })%>
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
        <a href="/Dealers/SelectDealer/<%= item.Id %>">
            <%= Html.Image("~/Image/ShowLogo/" + item.Id, new { style="border:1px solid #ccc;" })%>
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
                <%= Html.ActionLink(menuItem.Name, "Index", "Dealers", new { id=menuItem.Id })%>
               </div>    
                 <%if(menuItem.Id == expandedGroup && menuItem.Children.Count>0){
                       foreach (var subItem in menuItem.Children)
                       {%>
                           
                   <div class="subMenuItem<%= selectedStyle(currentCategory, subItem.Id) %>">
                        <%= Html.ActionLink(subItem.Name, "Index", "Dealers", new { id = menuItem.Id })%>
                   </div>    
                  <%   }%>  
                   
                 <%} %>
             <%} %>
        </div>
    </div>
</asp:Content>

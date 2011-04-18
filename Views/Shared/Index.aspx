<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Oksi.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
           <%if (Request.IsAuthenticated)
             { %>
                <div class="adminEditLink">
                    <a href="/Admin/EditText/<%=ViewData["contentName"] %>?controllerName=<%= ViewContext.RouteData.Values["controller"]%>">
                        Редактировать
                    </a>
                    <%=Html.ActionLink("Редактировать", "EditText", "Admin", new { contentName = ViewData["contentName"], controllerName = ViewContext.RouteData.Values["controller"], culture = LocaleHelper.GetCultureName() }, null)%>
                </div>
           <%} %>
    <%= ViewData["text"]%>

</asp:Content>

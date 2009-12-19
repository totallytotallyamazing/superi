<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
           <%if (Request.IsAuthenticated)
             { %>
                <div class="adminEditLink">
                    <a href="<%= LocaleHelper.GetCultureName() %>/Admin/EditText/<%=ViewData["contentName"] %>?controllerName=<%= ViewContext.RouteData.Values["controller"]%>">
                        Редактировать
                    </a>
                </div>
           <%} %>
    <%= ViewData["text"]%>

</asp:Content>

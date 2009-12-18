<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
           <%if (Request.IsAuthenticated)
             { %>
                <div class="adminEditLink">
                    
                    
                    
                    <%=Html.ActionLink("Редактировать", "EditText", "Admin", new { contentUrl = ViewData["contentUrl"], controllerName = ViewContext.RouteData.Values["controller"] }, null)%>
                
              
                </div>
           <%} %>
    <%= ViewData["text"]%>

</asp:Content>

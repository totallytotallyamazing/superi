<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
           <%if (Request.IsAuthenticated)
             { %>
                <div class="adminEditLink">
                    <a href="/<%= LocaleHelper.GetCultureName() %>/Admin/EditText/<%=ViewData["contentName"] %>?controllerName=<%= ViewContext.RouteData.Values["controller"]%>">
                        �������������
                    </a>
                </div>
           <%} %>
    <%= ViewData["text"]%>
    <% if(ViewContext.RouteData.Values["contentName"].ToString() == "Contacts"){ %> 
        <% Html.RenderPartial("FeedbackForm"); %>
    <%} %>

</asp:Content>

<asp:Content ContentPlaceHolderID="TitleContent" runat="server"><%= ViewData["title"] %></asp:Content>
<asp:Content ContentPlaceHolderID="HeadTitle" runat="server"><%= ViewData["title"] %></asp:Content>
<asp:Content ContentPlaceHolderID="HeaderSubTitle" runat="server"><%= ViewData["subTitle"] %></asp:Content>

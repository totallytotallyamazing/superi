<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Dev.Models.Article>" %>
<%@ Import Namespace="Dev.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.Title %> <%= Model.SubTitle %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%if(Request.IsAuthenticated){ %>
        <div class="adminLink">
            <a href="/Admin/Article/<%= Model.Name %>/?type=<%= ArticleType.LifeStyle %>">Изменить</a>
            / 
            <a href="/Admin/DeleteArticle/<%= Model.Name %>/?type=<%= ArticleType.LifeStyle %>">Удалить</a>  
        </div>
    <%} %>
    <%= Model.Text %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeadTitle" runat="server">
<%= Model.Title %>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="HeaderSubTitle" runat="server">
 <%= Model.SubTitle %>
</asp:Content>

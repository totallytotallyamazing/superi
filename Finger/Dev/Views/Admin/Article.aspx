<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Dev.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<%@ Import Namespace="Dev.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%--<asp:Literal runat="server" Text="<%$ Resources:Resources, Notes%>"></asp:Literal>--%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        List<Languages> languages = new List<Languages>();
        using (DataStorage context = new DataStorage())
        {
            languages = context.Languages.Select(l => l).ToList();
        }

        string[] tabs = new string[languages.Count];
        string[] content = new string[languages.Count];
        
        for (int i= 0; i<languages.Count; i++)
        {
            Languages item = languages[i];
            tabs[i] = item.Name;
            content[i] = Html.GetPartialOutput("ArticleDetails", item.CultureName);
        }
    %>
    <% using (Html.BeginForm()){ %>
        Адрессная строка: <%= Html.TextBox("name") %><br />
        Дата: <%= Html.DatePicker("date", ViewData["date"], null, new {dateFormat = "dd.mm.yy"}) %>
        <%= Ajax.Tabs("tabs", tabs, content, new { })%>
        <input type="submit" value="Сохранить" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
    <%= Ajax.UiScriptInclude("pepper-grinder")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeadTitle" runat="server">
    <%--<asp:Literal ID="Literal1" runat="server" Text="<%$ Resources:Resources, Notes%>"></asp:Literal>--%>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="HeaderSubTitle" runat="server">
</asp:Content>

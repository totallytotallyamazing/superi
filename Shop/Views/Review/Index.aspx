<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Review.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>
    <br/><br/><br/>
    <%Html.RenderPartial("CustomBlock"); %>
    <br/><br/><br/>
    <%Html.RenderPartial("CustomBlock"); %>
    <br/><br/><br/>
    <%Html.RenderPartial("CustomBlock"); %>

</asp:Content>


<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>


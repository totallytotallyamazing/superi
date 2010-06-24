<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.ProductAttribute>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using(Html.BeginForm()){ %>
<%=Html.Hidden("productId",ViewData["productId"])%>
<%=Html.Hidden("categoryId", ViewData["categoryId"])%>
<% foreach (var item in Model)
   {
       %>
       <div>
       <strong><%=item.Name%></strong>
       <%
           Html.RenderPartial("ProuctAttributeValue", item.ProductAttributeValue);
       %>
       </div>
       <%
   } %>
   <input type="submit" value="Сохранить" />
   <%} %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
</asp:Content>

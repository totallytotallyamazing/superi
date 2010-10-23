<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.ProductAttribute>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Атрибуты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% foreach (var item in Model){%>
    <div>
<% if(item.ValueType == "DROPDOWN"){ %>
        <%= Html.ActionLink(item.Name, "Index", new{id=item.Id }) %> | 
<%} else{ %>
       <span><%= item.Name %></span> | 
<%} %>
    
        <%= Html.ActionLink("Удалить", "Delete", new { id = item.Id }, new { @class="adminLink", onclick="return confirm('Вы уверены?')" })%> |
        <%= Html.ActionLink("Редактировать", "AddEdit", new { id = item.Id }, new { @class="adminLink"})%>
    </div>       
<%} %>
<p class="adminLink">
    <%= Html.ActionLink("Создать", "AddEdit")%>
</p>
<% 
    if(ViewData["id"]!=null)
    {
        int id = (int)ViewData["id"];
        var attribute = Model.Single(i => i.Id == id);
        if(attribute.ValueType == "DROPDOWN")
            Html.RenderAction("Index", new { controller="AttributeValues", attributeId = ViewData["id"] });
    }
%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">  
    <script type="text/javascript">
        $(function() {
            $(".fancyAttributeValue").fancybox({hideOnOverlayClick:false, showCloseButton:true, autoDimensions: false, width: 200, height: 200 });
        })
    </script>
</asp:Content>


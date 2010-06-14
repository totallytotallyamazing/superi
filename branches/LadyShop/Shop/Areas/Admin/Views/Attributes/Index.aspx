<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.ProductAttribute>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Атрибуты
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% foreach (var item in Model){%>
    <div>
        <%= Html.ActionLink(item.Name, "Index", new{id=item.Id }) %>
    </div>       
<%} %>

<%= Html.ActionLink("Создать", "AddEdit") %>

<% if(ViewData["id"]!=null)
   {
       Html.RenderAction("Index", new { controller="AttributeValues", attributeId = ViewData["id"] });
   }
%>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">  
    <script type="text/javascript" src="/Scripts/jquery.fancybox.js"></script>
    <link href="/Content/fancybox/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        $(function() {
            $(".fancyAttributeValue").fancybox({ modal: true, autoDimensions: false, width: 200, height: 200 });
        })
    </script>
</asp:Content>

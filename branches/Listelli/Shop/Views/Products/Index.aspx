<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Products/Products.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Product>>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"] %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentTitle" runat="server">
 <div id="contName">
                <div id="pageName">
                    <p class="txtPageName"><%= ViewData["title"] %></p>            
                </div>
            </div>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.EnableClientValidation(); %> 
    <% if(Roles.IsUserInRole("Administrators") && ViewData["tags"] == null){ %>
        <% Html.RenderPartial("CategoriesAdmin"); %>
    <%} %>
    <% if (Model != null && Model.Count() > 0)
           foreach (var item in Model)
           {
               Html.RenderPartial("Product", item);
           }
       else
       { 
        %>Извините, по вашему запросу ничего не найдено<%
       } %>
           <div style="clear:both"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <link rel="Stylesheet" href="/Content/catalog.css" />
    <link href="/Content/LislelliStyles/products.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            ProductClientExtensions.initialize();
            ProductClientExtensions.bindFancy();
        })    
    </script>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js") %>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcAjax.js")%>
    <script type="text/javascript">
        function OnCaptchaValidationError() {
            $.get("/Captcha/DrawForFeedback", function (data) { $("#captchaImage").html(data); });
        }
    </script>

</asp:Content>

<asp:Content ID="Content5" runat="server" ContentPlaceHolderID="Footer">
    <% Html.RenderPartial("Pager"); %>
</asp:Content>


<asp:Content runat="server" ContentPlaceHolderID="SortingPanel">
    <% Html.RenderPartial("SortingPanel"); %>
</asp:Content>
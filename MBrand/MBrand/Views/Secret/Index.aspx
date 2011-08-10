<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MBrand.Models.ViewModel.SecretPresentation>" %>
<%@ Import Namespace="MBrand.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Model.SecretText.Title%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate></AnonymousTemplate>
        <LoggedInTemplate>
            <%= Html.ActionLink("Редактировать", "Secret", "Admin", null, new { @class = "adminLink" })%>
            <br /><br />
            <% using (Html.BeginForm("AddSecretImage", "Admin", FormMethod.Post, new { enctype = "multipart/form-data" }))
               { %>
    <span style="color:Black">Изображение:</span> <input type="file" name="image" />
    <br />
    <input type="submit" value="Сохранить" />
<%} %>

<br /><br />


        </LoggedInTemplate>
    </asp:LoginView>


    <%=Model.SecretText.Content %>

    <div class="secretImagesContainer">
    <% foreach (var item in Model.Imageses)
       {
           %>
           <div class="secretImage">
           
           <%if (Request.IsAuthenticated)
{ %>
            <%=Html.ActionLink("удалить", "DeleteSecretImage", "Admin", new { id = item.Id }, new { @class = "adminLink", onclick = "return confirm('Вы действительно хотите удалить запись?')" })%>
            <br/>
           <% } %>
            <a rel="group1" href="/Content/images/secret/<%=item.Image %>" class="fancy" >
                       <%=Html.CachedImage("~/Content/images/secret", item.Image, "secret", item.Image)%>
           </a>
           </div>
           <%
       } %>
       </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
<script type="text/javascript">
    $(function () {
        //$(".fancy").fancybox({ hideOnContentClick: true, showCloseButton: false, cyclic: true, showNavArrows: false, padding: 0, margin: 0, centerOnScroll: false, titleShow: false, autoScale: false });
        $(".fancy").fancybox({ showCloseButton: true, cyclic: true, showNavArrows: true, padding: 0, margin: 0, centerOnScroll: true });
    });
</script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
Секретная раздел
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="SeoCustomTextContainer" runat="server">
<% Html.RenderPartial("SeoText", Model.SecretText.SeoCustomText ?? ""); %>
</asp:Content>

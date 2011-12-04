<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Designer>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["Name"]%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("AddEdit", "Designers", FormMethod.Post, new { enctype="multipart/form-data" })){%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
        <%= Html.HiddenFor(model => model.Id)%>
            <div class="editor-label">
                <b>Ваши имя и фамилия:</b>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            <div class="editor-label">
               <b> Портфолио дизайнера...</b> (Ваше имя в родительном падеже &mdash; например, "Михаила Задорнова")
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.NameF) %>
                <%: Html.ValidationMessageFor(model => model.NameF) %>
            </div>

            <%if (Roles.IsUserInRole(User.Identity.Name, "Administrators"))
            { %>
            <div class="editor-label">
                <%:Html.LabelFor(model => model.Url)%>
            </div>
            <div class="editor-field">
                <%:Html.TextBoxFor(model => model.Url)%>
                <%:Html.ValidationMessageFor(model => model.Url)%>
            </div>
             <div class="editor-label">
                <%: Html.LabelFor(model => model.Room0) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Room0)%>
                <%: Html.ValidationMessageFor(model => model.Room0)%>
            </div>
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Room1) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Room1)%>
                <%: Html.ValidationMessageFor(model => model.Room1)%>
            </div>
            <% }else
{
                  %>
                  <%=Html.HiddenFor(model => model.Url)%>
                  <%=Html.HiddenFor(model => model.Room0)%>
                  <%=Html.HiddenFor(model => model.Room1)%>
                  <%
} %>

           
            <div class="editor-label">
                <b>Ваше фото</b> (jpg размером не больше 500 кб):
            </div>
            <div class="editor-field">
                <% if (Model != null) %>
                        <%= Html.Image("~/Content/DesignerLogos/" + Model.Logo, Model.Name,200)%>
                        <br />
                <input type="file" name="logo" />
                
            </div>
            <div class="editor-label">
                <b>Информация о Вас:</b>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Summary)%>
                <%= Html.ValidationMessageFor(model => model.Summary)%>
            </div>
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>
    <% } %>

    <div>
        <% if (Roles.IsUserInRole(User.Identity.Name, "Administrators"))
           { %>
        <%:Html.ActionLink("к списку", "Index")%>
        <% }else
           {
               %>
               <%:Html.ActionLink("к списку", "UserCabinet")%>
               <%
               
           } %>
    </div>

</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">

    <%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js")  %>
    <%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
      
    <%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
    <%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>

<script type="text/javascript">
    $(function () {
        $(".fancyAdmin").fancybox({ showCloseButton: true, hideOnOverlayClick: false, hideOnContentClick: false });
        CKEDITOR.replace("Summary", { toolbar: "Media" });
    })
</script>

</asp:Content>

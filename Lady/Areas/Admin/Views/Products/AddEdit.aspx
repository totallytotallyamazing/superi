<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lady.Models.Product>" %>
<%@ Import Namespace="Lady.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= ViewData["title"]%>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">  
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>

    <script type="text/javascript">
        $(function() {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
            $("#Description, #ShortDescription").fck({ toolbar: "Basic", height: 200 });
        });
    </script>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%
    Dictionary<long, IEnumerable<ProductImage>> item = new Dictionary<long, IEnumerable<ProductImage>>();
    item.Add(Model.Id, Model.ProductImages);
    %>
    <%if (ViewData["id"] != null)
     {
         Html.RenderPartial("CarAdImages", item);
     }%>
     <br />

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("AddEdit", "Products", FormMethod.Post, new { enctype = "multipart/form-data" })){%>
        <%= Html.ValidationSummary(true) %>

        <fieldset>
            <legend>
                Основные
            </legend>
            <%= Html.HiddenFor(model => model.Id) %>

            <div class="editor-label">
                <%= Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Name) %>
                <%= Html.ValidationMessageFor(model => model.Name) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.PartNumber) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.PartNumber) %>
                <%= Html.ValidationMessageFor(model => model.PartNumber) %>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.ShortDescription) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.ShortDescription) %>
                <%= Html.ValidationMessageFor(model => model.ShortDescription) %>
            </div>

            <div class="editor-label">
                <%= Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Description) %>
                <%= Html.ValidationMessageFor(model => model.Description) %>
            </div>
         </fieldset>
         <fieldset>  
            <legend>
               Цена
            </legend>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.OldPrice) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.OldPrice) %>
                <%= Html.ValidationMessageFor(model => model.OldPrice) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.Price) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.Price) %>
                <%= Html.ValidationMessageFor(model => model.Price) %>
            </div>
         </fieldset>
         <fieldset> 
            <legend>
               Seo
            </legend>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoDescription) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoDescription) %>
                <%= Html.ValidationMessageFor(model => model.SeoDescription) %>
            </div>
            
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoKeywords) %>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoKeywords) %>
                <%= Html.ValidationMessageFor(model => model.SeoKeywords) %>
            </div>

        </fieldset>
        <p>
            <input type="submit" value="Сохранить" />
        </p>
    <% } %>

    <div>
        <%= Html.ActionLink("Назад", "Index") %>
    </div>
</asp:Content>

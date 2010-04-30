<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Lady.Models.Brand>" %>
<%@ Import Namespace="Dev.Mvc.Helpers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Html.EnableClientValidation(); %>

    <% using (Html.BeginForm("AddEdit", "Brands", FormMethod.Post, new { enctype="multipart/form-data" })){%>
        <%= Html.ValidationSummary(true)%>

        <fieldset>
            
             <%= Html.HiddenFor(model => model.Id)%>
            <div>
                <div style="float:left; width:100px;">
                    <div class="editor-label">
                        <%= Html.LabelFor(model => model.Name)%>
                    </div>
                    <div class="editor-field" style="width:250px;">
                        <%= Html.TextBoxFor(model => model.Name)%>
                        <%= Html.ValidationMessageFor(model => model.Name, "*")%>
                    </div>
                    <div class="editor-label">
                        <%= Html.LabelFor(model => model.Logo)%>
                    </div>
                    <div class="editor-field">
                        <input type="file" name="logo" />
                    </div>
                </div>
                <div style="margin-left:101px">
                    <% if (Model != null) %>
                        <%= Html.Image("~/Content/BrandLogos/" + Model.Logo, Model.Name)%>
                </div>
            </div>
            
            <div class="editor-label" style="clear:both">
                <%= Html.LabelFor(model => model.Description)%>
            </div>
            <div class="editor-field">
                <%= Html.TextAreaFor(model => model.Description)%>
                <%= Html.ValidationMessageFor(model => model.Description)%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoDescription)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoDescription)%>
                <%= Html.ValidationMessageFor(model => model.SeoDescription)%>
            </div>
            <div class="editor-label">
                <%= Html.LabelFor(model => model.SeoKeywords)%>
            </div>
            <div class="editor-field">
                <%= Html.TextBoxFor(model => model.SeoKeywords)%>
                <%= Html.ValidationMessageFor(model => model.SeoKeywords)%>
            </div>
            
            <div>
                <input type="submit" value="Сохранить" />
            </div>
        </fieldset>

    <% } %>

    <p>
        <%= Html.ActionLink("к списку", "Index") %>
    </p>
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>

    <script type="text/javascript">
        $(function() {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
            $("#Description").fck({ toolbar: "Basic", height: 200 });
        });
    </script>

</asp:Content>

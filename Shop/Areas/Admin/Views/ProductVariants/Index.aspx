<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.ProductVariant>>" %>

<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Парианты продукта
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% foreach (var item in Model)
       { %>
    <div class="productVariantItem">
        <%= item.Name %>
        <span class="adminLinks">
            <%= Ajax.ActionLink("Редактировать", "AddEdit", new { id = item.Id }, new AjaxOptions { UpdateTargetId = "editVariantContainer_" + item.Id, OnBegin = "beforeVariantEditorLoad", OnSuccess = "variantEditorLoaded" }) %>
            &nbsp;|&nbsp;
            <%= Html.ActionLink("Удалить", "Delete", new { id = item.Id }) %>
        </span>
    </div>
    <div id="editVariantContainer_<%= item.Id %>" class="editorVariantContainer">
    </div>
    <% } %>
    <%= Ajax.ActionLink("Добавить", "AddEdit", new { }, new AjaxOptions {HttpMethod="GET", UpdateTargetId = "editVariantContainer_0", OnBegin = "beforeVariantEditorLoad", OnSuccess = "variantEditorLoaded" }) %>
    <div id="editVariantContainer_0" class="editorVariantContainer">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/MicrosoftMvcAjax.js")%>
    <%= Ajax.ScriptInclude("/Scripts/jquery.validate.js")%>
    <%= Ajax.DynamicCssInclude("/Content/AdminStyles/addEditProduct.css")%>
    <script type="text/javascript">
        var frm = null;

        function beforeVariantEditorLoad() {
            $(".editorVariantContainer").hide(0);
        }

        function variantEditorLoaded(context) {
            $(context.get_updateTarget()).show("slow");
            var form = context.get_updateTarget().getElementsByTagName("form")[0];
            frm = form;
        }

        function bindValidation(form) {
            return $(form).validate(
            {
                rules: {
                    Name: "required",
                    Price: "required"
                },
                messages: {
                    Name: "*",
                    Price: "*"
                },
                errorPlacement: function (error, element) {
                    error.appendTo(element.parent("td").next("td"));
                }

            }).form();
        }

        function variantUpdateStarted() {
            return bindValidation(frm);
        }

        function variantUpdated() {
        }
    </script>
</asp:Content>
<asp:Content ContentPlaceHolderID="Footer" runat="server">
</asp:Content>

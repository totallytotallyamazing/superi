<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.Product>" %>

<%@ Import Namespace="Shop.Models" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["title"]%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <script type="text/javascript" src="/Scripts/jquery.FCKEditor.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
    <%= Ajax.ScriptInclude("/Scripts/jquery.fancybox.js")  %>
    <%= Ajax.DynamicCssInclude("/Content/fancybox/jquery.fancybox.css")%>
    <%= Ajax.DynamicCssInclude("/Content/AdminStyles/addEditProduct.css")%>
    <script type="text/javascript">
        $(function () {
            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/", DefaultLanguage: "ru", AutoDetectLanguage: false, EnterMode: "br", ShiftEnterMode: "p", HtmlEncodeOutput: true} };
            $("#Description, #ShortDescription").fck({ toolbar: "Basic", height: 200 });

            $(".fancyAdmin").fancybox({ showCloseButton: true, hideOnOverlayClick: false, hideOnContentClick: false });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.ValidationSummary(true) %>
    <span class="sectionTitle">О товаре </span>
    <div class="section">
        <%if (ViewData["id"] != null)
          {
              Dictionary<long, IEnumerable<ProductImage>> item = new Dictionary<long, IEnumerable<ProductImage>>();
              item.Add(Model.Id, Model.ProductImages);
              Html.RenderPartial("ProductImages", item);
          }%>
        <br />
        <% using (Html.BeginForm("AddEdit", "Products", FormMethod.Post, new { enctype = "multipart/form-data" }))
           {%>
        <%= Html.Hidden("cId") %>
        <%= Html.Hidden("bId") %>
        <%= Html.HiddenFor(model => model.Id) %>
        <table>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model => model.Name) %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model => model.Name) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(model => model.Name) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model => model.PartNumber) %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model => model.PartNumber) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(model => model.PartNumber) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model => model.SortOrder) %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model => model.SortOrder) %>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(model => model.SortOrder) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model => model.Published) %>
                </td>
                <td>
                    <%= Html.CheckBoxFor(model => model.Published)%>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model => model.Price) %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model => model.Price) %>
                </td>
                <td>
                    <div style="width: 35px; float: left; height: 20px;">
                        <%= Html.ValidationMessageFor(model => model.Price) %>
                    </div>
                    <span class="labelCell">
                        <%= Html.LabelFor(model => model.OldPrice) %>
                    </span><span class="comments">(не обязательно)</span>
                    <%= Html.TextBoxFor(model => model.OldPrice) %>
                    <%= Html.ValidationMessageFor(model => model.OldPrice) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    Бренд
                </td>
                <td>
                    <%= Html.DropDownList("brandId", (IEnumerable<SelectListItem>)ViewData["Brands"]) %>
                </td>
                <td class="explanation">
                    Добавить бренд можно, перейдя в
                    <%= Html.ActionLink("область редактирования брендов", "Index", new { controller="Brands", area="Admin"})%>,
                    находящуюся в разделе "О брендах"
                </td>
            </tr>
            <tr>
                <td class="labelCell">
                    <%= Html.LabelFor(model => model.Color) %>
                </td>
                <td>
                    <%= Html.TextBoxFor(model => model.Color)%>
                </td>
                <td>
                    <%= Html.ValidationMessageFor(model => model.Color)%>
                </td>
            </tr>
        </table>
<%if (Model!=null){ %>
        <div class="productLinks">
            <%--<%= Html.ActionLink("Дополнительные категории", "Index", "ProductCategories", new { id = Model.Id }, new { @class = "fancyAdmin iframe" })%>--%>
            <%= Html.ActionLink("Теги", "Index", "ProductTags", new { id = Model.Id }, new { @class = "fancyAdmin iframe" })%>
        </div>
<%} %>
        <div class="labelCell" style="margin-bottom: 0px; margin-top: 20px;">
            <%= Html.LabelFor(model => model.IsNew) %>
            <%= Html.CheckBoxFor(m => m.IsNew) %>
        </div>
    </div>
    <span class="sectionTitle">Атрибуты</span>
        
    <div class="section">
        <% Html.RenderPartial("ProductAttributeStaticValues", ViewData["attributesData"]); %>
    </div>
    <span class="sectionTitle">Описание</span>
    <div class="section">
        <div class="labelCell" style="margin-bottom: 0px; margin-top: 20px;">
            <%= Html.LabelFor(model => model.Description) %>
        </div>
        <%= Html.TextAreaFor(model => model.Description) %>
        <div class="labelCell" style="margin-bottom: 0px; margin-top: 20px;">
            <%= Html.LabelFor(model => model.ShortDescription) %>
        </div>
        <%= Html.TextAreaFor(model => model.ShortDescription)%>
    </div>
    <span class="sectionTitle">Оптимизация для поисковиков</span>
    <div class="section">
        <table>
            <tr>
                <td class="labelCell" style="width: 150px; white-space: nowrap;">
                    <%= Html.LabelFor(model => model.SeoDescription) %>:
                </td>
                <td>
                    <%= Html.TextAreaFor(model => model.SeoDescription) %>
                </td>
            </tr>
            <tr>
                <td class="labelCell" style="width: 150px; white-space: nowrap;">
                    <%= Html.LabelFor(model => model.SeoKeywords) %>:
                </td>
                <td>
                    <%= Html.TextAreaFor(model => model.SeoKeywords) %>
                </td>
            </tr>
        </table>
    </div>
    <p style="text-align: center;">
        <input type="submit" value="Сохранить все" />
    </p>
    <% } %>
</asp:Content>

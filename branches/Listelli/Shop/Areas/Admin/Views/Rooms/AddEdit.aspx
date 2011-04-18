<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.DesignerRoom>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["title"]%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% Html.EnableClientValidation(); %>
    <% using (Html.BeginForm()){%>
    <%: Html.ValidationSummary(true) %>
    <fieldset>
        <%= Html.HiddenFor(model => model.Id)%>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Type) %>
        </div>
        <div class="editor-field">
            <%=Html.DropDownList("Type", new List<SelectListItem>() { new SelectListItem { Text = "Жилые помещения", Value = "0", Selected = Model != null && Model.Type == 0 }, new SelectListItem { Text = "Нежилые помещения", Value = "1", Selected = Model != null && Model.Type == 1 } })%>
            <%: Html.ValidationMessageFor(model => model.Type)%>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>
        <p>
            <input type="submit" value="Сохранить" />
        </p>
    </fieldset>
    <% } %>
    <div>
        <%: Html.ActionLink("к списку", "Index") %>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
</asp:Content>

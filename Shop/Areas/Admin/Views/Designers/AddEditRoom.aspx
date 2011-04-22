<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.DesignerContent>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%Response.Write(Model == null ? "Создание помещения" : "Редактирование помещения");%>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<% Html.EnableClientValidation(); %>
    <h2> <%Response.Write(Model == null ? "Создание помещения" : "Редактирование помещения");%> </h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>
        
        <fieldset>
            
            
            <%=Html.HiddenFor(model=>model.Id) %>
            <%=Html.Hidden("designerId")%>            
            
            <%
           int dId = (int)ViewData["designerId"];
            %>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RoomName) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.RoomName) %>
                <%: Html.ValidationMessageFor(model => model.RoomName) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.RoomType) %>
            </div>
            <div class="editor-field">
                <%=Html.DropDownList("RoomType", new List<SelectListItem>() { new SelectListItem { Text = "Жилые помещения", Value = "0", Selected = Model != null && Model.RoomType == 0 }, new SelectListItem { Text = "Нежилые помещения", Value = "1", Selected = Model != null && Model.RoomType == 1 } })%>
                <%: Html.ValidationMessageFor(model => model.RoomType) %>
            </div>
            
            <p>
                <input type="submit" value="Сохранить" />
            </p>
        </fieldset>
         <div>
        <%: Html.ActionLink("Назад к списку помещений", "Rooms", new { id = dId })%>
    </div>
    <% } %>

   

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
 <script type="text/javascript" src="/Scripts/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/Scripts/MicrosoftMvcValidation.js"></script>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentHeader" runat="server">
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content6" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>


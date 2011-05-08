<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Designers.Master" Inherits="System.Web.Mvc.ViewPage<Shop.Models.DesignerContent>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	EditContent
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Редактирование информации о помещении "<%=Model.RoomName%>" дизайнера <%=Model.Designer.NameF %></h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

         <%=Html.Hidden("designerId")%>           

            <%
           int dId = (int)ViewData["designerId"];
            %>
        
        <fieldset>
            <%=Html.HiddenFor(model => model.Id)%>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Summary) %>
                <%: Html.ValidationMessageFor(model => model.Summary) %>
            </div>
            <p>
                <input type="submit" value="Сохранить" /> 
            </p>
            <%: Html.ActionLink("Назад к списку помещений", "Rooms", new { id = dId })%>
        </fieldset>

    <% } %>


</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
  <%= Ajax.ScriptInclude("/Controls/ckeditor/ckeditor.js")%>
<%= Ajax.ScriptInclude("/Controls/ckeditor/adapters/jquery.js")%>

<script type="text/javascript">
    $(function () {
        CKEDITOR.replace("Summary", { toolbar: "Media" });
    })
</script>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>


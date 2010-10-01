<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Models.Tag>>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% foreach (var item in Model) {
           Html.RenderPartial("TagEdit", item);
     } %>
     <fieldset style="margin-top:20px;">
        <legend style="font-size:12px;">Добавить</legend>
        <%using (Html.BeginForm("Add", "Tags", FormMethod.Post, new { id="addTagForm" })){ %>
            <div>
                <%= Html.Hidden("viewName", "Index") %>
                <%= Html.TextBox("Value")%>&nbsp;&nbsp;
                <%= Html.TextBox("Left") %>
            </div>
            <input type="submit" value="Добавить" />
        <%} %>
    </fieldset>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <%= Ajax.ScriptInclude("/Scripts/jquery.validate.js") %>
    <%= Ajax.ScriptInclude("/Scripts/jquery.watermark.js")%>
    <script type="text/javascript">
        $(function() {
            $("#addTagForm").validate(
            {
                rules: { Value: {required:true} }, 
                messages: {Value: "*"}
            });

            $("fieldset #Value").watermark({ html: "Тег", cls: "watermark" });
            $("fieldset #Left").watermark({ html: "Отступ слева", cls: "watermark" });

        })
    </script>
</asp:Content>
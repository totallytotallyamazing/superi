<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Categories") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var changes = {};

        function insertCategory(link, parentId) {
            var pos = $(link).offset();
            if (parentId >= 0) {
                $("#parentId").val(parentId);
                pos.left = pos.left - $("#insertCategory").width();
            }
            else {
                pos.left = pos.left + $(link).width();
            }
            $("#insertCategory").css("top", pos.top).css("left", pos.left).slideDown("fast");
            window.setTimeout(bindBodyClick, 50);
        }

        function bindBodyClick() {
            $("body").click(bodyClick);
        }

        function bodyClick() {
            $("#insertCategory").slideUp("fast");
            $("body").unbind("click", bodyClick);
        }

        $(function() {
            $("#insertCategory").click(function(e) { e.stopPropagation(); if (window.event) { window.event.cancelBubbling = true; } });
        }
        );
    </script>

    <h2>
        <%= Html.ResourceString("Categories") %></h2>
    <% using (Html.BeginForm("UpdateCategories", "Admin", FormMethod.Post)){ %>
    <% Html.RenderAction<Zamov.Controllers.AdminController>(a => a.CategoriesList(null, 0)); %>
    <%= Html.Hidden("updates") %>
    <input type="submit" value="<%= Html.ResourceString("Save") %>" onclick="return collectChanges(changes, 'updates');" />
    <%} %>
    
    <a href="#" onclick="insertCategory(this, <%= int.MinValue %>)">
        <%= Html.ResourceString("AddCategory") %>
    </a>
    
    <div id="insertCategory" class="greyBorderBox popUpBox">
        <% using (Html.BeginForm("InsertCategory", "Admin")){ %>
        <table class="adminTable">
            <tr>
                <th>
                    ID
                </th>
                <th>
                    Укр
                </th>
                <th>
                    Рус
                </th>
            </tr>
            <tr>
                <td>
                    <%= Html.TextBox("categoryName") %>
                </td>
                <td>
                    <%= Html.TextBox("categoryUkrName")%>
                </td>
                <td>
                    <%= Html.TextBox("categoryRusName")%>
                </td>
            </tr>
        </table>
        <%= Html.Hidden("parentId") %>
        <input type="submit" value="<%= Html.ResourceString("Add") %>" />
        <%} %>
    </div>
</asp:Content>
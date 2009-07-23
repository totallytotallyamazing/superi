<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Admin/Admin.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Categories") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var changes = {};
        var enables = {};
        function updateEnables(check, id) {
            if (check.checked) {
                enables[id] = true;
            }
            else {
                enables[id] = false;
            }
        }

        function collectCategoryChanges() {
            collectChanges(changes, 'updates');
            var enablities = $get("enablities");
            enablities.value = Sys.Serialization.JavaScriptSerializer.serialize(enables);
            return true;
        }
    
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
            $("#imagePopUp").dialog({ autoOpen: false, width: 440, height: 360, minHeight: 360, resizable: false });
        }
        );

        function openImageIframe(categoryId) {
            $("#updateImageBox").attr("src", "/Admin/UpdateCategoryImage/" + categoryId);
            $("#imagePopUp").dialog('open').css("height", 300);

            $('#imagePopUp').dialog('option', 'height', 360);
            $('#imagePopUp').dialog('option', 'position', 'center');
            $('#imagePopUp').css('height', 'auto');
        }
    </script>
    <div title="<%= Html.ResourceString("Image") %>" id="imagePopUp" style="display: block; height: 300px;">
        <iframe id="updateImageBox" frameborder="0" hidefocus="true" style="width: 400px;
            height: 299px; background: transparent;"></iframe>
    </div>
    <h2>
        <%= Html.ResourceString("Categories") %></h2>
    <% using (Html.BeginForm("UpdateCategories", "Admin", FormMethod.Post)){ %>
    <% Html.RenderAction<Zamov.Controllers.AdminController>(a => a.CategoriesList(null, 0)); %>
    <%= Html.Hidden("updates") %>
    <%= Html.Hidden("enablities") %>
    <input type="submit" value="<%= Html.ResourceString("Save") %>" onclick="return collectCategoryChanges();" />
    <%} %>
    
    <a href="#" onclick="insertCategory(this, <%= int.MinValue %>)">
        <%= Html.ResourceString("AddCategory") %>
    </a>
    
    <div id="insertCategory" class="greyBorderBox popUpBox">
        <% using (Html.BeginForm("InsertCategory", "Admin")){ %>
        <table class="adminTable">
            <tr>
                <th>
                    <%= Html.ResourceString("Ukr") %>
                </th>
                <th>
                    <%= Html.ResourceString("Rus") %>
                </th>
                <th>
                    <%= Html.ResourceString("Show") %>
                </th>
            </tr>
            <tr>
                <td>
                    <%= Html.TextBox("categoryUkrName")%>
                </td>
                <td>
                    <%= Html.TextBox("categoryRusName")%>
                </td>
                <td align="center">
                    <%= Html.CheckBox("categoryEnabled", true) %>
                </td>
            </tr>
        </table>
        <%= Html.Hidden("parentId", int.MinValue) %>
        <input type="submit" value="<%= Html.ResourceString("Add") %>" />
        <%} %>
    </div>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="includes">
    <%= Html.RegisterCss("~/Content/Admin.css") %>
    <%= Html.RegisterCss("~/Content/redmond/jquery.ui.css")%>
    <%= Html.RegisterJS("jquery.ui.js")%>
</asp:Content>
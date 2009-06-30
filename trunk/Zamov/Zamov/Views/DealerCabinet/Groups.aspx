<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	<%= Html.ResourceString("Groups") %>
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

        function collectGroupChanges() {
            collectChanges(changes, 'updates');
            var enablities = $get("enablities");
            enablities.value = Sys.Serialization.JavaScriptSerializer.serialize(enables);
            return true;
        }
        
        function insertGroup(link, parentId) {
            var pos = $(link).offset();
            if (parentId >= 0) {
                $("#parentId").val(parentId);
                pos.left = pos.left - $("#insertGroup").width();
            }
            else {
                pos.left = pos.left + $(link).width();
            }
            $("#insertGroup").css("top", pos.top).css("left", pos.left).slideDown("fast");
            window.setTimeout(bindBodyClick, 50);
        }

        function bindBodyClick() {
            $("body").click(bodyClick);
        }

        function bodyClick() {
            $("#insertGroup").slideUp("fast");
            $("body").unbind("click", bodyClick);
        }

        $(function() {
            $("#insertGroup").click(function(e) { e.stopPropagation(); if (window.event) { window.event.cancelBubbling = true; } });
        }
        );
    </script>
    
    <h2><%= Html.ResourceString("Groups") %></h2>
    <% 
        using (Html.BeginForm("UpdateGroups", "DealerCabinet", FormMethod.Post))
        {
            int dealerId = Convert.ToInt32(ViewData["dealerId"]);
            Response.Write(Html.Hidden("updates"));
            Response.Write(Html.Hidden("enablities"));
            Html.RenderAction<Zamov.Controllers.DealerCabinetController>(ac => ac.GoupList(dealerId, null, 0));
            Response.Write("<input type=\"submit\" onclick=\"return collectGroupChanges();\" value=\"" + Html.ResourceString("Save") + "\" /> ");
        }
    %>
    
    <a href="#" onclick="insertGroup(this, <%= int.MinValue %>)">
        <%= Html.ResourceString("AddGroup") %>
    </a>
    
        <div id="insertGroup" class="greyBorderBox popUpBox">
        <% using (Html.BeginForm("InsertGroup", "DealerCabinet"))
           { %>
        <table class="adminTable">
            <tr>
                <th>
                    ID
                </th>
                <th>
                    ���
                </th>
                <th>
                    ���
                </th>
                <th>
                    <%= Html.ResourceString("ActiveF") %>
                </th>
            </tr>
            <tr>
                <td>
                    <%= Html.TextBox("groupName") %>
                </td>
                <td>
                    <%= Html.TextBox("groupUkrName")%>
                </td>
                <td>
                    <%= Html.TextBox("groupRusName")%>
                </td>
                <td align="center">
                    <%= Html.CheckBox("enabled", true) %>
                </td>
            </tr>
        </table>
        <%= Html.Hidden("parentId", int.MinValue) %>
        <input type="submit" value="<%= Html.ResourceString("Add") %>" />
        <%} %>
    </div>
    
</asp:Content>

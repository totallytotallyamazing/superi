<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ImportedProducts
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var newItems = {};
        var updatedItems = {};

        $(function() {
            $("#tabs").tabs();
            $(".productDescriptionContainer")
                .dialog({
                    autoOpen: false,
                    width: 700,
                    height: 530,
                    minHeight: 360,
                    resizable: false,
                    modal: true,
                    buttons: { "Ok": closeDescriptionDialog }
                });

            $.fck.config = { path: '<%= VirtualPathUtility.ToAbsolute("~/Controls/fckeditor/") %>', config: { SkinPath: "skins/office2003/"} };
            $('textarea.fck').fck({ toolbar: "Basic", height: 400, language: "RU", HTMLEncode: true });
        })
        
        function closeDescriptionDialog() {
            $(".productDescriptionContainer").dialog('close');
        }

        function openDescriptionDialog(id) {
            $("#" + id).dialog('open');
            $("#" + id).dialog('open').css("height", 425);
            $("#" + id).dialog('option', 'height', 530);
            $("#" + id).dialog('option', 'position', 'center');
        }

        function saveImports() {
            collectChanges(newItems, 'newItemUpdates');
            collectChanges(updatedItems, 'updatedItemUpdates');
            $("#saveForm").submit();
        }
    </script>
<%
    List<Dictionary<string, string>> updatedItems = (List<Dictionary<string, string>>)ViewData["updatedItems"];
    List<Dictionary<string, string>> newItems = (List<Dictionary<string, string>>)ViewData["newItems"];
%>
    
    <h2>ImportedProducts</h2>
    <input style="padding:10px; margin-top:10px;" type="button" class="ui-state-default ui-corner-all" value="<%= Html.ResourceString("Save") %>" onclick="saveImports()" />
    <div id="tabs">
        <ul>
            <li>
                <a href="#tabs-1"><%= Html.ResourceString("NewProducts")%></a>
            </li>
            <li>
                <a href="#tabs-2"><%= Html.ResourceString("UpdatedProducts")%></a>
            </li>
        </ul>
        <div id="tabs-1">
            <table>
                <tr>
                    <td align="center"><%= Html.ResourceString("Group") %></td>
                    <td align="center"><%= Html.ResourceString("PartNumber") %></td>
                    <td align="center"><%= Html.ResourceString("Name") %></td>
                    <td align="center"><%= Html.ResourceString("Price") %></td>
                    <td align="center"><%= Html.ResourceString("Unit") %></td>
                    <td align="center"><%= Html.ResourceString("Description") %></td>
                </tr>
                <%
                    foreach(var item in newItems)
                        Html.RenderAction<Zamov.Controllers.DealerCabinetController>(ac=>ac.ImportedProduct(item, true));
                %>
            </table>
        </div>
        <div id="tabs-2">
            <table>
                <tr>
                    <td align="center"><%= Html.ResourceString("Group") %></td>
                    <td align="center"><%= Html.ResourceString("PartNumber") %></td>
                    <td align="center"><%= Html.ResourceString("Name") %></td>
                    <td align="center"><%= Html.ResourceString("Price") %></td>
                    <td align="center"><%= Html.ResourceString("Unit") %></td>
                    <td align="center"><%= Html.ResourceString("Description") %></td>
                </tr>
                <%
                    foreach(var item in updatedItems)
                        Html.RenderAction<Zamov.Controllers.DealerCabinetController>(ac=>ac.ImportedProduct(item, false));
                %>
            </table>
        </div>
    </div>
    
    <% using (Html.BeginForm("SaveImportedProducts", "DealerCabinet", FormMethod.Post, new { id="saveForm" }))
       { %>
        <%= Html.Hidden("newItemUpdates")%>
        <%= Html.Hidden("updatedItemUpdates")%>
    <%} %>
    <input style="padding:10px; margin-top:10px;" type="button" class="ui-state-default ui-corner-all" value="<%= Html.ResourceString("Save") %>" onclick="saveImports()" />

</asp:Content>

<asp:Content ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("fckeditorapi.js") %>
    <%= Html.RegisterJS("fckeditor.js") %>
    <%= Html.RegisterJS("fcktools.js") %>
    <%= Html.RegisterJS("jquery.FCKeditor.js") %>
    <style type="text/css">
        .ui-tabs-nav { height:2.4em; }
    </style>
</asp:Content>

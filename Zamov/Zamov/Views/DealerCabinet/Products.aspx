<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<Zamov.Models.Product>>" %>

<%@ Import Namespace="Zamov.Helpers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Products") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        function groupSelected() {
            $("#groupIds option").each(function(i) {
                if (this.selected)
                    location.href = "/DealerCabinet/Products/" + this.value;
            }
            )

        }
    </script>

    <h2>
        <%= Html.ResourceString("Products") %></h2>
    <br />
    <%= Html.DropDownList("groupIds", (List<SelectListItem>)ViewData["groups"], new { onchange = "groupSelected()" })%>
    <%= Html.ResourceActionLink("ManageGroups", "Groups") %>
    
    <table class="adminTable">
        <tr>
        
        </tr>
        <tr>
        
        </tr>
        <tr>
        
        </tr>
    </table>
</asp:Content>

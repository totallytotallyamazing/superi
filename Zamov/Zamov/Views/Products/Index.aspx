<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Zamov.Models.Product>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        var items = new Array();
        $(function() {
            $(".productDescription").fancybox({frameWidth: 700, frameHeight: 500});
        })

        function submitForm() {
            collectChanges(items, "items");
            $get("addToCart").submit();
        }
        
    </script>
    <%if(Model.Count>0){ %>
        <input type="button" value="<%= Html.ResourceString("AddToCart") %>" onclick="submitForm()" />
        <%using (Html.BeginForm("AddToCart", "Products", FormMethod.Post, new { id="addToCart" }))
          { %>
            <%= Html.Hidden("dealerId", ViewData["dealerId"])%>
            <%= Html.Hidden("items")%>
        <%} %>
    <table class="commonTable">
        <tr>
            <th><%= Html.ResourceString("Name") %></th>
            <th><%= Html.ResourceString("Description") %></th>
            <th><%= Html.ResourceString("MeassureUnit") %></th>
            <th><%= Html.ResourceString("Price") %>, דנם.</th>
            <th><%= Html.ResourceString("Quantity") %></th>
            <th><%= Html.ResourceString("ToOrder") %></th>
        </tr>
<%
foreach (var item in Model)
    {
    %>
        <tr>
            <td>
                <%= item.Name %>
            </td>
            <td align="center">
                <a class="productDescription" style="text-decoration:none" href="/Products/Description/<%= item.Id %>">
                    <%= Html.Image("~/Content/img/productImage.JPG", new { style="border:none;" })%> / <span class="productDescriptionLink">i</span>
                </a>
            </td>
            <td align="center">
                רע.
            </td>
            <td align="right">
                <%= item.Price.ToString("#.00#") %>
            </td>
            <td align="center">
                <%= Html.TextBox("quantity_" + item.Id, null, new { style="width:20px;", onblur = "tableChanged(items, this)"})%>
            </td>
            <td align="center">
                <%= Html.CheckBox("order_" + item.Id, false, new { onblur = "tableChanged(items, this)" })%>
            </td>
        </tr>
    <%   
    }     
%>
    </table>
    <input type="button" value="<%= Html.ResourceString("AddToCart") %>" onclick="submitForm()" />
    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("jquery.easing.js")%>
    <%= Html.RegisterJS("jquery.fancybox.js")%>
    <%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
    <% Html.RenderPartial("ProductGroups"); %>
</asp:Content>

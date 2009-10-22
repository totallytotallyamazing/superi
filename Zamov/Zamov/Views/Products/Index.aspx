<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Zamov.Models.Product>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Zamov.Controllers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<%@ Import Namespace="AjaxControlToolkitMvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>

<asp:Content ContentPlaceHolderID="dealerLogo" runat="server">
    <% Html.RenderPartial("CurrentDealer");  %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        $(function() {
            $(".productDescription").fancybox({ width: "700px", hideOnContentClick: false });
        })
        
        var items = {};
        function order(element) {
            var fieldSegments = element.name.split("_");

            var id = fieldSegments[1];

            if (element.type == "checkbox") {
                var input = $get("quantity_" + id);
                if (input.value == "") {
                    input.value = 1;
                }
            }
            else {
                var checkbox = $get("order_" + id);
                if (!checkbox.checked) {
                    checkbox.checked = true;
                }
            }
        }
        
    </script>
    
    <%

        SortFieldNames? sortFieldName = null;
        SortDirection? sortDirection = null;
        SortDirection? invertSortDirection = null;

        if (ViewData["sortFieldName"] != null && ViewData["sortDirection"] != null)
        {
            sortFieldName = (SortFieldNames)ViewData["sortFieldName"];
            sortDirection = (SortDirection)ViewData["sortDirection"];

            if (sortDirection == SortDirection.Ascending)
                invertSortDirection = SortDirection.Descending;
            else
                invertSortDirection = SortDirection.Ascending;
        }


        string sortDealerId = (string)ViewData["sortDealerId"];
        int? groupId = null;
        if (ViewData["groupId"] != null)
            groupId = (int)ViewData["groupId"];


        int dealerId = (int)ViewData["dealerId"];
       
    %>
    
    <%= Html.ResourceActionLink("PickAnotherDealer", "Index", "Dealers")%><br />
    <br />
    
    <% Html.RenderPartial("TopProducts"); %>
        
    <%if(Model.Count>0){ %>
        <%using (Html.BeginForm("AddToCart", "Products", FormMethod.Post, new { id="addToCart", style="margin-bottom:20px;" }))
          { %>
            <input type="hidden" name="dealerId" value="<%= dealerId %>" />
            <%= Html.Hidden("groupId")%>
            <div style="text-align:right;">
                <input type="submit" value="<%= Html.ResourceString("AddToCart") %>" />
            </div>
    <table class="commonTable" style="width:100%; margin:5px 0;">
        <tr>
            <th>
            <table class="searchTableIneerHeader">
                <tr>
                    <td>
                         <%
                          if (sortFieldName == null)
                          {    
                        %>
                        <%=Html.ResourceActionLink("Name", "Index", new { dealerId = sortDealerId, groupId = groupId, sortFieldName = SortFieldNames.Name, sortDirection = SortDirection.Ascending })%>
                        <%}
                          else
                          {%>
                          <%=Html.ResourceActionLink("Name", "Index", new { dealerId = sortDealerId, groupId = groupId, sortFieldName = SortFieldNames.Name, sortDirection = invertSortDirection })%>
                        <%} %>
                    </td>
                    <td>
                       <%if (sortFieldName == SortFieldNames.Name)
                         { if (sortDirection == SortDirection.Ascending)
                          {%>
                        <%=Html.Image("~/Content/images/sort_up.gif", new { style = "border-style:none" })%>
                        <%}
                          else
                          { %>
                        <%=Html.Image("~/Content/images/sort_down.gif", new { style = "border-style:none" })%>
                        
                        <%}
                         } %>
                    </td>
                </tr>
                </table> 
                        
            </th>
            <th style="width:20px;"><%= Html.ResourceString("Photo") %> / <%= Html.ResourceString("Description") %></th>
            <th style="width:20px;"><%= Html.ResourceString("MeassureUnit") %></th>
            <th style="width:20px;">
            <table class="searchTableIneerHeader">
                <tr>
                    <td>
                        <%
                          if (sortFieldName == null)
                          {    
                        %>
                        <%=Html.ResourceActionLink("Price", "Index", new { sortFieldName = SortFieldNames.Price, sortDirection = SortDirection.Ascending })%>, грн.
                        <%}
                          else
                          {%>
                          <%=Html.ResourceActionLink("Price", "Index", new { sortFieldName = SortFieldNames.Price, sortDirection = invertSortDirection })%>, грн.
                        <%} %>
                    </td>
                    <td>
                       <%if (sortFieldName == SortFieldNames.Price)
                         { if (sortDirection == SortDirection.Ascending)
                          {%>
                        <%=Html.Image("~/Content/images/sort_up.gif", new { style = "border-style:none" })%>
                        <%}
                          else
                          { %>
                        <%=Html.Image("~/Content/images/sort_down.gif", new { style = "border-style:none" })%>
                        
                        <%}
                         } %>
                    </td>
                </tr>
                </table>
            
            </th>
            <th style="width:20px;"><%= Html.ResourceString("Quantity") %></th>
            <th style="width:20px;"><%= Html.ResourceString("ToOrder") %></th>
        </tr>
<%
foreach (var item in Model)
    {
        string trClass = "";
        if (item.Action && item.New)
            trClass = "actionNew";
        else if (item.Action)
            trClass = "action";
        else if (item.New)
            trClass = "new";
        string classAttribute = (!string.IsNullOrEmpty(trClass)) ? "class=\"" + trClass + "\"" : "";
            
    %>
        <tr>
            <td <%= classAttribute %>>
                <%= item.Name %>
            </td>
            <td align="center">
                <a class="productDescription" style="text-decoration:none" href="/Products/Description/<%= item.Id %>">
                    <%= Html.Image("~/Content/img/productImage.JPG", new { style="border:none;" })%> / <span class="productDescriptionLink">i</span>
                </a>
            </td>
            <td align="center">
                <%= item.Unit %>
            </td>
            <td align="right">
                <%= item.Price.ToString("#.00#") %>
            </td>
            <td align="center" valign="middle">
<%
    string mask = "9{4}";
   // if (item.Unit == "кг." || item.Unit == "кг" || item.Unit == "л" || item.Unit == "л.")
     //   mask = "99.99";
%>
                <%= Html.TextBox("quantity_" + item.Id, null, new { style = "width:24px; font-size:10px; text-align:center", onkeyup = "validateQuantity(this); order(this)" })%>
                <%--<%= Ajax.MaskEdit("", MaskTypes.Number, mask, false, true, "quantity_" + item.Id)%>--%>
            </td>
            <td align="center" valign="middle">
                <%= Html.CheckBox("order_" + item.Id, false, new {onclick="order(this)" })%>
            </td>
        </tr>
    <%   
    }     
%>
    </table>
      <div>
    <input type="submit" style="float:right" value="<%= Html.ResourceString("AddToCart") %>" />
      </div>
   <%} %>

    <%} %>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
    <%= Html.RegisterJS("jquery.easing.js")%>
    <%= Html.RegisterJS("jquery.fancybox.js")%>
    <%= Html.RegisterCss("~/Content/fancy/jquery.fancybox.css")%>
    <%= Html.RegisterCss("~/Content/shadows.css")%>
    <%= Html.RegisterJS("dropshadow.js")%>
    <%= Html.RegisterJS("jquery.treeview.js") %>
    <%= Html.RegisterCss("~/Content/GroupsTreeview.css") %>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
    <% Html.RenderAction<ProductsController>(c => c.ProductGroups((string)ViewData["sortDealerId"], (int?)ViewData["groupId"])); %>
</asp:Content>

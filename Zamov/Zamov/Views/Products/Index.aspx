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
            $(".sortable a").click(function(e) {
                e.stopPropagation();
            }
            );

            $(".productDescription").fancybox({ width: "700px", hideOnContentClick: false });

            $(".sortable")
            .mouseover(function() {
                //this.style.backgroundImage = "url(img/logo.jpg)";
                this.className = "thHover";
                //this.style.border= "1px solid lime";
            })
            .mouseout(function() {
                this.className = "";
            })
            .click(function() {
                location.href = this.firstChild.href;
            })

            $(".orderCheckLink").click(function() {
                Sys.UI.DomElement.toggleCssClass(this, "ordered");
                var check = $get("order_" + this.getAttribute("rel"));
                check.checked = !check.checked;
                order(check);
            }
            )
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
                    Sys.UI.DomElement.addCssClass($get("orderLink_" + id), "ordered");
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
    <% Html.RenderPartial("TopProducts"); %>
    <%if (Model.Count > 0)
      { %>
    <%using (Html.BeginForm("AddToCart", "Products", FormMethod.Post, new { id = "addToCart", style = "margin-bottom:20px;" }))
      { %>
          <%= Html.ResourceActionLink("PickAnotherDealer", "Index", "Dealers")%><br />

    <input type="hidden" name="dealerId" value="<%= dealerId %>" />
    <%= Html.Hidden("groupId")%>
    <div style="text-align: right; margin-top:-20px;">
        <input type="submit" value="<%= Html.ResourceString("AddToCart") %>" />
    </div>
    <table class="blueHeaderedTable" style="width: 100%; margin: 5px 0;" cellpadding="0"
        cellspacing="0">
        <tr class="blueHeader">
            <th style="width: 20px;" align="center">
                <%= Html.ResourceString("Photo") %>
            </th>
            <th class="sortable" align="center">
                <%= Html.SortHeader("Name", "/Products/" + sortDealerId + "/" + groupId, "Name", "", "") %>
            </th>
            <th style="width: 20px;">
                <%= Html.ResourceString("MeassureUnit") %>
            </th>
            <th class="sortable"  align="center">
                <%= Html.SortHeader("PriceHrn", "/Products/" + sortDealerId + "/" + groupId, "Price", "", "") %>
            </th>
            <th style="width: 20px;"  align="center">
                <%= Html.ResourceString("Quantity") %>
            </th>
            <th style="width: 20px;"  align="center">
                <%= Html.ResourceString("ToOrder") %>
            </th>
        </tr>
        <%
            int i = 0;
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
                string rowClass = ((i % 2 > 0) ? "odd" : "even");
                i++; 
        %>
        <tr class="<%= rowClass %>">
            <td align="center">
                <table class="noBorder">
                    <% if ((bool)ViewData["displayGroupImages"]){ %>
                    <tr>
                        <td style="height: 80px" valign="middle" align="center">
                            <%
                                ViewData["productId"] = item.Id;
                                Html.RenderPartial("ProductImageThumbnail");
                            %>
                        </td>
                    </tr>
                    <%} %>
                    <tr>
                        <td align="center">
                            <a class="productDescription" href="/Products/Description/<%= item.Id %>">
                                <%= Html.ResourceString("Details") %>
                            </a>
                        </td>
                    </tr>
                </table>
            </td>
            <td <%= classAttribute %> valign="top">
                <a class="productDescription" href="/Products/Description/<%= item.Id %>">
                    <%= item.Name %><br />
                </a>
                <div class="productDescription <%= ((bool)ViewData["displayGroupImages"]).ToString() %>">
                    <%if (item.Descriptions.ContainsKey(SystemSettings.CurrentLanguage)) %>
                        <%= item.Descriptions[SystemSettings.CurrentLanguage] %>
                </div>
            </td>
            <td align="center">
                <%= item.Unit %>
            </td>
            <td align="center">
                <%= item.Price.ToString("#.00#") %>
            </td>
            <td align="center" valign="middle">
                <%
                    string mask = "9{4}";
                    // if (item.Unit == "êã." || item.Unit == "êã" || item.Unit == "ë" || item.Unit == "ë.")
                    //   mask = "99.99";
                %>
                <%= Html.TextBox("quantity_" + item.Id, null, new { style = "width:24px; font-size:10px; text-align:center", onkeyup = "validateQuantity(this); order(this)" })%>
                <%--<%= Ajax.MaskEdit("", MaskTypes.Number, mask, false, true, "quantity_" + item.Id)%>--%>
            </td>
            <td align="center" valign="middle">
                <a id="orderLink_<%= item.Id %>" class="orderCheckLink <%= SystemSettings.CurrentLanguage %>" rel="<%= item.Id %>"></a>
                <%= Html.CheckBox("order_" + item.Id, false, new { onclick = "order(this)", style = "visibility:hidden; display: block; height: 0px; font-size: 0px;" })%>
            </td>
        </tr>
        <%   
            }     
        %>
    </table>
    <div>
        <input type="submit" style="float: right" value="<%= Html.ResourceString("AddToCart") %>" />
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

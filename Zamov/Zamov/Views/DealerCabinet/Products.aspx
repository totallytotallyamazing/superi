<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master"
    Inherits="System.Web.Mvc.ViewPage<List<Zamov.Models.Product>>" %>

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

        $(function() { $(".updateImage").html("<img src=\"/Content/img/productImage.JPG\" style=\"border:none\">") })
    </script>

    <h2>
        <%= Html.ResourceString("Products") %></h2>
    <br />
    <%= Html.DropDownList("groupIds", (List<SelectListItem>)ViewData["groups"], new { onchange = "groupSelected()" })%>
    <%= Html.ResourceActionLink("ManageGroups", "Groups") %>
<%
    if (Model != null && Model.Count > 0)
    { 
%>
    <table class="adminTable">
           <tr>
                <th>
                    <%= Html.ResourceString("PartNumber")%>
                </th>
                <th>
                    <%= Html.ResourceString("Name")%>
                </th>
               <th>
                    <%= Html.ResourceString("Image") %>
                    /
                    <%= Html.ResourceString("Description") %>
                </th>
                <th>
                    <%= Html.ResourceString("Price")%>
                </th>
                <th>
                    <%= Html.ResourceString("ActiveM")%>
                </th>
            </tr>
            <%foreach (var item in Model)
	{%>
            <tr>
                <td>
                    <%= Html.TextBox("partNumber_" + item.Id, item.PartNumber)%>
                </td>
                <td>
                    <%= Html.TextBox("name_" + item.Id, item.Name)%>
                </td>
                <td align="center">
                    <%= Ajax.ActionLink("image", "UpdateProductImage", new { id = item.Id }, new AjaxOptions { HttpMethod = "post", InsertionMode = InsertionMode.Replace, OnSuccess = "displayImageDialog", OnFailure = "failureCallback", OnBegin = "fadeScreenIn", OnComplete = "fadeScreenOut", UpdateTargetId = "imageDialog" }, new { @class = "updateImage" })%>
                    &nbsp;
                    <%= Ajax.ActionLink("i", "UpdateProductDescription", new { id = item.Id }, new AjaxOptions { HttpMethod = "post", InsertionMode = InsertionMode.Replace, OnSuccess = "displayDescriptionDialog", OnFailure = "failureCallback", OnBegin = "fadeScreenIn", OnComplete = "fadeScreenOut", UpdateTargetId = "descriptionDialog" }, new { @class = "updateDescription" })%>
                </td>
                <td>
                    <%= Html.TextBox("price_" + item.Id, item.Price)%>
                </td>
                <td align="center">
                    <%= Html.CheckBox("active_" + item.Id, item.Enabled)%>
                </td>
            </tr>
            		 
<%	} %>

    </table>
<%} %>

<%
    if(Convert.ToInt32(ViewData["groupId"])>=0){        
%>
    <div>
        <% using (Html.BeginForm("AddProduct", "DealerCabinet"))
           { %>
        <%= Html.Hidden("groupId") %>
        <table class="adminTable">
            <tr>
                <th>
                    <%= Html.ResourceString("PartNumber")%>
                </th>
                <th>
                    <%= Html.ResourceString("Name")%>
                </th>
                <%--                <th>
                    <%= Html.ResourceString("Description") %>
                    /
                    <%= Html.ResourceString("Image") %>
                </th>--%>
                <th>
                    <%= Html.ResourceString("Price")%>
                </th>
                <th>
                    <%= Html.ResourceString("ActiveM")%>
                </th>
            </tr>
            <tr>
                <td>
                    <%= Html.TextBox("partNumber")%>
                </td>
                <td>
                    <%= Html.TextBox("name")%>
                </td>
                <td>
                    <%= Html.TextBox("price")%>
                </td>
                <td align="center">
                    <%= Html.CheckBox("active")%>
                </td>
            </tr>
        </table>
        <input type="submit" value="<%= Html.ResourceString("Add") %>" />
        <%} %>
    </div>
    <%} %>
</asp:Content>

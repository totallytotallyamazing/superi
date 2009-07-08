<%@ Page Title="" Language="C#" MasterPageFile="~/Views/DealerCabinet/Cabinet.Master"
    Inherits="System.Web.Mvc.ViewPage<List<Zamov.Models.Product>>" %>

<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= Html.ResourceString("Products") %>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var updates = {};
        
        $(function() {
            $("#imagePopUp").dialog({ autoOpen: false, width: 440, height: 360, minHeight: 360, resizable: false });
        })

        function groupSelected() {
            $("#groupIds option").each(function(i) {
                if (this.selected)
                    location.href = "/DealerCabinet/Products/" + this.value;
            }
            )
        }

        function openImageIframe(productId) {
            $("#updateImageBox").attr("src", "/DealerCabinet/UpdateProductImage/" + productId);
            $("#imagePopUp").dialog('open').css("height", 300);

            $('#imagePopUp').dialog('option', 'height', 360);
            $('#imagePopUp').dialog('option', 'position', 'center');
            $('#imagePopUp').css('height', 'auto');
        }

        function closeImageDialog() {
            $("#imagePopUp").dialog('close');
        }
    </script>
    <div  id="imagePopUp" style="display:block; height:300px;">
        <iframe id="updateImageBox" frameborder="0" hidefocus="true" style="width:400px; height:299px; background:transparent;">
        
        </iframe>
    </div>
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
                    <%= Html.TextBox("partNumber_" + item.Id, item.PartNumber, new { onblur = "tableChanged(updates, this)"})%>
                </td>
                <td>
                    <%= Html.TextBox("name_" + item.Id, item.Name, new { onblur = "tableChanged(updates, this)" })%>
                </td>
                <td align="center">
                    <a href="javascript:openImageIframe(<%= item.Id %>)">
                        <%= Html.Image("~/Content/img/productImage.jpg", new {style="border:none" })%>
                    </a>
                    &nbsp;
                    <%= Ajax.ActionLink("i", "UpdateProductDescription", new { id = item.Id }, new AjaxOptions { HttpMethod = "post", InsertionMode = InsertionMode.Replace, OnSuccess = "displayDescriptionDialog", OnFailure = "failureCallback", OnBegin = "fadeScreenIn", OnComplete = "fadeScreenOut", UpdateTargetId = "descriptionDialog" }, new { @class = "updateDescription" })%>
                </td>
                <td>
                    <%= Html.TextBox("price_" + item.Id, item.Price, new { onblur = "tableChanged(updates, this)" })%>
                </td>
                <td align="center">
                    <%= Html.CheckBox("active_" + item.Id, item.Enabled, new { onclick = "tableChanged(updates, this)" })%>
                </td>
            </tr>
            		 
<%	} %>

    </table>
    <%using (Html.BeginForm("UpdateProducts", "DealerCabinet", FormMethod.Post))
      { %>
    <%= Html.Hidden("changes") %>
    <input type="submit" value="<%= Html.ResourceString("Save") %>" onclick="collectChanges(updates, 'changes')" />
    <%} %>
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

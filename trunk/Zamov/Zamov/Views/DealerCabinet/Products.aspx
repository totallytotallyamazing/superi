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
            $("#importProducts")
                .dialog({
                    autoOpen: false, 
                    resizable: false,
                    modal: true,
                    buttons: { "<%= Html.ResourceString("Upload") %>": function(){ $get("xslForm").submit(); } }
                 });
            $("#descriptionPopUp")
                .dialog({
                    autoOpen: false,
                    width: 700,
                    height: 600,
                    minHeight: 360,
                    resizable: false,
                    buttons: {
                        "<%= Html.ResourceString("Cancel") %>": function(){closeDescriptionDialog();},
                        "<%= Html.ResourceString("Save") %>": function() { $get("descriptionsFrame").contentWindow.updateDescription(); }
                    }
                });
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

        function openDescriptionIframe(productId) {
            $("#descriptionPopUp")
                .html('<iframe frameborder="0" name="descriptionsFrame" id="descriptionsFrame" hidefocus="true" style="width:660px; height:500px;" src="/DealerCabinet/UpdateProductDescription/' +
                    productId + 
                    '"></iframe>');

            $("#descriptionPopUp").dialog('open').css("height", 500);
            $('#descriptionPopUp').dialog('option', 'height', 600);
            $('#descriptionPopUp').dialog('option', 'position', 'center');
            //$('#descriptionPopUp').css('height', 'auto');
        }

        function closeImageDialog() {
            $("#imagePopUp").dialog('close');
        }

        function closeDescriptionDialog() {
            $("#descriptionPopUp").dialog('close');
        }
        
        function uploadXsl(){
            $("#importProducts").dialog('open');

//            $('#imagePopUp').dialog('option', 'height', 360);
//            $('#imagePopUp').dialog('option', 'position', 'center');
//            $('#imagePopUp').css('height', 'auto');
        }
    </script>
    
    <div title="<%= Html.ResourceString("Image") %>" id="imagePopUp" style="display: block; height: 300px;">
        <iframe id="updateImageBox" frameborder="0" hidefocus="true" style="width: 400px;
            height: 299px; background: transparent;"></iframe>
    </div>
    
    <div title="<%= Html.ResourceString("Description") %>" id="descriptionPopUp" style="display: block; height: 300px;">
    </div>
    
    <div id="importProducts" style="padding:20px; text-align:center;">  
        <%using (Html.BeginForm("UploadXsl", "DealerCabinet", FormMethod.Post, new { id="xslForm", enctype="multipart/form-data" }))
          { %>
            <input type="file" name="xsl" id="xsl" />
        <%} %>
    </div>
    <h2>
        <%= Html.ResourceString("Products") %></h2>
    <br />
    
    <%= Html.DropDownList("groupIds", (List<SelectListItem>)ViewData["groups"], new { onchange = "groupSelected()" })%>
    <%= Html.ResourceActionLink("ManageGroups", "Groups") %>
    <a href="javascript:uploadXsl()">
        <%= Html.ResourceString("ImportProducts") %>
    </a>
    
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
                <a href="javascript:openImageIframe(<%= item.Id %>)" style="text-decoration:none;">
                    <%= Html.Image("~/Content/img/productImage.jpg", new {style="border:none" })%>
                </a>&nbsp;
                <a href="javascript:openDescriptionIframe(<%= item.Id %>)" class="productDescriptionLink">
                    i
                </a>
            </td>
            <td>
                <%= Html.TextBox("price_" + item.Id, item.Price, new { onblur = "tableChanged(updates, this)" })%>
            </td>
            <td align="center">
                <%= Html.CheckBox("active_" + item.Id, item.Enabled, new { onblur = "tableChanged(updates, this)" })%>
            </td>
        </tr>
        <%	} %>
    </table>
    <%using (Html.BeginForm("UpdateProducts", "DealerCabinet", FormMethod.Post))
      { %>
    <%= Html.Hidden("changes") %>
    <%= Html.Hidden("groupId") %>
    <input type="submit" value="<%= Html.ResourceString("Save") %>" onclick="collectChanges(updates, 'changes')" />
    <%} %>
    <%} %>
    <%
        if (Convert.ToInt32(ViewData["groupId"]) >= 0)
        {        
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

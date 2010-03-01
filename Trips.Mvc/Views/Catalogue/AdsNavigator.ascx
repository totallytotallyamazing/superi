<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<KeyValuePair<string, long>, List<KeyValuePair<string, long>>>>" %>
<div id="classBox">
    <div id="newsHeader">
        <p><asp:Literal runat="server" Text="<%$ Resources:WebResources, Classes %>"></asp:Literal></p>
    </div>
    <div id="newsContent">
        <div class="classMenuItems">
            <% foreach (var item in Model)
               {%>
                <div class="classMenuItem">
                    <a href="#"><%= item.Key.Key %></a>
                </div>
                <ul class="treeview" id="productGroups">
                    <% foreach (var brand in item.Value)
                       {%>
                        <li>
                            <div class="subMenuItem">
                                <%= Html.ActionLink(brand.Key, "Index", new {classId = item.Key.Value, brandId=brand.Value}) %>
                            </div>
                        </li>    
                     <%} %>
                </ul>
             <%} %>
        </div>
    </div>
    <div id="newsFooter">
    </div>
</div>
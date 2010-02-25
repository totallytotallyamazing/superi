<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Dictionary<string, List<KeyValuePair<string, int>>>>" %>
<div id="classBox">
    <div id="newsHeader">
        <p><asp:Literal runat="server" Text="<%$ Resources:WebResources, Classes %>"></asp:Literal></p>
    </div>
    <div id="newsContent">
        <div class="classMenuItems">
            <% foreach (var item in Model)
               {%>
                <div class="classMenuItem">
                    <a href="#"><%= item.Key %></a>
                </div>
                <ul class="treeview" id="productGroups">
                    <% foreach (var brand in item.Value)
                       {%>
                        <li>
                            <div class="subMenuItem">
                                <%= Html.ActionLink(brand.Key, "Index", new {id=brand.Value}) %>
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
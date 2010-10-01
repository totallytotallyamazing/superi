<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Shop.Models" %>

<% 
using (ShopStorage context = new ShopStorage())
{
    context.Tags.MergeOption = System.Data.Objects.MergeOption.NoTracking;
    foreach (var item in context.Tags.Where(t=>t.Type == 0))
    {%>
        <span style="padding-left:<%= item.Left %>px">
            <%= Html.ActionLink(item.Value, "Tags", new { controller = "Products", id = item.Id }) %>
        </span>             
    <%}    
}    
%>  
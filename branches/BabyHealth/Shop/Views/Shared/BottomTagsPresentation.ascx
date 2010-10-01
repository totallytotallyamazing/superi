<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Shop.Models" %>
<div id="notes">
<% 
using (ShopStorage context = new ShopStorage())
{
    context.Tags.MergeOption = System.Data.Objects.MergeOption.NoTracking;
    foreach (var item in context.Tags.Where(t=>t.Type == 1))
    {%>
        <div style="height:30px; position:absolute; top:<%= item.Top%>px; left:<%= item.Left %>px">
            <p style="font-size:<%= item.FontSize%>px; font-weight:bold;">
                <a style="color:#ff9999" href="<%= item.Url %>"><%= item.Value %></a>
            </p>
        </div>
    <%}    
}    
%>  
</div>
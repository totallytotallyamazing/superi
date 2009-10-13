<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<List<Zamov.Models.Category>>" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<asp:Content ID="Content4" ContentPlaceHolderID="leftMenu" runat="server">
    <%
        List<SelectListItem> leftMenuItems = (List<SelectListItem>)ViewData["leftMenuItems"];
        List<SelectListItem> items=  new List<SelectListItem>();
        foreach (var item in leftMenuItems)
        {
            SelectListItem listItem = new SelectListItem { Text = item.Text, Value = "/Categories/SelectCategory/" + item.Value };
            items.Add(listItem);
        }

        string menuHeader = (string)ViewData["menuHeader"];
        Html.RenderAction<Zamov.Controllers.PagePartsController>(ac => ac.LeftMenu(menuHeader, items)); 
    %>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
</asp:Content>
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<%
    List<SelectListItem> leftMenuItems = (List<SelectListItem>)ViewData["leftMenuItems"];

    if(Model!=null)
    foreach (Category subCategory in Model)
    {
        
        %>
        <div class="categoryItem">
            <div class="categoryImage">
                <a href="/Categories/SelectCategory/<%= subCategory.Id %>">
                    <%= Html.Image("~/Image/CategoryImageByCategoryId/" + subCategory.Id, new { style = "border:none;" })%>
                </a>
            </div>
            <%= Html.ActionLink(subCategory.Name, "SelectCategory", new { id = subCategory.Id }, new { @class = "categoryLink" })%>
    <%
        
        if (subCategory.Categories != null)
            if (subCategory.Categories.Count > 0)
            {
                %><ul><%
                foreach (Category subSubCategory in subCategory.Categories)
                {
                    if (subSubCategory.Enabled)
                    {
                    %>
                    <li>
                       
                        <%= Html.ActionLink(subSubCategory.Name, "SelectCategory", new { id = subSubCategory.Id }, new { @class = "categoryLink" })%>
                        
                    </li>
                    
                    <%
                          }
                }
                %></ul><%
            }
        %>
        </div>
        <%
    }
    
    
  
%>
    <div style="clear:both;"></div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="includes" runat="server">
</asp:Content>


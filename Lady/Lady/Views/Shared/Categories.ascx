﻿<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Lady.Models.Category>>" %>
<%@ Import Namespace="Lady.Models" %>
    <ul>
    <% foreach (var item in Model){ %>
        <li>
            <%= Html.ActionLink(item.Name, "Index", "Products", new { id = item.Id }, null) %>
        </li>    
    <% } %>
    </ul>
    
    <% if(Roles.IsUserInRole("Administrators")){ %>    
        <p class="adminLink categoriesAdmin">
            <a href="/Admin/Categories/AddEdit">Добавить категорию</a>
        </p>
    <%} %>


<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>
<script type="text/javascript">
    
</script>
<div id="searchText">
    <p>
        ПОИСК ПО КАТАЛОГУ
    </p>
</div>
<div id="search">
    <% using(Html.BeginForm("Search", "Products", FormMethod.Get, null)){ %>
        <%= Html.TextBox("searchField") %>
    <%} %>
<%--    <p>
        <a href="#">Расширенный поиск</a>
    </p>--%>
</div>
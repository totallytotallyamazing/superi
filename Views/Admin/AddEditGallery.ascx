<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<script type="text/javascript">
    function adminCattegoryAddSuccess() {
        $.fancybox.close();
        ClientLibrary.PageManager.get_current().goToUrl("/Gallery");
    }
</script>

<% using (Ajax.BeginForm(new AjaxOptions { OnSuccess = "adminCattegoryAddSuccess" }))
   { %>
    <%= Html.Hidden("id") %>
    Название<br />
    <%= Html.TextBox("name") %>
    <br />
    Комметарии<br />
    <%= Html.TextArea("comments", (string)ViewData["comments"], new { style="width:100px; height:50px;" })%>
    <br />
    <input type="submit" value="Сохранить" />
<%} %>
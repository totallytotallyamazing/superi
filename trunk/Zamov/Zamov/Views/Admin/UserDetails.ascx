<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<UserPresentation>" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Profile" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%@ Import Namespace="Zamov.Models" %>


<% using(Html.BeginForm("UpdateUser", "Admin", FormMethod.Post)){%>
<tr>
    <td>
        <%= Model.Email%>
        <%= Html.Hidden("userName", Model.Email) %>
    </td>
    <td>
        <%= Html.TextBox("firstName", Model.FirstName) %>
    </td>
    <td>
        <%= Html.TextBox("lastName", Model.LastName)%>
    </td>
    <td align="center">
        <%= Html.CheckBox("dealerEmployee", Model.DealerEmployee, new { rel = Model.Email })%>
    </td>
    <td>
       <%= Html.DropDownList("dealerId")%>
    </td>
    <td><input type="submit" value="<%= Html.ResourceString("Save") %>" /></td>
</tr>
<%} %>

<script type="text/javascript">
    $(function() { 
        
    })
</script>
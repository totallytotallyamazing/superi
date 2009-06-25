<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MembershipUser>" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Profile" %>
<%@ Import Namespace="Zamov.Helpers" %>
<%
    Zamov.Models.ProfileCommon profile = Zamov.Models.ProfileCommon.Create(Model.UserName);
%>
<% using(Html.BeginForm("UpdateUser", "Admin", FormMethod.Post)){%>
<tr>
    <td>
        <%= Model.UserName %>
        <%= Html.Hidden("userName", Model.UserName) %>
    </td>
    <td>
        <%= Html.TextBox("firstName", profile.FirstName) %>
    </td>
    <td>
        <%= Html.TextBox("lastName", profile.LastName) %>
    </td>
    <td align="center">
        <%= Html.CheckBox("dealerEmployee", profile.DealerEmployee, new {rel=Model.UserName })%>
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
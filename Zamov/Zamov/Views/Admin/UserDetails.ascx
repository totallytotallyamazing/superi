<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MembershipUser>" %>
<%@ Import Namespace="System.Web.Security" %>
<%@ Import Namespace="System.Web.Profile" %>
<%
    ProfileCommon profile = Profile.GetProfile(Model.UserName);
%>
<% using(Html.BeginForm("UpdateUser", "Admin", FormMethod.Post)){%>
<td>
    <%= Model.UserName %>
</td>
<td>
    <%= Html.TextBox("firstName", profile.FirstName) %>
</td>
<td>
    <%= Html.TextBox("lastName", profile.LastName) %>
</td>
<td>
    <%= Html.CheckBox("dealerEmployee", profile.DealerEmployee, new {rel=Model.UserName })%>
</td>
<td>
   <%= Html.DropDownList("dealerId")%>
</td>
<%} %>

<script type="text/javascript">
    $(function() { 
        
    })
</script>
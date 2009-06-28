<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Helpers" %>
<div style="padding:20px;">
    <center>
        <%= Html.ResourceString("Register").ToUpper() %>
    </center>
    <% using (Html.BeginForm("LogOn", "Account", FormMethod.Post)){ %>
    <table cellspacing="5">
        <tr>
            <td>
                <%= Html.ResourceString("Login")%>:
            </td>
            <td>
                <input type="text" id="userName" name="userName" class="logonInput" name="" />
            </td>
        </tr>
        <tr>
            <td>
                <%= Html.ResourceString("Password")%>:  
            </td>
            <td>
                <input type="password" id="password" name="password" class="logonInput" name="" />
            </td>
        </tr>
        <tr>
            <td>&nbsp</td>
            <td>
                <%= Html.CheckBox("rememberMe") + "&nbsp;" + Html.ResourceString("RememberMe")%>
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <input type="submit" value="<%= Html.ResourceString("LogOn") %>" />
            </td>
        </tr>
    </table>
    <%} %>
</div>
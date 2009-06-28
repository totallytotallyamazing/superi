<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<%@ Import Namespace="Zamov.Helpers" %>
<% using(Html.BeginForm("LogOff", "Account", FormMethod.Get)){ %>
    <input type="submit" value="<%= Html.ResourceString("LogOff") %>" />
<%} %>
<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KeyValuePair<string, bool>>" %>
<%
    string cssClass = (Model.Value) ? "current" : "";
 %>
 <span class="<%= cssClass %>"><%= Model.Key %></span   >
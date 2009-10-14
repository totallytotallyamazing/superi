<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PolialClean.Models.Objects>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<a href="/Content/Objects/<%= Model.Image %>">
    <%= Html.Image("~/Content/Objects/Previews/" + Model.Preview)%>
</a>

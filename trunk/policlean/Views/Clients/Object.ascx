<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<PolialClean.Models.Objects>" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>

<div class="objectImage">
<a href="/Content/Objects/<%= Model.Image %>" class="fancy" rel="<%=  Model.Clients.Id %>" >
    <%= Html.Image("~/Content/Objects/Previews/" + Model.Preview)%>
</a>

<%if(Request.IsAuthenticated){ %>
    <br />
    <%= Html.ActionLink("�������", "DeleteObject", "Admin", new {id = Model.Id}, new { @class="adminLink", onclick="return confirm('�� �������?')" }) %>
<%} %>
</div>

<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<Oksi.Models.Image>>" %>
<%@ Import Namespace="Oksi.Models" %>
<%@ Import Namespace="Oksi.Mvc.Ajax" %>

<% string id = "carousel_" + Model.First().GalleryId.ToString(); %>
  <ul id="<%= id %>" class="jcarousel-skin-tango">
<%foreach (var item in Model)
  {%>
    <li>
        <a href="/Content/Photo/<%= item.Picture %>" class="photoSession">
            <img alt="" src="/Content/Photo/<%= item.Preview %>" /> 
        </a>
    </li>  
  <%} %>
  </ul>
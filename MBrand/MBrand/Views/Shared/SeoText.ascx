<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%@ Import Namespace="MBrand.Helpers" %>


<%
    string seoText = Html.WriteSeoText(Model);
    
 %>

    
    <%if (!string.IsNullOrEmpty(seoText))
      { %>
      <div class="seoCustomText">
        <%=seoText%>
        </div>
        <%} %>
    

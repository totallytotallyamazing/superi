<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<string>" %>
<%@ Import Namespace="MBrand.Helpers" %>
   
    <%if (!string.IsNullOrEmpty(Model))
      { %>
      <div class="seoCustomText">
        <%=Model%>
        </div>
        <%} %>
    

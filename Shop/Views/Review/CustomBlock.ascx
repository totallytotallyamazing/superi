<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Shop.Models.ReviewContentItem>" %>
<%if (Model.ContentType == 1)
  {
  %>
  
  <%=Model.Text%>
  <%
  }
  else if (Model.ContentType == 2)
  {
%>
<div class="customBlock">
    <div class="customBlockTop">
    </div>
    <div class="customBlockContent">
    <%=Model.Text%> <br />
        К слову, основными ингридиентами хорошей статьи являются правильно выдрессированные
        журналистские замашки, сигара, ром, Рома, Игорь и Света на готовке чая. А то, что
        вам кажется будто написание случайного текста — труд каторжный, это всё напускное.
        Хотя, некоторые этим бравируют. А мы просто работаем.
    </div>
    <div class="customBlockBottom">
    </div>
</div>
<%
  }
    if (Model.ReviewContentItemImages.Count() > 0)
    {
        foreach (var image in Model.ReviewContentItemImages)
        {

        }
    }
%>

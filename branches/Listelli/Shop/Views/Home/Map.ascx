<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% Html.RenderAction("ShowContent", new { id = "MapTop" }); %>
<center>
<iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://maps.google.com/maps?q=50.42852,30.53843&amp;num=1&amp;sll=37.0625,-95.677068&amp;sspn=47.972233,78.662109&amp;ie=UTF8&amp;ll=50.429928,30.539331&amp;spn=0.009486,0.019205&amp;z=14&amp;output=embed&hl=ru"></iframe><br /><small><a href="http://maps.google.com/maps?q=50.42852,30.53843&amp;num=1&amp;sll=37.0625,-95.677068&amp;sspn=47.972233,78.662109&amp;ie=UTF8&amp;ll=50.429928,30.539331&amp;spn=0.009486,0.019205&amp;z=14&amp;source=embed" style="color:#0000FF;text-align:left">Просмотреть на карту побольше</a></small>
</center>
<% Html.RenderAction("ShowContent", new { id = "MapBottom" }); %>
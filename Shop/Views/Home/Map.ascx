<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<% Html.RenderAction("ShowContent", new { id = "MapTop" }); %>
<center>
<iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://maps.google.com/maps/ms?ie=UTF8&amp;hl=uk&amp;msa=0&amp;msid=202260091930978069168.00049ec3241db6b5192e0&amp;ll=50.436474,30.503012&amp;spn=0,0&amp;output=embed"></iframe><br /><small><a href="http://maps.google.com/maps/ms?ie=UTF8&amp;hl=uk&amp;msa=0&amp;msid=202260091930978069168.00049ec3241db6b5192e0&amp;ll=50.436474,30.503012&amp;spn=0,0&amp;source=embed" style="color:#0000FF;text-align:left"><%= Shop.Resources.Global.LargerMap %></a></small>
</center>
<% Html.RenderAction("ShowContent", new { id = "MapBottom" }); %>
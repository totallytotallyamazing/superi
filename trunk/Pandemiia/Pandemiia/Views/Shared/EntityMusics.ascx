<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Pandemiia.Models.Entity>" %>
<%@ Import Namespace="Pandemiia.Helpers" %>
<%@ Import Namespace="Pandemiia.Models" %>
<%@ Import Namespace="Microsoft.Web.Mvc" %>
<% foreach (EntityMusic music in Model.EntityMusics)
   {
       %>
    <div class="song">
        <center style="color:#ccc">
            <%= music.Artist + " - " + music.Name %><br />
            <object type="application/x-shockwave-flash" data="<%= VirtualPathUtility.ToAbsolute("~/Content/mp3Mini.swf") %>" width="200" height="20">
	            <param name="movie" value="<%= VirtualPathUtility.ToAbsolute("~/Content/mp3Mini.swf") %>" />
	            <param name="bgcolor" value="000000" />
	            <param name="FlashVars" value="mp3=<%= VirtualPathUtility.ToAbsolute("~/EntityMusic/" + music.FileName) %>" />
            </object>
        </center>
    </div>     
  <%} %>
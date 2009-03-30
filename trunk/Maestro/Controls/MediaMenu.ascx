<%@ Control Language="C#" ClassName="GalleryMeny" %>
<%@ Register Assembly="Superi" Namespace="Superi.CustomControls" TagPrefix="superi" %>
<%@ Import Namespace="Superi.Common" %>
<script runat="server">
    public int CurrentIndex
    {
        get
        {
            if (ViewState["CurrentIndex"] != null)
                return Convert.ToInt32(ViewState["CurrentIndex"]);
            return 0;
        }
        set { ViewState["CurrentIndex"] = value; }
    }
</script>
<% if(CurrentIndex!=0){ %>
  <a   
<%} %>
<% else{ %>
<span
<% } %>
 href="<%= WebSession.BaseUrl %>multimedia/photo" class="mediaLink">
     <superi:ResourceLabel runat="server" ResourceName="photo"></superi:ResourceLabel>
<% if(CurrentIndex!=0){ %>
  </a>   
<%} %>
<% else{ %>
</span>
<% } %>
<span class="mediaLinkSeparator">&nbsp;|&nbsp;</span>
<% if(CurrentIndex!=1){ %>
  <a   
<%} %>
<% else{ %>
<span
<% } %>
 href="<%= WebSession.BaseUrl %>multimedia/images" class="mediaLink">
     <superi:ResourceLabel ID="ResourceLabel1" runat="server" ResourceName="wallpapers"></superi:ResourceLabel>
<% if(CurrentIndex!=1){ %>
  </a>   
<%} %>
<% else{ %>
</span>
<% } %>
<span class="mediaLinkSeparator">&nbsp;|&nbsp;</span>
<% if(CurrentIndex!=2){ %>
  <a   
<%} %>
<% else{ %>
<span
<% } %>
 href="<%= WebSession.BaseUrl %>multimedia/video" class="mediaLink">
     <superi:ResourceLabel ID="ResourceLabel2" runat="server" ResourceName="video"></superi:ResourceLabel>
<% if(CurrentIndex!=2){ %>
  </a>   
<%} %>
<% else{ %>
</span>
<% } %>

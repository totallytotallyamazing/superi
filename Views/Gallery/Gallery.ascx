<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Gallery>" %>
<%@ Import Namespace="Oksi.Models" %>

    <div class="gallery">
        <div class="galleryTitle">
            <%= Model.Name %>
                <% if(Request.IsAuthenticated){ %>
            <%= Html.ActionLink("�������������", "AddEditGallery", "Admin", new { id = Model.Id }, new { @class = "adminLink" })%>
            <%} %>

        </div>
        <% 
            ViewData["galleryId"] = Model.Id;
            Html.RenderPartial("Images", Model.Images);
        %>
        <div class="galleryComments">
            <%= Model.Comments.Replace(Environment.NewLine, "<br />")%>
            
            <div class="shareButtons galleryShareButtons">
                <%string url = "http://oksi.com.ua/#url=%2FGallery"; %>
            <div>
                <a href="<%=url%>"  target="_blank" rel="nofollow" onclick="ODKL.Share(this);return false;" title="���������� � ��������������" class="shareButton odnoklassnikiButton"></a>
            </div>
            <div>
                <a href="http://www.facebook.com/sharer.php?u=<%=url%>" title="���������� � Facebook" rel="nofollow" target="blank" class="shareButton fbButton"></a>
            </div>  
            <div>
                <a href="http://twitter.com/home?status=<%=HttpUtility.UrlPathEncode(Model.Name.Trim())%> <%=HttpUtility.UrlEncode(url)%>"  target="_blank" rel="nofollow" class="shareButton twitterButton"></a>
            </div>                      
            <div>
                <a href="http://vkontakte.ru/share.php?url=<%=url%>" target="_blank" rel="nofollow" class="shareButton vkButton"></a>
            </div>
            </div>
        </div>
            <% if(Request.IsAuthenticated){ %>
        <div class="adminAction">
            <%= Html.ActionLink("�������", "DeleteGallery", "Admin", new { id = Model.Id }, new { @class = "adminConfirmLink" })%>
        </div>
    <%} %>

    </div>
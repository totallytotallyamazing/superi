<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Oksi.Models.Gallery>" %>
<%@ Import Namespace="Oksi.Models" %>

    <div class="gallery">
        <div class="galleryTitle">
            <%= Model.Name %>
                <% if(Request.IsAuthenticated){ %>
            <%= Html.ActionLink("Редактировать", "AddEditGallery", "Admin", new { id = Model.Id }, new { @class = "adminLink" })%>
            <%} %>

        </div>
        <% 
            ViewData["galleryId"] = Model.Id;
            Html.RenderPartial("Images", Model.Images);
        %>
        <div class="galleryComments">
            <%= Model.Comments.Replace(Environment.NewLine, "<br />")%>
            
            <div class="shareButtons galleryShareButtons">
                <%
                    string url ="http://oksi.com.ua/#url=%2FGallerys%2FIndex%2F"+Model.Id;
                    //string url = "http://1gb.ua";
                     %>
                <div>
                    <a href="<%=url%>"  target="_blank" rel="nofollow" onclick="ODKL.Share(this);return false;" title="Поделиться в Одноклассниках" class="shareButton odnoklassnikiButton"></a>
                </div>
                <div>
                    <a href="http://www.facebook.com/sharer.php?u=<%=HttpUtility.UrlEncode(url)%>" title="Поделиться в Facebook" rel="nofollow" target="blank" class="shareButton fbButton"></a>
                </div>  
                <div>
                    <a href="http://twitter.com/intent/tweet?text=<%=HttpUtility.UrlPathEncode(Model.Name.Trim())%> <%=HttpUtility.UrlEncode(url)%>"  target="_blank" rel="nofollow" class="shareButton twitterButton"></a>
                </div>                      
                <div>
                    <a href="http://vkontakte.ru/share.php?url=<%=HttpUtility.UrlEncode(url)%>" target="_blank" rel="nofollow" class="shareButton vkButton"></a>
                </div>
                <div style="clear:both"></div>
            </div>
            <div style="clear:both"></div>
        </div>
            <% if(Request.IsAuthenticated){ %>
        <div class="adminAction">
            <%= Html.ActionLink("Удалить", "DeleteGallery", "Admin", new { id = Model.Id }, new { @class = "adminConfirmLink" })%>
        </div>
    <%} %>

    </div>
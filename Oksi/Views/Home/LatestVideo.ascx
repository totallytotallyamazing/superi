<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div id="latestVideo">
    <div id="videoTitle"> 
        Последняя видео работа.
    </div>
    <div id="videoInfo">
        Краткая информация по клипу. Режисер. Оператор. Премьера.
    </div>
    <div id="videoPlayer">
        <object width="433" height="250">
            <param name="movie" value="http://www.youtube.com/v/pueZgI3_gQ0&hl=ru_RU&fs=1&"></param>
            <param name="allowFullScreen" value="true"></param><param name="allowscriptaccess" value="always"></param>
            <embed src="http://www.youtube.com/v/pueZgI3_gQ0&hl=ru_RU&fs=1&" 
                type="application/x-shockwave-flash" 
                allowscriptaccess="always" 
                allowfullscreen="true" 
                width="433" 
                height="250"
                wmode="transparent"></embed>
        </object>
    </div>
</div>
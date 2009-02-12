<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.preloadImages.js" type="text/javascript"></script>
    <script src="js/music.js" type="text/javascript"></script>
    <script src="js/master.js" type="text/javascript"></script>
    <script src="js/jquery.flash.js" type="text/javascript"></script>
    <script src="js/jquery.ui.draggable.js" type="text/javascript"></script>
    <script src="js/video.js" type="text/javascript"></script>
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>    
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server" ID="smMain">
            <Services>
                <asp:ServiceReference Path="~/Services/Music.asmx" />
                <asp:ServiceReference Path="~/Services/VideoService.asmx" />
            </Services>
        </asp:ScriptManager>
        <div id="main">
            <div id="top">
                <ul id="menu">
                    <li image="images/AlbumImages/nochenka.png" section="music" class="currentSection">музыка</li>
                    <li image="images/AlbumImages/newalbum.png" section="photo">фото</li>
                    <li image="images/AlbumImages/nochenka.png" section="video">видео</li>
                    <li image="images/AlbumImages/newalbum.png" section="news">новости</li>
                </ul>
                <script type="text/javascript">
                    var imgs = $("#menu li");
                    for (var i in imgs) {
                        $.preloadImages(imgs.eq(i).attr("image"));
                    }
                </script>
                <div id="subMenu">
                    <ul>
                        
                    </ul>
                </div>
            </div>
            <div id="middle">
                <div class="videoPlaceHolder">
                
                </div>
                <div class="songsPlaceHolder">
                    <ul>
                    
                    </ul>
                </div>
                <img class="currentBackground" alt="" />
                <img class="newBackground" alt="" />
            </div>
            <div id="bottom">
                <div id="copyrigth">
                    © 2009, Tina Karol, все права защищены
                </div>
                <div id="administration">
                    администрация:<br />                    Дарья Новикова<br />                    8 (067) 444-44-44<br />                    e-mail: <a href="mailto:darya@tinakarol.ua">darya@tinakarol.ua</a>
                </div>
                <div id="flashContainer">
                
                </div>
            </div>
        </div>
    </form>
</body>
</html>

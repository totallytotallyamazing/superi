<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.history.js" type="text/javascript"></script>
    <script src="js/jquery.preloadImages.js" type="text/javascript"></script>
    <script src="js/music.js" type="text/javascript"></script>
    <script src="js/master.js" type="text/javascript"></script>
    <script src="js/jquery.flash.js" type="text/javascript"></script>
    <script src="js/jquery.ui.js" type="text/javascript"></script>
    <script src="js/gallery.js" type="text/javascript"></script>
    <script src="js/video.js" type="text/javascript"></script>
    <script src="js/jquery.galleriffic.js" type="text/javascript"></script>
    <script src="js/news.js" type="text/javascript"></script>
    <script src="js/jquery.mousewheel.js" type="text/javascript"></script>
    <script src="js/jquery.em.js" type="text/javascript"></script>
    <script src="js/jScrollPane.js" type="text/javascript"></script>
    <link href="css/galleriffic.css" rel="stylesheet" type="text/css" />
    <link href="theme/ui.core.css" rel="stylesheet" type="text/css" />
    <link href="theme/ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="theme/ui.dialog.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/jScrollPane.css" rel="stylesheet" type="text/css" />
    <link href="theme/ui.accordion.css" rel="stylesheet" type="text/css" />
    <title></title>
    <script type="text/javascript">
        function noError(){return true;}
        window.onerror = noError;

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="smMain">
        <Services>
            <asp:ServiceReference Path="~/Services/Music.asmx" />
            <asp:ServiceReference Path="~/Services/VideoService.asmx" />
            <asp:ServiceReference Path="~/Services/GalleryService.asmx" />
            <asp:ServiceReference Path="~/Services/News.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="loadingContainer">
        <div id="loading">
        
        </div>
        <div class="myShadow" style="width:120px; height:60px; display:block;">

        </div>
        <div id="loadingSign" style="background:black; width:100px; display:block; height:30px; color:White; position:absolute; z-index:10002; text-align:center; padding-top:10px;">
            загрузка...
        </div>
    </div>


    <div id="main">
        <script type="text/javascript">
    </script>
        <div id="top">
            <ul id="menu">
                <li image="images/music.jpg" section="music">музыка</li>
                <li image="images/photo.jpg" section="photo">фото</li>
                <li image="images/video.jpg" section="video">видео</li>
                <li image="images/news.jpg" section="news">новости</li>
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
            <div class="galleryPlaceHolder">
                <div id="thumbs" class="navigation">
                    <ul class="thumbs noscript">
                    </ul>
                </div>
                <div id="gallery" class="content">
                    <div id="controls" class="controls">
                    </div>
                    <div id="slideshow" class="slideshow">
                    </div>
                </div>
            </div>
            <div class="videoPlaceHolder">
            </div>
            <div class="songsPlaceHolder">
                <ul>
                </ul>
            </div>
            <div id="newsContainer">
                <div id="newsContent">
                </div>
                <div class="bottom pagination" id="newsBottomPager">
                </div>
            </div>
            <div id="newsTextContainer">
            </div>
            <img class="currentBackground" alt="" src="Images/glava.jpg" />
            <img class="newBackground" alt="" />
        </div>

        <div id="bottom">
            <div id="footerMenu">
                <a href="javascript:showAlbumPhoto()">фото из альбома</a> &nbsp;&nbsp; <a>видео
                    из альбома</a>
            </div>
            <div id="copyrigth">
                © 2009, Tina Karol, все права защищены
            </div>
            <div id="administration" onclick="openContacts()">
                <img src="Images/contacts.jpg" />
            </div>
            <div id="contactsFull" title="Контакты">
                <span>администратор:</span><br />
                Дарья Новикова<br />
                8 (067) 659 44 44<br />
                <br />
                <span>PR:</span><br />
                Павел Подопригора<br />
                8 (050) 376 77 88<br />
                <br />
                <span>продюсер:</span><br />
                Евгений Огир
            </div>
            <div id="flashContainer">
            </div>
        </div>
    </div>
    </form>


</body>
</html>

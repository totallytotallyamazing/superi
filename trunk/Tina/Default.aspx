<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Title="Официальный сайт Тины Кароль" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery.preloadImages.js" type="text/javascript"></script>
    <script src="js/albums.js" type="text/javascript"></script>
    <script src="js/master.js" type="text/javascript"></script>
    <script src="js/jquery.flash.js" type="text/javascript"></script>
    <script src="js/jquery.ui.js" type="text/javascript"></script>
    <script src="js/gallery.js" type="text/javascript"></script>
    <script src="js/video.js" type="text/javascript"></script>
    <script src="js/jquery.galleriffic.js" type="text/javascript"></script>
    <script src="js/news.js" type="text/javascript"></script>
    <script src="js/jquery.mousewheel.js" type="text/javascript"></script>
    <script src="js/jquery.em.js" type="text/javascript"></script>
    <script src="js/jquery.easing.js" type="text/javascript"></script>
    <script src="js/jScrollPane.js" type="text/javascript"></script>
    <script src="js/jquery.pngFix.js" type="text/javascript"></script>
    <script src="js/jquery.fancybox.js" type="text/javascript"></script>
    <script src="js/history.js" type="text/javascript"></script>
    <script src="js/tours.js" type="text/javascript"></script>
    <link href="theme/ui.core.css" rel="stylesheet" type="text/css" />
    <link href="theme/ui.theme.css" rel="stylesheet" type="text/css" />
    <link href="theme/ui.dialog.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/jScrollPane.css" rel="stylesheet" type="text/css" />
    <link href="theme/ui.accordion.css" rel="stylesheet" type="text/css" />
    <link href="css/fancy.css" rel="stylesheet" type="text/css" />
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
            <asp:ServiceReference Path="~/Services/Tours.asmx" />
        </Services>
    </asp:ScriptManager>
    <div id="loadingContainer">
        <div id="loading">
            <div id="loadingSign" style="background:transparent; width:32px; display:block; height:32px; position:absolute; z-index:10002; text-align:center; padding-top:10px;">
                <img src="Images/ajaxLoader.gif" alt="Загрузка..." />
            </div>
        </div>
    </div>


    <div id="main">
        <script type="text/javascript">
    </script>
        <div id="top">
            <ul id="menu">
                <li style="font-size:0px; width:0px; height:0px; padding:0; margin:0;"></li>
                <li image="Images/music.jpg" section="music">альбомы</li>
                <li image="Images/photo.jpg" section="photo">фото</li>
                <li image="Images/video.jpg" section="video">клипы</li>
                <li image="Images/news.jpg" section="news">новости</li>
                <li image="Images/TourImages/bgTour1.jpg" section="tours">туры</li>
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
            <div id="funClub">
                <a target="_blank" href="http://www.tinakarol.net"><img alt="Фан клуб" src="Images/fun.jpg" /></a>
            </div>
            <div id="promoDiv">
                не бойся &nbsp;
                <img src="Images/playPromoG.jpg" id="promoStop" />
                &nbsp;
                <img src="Images/stopPromoW.jpg" id="promoPlay" />
            </div>


        <div id="middle">
            <div class="galleryPlaceHolder">
                <div id="thumbs" class="navigation">
                    <ul class="thumbs">
                        <center></center>
                    </ul>
                </div>
                <div id="galleryPages" class="bottom pagination">
                    <center></center>
                </div>
            </div>
            <div class="videoPlaceHolder">
                <div class="videoDragHandle">
                </div>
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
            <div id="tourContainer">
                
            </div>
            <img class="currentBackground" alt="" src="Images/main.jpg" />
            <img class="newBackground" alt="" />
        </div>

        <div id="bottom">
            <div id="footerMenu">

            </div>
            <div id="copyrigth">
                <a href="mailto:al@akula.com.ua" ><img src="Images/akula.jpg" /></a>
                © 2009, Tina Karol, все права защищены
            </div>
            <div id="administration" onclick="openContacts()">
                <!--img src="Images/contacts.jpg" /-->
                контакты
            </div>
            <div id="contactsFull" title="Контакты">
                <span>продюсер:</span><br />
                Евгений Огир<br />
                <a href="mailto:ogir@tinakarol.com.ua">ogir@tinakarol.ua</a>
                <br /><br />
                <span>администратор:</span><br />
                Дарья Новикова<br />
                8 (067) 659 44 44<br />
                <a href="mailto:darya@tinakarol.com.ua">darya@tinakarol.ua</a>
                <br /><br />
                <span>PR:</span><br />
                Павел Подопригора<br />
                8 (050) 376 77 88<br />
                <a href="mailto:pavel@tinakarol.com.ua">pavel@tinakarol.ua</a>
            </div>
            <div id="flashContainer">
            </div>
            <div id="promoContainer">
            </div>
        </div>
    </div>
    </form>
<div id="iframeContainer" style="width:1px; height:1px; overflow:hidden; margin-left:-1000px">
    <iframe id="historyIframe" src="cache.aspx"></iframe>
</div>
<script type="text/javascript">
    //playPromo();
    showPromoClip()
    startHistoryLoop();
</script>
</body>
</html>

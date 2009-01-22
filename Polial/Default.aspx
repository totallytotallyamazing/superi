<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link rel="Stylesheet" href="css/start.css" />
    <title>Untitled Page</title>
    <script type="text/javascript" src="js/master.js"></script>
    <script type="text/javascript">
        function setBgImage(el, num)
        {
            if(num.indexOf('a')>-1)
            {
                el.style.backgroundImage='url("images/startMenu/'+num+'")';
            }
            else
            {
                el.style.backgroundImage='';
            }
            
        }
        
        function placeLangs()
        {
        
            var switcher = document.getElementById('switcher');
            switcher.style.top = '';
            var switcherTop = getAbsolutePos(switcher).y;
            if(switcherTop<701)
            {
                switcher.style.top = 701+'px';
            }

            
        }
    </script>
    
</head>
<body onload="placeLangs();" onresize="placeLangs();">
    <form id="form1" runat="server">
    <div id="main">
        <div id="mainBottom">
            <div id="spaceMaker"></div>
            <map name="map">
                <area shape="rect" coords="0,0,21,18" href="mailto:mail@mail.mail" />
                <area shape="rect" coords="0,18,21,36" href="contacts" />
            </map>
            <div class="switcher" id="switcher">
                <img src="Images/startMenu/switcher.jpg" usemap="#map" /><br />
                <div class="lang">
                    <a href="lang=<%= (WebSession.Language == "RU")?"EN":"RU" %>"><%= (WebSession.Language == "RU")?"EN":"RU" %></a>
                </div>
            </div>
        </div>
        <div id="mainTop">
            <div id="spacerTop"></div>
            <div id="spacerLeft"></div>
            <div class="m1" onmouseover="setBgImage(this, 'm1a.jpg')" onmouseout="setBgImage(this, 'm1.jpg')">
                <a href="aboutus">
                    <%= (WebSession.Language=="RU")?"о компании":"about us" %>
                </a>
            </div>
            <div class="m2" onmouseover="setBgImage(this, 'm2a.jpg')" onmouseout="setBgImage(this, 'm2.jpg')">
                <a href="contacts">
                    <%= (WebSession.Language=="RU")?"контакты":"contacts" %>
                </a>
            </div>
            <div class="m3" onmouseover="setBgImage(this, 'm3a.jpg')" onmouseout="setBgImage(this, 'm3.jpg')">
                <a href="works">
                     <%= (WebSession.Language=="RU")?"виды работ":"work kinds" %>
                </a>
            </div>
            <div id="central"></div>
            <div class="m4" onmouseover="setBgImage(this, 'm4a.jpg')" onmouseout="setBgImage(this, 'm4.jpg')">
                <a href="objects">
                    <%= (WebSession.Language=="RU")?"объекты":"objects" %>
                </a>
            </div>
            <div class="m5" onmouseover="setBgImage(this, 'm5a.jpg')" onmouseout="setBgImage(this, 'm5.jpg  ')">
                <a href="declaration">
                    <%= (WebSession.Language=="RU")?"политика качества":"quality politics" %>
                </a>
            </div>

        </div>
    </div>
    
    </form>
</body>
</html>

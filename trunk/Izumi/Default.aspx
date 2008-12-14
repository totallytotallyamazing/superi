<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="Controls" TagName="MainMenu" Src="~/Controls/MainMenu.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
        <% switch (WebSession.Language)
           { 
               case "RU":
                   Response.Write("Изуми");
                   break;
               case "EN":
                   Response.Write("Izumi");
                   break;
               case "UA":
                   Response.Write("Iзумi");
                   break;
           }
               %>
        
    </title>
        <script type="text/javascript">
        function menuDivOver(el)
        {
            el.style.backgroundImage='url(<%= DefaultValues.BaseUrl %>images/menuHover.jpg)';
        }
        
        function menuDivOut(el)
        {
            el.style.backgroundImage='';
        }
        
        function displayLangTip(id, text)
        {
            var div = document.getElementById(id);
            div.style.color='white';
        //    div.innerHTML = text;
        }
        
        function hideLangTip(id)
        {
            var div = document.getElementById(id);
            div.style.color='#520101';
           // div.innerHTML = '';  
        }
    </script>
    <link rel="Stylesheet" href="<%= DefaultValues.BaseUrl+"css/global.css" %>" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="startMain">
        <div id="langSpacer">
        </div>
        <div id="langsDiv">
            <% if(WebSession.Language!="UA") %>
            <%{ %>
            <div id="uaImg"><a onmouseover="displayLangTip('uaText','укр.')" onmouseout="hideLangTip('uaText')" href="lang=UA" ><img class="langImg" src="<%=DefaultValues.BaseUrl %>Images/UALang.jpg" alt="UA" /></a></div>
            <div id="uaText">UA</div>
            <% } %>
            <% if(WebSession.Language!="RU") %>
            <%{ %>
            <div id="ruImg"><a onmouseover="displayLangTip('ruText','рус.')" onmouseout="hideLangTip('ruText')"  href="lang=RU"><img class="langImg" src="<%=DefaultValues.BaseUrl %>Images/RULang.jpg" alt="RU" /></a></div>
            <div id="ruText">RU</div>
            <% } %>
            <% if(WebSession.Language!="EN") %>
            <%{ %>
            <div id="enImg"><a onmouseover="displayLangTip('enText','en.')" onmouseout="hideLangTip('enText')"  href="lang=EN"><img class="langImg" src="<%=DefaultValues.BaseUrl %>Images/ENLang.jpg" alt="EN" /></a></div>
            <div id="enText">EN</div>
            <% } %>
        </div>
        <div id="menuSpacer"></div>
        <center>
            <Controls:MainMenu runat="server" />
        </center>        

    </div>
    </form>
</body>
</html>

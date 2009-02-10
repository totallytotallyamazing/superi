<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="Controls" TagName="MainMenu" Src="~/Controls/MainMenu.ascx" %>
<%@ Import Namespace="Superi.Common" %>
<html>
<head runat="server">
    <title>        
        <% switch (WebSession.Language)
           { 
               case "RU":
                   Response.Write("Лермонт");
                   break;
               case "EN":
                   Response.Write("Lermont");
                   break;
               case "UA":
                   Response.Write("Лермонт");
                   break;
           }
               %>
    </title>
    <link rel="stylesheet" href="css/start.css" />
    <script type="text/javascript" src="js/master.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <table border="0" cellpadding="0" cellspacing="0" id="main">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" style="width:100%; height:100%;">
                        <tr>
                           <td valign="bottom" style="width:234px;">                                
                                <div id="langsDiv">
                                    <% if(WebSession.Language!="UA") %>
                                    <%{ %>
                                    <div id="uaImg"><a onmouseover="displayLangTip('uaText','укр.')" onmouseout="hideLangTip('uaText')" href="lang=UA" ><img class="langImg" src="<%=WebSession.BaseUrl %>Images/UALang.jpg" alt="UA" /></a></div>
                                    <div id="uaText">&nbsp;UA</div>
                                    <% } %>
                                    <% if(WebSession.Language!="RU") %>
                                    <%{ %>
                                    <div id="ruImg"><a onmouseover="displayLangTip('ruText','рус.')" onmouseout="hideLangTip('ruText')"  href="lang=RU"><img class="langImg" src="<%=WebSession.BaseUrl %>Images/RULang.jpg" alt="RU" /></a></div>
                                    <div id="ruText">&nbsp;RU</div>
                                    <% } %>
                                    <% if(WebSession.Language!="EN") %>
                                    <%{ %>
                                    <div id="enImg"><a onmouseover="displayLangTip('enText','en.')" onmouseout="hideLangTip('enText')"  href="lang=EN"><img class="langImg" src="<%=WebSession.BaseUrl %>Images/ENLang.jpg" alt="EN" /></a></div>
                                    <div id="enText">&nbsp;EN</div>
                                    <% } %>
                                </div></td>
                           <td valign="bottom" style="width:80%;">
                                <center>
                                    <Controls:MainMenu ID="MainMenu1" runat="server" />
                                </center>
                           </td>
                           <td style="width:234px;">&nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>

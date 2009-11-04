<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MBrand.Models.Work>>" %>
<%@ Import Namespace="MBrand.Models" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["workGroupName"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%
        WorkType workType = (WorkType)ViewData["workType"];
        string chapterName = "";
        switch (workType)
        {
            case WorkType.Site:
                chapterName = "Сайты";
                break;
            case WorkType.Vcard:
                chapterName = "Визитки";
                break;
            case WorkType.Logo:
                chapterName = "Логотипы";
                break;
            case WorkType.Poly:
                chapterName = "Полиграфия";
                break;
            case WorkType.Text:
                chapterName = "Работа с текстом";
                break;
        }
    %>
    <h2>
       » <a href="/See/<%= workType.ToString() %>"><%= chapterName %></a> » <%= ViewData["workGroupName"] %>
    </h2>
    <div style="padding-left:17px;">
        
    </div>
    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
	Посмотреть
</asp:Content>

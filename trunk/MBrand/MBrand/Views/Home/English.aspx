<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Engish
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="english">
        <span>LEAЯИ ЯUSSIAИ!</span><br />
        Иностранцы должны проявлять больше уважения к нашей культуре.
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Includes" runat="server">
    <style type="text/css">
        .english{text-align:center; float:left; padding-top:150px;}
        .english span{font-size:70px;}
    </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="HeaderTitle" runat="server">
    Ага, щас
</asp:Content>

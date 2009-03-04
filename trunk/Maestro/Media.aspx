<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Media.aspx.cs" Inherits="Media" %>
<%@ Register TagPrefix="superi" Assembly="Superi" Namespace="Superi.CustomControls" %>
<%@ Import Namespace="Superi.Common" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link rel="Stylesheet" href="<%= WebSession.BaseUrl + "css/media.css" %>" />
    <script type="text/javascript">
        $(document).ready(function() {
            $("#photo").mouseover(function() { $("#photo").attr("class", "photoOver"); $("#photo img").attr("src", "Images/photoGalleryHover.jpg"); }).mouseout(function() { $("#photo").attr("class", "photo"); $("#photo img").attr("src", "Images/photoGallery.jpg"); });
            $("#wallpaper").mouseover(function() { $("#wallpaper").attr("class", "wallpaperOver"); $("#wallpaper img").attr("src", "Images/wallpaperHover.jpg"); }).mouseout(function() { $("#wallpaper").attr("class", "wallpaper"); $("#wallpaper img").attr("src", "Images/wallpaper.jpg"); });
            $("#video").mouseover(function() { $("#video").attr("class", "videoOver"); $("#video img").attr("src", "Images/videoHover.jpg"); }).mouseout(function() { $("#video").attr("class", "video"); $("#video img").attr("src", "Images/video.jpg"); });
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <div id="mediaContainer">
        <div id="photo" class="photo">
            <a href="<%= WebSession.BaseUrl %>multimedia/photo">
                <img src="Images/photoGallery.jpg" alt="photo" /><br />
                <superi:ResourceLabel runat="server" ResourceName="photo"></superi:ResourceLabel>
            </a>
        </div>
        <div id="wallpaper" class="wallpaper">
            <a href="<%= WebSession.BaseUrl %>multimedia/images">
                <img src="Images/wallpaper.jpg" alt="wallpaper" /><br />
                <superi:ResourceLabel runat="server" ResourceName="wallpapers"></superi:ResourceLabel>
            </a>
        </div>
        <div id="video" class="video">
            <a href="<%= WebSession.BaseUrl %>multimedia/video">
                <img src="Images/video.jpg" alt="video" /><br />
                <superi:ResourceLabel runat="server" ResourceName="video"></superi:ResourceLabel>
            </a>
        </div>
    </div>
</asp:Content>


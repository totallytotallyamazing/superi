<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Shop.Areas.BrandCatalog.Models.CatalogueImage>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Управление каталогом
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="selects">
        Бренды:<%= Html.DropDownList("brandId", (IEnumerable<SelectListItem>)ViewData["brands"]) %>
        Группы:<%= Html.DropDownList("groupId", (IEnumerable<SelectListItem>)ViewData["groups"]) %>
    </div>
    <div id="images">
        
    </div>
    <div id="upload">
        <div id="myQueue"></div>
        <input type="file" id="file_upload" name="Filedata" /><br />
    </div>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentTitle" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="includes" runat="server">
    <script src="/Scripts/swfobject.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.uploadify.js" type="text/javascript"></script>
    <link href="/Content/AdminStyles/uploadify.css" rel="stylesheet" type="text/css" />
    <link href="/Content/AdminStyles/manageCatalogue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        /// <reference path="jquery.uploadify.js"/>
        $(function () {
            $('#file_upload').uploadify({
                uploader: '/scripts/uploadify.swf',
                script: '/Admin/BrandCatalogue/UploadImage',
                cancelImg: '/Content/AdminStyles/img/cancel.png',
                fileDesc: 'Image Files (.JPG, .GIF, .PNG)',
                folder: '/uploads',
                fileExt: '*.jpg;*.gif;*.png',
                multi: true,
                queueSizeLimit: 150,
                queueID: 'myQueue',
                removeCompleted: false,
                simUploadLimit : 3, 
                scriptData: <%= ViewData["scriptData"] %>,
                scriptAccess : 'always',
                buttonText: "KAPTUHKU",
                auto: true
            });
        })
    </script>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>


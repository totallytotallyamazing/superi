<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>
<%@ Import Namespace="Dev.Mvc.Ajax" %>

<%= Ajax.ScriptInclude("/Scripts/swfobject.js")%>
<%= Ajax.ScriptInclude("/Scripts/jquery.uploadify.js")%>
<%= Ajax.DynamicCssInclude("/Content/AdminStyles/uploadify.css") %>
<%= Ajax.DynamicCssInclude("/Content/AdminStyles/manageCatalogue.css") %>
<script type="text/javascript">
        /// <reference path="jquery.uploadify.js"/>
        $(function () {
            $('#file_upload').uploadify({
                uploader: '/scripts/uploadify.swf',
                script: '/Admin/Review/UploadImage',
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
                //buttonImg   : '/Content/AdminStyles/img/browseButton.jpg',
                auto: true,
                onAllComplete: function(){ $("#selects form").get(0).submit(); }
            });
            $("#upload").hide(0);
        })
    </script>

<a onclick="$('#upload').show('normal');" href="#" class="backLink" >Загрузить фото</a>
<div id="upload" >
    <div id="myQueue"></div>
    <input type="file" id="file_upload" name="Filedata" />
    <a href="#" onclick="$('#upload').hide('normal');" class="backLink">Отмена</a>
</div>

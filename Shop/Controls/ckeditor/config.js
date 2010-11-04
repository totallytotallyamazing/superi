/*
Copyright (c) 2003-2010, CKSource - Frederico Knabben. All rights reserved.
For licensing, see LICENSE.html or http://ckeditor.com/license
*/
var _FileBrowserLanguage = 'aspx'; // asp | aspx | cfm | lasso | perl | php | py
var _QuickUploadLanguage = 'aspx'; // asp | aspx | cfm | lasso | perl | php | py

// Don't care about the following two lines. It just calculates the correct connector
// extension to use for the default File Browser (Perl uses "cgi").
var _FileBrowserExtension = _FileBrowserLanguage == 'perl' ? 'cgi' : _FileBrowserLanguage;
var _QuickUploadExtension = _QuickUploadLanguage == 'perl' ? 'cgi' : _QuickUploadLanguage;

CKEDITOR.editorConfig = function (config) {
    config.filebrowserBrowseUrl = '/Controls/filemanager/browser/default/browser.html?Connector=' + encodeURIComponent('/Controls/filemanager/connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension);
    config.filebrowserImageBrowseUrl = '/Controls/filemanager/browser/default/browser.html?Type=Image&Connector=' + encodeURIComponent('/Controls/filemanager/connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension);
    config.filebrowserFlashBrowseUrl = '/Controls/filemanager/browser/default/browser.html?Type=Flash&Connector=' + encodeURIComponent('/Controls/filemanager/connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension);
    config.filebrowserUploadUrl = '/Controls/filemanager/connectors/' + _QuickUploadLanguage + '/upload.' + _QuickUploadExtension;
    config.filebrowserImageUploadUrl = '/Controls/filemanager/connectors/' + _QuickUploadLanguage + '/upload.' + _QuickUploadExtension + '?Type=Image';
    config.filebrowserFlashUploadUrl = '/Controls/filemanager/connectors/' + _QuickUploadLanguage + '/upload.' + _QuickUploadExtension + '?Type=Flash';
    config.extraPlugins = 'MediaEmbed';
    config.htmlEncodeOutput = true;
    config.language = "ru";
    config.toolbar_Media =
[
    ['Source'],
    ['Cut', 'Copy', 'Paste', 'PasteText', 'PasteFromWord'],
    ['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
    '/',
    ['Bold', 'Italic', 'Underline', 'Strike', '-', 'Subscript', 'Superscript'],
    ['NumberedList', 'BulletedList', '-', 'Outdent', 'Indent', 'Blockquote'],
    ['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyBlock'],
    ['Link', 'Unlink', 'Anchor'],
    ['Image', 'MediaEmbed', 'Flash', 'Table', 'HorizontalRule'],
    '/',
    ['Styles', 'Format', 'Font', 'FontSize'],
    ['TextColor', 'BGColor'],
    ['Maximize', 'ShowBlocks']
];
};

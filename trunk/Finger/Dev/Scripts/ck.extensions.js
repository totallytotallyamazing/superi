var ckExtender = new Object();

ckExtender.enableHtmlEncodeOutput = function(editor, textId) {
    editor.updateElement = function() {
        var element = this.element;
        var data = editor.getData();
        data = CKEDITOR.tools.htmlEncode(data);

        if (element && this.elementMode == CKEDITOR.ELEMENT_MODE_REPLACE) {
            if (element.is('textarea'))
                element.setValue(data);
            else
                element.setHtml(data);
        }
    }
};



ckExtender.bindFileManager = function(editorId) {

    var _FileBrowserLanguage = 'aspx'; // asp | aspx | cfm | lasso | perl | php | py
    var _QuickUploadLanguage = 'aspx'; // asp | aspx | cfm | lasso | perl | php | py

    // Don't care about the following two lines. It just calculates the correct connector
    // extension to use for the default File Browser (Perl uses "cgi").
    var _FileBrowserExtension = _FileBrowserLanguage == 'perl' ? 'cgi' : _FileBrowserLanguage;
    var _QuickUploadExtension = _QuickUploadLanguage == 'perl' ? 'cgi' : _QuickUploadLanguage;

    CKEDITOR.replace(editorId,
    {
        filebrowserBrowseUrl: '/Controls/filemanager/browser/default/browser.html?Connector=' + encodeURIComponent('/Controls/filemanager/connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension),
        filebrowserImageBrowseUrl: '/Controls/filemanager/browser/default/browser.html?Type=Image&Connector=' + encodeURIComponent('/Controls/filemanager/connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension),
        filebrowserFlashBrowseUrl: '/Controls/filemanager/browser/default/browser.html?Type=Flash&Connector=' + encodeURIComponent('/Controls/filemanager/connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension),
        filebrowserUploadUrl: '/Controls/filemanager/connectors/' + _QuickUploadLanguage + '/upload.' + _QuickUploadExtension,
        filebrowserImageUploadUrl: '/Controls/filemanager/connectors/' + _QuickUploadLanguage + '/upload.' + _QuickUploadExtension + '?Type=Image',
        filebrowserFlashUploadUrl: '/Controls/filemanager/connectors/' + _QuickUploadLanguage + '/upload.' + _QuickUploadExtension + '?Type=Image',
        
        toolbar: "Media", language: "ru-RU", width:400
    });
};
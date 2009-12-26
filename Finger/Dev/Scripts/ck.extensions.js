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
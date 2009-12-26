var ckExtender = new Object();

ckExtender.enableHtmlEncodeOutput = function(editor, textId) {
    $(function() {
        $("input[type='submit']").click(function() {
            var data = editor.getData();
            editor.setData(CKEDITOR.tools.htmlEncode(data));
            try {
                editor.getData();
            }
            catch (ex) { }
            $("#" + textId).val(CKEDITOR.tools.htmlEncode(data));
        })
    })
};
var ckExtender = new Object();

ckExtender.enableHtmlEncodeOutput = function(editor) {
    $(function() {
        $("input[type='submit']").click(function() {
            var data = editor.getData();
            editor.setData(CKEDITOR.tools.htmlEncode(data));
            try {
                editor.getData();
            }
            catch (ex) { }
        })
    })
};
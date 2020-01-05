var markdownEditors = {};
window.initilizeEditor = function (el, mdEditor, height, value, enableSyncScroll) {
    var editor = CodeMirror.fromTextArea(el, {
        lineNumbers: true,
        mode: "markdown",
        highlightFormatting: true,
        foldGutter: true,
        lineWrapping: true,
        matchBrackets: true,
        styleActiveLine: true,
        styleSelectedText: true,
        showTrailingSpace: true,
        gutters: ["CodeMirror-linenumbers", "CodeMirror-foldgutter"]
    });
    editor.setValue(value);
    editor.display.wrapper.style.marginTop = "43px";
    editor.display.wrapper.style.height = (height - 42) + "px";
    editor.on("change", function () {
        mdEditor.invokeMethodAsync("refreshPreview", editor.getValue());
    });
    markdownEditors[el] = editor;
    if (!enableSyncScroll) {
        return;
    }
    editor.on("scroll", function () {
        var scrollInfo = editor.getScrollInfo();
        mdEditor.invokeMethodAsync("scrollPreview", scrollInfo.top);
    });
};
window.scrollPreview = function (preview, scrollTop) {
    preview.scrollTop = scrollTop;
};
window.wrapSelection = function (el, prefix, suffix) {
    var editor = this.markdownEditors[el];
    var selection = editor.getSelection();
    if (!selection) {
        selection = "内容";
    }
    editor.replaceSelection(prefix + selection + suffix);
}
window.append = function (el, content) {
    var editor = this.markdownEditors[el];
    editor.replaceSelection(content);
}
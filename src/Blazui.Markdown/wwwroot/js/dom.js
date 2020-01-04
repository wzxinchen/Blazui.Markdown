window.initilizeEditor = function (el, mdEditor, height) {
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
    editor.display.wrapper.style.marginTop = "43px";
    editor.display.wrapper.style.height = (height - 42) + "px";
    editor.on("change", function () {
        mdEditor.invokeMethodAsync("refreshPreview", editor.getValue());
    });
}
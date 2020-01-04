window.initilizeEditor = function (el) {
    var editor = CodeMirror.fromTextArea(el, {
        lineNumbers: true,
        mode: "markdown",
        highlightFormatting: true,
        foldGutter: true,
        lineWrapping: true,
        matchBrackets: true,
        gutters: ["CodeMirror-linenumbers", "CodeMirror-foldgutter"],
    });
}
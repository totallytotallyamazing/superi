var historyCallBacks = new Array();
var currentHash = "";
var newHash = "";
var intervalID;

function setHistoryCallback(hash, callback) {
    window.location.hash = hash;
    if ($.browser.msie) {
        document.getElementById("historyIframe").contentWindow.location.href = "cache.aspx?" + hash;
    }
    currentHash = hash;
    for (var i in historyCallBacks) {
        if (historyCallBacks[i].hash == hash) {
            historyCallBacks[i] = { hash: hash, callback: callback };
            return;
        }   
    }
    historyCallBacks[historyCallBacks.length] = {hash:hash, callback:callback};
}

function startHistoryLoop() {
    intervalID = setInterval(historyLoopProcess, 50)
}

function stopHistoryLoop() {
    if (intervalID != null)
        clearInterval(intervalID);
}

function historyLoopProcess() {
    var newHash = window.location.hash.replace("#", "");
    if ($.browser.msie) {
        var loc = document.getElementById("historyIframe").contentWindow.location.href;
        if (loc.indexOf("?") > -1)
            newHash = loc.substring(loc.indexOf("?") + 1);
        else
            newHash = "";
    }
    
    if (newHash === currentHash)
        return;
    if ($.browser.msie) {
        window.location.hash = newHash;
    }
    if (newHash === "") {
        currentHash = "";
        resetMainMenu();
        return;
    }
    for (var i in historyCallBacks) {
        if (newHash === historyCallBacks[i].hash) {
            currentHash = newHash;
            historyCallBacks[i].callback(historyCallBacks[i].hash);
            return;
        }
    }
}

startHistoryLoop();
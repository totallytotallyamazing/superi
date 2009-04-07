var historyCallBacks = new Array();
var currentHash = "";
var newHash = "";
var intervalID;

function setHistoryCallback(hash, callback) {
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
    var newHash = window.location.hash;
    if (newHash === currentHash)
        return;
    for (var i in historyCallBacks) {
        if (newHash === historyCallBacks[i].hash) {
            currentHash = newHash;
            historyCallBacks[i].callback(historyCallBacks[i].hash);
            return;
        }
    }
}

startHistoryLoop();
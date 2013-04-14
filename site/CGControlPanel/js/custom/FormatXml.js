// JScript File
function f(e) {
    if (e.className == "ci") {
        if (e.children(0).innerText.indexOf("\n") > 0) fix(e, "cb");
    }
    if (e.className == "di") {
        if (e.children(0).innerText.indexOf("\n") > 0) fix(e, "db");
    } e.id = "";
}

function fix(e, cl) {
    e.className = cl;
    e.style.display = "block";
    j = e.parentElement.children(0);
    j.className = "c";
    k = j.children(0);
    k.style.visibility = "visible";
    k.href = "#";
}

function ch(e) {
    // mark = e.children(0).children(0);
    mark = e.children[0].children[0];
    if (mark.innerText == "+") {
        mark.innerText = "-";
        for (var i = 1; i < e.children.length; i++) {
            e.children[i].style.display = "block";
        }
    }
    else if (mark.innerText == "-") {
        mark.innerText = "+";
        for (var i = 1; i < e.children.length; i++) {
            e.children[i].style.display = "none";
        }
    }
}

function ch2(e) {
    mark = e.children(0).children(0);
    contents = e.children(1);
    if (mark.innerText == "+") {
        mark.innerText = "-";
        if (contents.className == "db" || contents.className == "cb") {
            contents.style.display = "block";
        }
        else {
            contents.style.display = "inline";
        }
    }
    else if (mark.innerText == "-") {
        mark.innerText = "+";
        contents.style.display = "none";
    }
}

function cl() {
    e = window.event.srcElement;
    if (e.className != "c") {
        e = e.parentElement;
        if (e.className != "c") {
            return;
        }
    }
    e = e.parentElement;
    if (e.className == "e") {
        ch(e);
    }
    if (e.className == "k") {
        ch2(e);
    }
}

function ex() { }
function h() { window.status = " "; }
document.onclick = cl;
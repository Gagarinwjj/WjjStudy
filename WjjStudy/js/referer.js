function getQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)", "i");
    var r = window.location.search.substr(1).match(reg);
    if (r != null)
        return unescape(r[2]);
    return null;
}

function getCookies(prefix) {
    if (document.cookie.length > 0) {
        var cookies = "";
        start = 0;
        n_start = document.cookie.indexOf(prefix + "_", start);
        if (n_start != -1) {
            v_start = n_start + prefix.length + 1;
            v_end = document.cookie.indexOf(";", v_start);
            if (v_end == -1)
                v_end = document.cookie.length;
            cookies += document.cookie.substring(n_start, v_end);
            start = v_end;
            n_start = document.cookie.indexOf(prefix + "_", start)
        }
        return cookies;
    }
    return ""
}
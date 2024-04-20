window.os = () => {
    let os = "Other";

    if (navigator.userAgent.indexOf("Win") !== -1) os = "Windows";
    else if (navigator.userAgent.indexOf("Mac") !== -1) os = "MacOS";
    else if (navigator.userAgent.indexOf("Linux") !== -1) os = "Linux";

    else if (navigator.userAgent.indexOf("Android") !== -1) os = "Android";
    else if (navigator.userAgent.indexOf("CrOS") !== -1) os = "ChromeOS";
    
    else if (navigator.userAgent.indexOf("iPod") !== -1) os = "iOS";
    else if (navigator.userAgent.indexOf("iPad") !== -1) os = "iPadOS";
    else if (navigator.userAgent.indexOf("iPhone") !== -1) os = "iOS";

    return os;
};
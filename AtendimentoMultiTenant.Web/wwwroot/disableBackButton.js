window.addEventListener('popstate', function (event) {
    document.location.replace("/#nocache");
    history.pushState(null, document.title, location.href);
});

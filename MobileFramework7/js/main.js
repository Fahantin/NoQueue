var myApp = new Framework7();
 
var $$ = Dom7;
 
var mainView = myApp.addView('.view-main', {
    // Because we want to use dynamic navbar, we need to enable it for this view:
    dynamicNavbar: true
});
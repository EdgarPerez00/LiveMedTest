// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
var myModal;
(function () {
    myModal = new bootstrap.Modal(document.getElementById('alertModal'), {
        keyboard: true
    });

})();

function showData(text) {
    $("#message").html(text);

    myModal.show();
}
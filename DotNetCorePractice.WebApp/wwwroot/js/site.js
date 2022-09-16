// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function () {
    $(document).ready(function () {
        $.get('https://localhost:5001/api/Products', function (data) {
            console.log(data);
        })
    })
})();
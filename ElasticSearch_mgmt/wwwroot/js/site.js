// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $("[data-autocomplete-source]").each(function () {
        var target = $(this);
        target.autocomplete({ source: target.attr("data-autocomplete-source") });
    });
});
$(document).ready(function () {
   
    $("input[type='submit']").click(function (e) {
        e.preventDefault();
        var namefunc = $(this).attr("act");
        var name = $(this).siblings("#Validform_phase").val();
        debugger
       
        var market = $(this).siblings("#Validform_market").val();
       
        var count = $(this).siblings("#Validform_count").val();

        name = encodeURIComponent(name);
        market = encodeURIComponent(market);
        count = encodeURIComponent(count);
        count = Number(count);

        $('#results').load("https://localhost:44372/Home/" + namefunc+"?name=" + name + "&market=" + market+"&count="+count);
    });
});
$(function () {
    $('.clos').click(function () {
        $(this).siblings("#Validform_phase").val("");
    });
});
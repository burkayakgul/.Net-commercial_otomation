$(document).ready(function () {
    hide = function () {
        $("#kategori-form").hide();
        $("#marka-form").hide();
        $("#ozellik-form").hide();
        $('#ozellik-buton').removeClass('btn-reddit').addClass('btn-outline-reddit');
        $('#kategori-buton').removeClass('btn-reddit').addClass('btn-outline-reddit');
        $('#marka-buton').removeClass('btn-reddit').addClass('btn-outline-reddit');
    }
    hide();
    $("#kategori-buton").click(function () {
        hide();
        $("#kategori-form").show();
        $('#kategori-buton').removeClass('btn-outline-reddit').addClass('btn-reddit');
    });

    $("#marka-buton").click(function () {
        hide();
        $("#marka-form").show();
        $('#marka-buton').removeClass('btn-outline-reddit').addClass('btn-reddit');
    });

    $("#ozellik-buton").click(function () {
        hide();
        $("#ozellik-form").show();
        $('#ozellik-buton').removeClass('btn-outline-reddit').addClass('btn-reddit');
    });
});
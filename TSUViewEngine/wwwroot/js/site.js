
$("#addBtn").on("click", function (e) {
    e.preventDefault();
    var url = $(this).attr("href");
    $.get(url, function (response) {
        $("#exampleModal").html(response);
    });
    $('#exampleModal').modal('show');
});

$(document).on("click", ".editBtn", function (e) {
    e.preventDefault();
    var url = $(this).attr("href");
    $.get(url, function (response) {
        $("#exampleModal").html(response);
    });
    $('#exampleModal').modal('show');
});

$(document).on("submit", "#form", function (e) {
    e.preventDefault();
    var url = $(this).attr("action");
    var data = $(this).serialize();
    $.post(url, data, function (data) {
        $("#tableBody").replaceWith(data);
        $('#exampleModal').modal('hide');
    });
});
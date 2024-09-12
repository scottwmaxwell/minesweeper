$(function () {
    console.log("Page is ready");

    $(document).bind("contextmenu", function (e) {
        e.preventDefault();
        console.log("Right click. Prevent context menu from showing.");
    });

    $(document).on("mousedown", ".cell", function (event) {
        switch (event.which) {
            case 1:
                event.preventDefault();
                var id = $(this).val();
                console.log("Cell Id " + id + " was left clicked");
                updateBoard(id);
                break;
            case 3:
                alert('Right mouse button is pressed');
            default:
                break;
        }
    });
});

function updateBoard(id) {
    $.ajax({
        datatype: "html",
        method: 'POST',
        data: {
            "Id": id
        },
        url: '/Gameboard/UpdateBoard',
        success: function (data) {
            $("#game-board").html(data);
        }
    });
}

// Left in here just in case we need it for right-click
function doCellUpdate(id, urlString) {
    $.ajax({
        datatype: "json",
        method: 'POST',
        url: urlString,
        data: {
            "Id": id
        },
        success: function(data) {
            console.log(data);
            $("#" + id).html(data);
        }
    });
};
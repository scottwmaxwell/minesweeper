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
                updateBoard(id, "/Gameboard/UpdateBoard");
                break;
            case 3:
                event.preventDefault();
                var id = $(this).val();
                console.log("Cell Id " + id + " was right clicked");
                updateBoard(id, "/Gameboard/FlagCell");
            default:
                break;
        }
    });
});

function updateBoard(id, urlString) {
    $.ajax({
        datatype: "html",
        method: 'POST',
        data: {
            "Id": id
        },
        url: urlString,
        success: function (data) {
            $("#game-board").html(data);
        }
    });
}

// Is this needed?s
function getBoardUpdate(id, urlString) {
    board = [];
    $.ajax({
        datatype: "json",
        method: 'POST',
        url: urlString,
        data: {
            "Board": board
        },
        success: function (data) {
            console.log(data);
        }
    });
};
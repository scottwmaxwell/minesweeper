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
                //doCellUpdate(id, "/gameboard/ShowOneCell"); 
                getBoardUpdate(id, "/gameboard/HandleLeftClick");
                break;
            case 3:
                alert('Right mouse button is pressed');
            default:
                break;
        }
    });
});

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

function updateBoard() {

}
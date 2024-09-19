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
                var audio = new Audio('../audio/reveal.mp3');
                audio.play();
                break;
            case 3:
                event.preventDefault();
                var id = $(this).val();
                console.log("Cell Id " + id + " was right clicked");
                updateBoard(id, "/Gameboard/FlagCell");
                var audio = new Audio('../audio/flag.mp3');
                audio.play();
            default:
                break;
        }
    });

    $('#save-game').on("mousedown", function (event) {
        saveGame();
    });

    $('#delete-game').on("mousedown", function (event) {
        const id = $('.saved-game.selected').attr('id');
        let result;
        if (id) 
            result = confirm("Are you sure you want to delete this game?");
        if(result) deleteGame(id);
    });

    getAllGames();

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
            updateStatus();
        }
    });
}

function getAllGames() {
    $.ajax({
        datatype: "json",
        method: 'GET',
        url: "/api/GameAPI/showSavedGames/",
        success: function (data) {
            console.log(data);
            appendGameList(data);
            $('.saved-game').each(function () {
                $(this).on("click", handleSaveGameClick);
            });
        }
    })
}

function handleSaveGameClick(e) {

    // Unselect all other games
    $('.saved-game').each(function () {
        $(this).removeClass("selected");
    });

    console.log(e.target.id);
    // Select new clicked game
    e.target.classList += " selected";

    // Show delete button
    $('#delete-game').removeClass('hide');
    
}

function appendGameList(games) {
    games.findLast((game) => {
        let newLine = `<li class="saved-game" id="${game.id}">${game.date}</li>`
        console.log(newLine);
        $('#saved-games').append(newLine);
    });
}

function saveGame() {
    $.ajax({
        datatype: "html",
        method: 'POST',
        url: "/Gameboard/SaveGame",
        success: function (data) {
            console.log("Game saved");
            $('#saved-games').empty();
            getAllGames();
        }
    })
}

function deleteGame(id) {
    $.ajax({
        datatype: "html",
        method: 'DELETE',
        url: "/api/GameAPI/deleteOneGame/" + id,
        success: function (data) {
            console.log("Deleted game");
            $('#saved-games').empty();
            getAllGames();
        }
    })
}

function updateStatus() {
    $.ajax({
        datatype: "html",
        method: 'POST',
        url: "/Gameboard/UpdateStatus",
        success: function (data) {
            console.log("Game Status: " + data);
            if (data == 2) {
                var audio = new Audio('../audio/bomb.mp3');
                audio.play();
                $('#game-status').html("Game Over!")
                setTimeout(() => {
                    $(".live").each((index, element) => {
                        $(element).attr('src', '../img/explode.png');
                    });
                }, 1500);

            } else if (data == 1) {
                var audio = new Audio('../audio/win.mp3');
                audio.play();
                $('#game-status').html("You won!")
            }
        }
    });
}
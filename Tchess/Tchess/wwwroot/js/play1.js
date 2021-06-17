var board = null
var game = new Chess()
let moveee
let enemyId
let blackplay = false
let whiteplay = false
let user = {
    name: document.getElementById("username").innerText,
    rating: document.getElementById("rating").innerText
}

function onDragStart(source, piece, position, orientation) {

    // do not pick up pieces if the game is over
    if (game.game_over()) return false

    // only pick up pieces for White
    if (piece.search(/^b/) !== -1) return blackplay
    if (piece.search(/^w/) !== -1) return whiteplay
}

function makeMove(moveee) {
    var possibleMoves = game.moves()

    // game over
    if (possibleMoves.length === 0) {
        lost()
    }

    game.move(moveee)
    var possibleMoves = game.moves()

    // game over
    if (possibleMoves.length === 0) {
        lost()
    }
    board.position(game.fen())
}

function onDrop(source, target) {
    // see if the move is legal
    var move = game.move({
        from: source,
        to: target,
        promotion: 'q' // NOTE: always promote to a queen for example simplicity
    })
    // illegal move
    if (move === null) return 'snapback'
    moveee = move.san
    send()

}

// update the board position after the piece snap
// for castling, en passant, pawn promotion
function onSnapEnd() {
    board.position(game.fen())
}

var config = {
    draggable: true,
    position: 'start',
    orientation: 'white',
    onDragStart: onDragStart,
    onDrop: onDrop,
    onSnapEnd: onSnapEnd
}
board = Chessboard('myBoard', config)

//connect
var connection = new signalR.HubConnectionBuilder().withUrl("/PlayHub").build();


//get move
connection.on("ReceiveMessage", function (user, message) {
    makeMove(message)
});

//start
connection.start().then(function () {
    connect()
}).catch(function (err) {
    return console.error(err.toString());
});

//emit
function send() {
    connection.invoke("SendMessage", enemyId, moveee).catch(function (err) {
        return console.error(err.toString());
    });
}


//networking
function connect() {
    connection.invoke("SendNetwork", "", JSON.stringify(user)).catch(function (err) {
        return console.error(err.toString());
    });
}


connection.on("ReceiveNetwork", function (user, message) {
    if (enemyId == null) {
        enemyId = user
    }
    showinfo(message)
    whiteplay = true
    connectToUser()
});

function connectToUser() {
    connection.invoke("SendToId", enemyId, JSON.stringify(user)).catch(function (err) {
        return console.error(err.toString());
    });
}

connection.on("ReceiveId", function (user, message) {
    if (enemyId == null) {
        enemyId = user
    }

    showinfo(message)
    blackplay = true
    var config = {
        draggable: true,
        position: 'start',
        orientation: 'black',
        onDragStart: onDragStart,
        onDrop: onDrop,
        onSnapEnd: onSnapEnd
    }
    board = Chessboard('myBoard', config)

});

function showinfo(message) {
    let name = JSON.parse(message).name
    let rating = JSON.parse(message).rating
    document.getElementById("enemyname").innerText = name
    document.getElementById("enemyrating").innerText = rating
    document.getElementById("enemyinfo").style.display = "block"
    document.getElementById("waiting").style.display = "none"
}

async function lost() {
    $("#loseModal").modal("show")
    connection.invoke("SendWin", enemyId, "").catch(function (err) {
        return console.error(err.toString());
    });
    await fetch("./LoseRating/"+document.getElementById("profileId").innerText)
}

async function won() {
    $("#winModal").modal("show")
    await fetch("./WinRating/"+document.getElementById("profileId").innerText)

}

connection.on("ReceiveWin", function (user, message) {
    won()
})

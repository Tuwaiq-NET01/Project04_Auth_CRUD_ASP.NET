const modalhandling = async (id) => {
    document.getElementById("form_id").action = "/Game/Edit";
    document.getElementById("submit").value = "Edit Game";
    const response = await fetch("https://localhost:5001/Game/getGame/"+id)
    const game = await response.json()
    console.log(game)
    document.getElementById("Moves").value = game.moves
    document.getElementById("Winner").value = game.winner
    document.getElementById("NumMoves").value = game.numMoves
    document.getElementById("id").value = game.id
    document.getElementById("Player").value = game.profileId
}

const emptyModel = () =>{
    document.getElementById("form_id").action = "/Game/Create";
    document.getElementById("submit").value = "Add Game";
    document.getElementById("Moves").value = ""
    document.getElementById("Winner").value = ""
    document.getElementById("NumMoves").value = ""
    document.getElementById("Player").value = ""
}

const addfav = async (id) => {
    await fetch("https://localhost:5001/Faviort/AddFaviorte/"+id)
    document.getElementById("alertt").style.display = "block"
}
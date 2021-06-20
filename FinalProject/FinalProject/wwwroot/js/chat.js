"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var imgCheck = message[message.length - 3] + message[message.length - 2] + message[message.length - 1]
    if (imgCheck == "png" || imgCheck == "gif" || imgCheck == "peg" || imgCheck == "jpg") {
        var img = document.createElement("IMG");
        img.src = message
        img.width = "150"
        img.height = "150"
        document.getElementById("messagesList").appendChild(img);
    } else {

        var li = document.createElement("p")
        var li2 = document.createElement("div")
        var span = document.createElement("span")
        var image = document.createElement("IMG");
        image.src = document.getElementById("mainimg").src
        image.classList.add("right")
        li2.appendChild(image)
        span.innerText = new Date().toUTCString()
        span.classList.add("time-left")
        li2.appendChild(li)
        li2.appendChild(span)
        li2.classList.add("ccontainer")
        li2.classList.add("darker")
        document.getElementById("messagesList").appendChild(li2);

    }
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    //li.textContent = `${user} says ${message}`;
    
    li.textContent = `${message}`;
});

connection.on("MeReceiveMessage", function (user, message) {
    var imgCheck = message[message.length - 3] + message[message.length - 2] + message[message.length - 1]
    if (imgCheck == "png" || imgCheck == "gif" || imgCheck == "peg" || imgCheck == "jpg") {
        var img = document.createElement("IMG");
        img.src = message
        img.width = "150"
        img.height = "150"
        document.getElementById("messagesList").appendChild(img);
    } else {

        var li = document.createElement("p")
        var li2 = document.createElement("div")
        var span = document.createElement("span")
        li2.appendChild(li)
        li2.classList.add("ccontainer")
        span.innerText = new Date().toUTCString()
        span.classList.add("time-right")
        li2.appendChild(span)
        document.getElementById("messagesList").appendChild(li2);

    }
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    //li.textContent = `${user} says ${message}`;
    var userInput = document.getElementById("userInput").value
    var messageInput = document.getElementById("messageInput").value
    var typeInput = document.getElementById("typeInput").value
    var chatIdInput = document.getElementById("chatIdInput").value
    gett({
        chatId: parseInt(chatIdInput),
        type: typeInput,
        data: messageInput,
        userId: userInput
    })
    li.textContent = `${message}`;
});


connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    //document.getElementById("messageInput").value = ""
    event.preventDefault();
    //document.getElementById("forms").submit()
});

const gett = (data1) => {
    fetch('https://localhost:5001/Message/CreateMsg', {
        method: "POST",
        body: JSON.stringify(data1),
        headers: { "Content-type": "application/json; charset=UTF-8" }
    })
        .then(response => {
            response.json()
            console.log(response)
        })
        .catch (err => console.log(err));

}
async function postData(url = '', data = {}) {
    // Default options are marked with *
    const response = await fetch(url, {
        method: 'POST', // *GET, POST, PUT, DELETE, etc.
        mode: 'cors', // no-cors, *cors, same-origin
        cache: 'no-cache', // *default, no-cache, reload, force-cache, only-if-cached
        credentials: 'same-origin', // include, *same-origin, omit
        headers: {
            'Content-Type': 'application/json'
            // 'Content-Type': 'application/x-www-form-urlencoded',
        },
        redirect: 'follow', // manual, *follow, error
        referrerPolicy: 'no-referrer', // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url
        body: JSON.stringify(data) // body data type must match "Content-Type" header
    });
    return response.json(); // parses JSON response into native JavaScript objects
}
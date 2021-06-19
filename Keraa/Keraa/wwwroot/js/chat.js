"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
//eventHub.server.joinGroup("my-awsm-group");
var room = document.getElementById("roomChat").value;
var userId = document.getElementById("userId").value;
var userImage = document.getElementById("userImage").value;


//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

/*connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("div");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    if (user == "1f4f9201-dd10-464f-8dff-2426be4d5f27") {*/

connection.on("ReceiveMessage", function (user, message, id, userImage) {
    var li = document.createElement("div");
    document.getElementById("messagesList").appendChild(li);
    if (userId == id) {

        li.innerHTML = ` <div class="d-flex justify-content-end mb-4">
                <div class="msg_cotainer_send">
                    ${message}
                    <span class="msg_time_send">${user}</span>
                </div>
                <div class="img_cont_msg">
                    <img src=${userImage} class="rounded-circle user_img_msg">
                </div>
            </div>`;
    } else {
        li.innerHTML =
            `
        <div class="d-flex justify-content-start mb-4">
                <div class="img_cont_msg">
                    <img src=${userImage} class="rounded-circle user_img_msg">
                </div>
                    <div class="msg_cotainer">
                ${message}
                    <span class="msg_time">${user}</span>
            </div>
        </div>
        `;
    }
/*    li.textContent = `${user} says ${message}`;
*/
});
connection.on("ReceiveNotify", function (message) {
    var notify = document.createElement("div");
    document.getElementById("messagesList").appendChild(notify);
    notify.innerHTML = ` <center>
                <div >
                    ${message}
                </div>
            </center>`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
    connection.invoke("JoinRoom", room).catch(function (err) {
        return console.error(err.toString());
    });
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage",room, user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

document.getElementById("RoomLeaver").addEventListener("click", function () {
        connection.invoke("LeaveRoom", room).catch(function (err) {
            return console.error(err.toString());
        });
});

/*
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
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
    event.preventDefault();
});
*/
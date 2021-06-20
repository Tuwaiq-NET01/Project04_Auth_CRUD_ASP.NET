import React, { Component } from 'react'

export default class Contact extends Component {
    render() {
        return (
            // contact us information
            <div className="contact">
                <h2>Contact us</h2>
                <h4>Welcome to the Red Sea Diving Center. My name is Adel, and I am the founder of the RSDC website. Email me if you have a problem and I can help you with it.</h4>
                <h4><a href = "mailto: abc@example.com">Send Email</a></h4>
                <p>Good luck,</p>
            </div>
        )
    }
}

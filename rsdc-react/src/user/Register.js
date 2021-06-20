import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'
import { Alert } from "react-bootstrap";

export default class Register extends Component {
    state = {
        message: null
    }

    // send value to register compount
    registerHandler = () => {
            // check if two password match
        if (this.state.password == this.state.confirmPassword) {
            this.props.register(this.state);  
        } else{
            this.setState({
                message: "password does not match"
              });
            //   remove alert massage
              setTimeout(() => {
                this.setState({
                  message:false
                });
              }, 3000);      
              }
    }

    // change input value 
    changeHandler = (e) => {
         let temp = {... this.state}
         temp[e.target.name] = e.target.value;
         this.setState(temp)
        console.log(temp);
    } 

    render() {

        // alert message show if message not null
        const message = this.state.message ? (
            <Alert variant="danger">{this.state.message}</Alert>
          ) : null;

        return (
            <div>
                {/* view message and input form */}
                {message}
                <Container>
                    <Form.Group>
                        <Form.Control type="text" name="username" placeholder="Enter your username" onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="email" name="email" placeholder="Enter your Email Address" onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="password" name="password" placeholder="Enter your Password" onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="password" name="confirmPassword" placeholder="Confirm your Password" onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Button variant="primary" block onClick={this.registerHandler}>Register</Button>
                </Container>
                
            </div>
        )
    }
}

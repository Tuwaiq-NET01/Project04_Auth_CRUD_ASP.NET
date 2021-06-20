import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'
import { Alert } from "react-bootstrap";

export default class ProfileEditForm extends Component {
    
    constructor(props){
        super(props);
        this.state ={
            newUser : props.user,
            successmessage: null,
            message: null

        }
    }

    // view user value and change it to new value 
    changeHandler= (event) =>{
        const attributeToChange = event.target.name
        const newValue = event.target.value

        const updatedUser = {...this.state.newUser}
        updatedUser[attributeToChange] = newValue
        console.log(updatedUser)
        this.setState({
            newUser: updatedUser
        })

    }

        // send new value to edit user compount
    handleSubmit =(e) =>{
        // check if two password match
        if (this.state.newUser.password == this.state.newUser.confirmPassword) {        
             this.props.editUser(this.state.newUser);
           this.setState({
            successmessage: "Profilo editing successfully"
          });
        } else{
            this.setState({
                message: "password does not match"
              });
              }

              //   remove alert massage 
              setTimeout(() => {
                this.setState({
                  successmessage:false,
                  message:false
                });
              }, 3000);     
    }

    render() {

        // alert message show if message not null
        const successmessage = this.state.successmessage ? (
            <Alert variant="success">{this.state.successmessage}</Alert>
          ) : null;

          const message = this.state.message ? (
            <Alert variant="danger">{this.state.message}</Alert>
          ) : null;

        return (
            <div>

                <Container>
                {/* view message and input form */}
                    <Form.Group>
                      <Form.Label>{message}{successmessage}</Form.Label>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="firstName" value={this.state.newUser.firstName} onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="lastName" value={this.state.newUser.lastName} onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Label>Image</Form.Label>
                        <Form.Control type="text" name="image" value={this.state.newUser.image} onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                    <Form.Label>Start Date</Form.Label>
                        <Form.Control type="date" name="startDate"  onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="password" name="password" placeholder="Enter your new Password or retype your old Password" onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="password" name="confirmPassword" placeholder="Confirm your Password" onChange={this.changeHandler} required></Form.Control>
                    </Form.Group>


                    <Button variant="primary" block onClick={this.handleSubmit}>Edit Profile</Button>
                </Container>

            </div>
        )
    }
}

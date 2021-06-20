import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class CoachNewForm extends Component {
    constructor(props){
        super(props);
        this.state ={
            new : {userEmail:props.email}
        }
    }

    // change the value in the input and save it
    changeHandler= (event) =>{
        const attributeToChange = event.target.name
        const newValue = event.target.value

        const updated = {...this.state.new}
        updated[attributeToChange] = newValue
        console.log(updated)
        this.setState({
            new: updated
        })

    }

    // send new value to add compount
    handleSubmit =(event) =>{
        event.preventDefault()
        this.props.add(this.state.new);
    }
    render() {
        return (
            // input for add new value
            <div>
                 <Container>
                    <Form.Group>
                        <Form.Control type="text" name="FirstName" placeholder="ex: Adel" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="LastName" placeholder="ex: Kalu" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="Email" placeholder="ex: Adel@Kalu" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="Password" placeholder="ex: Adel12345" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="Username" placeholder="ex: AdelKalu" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="Phone" placeholder="ex: 535555555" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="StartDate" placeholder="ex: 2018-01-06T17:16:40" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="Gender" placeholder="ex: M or F" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="Image" placeholder="ex: http://adel-kalu.com/index/images/icon.png" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Button variant="primary" block onClick={this.handleSubmit}>Add Coach</Button>
                </Container>
                
            </div>
        )
    }
}

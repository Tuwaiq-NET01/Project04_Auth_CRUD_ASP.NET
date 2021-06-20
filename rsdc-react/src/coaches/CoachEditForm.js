import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class CoachEditForm extends Component {
    constructor(props){
        super(props);
        this.state ={
            newCoach : props.coach
        }
    }

    // change the value in the input and save it
    changeHandler= (event) =>{
        const attributeToChange = event.target.name
        const newValue = event.target.value

        const updated = {...this.state.newCoach}
        updated[attributeToChange] = newValue
        console.log(updated)
        this.setState({
            newCoach: updated
        })

    }

    // send new value to add compount
    handleSubmit =(event) =>{
        event.preventDefault()
        this.props.edit(this.state.newCoach);
    }
    render() {
        return (
            // input show the old value and you can edit it
            <div>
                 <Container>
                    <Form.Group>
                        <Form.Control type="text" name="firstName" value={this.state.newCoach.firstName} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="lastName" value={this.state.newCoach.lastName} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="email" value={this.state.newCoach.email} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="password" value={this.state.newCoach.password} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="username" value={this.state.newCoach.username} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="phone" value={this.state.newCoach.phone} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="startDate" value={this.state.newCoach.startDate} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="gender" value={this.state.newCoach.gender} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="image" value={this.state.newCoach.image} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>
                    
                    <Button variant="primary" block onClick={this.handleSubmit}>Edit Coach</Button>
                </Container>
            </div>
        )
    }
}

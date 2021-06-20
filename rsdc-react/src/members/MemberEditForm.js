import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class MemberEditForm extends Component {
    constructor(props){
        super(props);
        this.state ={
            newMember : props.member
        }
    }

    // change the value in the input and save it
    changeHandler= (event) =>{
        const attributeToChange = event.target.name
        const newValue = event.target.value

        const updated = {...this.state.newMember}
        updated[attributeToChange] = newValue
        console.log(updated)
        this.setState({
            newMember: updated
        })

    }

    // send new value to add compount
    handleSubmit =(event) =>{
        event.preventDefault()
        this.props.edit(this.state.newMember);
    }
    render() {
        return (
            // input show the old value and you can edit it
            <div>
                 <Container>
                    <Form.Group>
                        <Form.Control type="text" name="firstName" value={this.state.newMember.firstName} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="lastName" value={this.state.newMember.lastName} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="email" value={this.state.newMember.email} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="password" value={this.state.newMember.password} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="username" value={this.state.newMember.username} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="phone" value={this.state.newMember.phone} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="startDate" value={this.state.newMember.startDate} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="gender" value={this.state.newMember.gender} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="image" value={this.state.newMember.image} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="coachId" value={this.state.newMember.coachId} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="typeId" value={this.state.newMember.typeId} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>
                    
                    <Button variant="primary" block onClick={this.handleSubmit}>Edit Member</Button>
                </Container>
            </div>
        )
    }
}

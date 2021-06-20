import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class StoryNewForm extends Component {
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
                        <Form.Control type="text" name="title" placeholder="ex: title" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="description" placeholder="ex: description" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="price" placeholder="ex: price" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="image" placeholder="ex: http://adel-kalu.com/index/images/icon.png" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="typeId" placeholder="ex: 1" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Button variant="primary" block onClick={this.handleSubmit}>Add Story</Button>
                </Container>
                
            </div>
        )
    }
}

import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class StoryEditForm extends Component {
    constructor(props){
        super(props);
        this.state ={
            newStory : props.story
        }
    }

    // change the value in the input and save it
    changeHandler= (event) =>{
        const attributeToChange = event.target.name
        const newValue = event.target.value

        const updated = {...this.state.newStory}
        updated[attributeToChange] = newValue
        console.log(updated)
        this.setState({
            newStory: updated
        })

    }

    // send new value to add compount
    handleSubmit =(event) =>{
        event.preventDefault()
        this.props.edit(this.state.newStory);
    }
    render() {
        return (
            // input show the old value and you can edit it
            <div>
                 <Container>
                    <Form.Group>
                        <Form.Control type="text" name="title" value={this.state.newStory.title} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="description" value={this.state.newStory.description} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="price" value={this.state.newStory.price} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="image" value={this.state.newStory.image} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="typeId" value={this.state.newStory.typeId} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>
                    
                    <Button variant="primary" block onClick={this.handleSubmit}>Edit Story</Button>
                </Container>
            </div>
        )
    }
}

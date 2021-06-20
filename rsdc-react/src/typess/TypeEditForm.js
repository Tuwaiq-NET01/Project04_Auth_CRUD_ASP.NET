import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class TypeEditForm extends Component {
    constructor(props){
        super(props);
        this.state ={
            newType : props.type
        }
    }

    // change the value in the input and save it
    changeHandler= (event) =>{
        const attributeToChange = event.target.name
        const newValue = event.target.value

        const updated = {...this.state.newType}
        updated[attributeToChange] = newValue
        console.log(updated)
        this.setState({
            newType: updated
        })

    }

    // send new value to add compount
    handleSubmit =(event) =>{
        event.preventDefault()
        this.props.edit(this.state.newType);
    }
    render() {
        return (
            // input show the old value and you can edit it
            <div>
                 <Container>
                    <Form.Group>
                        <Form.Control type="text" name="fee" value={this.state.newType.fee} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="divingType" value={this.state.newType.divingType} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    
                    <Button variant="primary" block onClick={this.handleSubmit}>Edit Type</Button>
                </Container>
            </div>
        )
    }
}

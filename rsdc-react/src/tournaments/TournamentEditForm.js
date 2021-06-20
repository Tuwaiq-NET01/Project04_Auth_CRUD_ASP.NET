import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class TournamentEditForm extends Component {
    constructor(props){
        super(props);
        this.state ={
            newTournament : props.tournament
        }
    }

    // change the value in the input and save it
    changeHandler= (event) =>{
        const attributeToChange = event.target.name
        const newValue = event.target.value

        const updated = {...this.state.newTournament}
        updated[attributeToChange] = newValue
        console.log(updated)
        this.setState({
            newTournament: updated
        })

    }

    // send new value to add compount
    handleSubmit =(event) =>{
        event.preventDefault()
        this.props.edit(this.state.newTournament);
    }
    render() {
        return (
            // input show the old value and you can edit it
            <div>
                 <Container>
                    <Form.Group>
                        <Form.Control type="text" name="tourName" value={this.state.newTournament.tourName} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="year" value={this.state.newTournament.year} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="tourType" value={this.state.newTournament.tourType} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Form.Group>
                        <Form.Control type="text" name="memberId" value={this.state.newTournament.memberId} onChange={this.changeHandler}></Form.Control>
                    </Form.Group>
                    
                    <Button variant="primary" block onClick={this.handleSubmit}>Edit Tournament</Button>
                </Container>
            </div>
        )
    }
}

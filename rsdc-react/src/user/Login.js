import React, { Component } from 'react'
import { Container, Form, Button } from 'react-bootstrap'

export default class Login extends Component {
    state = {}

    // send input to login compount by state
    loginHandler = () => {
        this.props.login(this.state);
    }

    // change input value and but in the state
    changeHandler = (e) => {
        let temp = {... this.state}
        temp[e.target.name] = e.target.value;
        this.setState(temp)
        console.log(temp);
    } 

    render() {
        return (
            // input to add login information
            <div>
                <Container>                   
                    <Form.Group>
                        <Form.Control type="email" name="Email" placeholder="Enter your Email Address" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>
                    
                    <Form.Group>
                        <Form.Control type="password" name="Password" placeholder="Enter your Password" onChange={this.changeHandler}></Form.Control>
                    </Form.Group>

                    <Button variant="primary" block onClick={this.loginHandler}>Login</Button>            
        
                </Container>
                
            </div>
        )
    }
}

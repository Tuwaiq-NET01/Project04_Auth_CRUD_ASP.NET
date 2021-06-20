import React, { Component } from 'react'
import { Button } from 'react-bootstrap'

export default class Story extends Component {

    render() {
        console.log(this.props)
        return (
            // this compount show the information 
            <div className="flip-card">	
    <div className="flip-card-inner">
        <div className="flip-card-front">
            <img src={this.props.image} alt="Avatar"width="300px" height="300px" />
        </div> 
        <div className="flip-card-back">
            <h1>{this.props.title}</h1> 
			<h3>{this.props.price}</h3>
            <h3>{this.props.description}</h3>
                    {/* button  for edit and change view*/}
                    <div className="cell"><Button variant="primary" onClick={()=>{this.props.editView(this.props.id)}}>Edit</Button></div>
                    {/*button delete by id number*/}
                    <div className="cell"><Button variant="danger" onClick={()=>{this.props.delete(this.props.id)}}>Delete</Button></div>        </div>
	</div>
</div>
        )
    }
}

import React, { Component } from 'react'
import { Button } from 'react-bootstrap'

export default class Member extends Component {

    render() {
        console.log(this.props)
        return (
            // this compount show the information 
            <div className="table table-dark table-hover">
                    <div>
                <div className="row">
                    <div className="cell"><h4>{this.props.username}</h4></div>
                    <div className="cell">{this.props.firstName}</div>
                    <div className="cell">{this.props.lastName}</div>
                    <div className="cell"><img src={this.props.image} width="200" height="200" /></div>

                    {/* button  for edit and change view*/}
                    <div className="cell"><Button variant="primary" onClick={()=>{this.props.editView(this.props.id)}}>Edit</Button></div>
                    {/*button delete by id number*/}
                    <div className="cell"><Button variant="danger" onClick={()=>{this.props.delete(this.props.id)}}>Delete</Button></div>
                </div>
                <hr/>
               </div>
            </div>
 
        )
    }
}

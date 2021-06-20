import React, { Component } from 'react'
import { Button } from 'react-bootstrap'

export default class Tournament extends Component {

    render() {
        console.log(this.props)
        return (
            // this compount show the information 
            <div className="table table-dark table-hover">
                    <div>
                <div className="row">
                    <div className="cell"><h4>{this.props.tourName}</h4></div>
                    <div className="cell">{this.props.year}</div>
                    <div className="cell">{this.props.tourType}</div>

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

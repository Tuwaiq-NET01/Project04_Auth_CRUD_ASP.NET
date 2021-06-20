import React, { Component } from 'react';
import axios from 'axios';
import Tournament from './Tournament';
import TournamentNewForm from './TournamentNewForm';
import TournamentEditForm from './TournamentEditForm';
import { Alert, Button } from "react-bootstrap";

export default class TournamentsList extends Component {
    constructor(props){
        super(props);
        this.state = {
            tournaments: [],
            isEdit: false,
            isAdd: false,
            clickedId : '',
            message: null,
            successMessage: null
        }
    }

    // make the excute automaticlly when find it down
    componentDidMount(){
        this.loadList();
    }

//pring all tournament list from database by axios
    loadList = () => {
        axios.get("tournaments", 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
        .then(response =>{
            console.log(response)
            this.setState({
                tournaments: response.data
            })
        })
        .catch(error =>{
            console.log("Error retreiving !!");
            console.log(error);
        })
    }

    // add new tournament to list and give you massage if success or failure
    add = (tournament) =>{
        axios.post("tournaments", tournament, 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Tournament adding successfully") {
                    this.setState({
                      successMessage: "Tournament adding successfully"
                    });
                        } 
                    else{
                    this.setState({
                      message: response.data.message,
                    });
                  }
                this.loadList();
            })
            .catch(error =>{
                console.log("Error Adding Tournament");
                console.log(error)
            });
            //remove the alert message after 3 seconds
            setTimeout(() => {
                this.setState({
                  message: false,
                  successMessage:false
                });
              }, 3000);
    }

    //delete tournament by id from database by axios and give you message if success or failure
    delete= (id) =>{
        axios.delete(`tournaments/${id}`,{
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message) {
                    this.setState({
                      successMessage: "Tournament deleted successfully"
                    });
                        } 
                    else{
                    this.setState({
                      message: response.data.message,
                    });
                  }            
                      this.loadList();
            })
            .catch(error =>{
                console.log("Error Deleting Tournament!")
                console.log(error)
            });
             
            //remove the alert message after 3 seconds
            setTimeout(() => {
                this.setState({
                  message: false,
                  successMessage:false
                });
              }, 3000);
    }

    // change the view when you press the edit button
    editView =(id) =>{
        this.setState({
            isEdit: !this.state.isEdit,
            clickedId: id
        })
    }

    // change the view when you press the add button
    addView =() =>{
        this.setState({
            isAdd: !this.state.isAdd
        })
    }

    //edit tournament in database by axios and give ypu message if success or faill
    edit = (tournament) =>{
        axios.put(`tournaments/${tournament.id}`, tournament, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Tournament editing successfully") {
                    this.setState({
                      successMessage: "Tournament editing successfully"
                    });
                        } 
                    else{
                    this.setState({
                      message: response.data.message,
                    });
                  }
                this.loadList();
            })
            .catch(error =>{
                console.log("Error Editing Tournament");
                console.log(error)
            });

            //remove the alert message after 3 seconds
            setTimeout(() => {
                this.setState({
                  message: false,
                  successMessage:false
                });
              }, 3000);
    }


    render() {

        // allert to view the message 
        const message = this.state.message ? (
            <Alert variant="danger">{this.state.message}</Alert>
          ) : null;
      
          const successMessage = this.state.successMessage ? (
            <Alert variant="success">{this.state.successMessage}</Alert>
          ) : null;
      
        return (
            <div>
                {/* show information here */}
                  {message} {successMessage}
                  <Button variant="primary" onClick={()=>{this.addView()}} block>View Add Tournament</Button>
                  {/* check if add button click it to view form or hidden */}
                {(this.state.isAdd) ? <TournamentNewForm add={this.add} email={this.props.email}/> : null}

                <h1>Tournaments List</h1>
                <ul>
                    {/*loop to genrate all value in the list */}
                    {this.state.tournaments.map((tournament, index) =>
                    <div  key={index}>
                    {/*send some value to  compount and view compount */}
                    <Tournament {...tournament} delete ={this.delete} email={this.props.email} editView={this.editView}/>
                     {/* check if edit button click it to view form or hidden by id */}
                    {(this.state.isEdit && this.state.clickedId === tournament.id) ? <TournamentEditForm  tournament={tournament} edit={this.edit}/> : null}
                   
                    </div>)}
                    
                </ul>
            </div>
        )
    }
}

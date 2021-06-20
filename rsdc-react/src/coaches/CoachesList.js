import React, { Component } from 'react';
import axios from 'axios';
import Coach from './Coach';
import CoachNewForm from './CoachNewForm';
import CoachEditForm from './CoachEditForm';
import { Alert, Button } from "react-bootstrap";

export default class CoachesList extends Component {
    constructor(props){
        super(props);
        this.state = {
            coaches: [],
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

//pring all coach list from database by axios
    loadList = () => {
        axios.get("coaches", 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
        .then(response =>{
            console.log(response)
            this.setState({
                coaches: response.data
            })
        })
        .catch(error =>{
            console.log("Error retreiving !!");
            console.log(error);
        })
    }

    // add new coach to list and give you massage if success or failure
    add = (coach) =>{
        axios.post("coaches", coach, 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Coach adding successfully") {
                    this.setState({
                      successMessage: "Coach adding successfully"
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
                console.log("Error Adding Coach");
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

    //delete coach by id from database by axios and give you message if success or failure
    delete= (id) =>{
        axios.delete(`coaches/${id}`,{
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message) {
                    this.setState({
                      successMessage: "Coach deleted successfully"
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
                console.log("Error Deleting Coach!")
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

    //edit coach in database by axios and give ypu message if success or faill
    edit = (coach) =>{
        axios.put(`coaches/${coach.id}`, coach, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Coach editing successfully") {
                    this.setState({
                      successMessage: "Coach editing successfully"
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
                console.log("Error Editing Coach");
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
                  <Button variant="primary" onClick={()=>{this.addView()}} block>View Add Coach</Button>
                  {/* check if add button click it to view form or hidden */}
                {(this.state.isAdd) ? <CoachNewForm add={this.add} email={this.props.email}/> : null}

                <h1>Coaches List</h1>
                <ul>
                    {/*loop to genrate all value in the list */}
                    {this.state.coaches.map((coach, index) =>
                    <div  key={index}>
                    {/*send some value to  compount and view compount */}
                    <Coach {...coach} delete ={this.delete} email={this.props.email} editView={this.editView}/>
                     {/* check if edit button click it to view form or hidden by id */}
                    {(this.state.isEdit && this.state.clickedId === coach.id) ? <CoachEditForm  coach={coach} edit={this.edit}/> : null}
                   
                    </div>)}
                    
                </ul>
            </div>
        )
    }
}

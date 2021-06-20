import React, { Component } from 'react';
import axios from 'axios';
import Member from './Member';
import MemberNewForm from './MemberNewForm';
import MemberEditForm from './MemberEditForm';
import { Alert, Button } from "react-bootstrap";

export default class MembersList extends Component {
    constructor(props){
        super(props);
        this.state = {
            members: [],
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

//pring all member list from database by axios
    loadList = () => {
        axios.get("members", 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
        .then(response =>{
            console.log(response)
            this.setState({
                members: response.data
            })
        })
        .catch(error =>{
            console.log("Error retreiving !!");
            console.log(error);
        })
    }

    // add new member to list and give you massage if success or failure
    add = (member) =>{
        axios.post("members", member, 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Member adding successfully") {
                    this.setState({
                      successMessage: "Member adding successfully"
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
                console.log("Error Adding Member");
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

    //delete member by id from database by axios and give you message if success or failure
    delete= (id) =>{
        axios.delete(`members/${id}`,{
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message) {
                    this.setState({
                      successMessage: "Member deleted successfully"
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
                console.log("Error Deleting Member!")
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

    //edit member in database by axios and give ypu message if success or faill
    edit = (member) =>{
        axios.put(`members/${member.id}`, member, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Member editing successfully") {
                    this.setState({
                      successMessage: "Member editing successfully"
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
                console.log("Error Editing Member");
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
                  <Button variant="primary" onClick={()=>{this.addView()}} block>View Add Member</Button>
                  {/* check if add button click it to view form or hidden */}
                {(this.state.isAdd) ? <MemberNewForm add={this.add} email={this.props.email}/> : null}

                <h1>Members List</h1>
                <ul>
                    {/*loop to genrate all value in the list */}
                    {this.state.members.map((member, index) =>
                    <div  key={index}>
                    {/*send some value to  compount and view compount */}
                    <Member {...member} delete ={this.delete} email={this.props.email} editView={this.editView}/>
                     {/* check if edit button click it to view form or hidden by id */}
                    {(this.state.isEdit && this.state.clickedId === member.id) ? <MemberEditForm  member={member} edit={this.edit}/> : null}
                   
                    </div>)}
                    
                </ul>
            </div>
        )
    }
}

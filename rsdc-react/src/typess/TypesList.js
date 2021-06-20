import React, { Component } from 'react';
import axios from 'axios';
import Type from './Type';
import TypeNewForm from './TypeNewForm';
import TypeEditForm from './TypeEditForm';
import { Alert, Button } from "react-bootstrap";

export default class TypesList extends Component {
    constructor(props){
        super(props);
        this.state = {
            types: [],
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

//pring all type list from database by axios
    loadList = () => {
        axios.get("types", 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
        .then(response =>{
            console.log(response)
            this.setState({
                types: response.data
            })
        })
        .catch(error =>{
            console.log("Error retreiving !!");
            console.log(error);
        })
    }

    // add new type to list and give you massage if success or failure
    add = (type) =>{
        axios.post("types", type, 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Type adding successfully") {
                    this.setState({
                      successMessage: "Type adding successfully"
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
                console.log("Error Adding Type");
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

    //delete type by id from database by axios and give you message if success or failure
    delete= (id) =>{
        axios.delete(`types/${id}`,{
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message) {
                    this.setState({
                      successMessage: "Type deleted successfully"
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
                console.log("Error Deleting Type!")
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

    //edit type in database by axios and give ypu message if success or faill
    edit = (type) =>{
        axios.put(`types/${type.id}`, type, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Type editing successfully") {
                    this.setState({
                      successMessage: "Type editing successfully"
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
                console.log("Error Editing Type");
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
                  <Button variant="primary" onClick={()=>{this.addView()}} block>View Add Type</Button>
                  {/* check if add button click it to view form or hidden */}
                {(this.state.isAdd) ? <TypeNewForm add={this.add} email={this.props.email}/> : null}

                <h1>Types List</h1>
                <ul>
                    {/*loop to genrate all value in the list */}
                    {this.state.types.map((type, index) =>
                    <div  key={index}>
                    {/*send some value to  compount and view compount */}
                    <Type {...type} delete ={this.delete} email={this.props.email} editView={this.editView}/>
                     {/* check if edit button click it to view form or hidden by id */}
                    {(this.state.isEdit && this.state.clickedId === type.id) ? <TypeEditForm  type={type} edit={this.edit}/> : null}
                   
                    </div>)}
                    
                </ul>
            </div>
        )
    }
}

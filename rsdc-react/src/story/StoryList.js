import React, { Component } from 'react';
import axios from 'axios';
import Story from './Story';
import StoryNewForm from './StoryNewForm';
import StoryEditForm from './StoryEditForm';
import { Alert, Button } from "react-bootstrap";

export default class StoryList extends Component {
    constructor(props){
        super(props);
        this.state = {
            stores: [],
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

//pring all story list from database by axios
    loadList = () => {
        axios.get("stores", 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
        .then(response =>{
            console.log(response)
            this.setState({
                stores: response.data
            })
        })
        .catch(error =>{
            console.log("Error retreiving !!");
            console.log(error);
        })
    }

    // add new story to list and give you massage if success or failure
    add = (story) =>{
        axios.post("stores", story, 
        {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Story adding successfully") {
                    this.setState({
                      successMessage: "Story adding successfully"
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
                console.log("Error Adding Story");
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

    //delete story by id from database by axios and give you message if success or failure
    delete= (id) =>{
        axios.delete(`stores/${id}`,{
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message) {
                    this.setState({
                      successMessage: "Story deleted successfully"
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
                console.log("Error Deleting Story!")
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

    //edit story in database by axios and give ypu message if success or faill
    edit = (story) =>{
        axios.put(`stores/${story.id}`, story, {
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        })
            .then(response =>{
                if (response.data.message == "Story editing successfully") {
                    this.setState({
                      successMessage: "Story editing successfully"
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
                console.log("Error Editing Story");
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
                  <Button variant="primary" onClick={()=>{this.addView()}} block>View Add Story</Button>
                  {/* check if add button click it to view form or hidden */}
                {(this.state.isAdd) ? <StoryNewForm add={this.add} email={this.props.email}/> : null}

                <h1>story List</h1>
                <ul>
                    {/*loop to genrate all value in the list */}
                    {this.state.stores.map((story, index) =>
                    <div  key={index}>
                    {/*send some value to  compount and view compount */}
                    <Story {...story} delete ={this.delete} email={this.props.email} editView={this.editView}/>
                     {/* check if edit button click it to view form or hidden by id */}
                    {(this.state.isEdit && this.state.clickedId === story.id) ? <StoryEditForm  story={story} edit={this.edit}/> : null}
                   
                    </div>)}
                    
                </ul>
            </div>
        )
    }
}

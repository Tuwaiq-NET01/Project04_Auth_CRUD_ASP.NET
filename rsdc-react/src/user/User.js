import React, { Component } from 'react'
import { Button } from 'react-bootstrap'
import facebook from "../images/facebook.png";
import twitter from "../images/twitter.png";
import google from "../images/google.png";
import linkedin from "../images/linkedin.png";
export default class User extends Component {

    render() {
        return (
            // this compount show the user information 
            <div>
            {/* check if the token email match email pring information */}
            {(this.props.email === this.props.emaill) ?(

            <div className="q2">

            <div>      
                
                 <h3>{this.props.firstName}{" "}{this.props.lastName}</h3>
                 <br/>
                 <h4>{this.props.email}</h4>
                 <h4>{this.props.startDate}</h4>
                 <a href="#"><i class="fa fa-facebook"></i><img className="img2" src={google} /></a>
                 <a href="#"><i class="fa fa-linkedin"></i><img className="img2" src={twitter} /></a> 
                 <a href="#"><i class="fa fa-twitter"></i><img className="img2" src={linkedin} /></a> 
                 <a href="#"><i class="fa fa-dribbble"></i><img className="img2" src={facebook} /></a>  
                 <br/>
                                     {/* the two button  for edit send the id number of user */}
                 <Button variant="primary" currentPassword = {this.props.password} onClick={()=>{this.props.editView(this.props.id)}}>Edit Profile</Button>  
             </div>

                 <div>
                 <img className="img1" src={this.props.image} />
                 </div>
                 

                 </div>                
                  ) : null}
</div>
        )
    }
}

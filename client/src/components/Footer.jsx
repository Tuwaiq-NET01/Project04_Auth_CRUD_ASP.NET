import React, { Component } from 'react';

class Footer extends Component {

    constructor(props){
        super(props);
        this.state = {
          data: ''
        }
      }


      componentDidMount(){
        this.setState({
            data: 'Website 2021. By Riham'
          })
      }
    render() {
        return (
            <>
        <footer class="footer my-0 py-5 px-3">
              <p class="text-muted small mb-4 mb-lg-0 text-center">&#169; {this.state.data} </p>
          </footer>   
            </>
        );
    }
}

export default Footer;
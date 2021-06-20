import React, { Component } from 'react'
import CelebritiesContainer from './CelebritiesContainer'
import Header from './Header'
import MainImage from './MainImage'

export default class HomePage extends Component {
    render() {
        return (
            <div className="wrapper">
               
                {/* <MainImage/> */}
                <CelebritiesContainer/>
            </div>
        )
    }
}

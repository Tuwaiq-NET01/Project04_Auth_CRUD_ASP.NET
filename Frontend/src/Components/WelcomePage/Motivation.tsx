import * as React from 'react'


interface MotivationProps {
    text:string
}

const Motivation = ({text}:MotivationProps)=> {
    return(
        <p style={{textAlign:'center' , fontFamily:"Montserrat" , padding: '10px' ,lineHeight:'1.5'}}> {text} </p> 
    )
}

export default Motivation
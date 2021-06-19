import * as React from 'react'

import {ActionButton} from '../../Styles/FeedPageStyles'
// props 
// function 
// icon 
interface ActionButtonProps {
    background: string , 
    handleClick:(id: number)=>void ,
    id: number 
}
const ActionIcon = ({background ,handleClick ,id} : ActionButtonProps)=> {


    return(<ActionButton  background = {background}  onClick= {()=>handleClick(id)}>  </ActionButton>)
}


export default ActionIcon 
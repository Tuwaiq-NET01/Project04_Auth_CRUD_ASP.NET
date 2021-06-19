import * as React from 'react'

import {AddNewMotivationButton} from '../../Styles/WelcomeStyles'



interface AddNewMotivationProps {
    text:string ,
    mode: React.Dispatch<React.SetStateAction<boolean>>
}
const AddNewMotivation = ({text , mode}:AddNewMotivationProps)=> {
   return (
       <AddNewMotivationButton  onClick={()=>mode(false)}>  {text} </AddNewMotivationButton> 
   )
}

export default AddNewMotivation
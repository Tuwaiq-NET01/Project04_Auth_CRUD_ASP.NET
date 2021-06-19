import * as React from 'react'
import axios from 'axios'
import {InputMotivationInput} from '../../Styles/WelcomeStyles'
import {AddNewMotivationButton} from '../../Styles/WelcomeStyles'


const {useState } =React 

interface InputMotivationProps {
    mode: React.Dispatch<React.SetStateAction<boolean>>
}
const InputMotivation = ({mode}:InputMotivationProps)=> {
const submitMotive = () => {

    Motive.length > 10 ? 
    axios.post('api/Motivations', {
        body: Motive ,
        CreatedAt: new Date(),
        UserId: 2
      })
      .then( (response)=> {
        alert('Well Recieved')
        console.log(response);
      })
      .catch( (error) => {
        alert('Try Again');
      }) : mode(true)
    }

   const [Motive , setMotive ] =  useState<string>('')
   
  
   return (

      <> <InputMotivationInput  onChange={(event) => setMotive(event.target.value)}/> <AddNewMotivationButton  onClick = {()=> {submitMotive();(mode(true)); }}>+ Submit +</AddNewMotivationButton> </>
   )
}

export default InputMotivation
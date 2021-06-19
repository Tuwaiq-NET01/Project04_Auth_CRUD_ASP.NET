import * as React from 'react' 
import {InputPostformContainer,InputFormStyles,ButtonForm} from '../../Styles/FeedPageStyles'



interface InputFormProps {
    body:string , 
    attachment:string,
    handleBody : React.Dispatch<React.SetStateAction<string>> ,
    handleAttachment : React.Dispatch<React.SetStateAction<string>> ,
    formdeActivite : React.Dispatch<React.SetStateAction<boolean>> , 
    updateMode : React.Dispatch<React.SetStateAction<boolean>> ,
    Submit : ()=> void , 
    Update : (id:number) => void ,
    updateModeValue : boolean , 
    currentId : number , 
    SubmitUpdate : (id:number)=> void 
}
const InputForm = ({handleBody,SubmitUpdate,currentId,handleAttachment,attachment,formdeActivite,Submit,body ,Update,updateMode,updateModeValue} :InputFormProps )=> {

    return (
        <InputPostformContainer>
            <ButtonForm onClick={()=> {formdeActivite(true) ;updateMode(false);handleBody('') ; handleAttachment('') } }> Close </ButtonForm>
            <h1 style={{color:'white'}}> FACTS ONLY </h1>
            <InputFormStyles placeholder="WRITE YOUR FACT HERE" onChange= {(e)=>handleBody(e.target.value)} value={body.length!==0 ? body :''} />
            <h2 style={{color:'white'}} > PLEASE PROVIDE A LINK  </h2>
            <InputFormStyles placeholder="https://www.example.com" onChange= {(e)=>handleAttachment(e.target.value) } value={attachment.length!==0 ? attachment :''}/>
            {  (updateModeValue) ? <ButtonForm onClick= {()=>{SubmitUpdate(currentId); formdeActivite(true); updateMode(false);}}> Update </ButtonForm>
           : <ButtonForm onClick= {()=>{Submit(); formdeActivite(true);updateMode(false); handleBody('') ;handleAttachment('') }}> Submit </ButtonForm>
   
              } 
         </InputPostformContainer>
    )

}



export default InputForm 
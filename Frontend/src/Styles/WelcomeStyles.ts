import styled from 'styled-components'

export const MainContainer = styled.div `
height: 100%;
background-color: #171717 ; 
display:grid;  
grid-template-rows: 40% 30% 30%; 
z-index: 0;
`

export const LogoContainer = styled.div `
height: 100%;
display:flex;
flex-direction: column;
margin-left:auto;
margin-bottom: auto ;
z-index: 2;

`

export const MotivationContainer = styled.div `
height: 90%; 
background-color:#851BCF  ; 
display: grid;
grid-template-rows: 70% 30% ; 
color:white;
padding-top:1em ;
box-shadow: 6px 5px 17px black ; 
margin-top: 1em ;
font-weight: 400;
z-index: 3;
flex-grow: 0; // prevent taking the whole page 

`
export const MotivationAddButtonContainer = styled.div`

display: flex;
flex-direction:row;
align-items:center ;
background-color: #57C4DC ;
`
export const AddNewMotivationButton = styled.button`

background-color:transparent;
color:white;
margin: auto;
border:0px;
font-weight: 700;
font-size:1em;

`

export const InputMotivationInput = styled.input`
background-color: #57C4DC;
height: 100%;
box-shadow: 6px 2px 8px black ; 

width: 100%;
color:white;
margin: auto;
border:0px;
font-weight: 700;
font-size:1em;
outline:none; 

`


export const Footer = styled.div `
height: 100%;
width:  100% ; 
display: grid;
grid-template-columns: 1fr; 
grid-template-rows: 46% 54%; 
`

export const CounterContainer = styled.div `
    color : white ;
    display: flex; 
    flex-direction: row; 
    margin-left:auto ;
    margin-top: auto;
    align-items: center;
   
`

export const EnterButtonContainer = styled.div `
    background-color:#57C4DC  ; 
    display: flex;
    flex-direction:column;
    flex-wrap: wrap;
    align-items:center ;
    
`

export const EnterButtonStyle = styled.button `

   margin:auto;
   background-color: #57C4DC ;
   border: 0px ;
   height: 100%;
   width: 100% ;
   color: white ; 
   font-weight: 700;
   font-size: 80px;

`


export const ArrowBody = styled.div`

  position: absolute ; 
  height: 71%;
  background-color: white ; 
  width: 12px ; 
  left: 4em ; 
  z-index: 1;


`


export const ArrowHead = styled.div`
  position:absolute;
  width: 0; 
  height: 0; 
  border-left: 30px solid transparent;
  border-right: 30px solid transparent;
  border-top: 50px solid white;
  z-index: 1;
  left:2.5em ; 
  top:72%;
`
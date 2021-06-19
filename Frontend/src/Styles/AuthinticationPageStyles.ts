import styled from 'styled-components' 


export const MainContainer = styled.div `
height: 100%;
background-color: #171717 ; 
display:grid;  
grid-template-rows: 40% 40% 20%;  
z-index: 0;
`



export const LogoContainer = styled.div `
height: 100%;
width:  100% ; 
display:flex ; 
flex-direction: column; 
align-items: center; 
z-index: 2;
`


export const AuthFormContainer = styled.div `
display:grid;
grid-template-rows: 1fr 1fr 1fr; 
background-color:#851BCF ; 
height: 100%;
`


export const ButtonForm = styled.button `

height: 100%;
background-color: #57C4DC ; 
color: white ; 
padding: 1em ; 
width: 100% ; 
font-weight: 600;
border:0px ; 
-webkit-box-shadow: 2px 8px 19px -6px #000000; 
box-shadow: 2px 8px 19px -6px #000000; 

`

export const ButtonFlipForm = styled.button `

height: 100%;
background-color: #57C4DC ; 
color: white ; 
padding: 1em ; 
width: 100% ; 
font-size:1em ;
font-weight: 600;
border:0px ; 

`



export const InputFormStyles = styled.input`
height: 100%;
width:100% ; 
background-color: #57C4DC34 ;
color:white ; 
padding:1em ; 
border:0px ;
outline:0px;
`


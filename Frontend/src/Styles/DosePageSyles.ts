import styled from 'styled-components'


export const MainContainer = styled.div `
height: 100%;
background-color: #171717 ; 
display:grid;  
grid-template-rows: 20% 68% 12%; 

`


export const LogoContainer = styled.div `
height: 100%;
width:  100% ; 
display:flex ; 
flex-direction: column; 
align-items: center; 

`
export const DoseContainer = styled.div `
height: 100%;
width:  100% ; 
display:grid ; 
grid-template-rows: 10% 90% ;

`
export const DoseTitleContainer = styled.div `

background-color:#57C4DC; 
overflow: hidden;
font-weight:800 ; 
box-shadow: 10px 20px 20px 10px black;
height: 90% ;
display:flex ; 
color: white ; 
flex-direction: row;
align-items: center ;
`

export const DoseBodyContainer = styled.div `
display:grid ; 
grid-template-columns: 10% 90% ;
height: 94% ;
background-color:#851BCF78;
`

export const DoseContentContainer = styled.div `

`


export const SideInfo = styled.div`

 background-color: green;
 border: 0px ; 
 color:white ; 
 background-color: #57C4DC ; 
 font-weight: 600; 
 writing-mode: vertical-lr;
 font-size:1em ;
 box-shadow: 2px 4px 5px 2px black;
 display: flex; 
 flex-direction: column;

`
export const Footer = styled.div `
height: 100%;
width:  100% ; 
display:flex ; 
flex-direction: row; 
background-color:#851BCF; 

`

export const AddNewFeedButton = styled.button `
height: 100%;
width:  100% ; 
color:white ; 
background-color: transparent;
border:0px;
font-size:2em;
font-weight:600;
`


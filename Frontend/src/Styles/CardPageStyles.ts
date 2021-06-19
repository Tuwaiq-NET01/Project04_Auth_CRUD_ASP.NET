import styled from 'styled-components'


export const MainContainer = styled.div `
height: 100%;
background-color: #171717 ; 
display:grid;  
grid-template-rows: 30% 58% 12%; 

`


export const LogoContainer = styled.div `
height: 100%;
width:  100% ; 
display:flex ; 
flex-direction: column; 
align-items: center; 

`
export const CardContainer = styled.div `
height: 100%;
width:  100% ; 
display:grid ; 
grid-template-rows: 30% 70% ;

`
export const CardTitleContainer = styled.button `

background-color:#57C4DC; 
font-size:2em ;
font-weight:800 ; 
box-shadow: 10px 20px 20px 10px black;
height: 90% ;
display:flex ; 
color: white ; 
flex-direction: row;
align-items: center ;
border :0px ;
`

export const CardBodyContainer = styled.div `
display:grid ; 
grid-template-columns: 10% 80% 10% ;
height: 94% ;
background-color:#851BCF78;
`

export const CardContentContainer = styled.div `

height: 100%;
width: 100% ; 
background-color: #851BCF56;
display: flex ; 
flex-direction:column ; 
align-items:center ; 
color: white ; 
overflow: hidden;

`


export const SideButton = styled.button`

 background-color: green;
 border: 0px ; 
 color:white ; 
 background-color: #57C4DC ; 
 font-weight: 600; 
 writing-mode: vertical-lr;
 font-size:1em ;
 box-shadow: 2px 1px 10px 3px black;

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


import styled from 'styled-components'


export const MainContainer = styled.div `
height: 100%;
background-color: #171717 ; 
display:grid;  
grid-template-rows: 16% 72% 12%; 
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

export const FeedContainer = styled.div `
height: 100%;
width:  100% ; 

overflow-y:scroll;

`
export const FeedCardContainer = styled.div `
height: 17%;
width:  100% ;
background-color: #851BCF78 ;
margin-top:3px;
display:grid;
grid-template-columns: 8% 82% 10%;
`


export const TimeContainer = styled.div `
writing-mode: vertical-lr;
background-color: #57C4DC ;
display:flex ; 
flex-direction: row;
align-items: center;
color:white ;
font-weight: 600;
`

export const ContentContainer = styled.div `
text-align:center; 
font-size: 1em;
padding: 10px;
color:white ;
overflow: hidden; 
` 

export const ActionsContainer = styled.div `

display: grid ; 
grid-template-rows: 1fr 1fr 1fr ;


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

interface ActionButtonProps {
    background:string
}

export const ActionButton = styled.button<ActionButtonProps>`
 
    background:url(${props => props.background});
    background-repeat:  no-repeat ;
    background-size: 17px;
    background-position: center;
    background-color:#851BCF ;
    border: 0px;
    
`

export const InputPostformContainer = styled.div`

 display:flex ; 
 flex-direction: column; 
 align-items:center ; 
 margin: auto ;

`


export const ButtonForm = styled.button `

height: 100%;
background-color: #57C4DC ; 
color: white ; 
padding: 1em ; 
width: 100% ; 
margin:1em ;
font-weight: 600;
border:0px ; 
box-shadow: 1px 1px 7px 1px black ; 

`

export const InputFormStyles = styled.input`
height: 100%;
width:100% ; 
background-color: #851BCF ;

color:white ; 
padding:1em ; 
`
import styled from 'styled-components'


export const MainContainer = styled.div `
height: 100%;
background-color: #171717 ; 
display:grid;  
grid-template-rows: 50% 50%; 
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

export const OptionsContainer = styled.div `
height: 100%;
width:  100% ; 
display: grid; 
grid-template-rows: 1fr 1fr 1fr;
grid-gap: 1em;
z-index: 2;
`


export const OptionItem = styled.button `
    background-color:#851BCF ;
    height: 90%;
    text-align: right;
    color:white; 
    font-weight: 700;
    font-size: 2em;
    border:0px ; 
    box-shadow: 10px 30px 20px black ;
    padding-right:0.5em;
`
import * as React from 'react'
import * as MyStyles from '../../Styles/AuthinticationPageStyles'
import MyLogo from '../../Mylogo'
import ReactCardFlip from 'react-card-flip'
import Login from './Login'
import Register from './Register'

const {useState, useEffect} = React

const {MainContainer, LogoContainer, AuthFormContainer,ButtonFlipForm} = MyStyles


interface AuthinticationProps {
    setLoginStatus : React.Dispatch<React.SetStateAction<boolean>>
}
const Authintication = ({setLoginStatus}:AuthinticationProps) => {

  
    const [isFlipped,
        setIsFlipped] = useState < boolean > (false)


    return (
        <MainContainer>
            <LogoContainer>
                <MyLogo backLink="/Options" nextLink="/"/></LogoContainer>
            <AuthFormContainer>
                <ButtonFlipForm onClick={()=> setIsFlipped(!isFlipped)}>{isFlipped ?   'I Have an account, LOGIN' : "I don't have an account, SIGN UP"}</ButtonFlipForm>
                <ReactCardFlip isFlipped={isFlipped} flipDirection='horizontal'>
                <Login setLoginStatus = {setLoginStatus}/>
                <Register isFlipped={setIsFlipped}/>
                </ReactCardFlip>
            </AuthFormContainer>
        </MainContainer>
    )
}

export default Authintication
import * as React from 'react'
import * as MyStyles from '../../Styles/AuthinticationPageStyles'
import axios from 'axios'

const {useState, useEffect} = React
const {ButtonForm,InputFormStyles} = MyStyles

interface LoginProps {
    setLoginStatus : React.Dispatch<React.SetStateAction<boolean>>
}
const Login = ({setLoginStatus}:LoginProps) => {

    const [email,
        setemail] = useState('')
    const [Password,
        setPassword] = useState('')

    const handleSignIn  = (e : React.SyntheticEvent) => {
        
        e.preventDefault();

        axios
            .post('/api/Auth/login', {
            email: email,
            password: Password, 
        })
            .then((res)=> res.data === 'success' ? setLoginStatus(true) : console.log('You have to login Again') )
    }

    return (
        <div>
            <form  onSubmit={handleSignIn} >
                <InputFormStyles
                    type='email'
                    placeholder='EMAIL'
                    required
                    onChange={(e) => setemail(e.target.value)}/>
                <InputFormStyles
                    type='password'
                    placeholder='PASSWORD'
                    required
                    onChange={(e) => setPassword(e.target.value)}/>
                <ButtonForm type='submit' >
                    LOGIN
                </ButtonForm>
            </form>
        </div>
    )
}

export default Login
import * as React from 'react'
import * as MyStyles from '../../Styles/AuthinticationPageStyles'
import axios from 'axios'

const {useState, useEffect } = React
const {ButtonForm,InputFormStyles} = MyStyles



interface RegisterPros {
    isFlipped : React.Dispatch<React.SetStateAction<boolean>>
}
const Register = ({isFlipped} :RegisterPros) => {

    const [name,
        setName] = useState('')
    const [email,
        setemail] = useState('')
    const [Password,
        setPassword] = useState('')


    const handleRegister  = (e : React.SyntheticEvent) => {
        e.preventDefault()
        axios
            .post('https://induction2030.azurewebsites.net/api/Auth/Register', {
            name: name,
            email: email,
            password: Password
        })
            .then((res) => {isFlipped(!isFlipped);console.log(res)})
    }
    return (

        <div>
            <form onSubmit={handleRegister}>
                <InputFormStyles  placeholder='NAME' required onChange={(e)=>setName(e.target.value)}/>
                <InputFormStyles type='email' placeholder='EMAIL' required onChange={(e)=>setemail(e.target.value)}/>
                <InputFormStyles type='password' placeholder='PASSWORD' required onChange={(e)=> setPassword(e.target.value)}/>
                 <ButtonForm type='submit'> + REGISTER +</ButtonForm>
            </form>
        </div>
    )
}

export default Register
import * as React from 'react'
import {EnterButtonStyle} from '../../Styles/WelcomeStyles'

interface EnterButtonProps {
    text : string
}
const EnterButton = ({text} : EnterButtonProps) => {

    return (

        <EnterButtonStyle onClick={() => console.log("h")}>
            {text}
        </EnterButtonStyle>
    )
}

export default EnterButton
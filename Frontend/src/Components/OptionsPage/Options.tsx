import * as React from 'react'
import * as MyStyles from '../../Styles/OptionsPageStyles'
import MyLogo from '../../Mylogo'
import {Link} from 'react-router-dom'

const {MainContainer, LogoContainer, OptionsContainer, OptionItem} = MyStyles

const OptionsPage = () => {

    return (
        <MainContainer>
            <LogoContainer>
                <MyLogo backLink="/"  nextLink="/Feed"/>
            </LogoContainer>
            <OptionsContainer>
                <OptionItem>
                    <Link to="/Feed">
                        FEED
                    </Link>
                </OptionItem>

                <OptionItem>
                    <Link to="/Card">CARD
                    </Link>
                </OptionItem>
                <OptionItem>
                    <Link to="/Dose">
                        DOSE
                    </Link>
                </OptionItem>
            </OptionsContainer>
        </MainContainer>
    )

}

export default OptionsPage
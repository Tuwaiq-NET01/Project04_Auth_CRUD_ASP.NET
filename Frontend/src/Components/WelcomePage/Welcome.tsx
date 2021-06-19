import * as React from 'react';
import * as MyStyles from '../../Styles/WelcomeStyles'
import Motivation from './Motivation'
import EnterButton from './EnterButton'
import AddNewMotivation from './AddNewMotivation'
import InputMotivation from './InputMotivation'
import MyLogo from '../../Mylogo'
import Counter from './Counter'
import {Link} from 'react-router-dom'
import axios from 'axios'

const {useState, useEffect} = React

const {
    MainContainer,
    LogoContainer,
    MotivationContainer,
    MotivationAddButtonContainer,
    Footer,
    CounterContainer,
    EnterButtonContainer,
    ArrowBody,
    ArrowHead
} = MyStyles;

interface Motivation {
    id : number,
    body : string,
    CreatedAt : string

}

//console.log(Motivation)
const Welcome = () => {
    const [motivations,
        setMotivations] = useState < Motivation[] > ([]);

    const [editingMode,
        setEditingMode] = useState < boolean > (true);

    useEffect(() => {
        axios.get < Motivation[] > ('api/Motivations').then(response => setMotivations(response.data))
    }, [])

    console.log(motivations)
    let randomNum = Math.floor(Math.random() * motivations.length)
    console.log(randomNum);
    return (
        <MainContainer>
            <LogoContainer>
                <MyLogo backLink="/" nextLink="/Options"/>
                </LogoContainer>
            <ArrowBody></ArrowBody>
            <ArrowHead></ArrowHead>
            <MotivationContainer>
                {editingMode
                    ? <Motivation
                            text={motivations.length !== 0
                            ? motivations[randomNum].body
                            : "wait for it"}/>
                    : <InputMotivation mode={setEditingMode}/>}
                <MotivationAddButtonContainer>
                    {editingMode && <AddNewMotivation text="+ ADD +" mode={setEditingMode}/>}
                </MotivationAddButtonContainer>
            </MotivationContainer>
            <Footer>
                <CounterContainer>
                    <Counter/>
                </CounterContainer>
                {editingMode && <EnterButtonContainer>
                    <Link to='/Options'><EnterButton text="ENTER"/></Link>
                </EnterButtonContainer>}
            </Footer>
        </MainContainer>
    )
}

export default Welcome
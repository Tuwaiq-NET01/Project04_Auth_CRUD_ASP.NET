import * as React from 'react'
import MyLogo from '../../Mylogo'
import * as MyStyles from '../../Styles/CardPageStyles'
import ReactCardFlip from 'react-card-flip'
import { useState ,useEffect } from 'react'
import axios from 'axios'


const {
    MainContainer,
    LogoContainer,
    CardTitleContainer,
    CardBodyContainer,
    CardContainer,
    SideButton,
    CardContentContainer,
    Footer,
    AddNewFeedButton
} = MyStyles



interface  QuestionsAndAnswers {
    id:number , 
    question: string ,
    answer: string  
}
const Card = () => {
    const [isFlipped , setIsFlipped] = useState<boolean>(false)

    const [questionsAnswers ,setQuestionsAnswers ] = useState<QuestionsAndAnswers[]>([]) 

    const [currentIndex , setCurrentIndex] = useState<number>(0) 
  
    useEffect(() => {
        axios.get < QuestionsAndAnswers[] > ('api/FlashCards').then(response => setQuestionsAnswers(response.data))
    }, [])
  


    console.log(questionsAnswers)
    const lengthOfquestions =  questionsAnswers.length
    const goPrevious = () => {currentIndex!== 0 && setCurrentIndex(currentIndex-1)}
    const goNext = () => {(currentIndex<lengthOfquestions-1)&& setCurrentIndex(currentIndex+1)}
    return (
        <MainContainer>
            <LogoContainer><MyLogo backLink="/Options"   nextLink="/Dose"/></LogoContainer>
            <CardContainer>
                <CardTitleContainer onClick={()=>setIsFlipped(!isFlipped)}>
                    <p style={{margin:'auto'}}> PRESS FOR AN ANSWER  #{currentIndex+1}/{questionsAnswers.length}</p>
                  
                </CardTitleContainer>

                <CardBodyContainer>
                    <SideButton onClick={()=>{goPrevious();setIsFlipped(false)}}> <p style={{writingMode: 'vertical-lr', margin:'auto'}}>PREVIOUS CARD</p> </SideButton>

                    <ReactCardFlip isFlipped={isFlipped} flipDirection="horizontal" >
                    <CardContentContainer>
                      <p style={{margin:'auto', padding:'20px'}}> {lengthOfquestions!==0&&questionsAnswers[currentIndex].question}  </p>   
                    </CardContentContainer>
                    <CardContentContainer>
                       <p style={{margin:'auto', padding:'20px'}} > {lengthOfquestions!==0&&questionsAnswers[currentIndex].answer} </p>  
                    </CardContentContainer>
                    </ReactCardFlip>

                    <SideButton onClick={()=>{goNext();setIsFlipped(false)}} > <p style={{writingMode: 'vertical-lr', margin:'auto'}}>NEXT CARD </p></SideButton>
                </CardBodyContainer>

            </CardContainer>
            <Footer>
                <AddNewFeedButton>+ CARD +</AddNewFeedButton>
            </Footer>
        </MainContainer>
    )

        


}

export default Card
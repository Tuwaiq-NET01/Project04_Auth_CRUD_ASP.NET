import * as React from 'react'
import * as MyStyles from '../../Styles/FeedPageStyles'
import MyLogo from '../../Mylogo'
import Timeslot from './Timeslot'
import ActionIcon from './ActionIcon'
import Content from './Content'
import axios from 'axios'
import InputForm from './InputForm'

const {useState, useEffect} = React



const {
    MainContainer,
    LogoContainer,
    FeedContainer,
    FeedCardContainer,
    TimeContainer,
    ContentContainer,
    ActionsContainer,
    AddNewFeedButton,
    Footer 
    
} = MyStyles

interface Feeds {
    id : number,
    body : string,
    createdAt : string,
    attachment : string
}

const Feed = () => {

    const [editingMode,
        setEditingMode] = useState < boolean > (true)

    const [feeds,
        setFeeds] = useState < Feeds[] > ([])

    const [body , setBody ] = useState<string> ('')
    const [attachment , setattachment ] = useState<string> ('')
    const [updateMode , setUpdateMode] = useState < boolean > (false)
    const [currentId , setCurrentID] = useState<number> (0)


    const PostAfeed = () => {
        setUpdateMode(false)
     
        axios.post('api/Facts', {
            Body: body ,
            CreatedAt: new Date(),
            Attachment : attachment , 
            UserId: 1
          })
          .then( (response)=> {
            console.log("I am the a bad alert")
            alert('Well Recieved')
            console.log(response);
            setFeeds([])
          })
          .catch( (error) => {
            alert(error);
          })
    }


    useEffect(() => {
        feeds.length == 0 &&
        axios.get < Feeds[] > ('api/Facts').then(response => setFeeds(response.data))
    }, [feeds])

    console.log(feeds)

    const openExternalURL = (id:number) => window.open(feeds.filter(e=>id === e.id)[0].attachment, '_blank', 'noopener,noreferrer')
    const deleteAfeed = (id:number) => {
        console.log(id)
        axios.delete(`api/Facts?id=${id}`).then(response => {alert("Deleted!") ;setFeeds([]);})
    }


    const updateAfeed = (id:number)=> {
      const feedToUpdate = feeds.filter(e=>id === e.id)[0]
      setCurrentID(id)
      setBody(feedToUpdate.body)
      setattachment(feedToUpdate.attachment)
      setUpdateMode(true)
      setEditingMode(false)
    }

    const submitUpdate = (id:number) => {  
      
      axios.put(`api/Facts?id=${id}`, {
        id: id ,
        body: body ,
        createdAt: new Date(),
        attachment : attachment,
        UserId: 1
      })
      .then( (response)=> {
        console.log("I am the a bad alert")
        alert('Well Recieved')
        setBody('')
        setattachment('')
        setFeeds([])
      })
      .catch( (error) => {
        alert(error);
      }) 
    }


    return (
        <MainContainer>
            <LogoContainer>
                <MyLogo backLink="/Options" nextLink="/Card"/>
            </LogoContainer>
            {editingMode &&
            <FeedContainer>
            {/*It can be achieved using useReducer */}
               {feeds.length !== 0 ?  feeds.map(feedah => 
                <FeedCardContainer key={feedah.id}>
                    <TimeContainer>
                        <Timeslot createdAt={feedah.createdAt.slice(11,19)}/>
                    </TimeContainer>
                    <ContentContainer>
                        <Content body={feedah.body} id={feedah.id}/>
                    </ContentContainer>
                    <ActionsContainer>
                        <ActionIcon background="/Assets/link.svg" handleClick={openExternalURL} id={feedah.id}/>
                        <ActionIcon background="/Assets/refresh.svg" handleClick={updateAfeed} id={feedah.id}/>
                        <ActionIcon background="/Assets/trash.svg" handleClick={deleteAfeed} id={feedah.id}/>
                    </ActionsContainer>
                </FeedCardContainer> ) : "waiting"
            }




            </FeedContainer>
             }
            <Footer>


              { editingMode ?
              <AddNewFeedButton onClick={()=>setEditingMode(false)}>  
              + FEED +
              </AddNewFeedButton> : 
             <InputForm body={body} attachment = {attachment} handleBody= {setBody} handleAttachment = {setattachment} formdeActivite ={setEditingMode} Submit={PostAfeed} updateMode = {setUpdateMode} Update= {updateAfeed} updateModeValue = {updateMode}  currentId={currentId} SubmitUpdate={submitUpdate}/>
               }
                

            </Footer>
        </MainContainer>
    )

}

export default Feed
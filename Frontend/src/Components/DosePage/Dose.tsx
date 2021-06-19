import * as React from 'react' 
import * as MyStyles from '../../Styles/DosePageSyles'
import MyLogo from '../../Mylogo'
import axios from 'axios'



const {useState, useEffect} = React 



const {
    MainContainer,
    LogoContainer,
    DoseTitleContainer,
    DoseBodyContainer,
    DoseContainer,
    SideInfo,
    DoseContentContainer,
    Footer,
    AddNewFeedButton
} = MyStyles


interface Books { 

id: number , 
name :string , 
url: string 

}

interface Chapters {
   id : number , 
   title : string , 
   bookId : number 
}

interface Chunks {
  id : number , 
  title : string , 
  body : string , 
  createdAt : string , 
  currentPage : number
}
const Dose = ()=> {


    const [books, setBooks] = useState<Books[]>([])
    const [Chapters, setChapters] = useState<Chapters[]>([])
    const [Chunks, setChunks] = useState<Chunks[]>([])


useEffect(() => {
    if (books.length === 0)
    axios.get('api/Books').then(res=>setBooks(res.data)).catch(()=>console.log('there is a big problem'))
    if (Chapters.length === 0)
    axios.get('api/Chapters').then(res=>setChapters(res.data)).catch(()=>console.log('there is a big problem'))
    if (Chunks.length === 0)
    axios.get('api/ChapterChunks').then(res=>setChunks(res.data)).catch(()=>console.log('there is a big problem'))
})
console.log(books)
console.log(Chapters)
console.log(Chunks)
    return(
    <MainContainer>
    <LogoContainer><MyLogo backLink="/Options"  nextLink="/Feed"/></LogoContainer>
    <DoseContainer>
        <DoseTitleContainer>
            <p style={{margin:'auto'}}> {books.length!==0 && books[0].name} </p>
        </DoseTitleContainer>
        <DoseBodyContainer>
            <SideInfo> <p style={{margin:'auto', color:'white'}}> CHAPTER [ {Chapters.length!==0 && Chapters[0].id } ] | TITLE [{Chapters.length!==0 && Chapters[0].title}] </p> </SideInfo>
            <DoseContentContainer>
            <p style={{margin:'auto', color:'white',padding:'1em'}}> {Chunks.length!==0 && Chunks[0].body } </p>
            </DoseContentContainer>
        </DoseBodyContainer>
    </DoseContainer>
    <Footer>
        <AddNewFeedButton>+ DOSE +</AddNewFeedButton>
    </Footer>
</MainContainer>
)
}

export default Dose 

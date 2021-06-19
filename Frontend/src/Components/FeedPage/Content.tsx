import * as React from 'react' 




interface ContentProps {
    id: number ,
    body: string , 

}

const Content = ({body ,id }:ContentProps)=> {
    
    return (<p> {body}</p>)
}


export default Content 
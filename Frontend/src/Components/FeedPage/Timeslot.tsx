import * as React from 'react' 



interface TimeslotProps {
    createdAt: string 
}
const Timeslot = ({createdAt}:TimeslotProps)=> {

    return (<p style={{margin:'auto'}}>{createdAt}</p> )
}


export default Timeslot 
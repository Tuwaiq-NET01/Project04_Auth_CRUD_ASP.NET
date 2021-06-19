import * as React from 'react' 

import Countdown from 'react-countdown';

const Counter = () => {

    
    return (
        <> 
        <h2>🎓 | </h2>
        
        <h2>  <Countdown date={new Date (2021,7,15)}/></h2>
        </>
    )
}

export default Counter ;
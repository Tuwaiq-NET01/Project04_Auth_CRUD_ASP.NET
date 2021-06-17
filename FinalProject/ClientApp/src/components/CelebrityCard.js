import React from 'react'

export default function CelebrityCard(props) {

    const { name ,img ,price} = props.info;
    const handleData = (e) => {
    
        window.location.href='/Celebrities/'+props.info.id
    
    }
    return (
        <div>

            <div className="card-container">
                <img src={img} alt="" ></img>
                <div className="desc">
                    <h2>{name}</h2>
                    <h3>Price: {price}</h3>
                    <button onClick={()=> handleData()}   > Show information</button> 
                </div>
            </div>


                


        </div>
    )
}
